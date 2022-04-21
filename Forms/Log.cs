using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VK_Group_Edit_Post.Forms
{
    public partial class Log : Form
    {
        public Log(string log)
        {
            InitializeComponent();
            TextLog.Text = log;
        }
    }
}
