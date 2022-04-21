using ImageMagick;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.AudioBypassService.Extensions;
using Microsoft.Extensions.DependencyInjection;
using VkNet.Model.Attachments;
using System.Net;
using VkNet.Enums.SafetyEnums;
using VK_Group_Edit_Post.Models;

namespace VK_Group_Edit_Post
{

    class Post
    {
        private string _pathToBackgroundImage = "InputImagePath/Img.png";
        private static string _datePath = "Date/Post.json";
        private List<string> _textPost = new List<string>();
        private Thread _myThread;
        private VkApi _api = null;
        private bool _authorize = false;

        public List<string> TextPost { get => _textPost; set => _textPost = value; }
        public SettingsApp SettingsApp { set; get; } = new SettingsApp();

        public delegate void OverPosts();
        public event OverPosts NotifyOverPosts;

        public delegate void ErrorPost();
        public event ErrorPost NotifyErrorPost;

        public delegate void ErrorCreatePost();
        public event ErrorCreatePost NotifyErrorCreatePost;

        public delegate void CreatePost();
        public event CreatePost NotifyCreatePost;

        public delegate void StatusBarLog(string log);
        public event StatusBarLog NotifyStatusBarLog;

        public void Start()
        {
            _myThread = new Thread(StartThread);
            _myThread.Start();
        }

        public void Stop()
        {
            if (_myThread == null)
                return;

            _myThread.Abort();
        }

        public void StartAuthorizeVK()
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();

            _api = new VkApi(services);

            ApiAuthParams _params = new ApiAuthParams
            {
                ApplicationId = SettingsApp.ApplicationVkId,
                Login = SettingsApp.Login,
                Password = SettingsApp.Password
            };

            try
            {
                _api.Authorize(_params);
            }
            catch (VkNet.AudioBypassService.Exceptions.VkAuthException)
            {
                NotifyStatusBarLog.Invoke("Не верный логин или пароль!");
            }
            catch (VkNet.Exception.VkApiException)
            {
                NotifyStatusBarLog.Invoke("Неизвестная ошибка при авторизации!");
            }

            _api.OnTokenExpires += OnTokenExpires;
        }

        private void OnTokenExpires(VkApi sender)
        {
            NotifyStatusBarLog.Invoke("Закончился токен доступа, попытка автоматической авторизации!");
            _api.OnTokenExpires -= OnTokenExpires;
            StartAuthorizeVK();
        }

        private void StartThread()
        {
            while (true)
            {
                if (_authorize == false)
                {
                    StartAuthorizeVK();
                    Thread.Sleep(15000);
                }

                if (TextPost.Count == 0)
                {
                    NotifyOverPosts?.Invoke();
                    break;
                }

                var pathToImage = Create(TextPost[0]);

                TextPost.RemoveAt(0);

                FileInfo fileInf = new FileInfo(_datePath);
                if (fileInf.Exists)
                {
                    fileInf.Delete();
                }

                var textJson = JsonConvert.SerializeObject(TextPost);

                using (FileStream fstream = new FileStream(_datePath, FileMode.OpenOrCreate))
                {
                    var array = Encoding.UTF8.GetBytes(textJson);
                    fstream.Write(array, 0, array.Length);
                }

                Publish(pathToImage);

                Thread.Sleep(SettingsApp.DelayBetweenPosts);
            }

        }

        private string Create(string textPost)
        {
            var date = $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}_{DateTime.Now.Hour}-{DateTime.Now.Minute}";
            var _pathToNewImage = $"SaveImagePath/{date}_Post.png";

            var readSettings = new MagickReadSettings
            {
                Font = "Calibri",
                StrokeColor = new MagickColor(255, 255, 255),
                FontPointsize = 68,
                TextGravity = Gravity.Forget,
                BackgroundColor = MagickColors.Transparent,
                Height = 880,
                Width = 1100
            };

            using (var image = new MagickImage(_pathToBackgroundImage))
            {
                using (var caption = new MagickImage($"caption:{string.Format(textPost)}", readSettings))
                {
                    image.Composite(caption, 100, 100, CompositeOperator.Over);

                    image.Write(_pathToNewImage);
                }
            }

            NotifyStatusBarLog.Invoke($"Пост создан - {date}");
            NotifyCreatePost.Invoke();

            return _pathToNewImage;
        }

        public void Publish(string pathToImage)
        {
            // Получить адрес сервера для загрузки.
            var uploadServer = _api.Photo.GetWallUploadServer(SettingsApp.OwnerId);
            // Загрузить файл.
            var wc = new WebClient();
            var responseFile = Encoding.UTF8.GetString(wc.UploadFile(uploadServer.UploadUrl, pathToImage));
            // Сохранить загруженный файл
            var photos = _api.Photo.SaveWallPhoto(response: responseFile, userId: 77609181, groupId: (ulong)SettingsApp.OwnerId, caption: null);

            var post = _api.Wall.Post(new WallPostParams
            {
                OwnerId = -SettingsApp.OwnerId,
                FromGroup = true,
                Message = SettingsApp.Hashtag,
                Attachments = photos,
                Signed = false
            });

            LikesAddParams likes = new LikesAddParams()
            {
                OwnerId = -SettingsApp.OwnerId,
                Type = LikeObjectType.Post,
                ItemId = post
            };

            NotifyStatusBarLog.Invoke($"Пост опубликован!");

            _api.Likes.Add(likes);
        }
    }

}
