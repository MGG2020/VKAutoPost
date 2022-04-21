using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VK_Group_Edit_Post.Models;

namespace VK_Group_Edit_Post.Forms
{
    public partial class FormSettings : Form
    {
        private SettingsApp _settingsApp = new SettingsApp();
        private string _settingsPath;

        public delegate void SaveSettings();
        public event SaveSettings NotifySaveSettings;

        public FormSettings(string settingsPath)
        {
            InitializeComponent();

            _settingsPath = settingsPath;

            using (FileStream fstream = File.OpenRead(_settingsPath))
            {
                var array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                var textSettingsFile = Encoding.UTF8.GetString(array);

                _settingsApp = JsonConvert.DeserializeObject<SettingsApp>(textSettingsFile);
            }

            Login.Text = _settingsApp.Login;
            Password.Text = _settingsApp.Password;
            AppID.Text = _settingsApp.ApplicationVkId.ToString();
            OwnerID.Text = _settingsApp.OwnerId.ToString();
            TimePost.Value = _settingsApp.DelayBetweenPosts / 60000;
            Hashtag.Text = _settingsApp.Hashtag;
        }

        private void SaveSetting_Click(object sender, EventArgs e)
        {
            _settingsApp = new SettingsApp()
            {
                Login = Login.Text,
                Password = Password.Text,
                ApplicationVkId = ulong.Parse(AppID.Text),
                OwnerId = long.Parse(OwnerID.Text),
                DelayBetweenPosts = (int)TimePost.Value * 60000,
                Hashtag = Hashtag.Text
            };

            using (FileStream fs = File.Create(_settingsPath))
            {
                var SettingsJson = JsonConvert.SerializeObject(_settingsApp);

                byte[] info = Encoding.UTF8.GetBytes(SettingsJson);
                fs.Write(info, 0, info.Length);
            }

            NotifySaveSettings?.Invoke();

            this.Close();
        }
    }
}
