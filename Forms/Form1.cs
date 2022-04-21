using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VK_Group_Edit_Post.Forms;
using VK_Group_Edit_Post.Models;

namespace VK_Group_Edit_Post
{
    public partial class Form1 : Form
    {
        public List<string> _test = new List<string>();

        private static Post _post = new Post();
        private static string _datePath = "Date/Post.json";
        private static string _settingsPath = "Date/Settings.json";

        private int index = 0;
        private delegate void NotifyCreatePost();

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        public Form1()
        {
            InitializeComponent();

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(ErrorRecording);

            try
            {
                throw new Exception("1");
            }
            catch (Exception e)
            {
                Console.WriteLine("Catch clause caught : {0} \n", e.Message);
            }

            NotifyIcon.Visible = false;
            this.NotifyIcon.MouseDoubleClick += new MouseEventHandler(NotifyIcon_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.FormClosed += AppClosed;

            LoadApp();

            ItemPost.Items.AddRange(_post.TextPost.ToArray());
        }

        private void ErrorRecording(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;

            var logString = $"{Status.Text} \r\n MyHandler caught :  {e.Message} \r\n Runtime terminating: {args.IsTerminating}";

            FileInfo fileInf = new FileInfo("log.json");
            if (fileInf.Exists)
                fileInf.Delete();
            
            using (FileStream fstream = new FileStream("log.json", FileMode.OpenOrCreate))
            {
                var array = Encoding.UTF8.GetBytes(logString);
                fstream.Write(array, 0, array.Length);
            }
        }

        private void LoadApp()
        {
            if (!File.Exists(_datePath))
            {
                using (FileStream fs = File.Create(_datePath))
                {
                    byte[] info = Encoding.UTF8.GetBytes("[]");
                    fs.Write(info, 0, info.Length);
                }
            }

            if (!File.Exists(_settingsPath))
            {
                using (FileStream fs = File.Create(_settingsPath))
                {
                    var SettingsJson = JsonConvert.SerializeObject(new SettingsApp());

                    byte[] info = Encoding.UTF8.GetBytes(SettingsJson);
                    fs.Write(info, 0, info.Length);
                }
            }

            using (FileStream fstream = File.OpenRead(_datePath))
            {
                var array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                var textFromFile = Encoding.UTF8.GetString(array);

                _post.TextPost = JsonConvert.DeserializeObject<List<string>>(textFromFile);
            }

            using (FileStream fstream = File.OpenRead(_settingsPath))
            {
                var array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                var textSettingsFile = Encoding.UTF8.GetString(array);

                _post.SettingsApp = JsonConvert.DeserializeObject<SettingsApp>(textSettingsFile);
            }
        }

        private void OpenSettings_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings(_settingsPath);
            formSettings.Show();
        }

        private void AppClosed(object sender, FormClosedEventArgs e)
        {
            _post.Stop();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) // проверяем наше окно, и если оно было свернуто, делаем событие
            {
                this.ShowInTaskbar = false; // прячем наше окно из панели
                NotifyIcon.Visible = true; // делаем нашу иконку в трее активной
                Hide(); //убираем из Alt + Tab
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            NotifyIcon.Visible = false; // делаем нашу иконку скрытой
            this.ShowInTaskbar = true; // возвращаем отображение окна в панели
            WindowState = FormWindowState.Normal; //разворачиваем окно
            Show(); //возвращаем в Alt + Tab
        }

        private void ItemPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = ItemPost.SelectedIndex;
            TextBox.Text = _post.TextPost[index];
        }

        private void Save_Click(object sender, EventArgs e)
        {
            _post.TextPost[index] = TextBox.Text;

            FileInfo fileInf = new FileInfo(_datePath);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }

            var textJson = JsonConvert.SerializeObject(_post.TextPost);

            using (FileStream fstream = new FileStream(_datePath, FileMode.OpenOrCreate))
            {
                var array = Encoding.UTF8.GetBytes(textJson);
                fstream.Write(array, 0, array.Length);
            }

            UpdateItemPost();

            ItemPost.SelectedIndex = index;
        }

        private void AddPost_Click(object sender, EventArgs e)
        {
            _post.TextPost.Add("Новый пост.");

            ItemPost.Items.Add(_post.TextPost[_post.TextPost.Count - 1]);
            ItemPost.SelectedIndex = _post.TextPost.Count - 1;
        }

        private void DeletePost_Click(object sender, EventArgs e)
        {
            _post.TextPost.RemoveAt(index);

            UpdateItemPost();
            ItemPost.SelectedIndex = _post.TextPost.Count - 1;
        }

        private void UpdateItemPost()
        {
            ItemPost.Items.Clear();
            ItemPost.Items.AddRange(_post.TextPost.ToArray());
            TextBox.Text = "";
        }

        private void StartThread_Click(object sender, EventArgs e)
        {
            _post.Start();

            _post.NotifyOverPosts += OverPosts;
            _post.NotifyErrorPost += ErrorPost;
            _post.NotifyErrorCreatePost += ErrorCreatePost;
            _post.NotifyCreatePost += CreatePost;
            _post.NotifyStatusBarLog += NotifyStatusBarLog; 
        }

        private void NotifyStatusBarLog(string log)
        {
            ItemPost.BeginInvoke(new Action(() =>
            {
                Status.Text += $"\r\n{log}";
            }));
        }

        private void CreatePost()
        {
            ItemPost.BeginInvoke(new Action(() => 
            {
                UpdateItemPost();
            }));
        }

        private void ErrorCreatePost()
        {
            
        }

        private void ErrorPost()
        {
            
        }

        private void OverPosts()
        {
            
        }

        private void StopThread_Click(object sender, EventArgs e)
        {
            _post.Stop();

            _post.NotifyOverPosts -= OverPosts;
            _post.NotifyErrorPost -= ErrorPost;
            _post.NotifyErrorCreatePost -= ErrorCreatePost;
            _post.NotifyCreatePost -= CreatePost;
        }

        private void Log_Click(object sender, EventArgs e)
        {
            Log formLog = new Log(Status.Text);
            formLog.Show();
        }
    }
}
