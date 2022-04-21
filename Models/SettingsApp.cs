using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK_Group_Edit_Post.Models
{
    public class SettingsApp
    {
        public string Login { set; get; }
        public string Password { set; get; }
        public ulong ApplicationVkId { set; get; }
        public long OwnerId { set; get; }
        public int DelayBetweenPosts { set; get; }
        public string Hashtag { set; get; }
    }
}
