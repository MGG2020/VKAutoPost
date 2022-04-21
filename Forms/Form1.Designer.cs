
namespace VK_Group_Edit_Post
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TextBox = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.DeletePost = new System.Windows.Forms.Button();
            this.ItemPost = new System.Windows.Forms.ListBox();
            this.AddPost = new System.Windows.Forms.Button();
            this.StartThread = new System.Windows.Forms.Button();
            this.StopThread = new System.Windows.Forms.Button();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.OpenSettings = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.TextBox();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Log = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBox.Location = new System.Drawing.Point(215, 12);
            this.TextBox.Multiline = true;
            this.TextBox.Name = "TextBox";
            this.TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox.Size = new System.Drawing.Size(573, 344);
            this.TextBox.TabIndex = 0;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(125, 362);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(84, 70);
            this.Save.TabIndex = 1;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // DeletePost
            // 
            this.DeletePost.Location = new System.Drawing.Point(12, 400);
            this.DeletePost.Name = "DeletePost";
            this.DeletePost.Size = new System.Drawing.Size(107, 32);
            this.DeletePost.TabIndex = 2;
            this.DeletePost.Text = "Удалить пост";
            this.DeletePost.UseVisualStyleBackColor = true;
            this.DeletePost.Click += new System.EventHandler(this.DeletePost_Click);
            // 
            // ItemPost
            // 
            this.ItemPost.AccessibleName = "";
            this.ItemPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ItemPost.FormattingEnabled = true;
            this.ItemPost.ItemHeight = 20;
            this.ItemPost.Location = new System.Drawing.Point(12, 12);
            this.ItemPost.Name = "ItemPost";
            this.ItemPost.Size = new System.Drawing.Size(197, 344);
            this.ItemPost.TabIndex = 3;
            this.ItemPost.SelectedIndexChanged += new System.EventHandler(this.ItemPost_SelectedIndexChanged);
            // 
            // AddPost
            // 
            this.AddPost.Location = new System.Drawing.Point(12, 362);
            this.AddPost.Name = "AddPost";
            this.AddPost.Size = new System.Drawing.Size(107, 32);
            this.AddPost.TabIndex = 4;
            this.AddPost.Text = "Добавить пост";
            this.AddPost.UseVisualStyleBackColor = true;
            this.AddPost.Click += new System.EventHandler(this.AddPost_Click);
            // 
            // StartThread
            // 
            this.StartThread.Location = new System.Drawing.Point(215, 363);
            this.StartThread.Name = "StartThread";
            this.StartThread.Size = new System.Drawing.Size(170, 32);
            this.StartThread.TabIndex = 5;
            this.StartThread.Text = "Начать постить";
            this.StartThread.UseVisualStyleBackColor = true;
            this.StartThread.Click += new System.EventHandler(this.StartThread_Click);
            // 
            // StopThread
            // 
            this.StopThread.Location = new System.Drawing.Point(411, 363);
            this.StopThread.Name = "StopThread";
            this.StopThread.Size = new System.Drawing.Size(170, 32);
            this.StopThread.TabIndex = 6;
            this.StopThread.Text = "Закончить постить";
            this.StopThread.UseVisualStyleBackColor = true;
            this.StopThread.Click += new System.EventHandler(this.StopThread_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "NotifyIcon";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // OpenSettings
            // 
            this.OpenSettings.Location = new System.Drawing.Point(618, 362);
            this.OpenSettings.Name = "OpenSettings";
            this.OpenSettings.Size = new System.Drawing.Size(170, 33);
            this.OpenSettings.TabIndex = 8;
            this.OpenSettings.Text = "Открыть настройки";
            this.OpenSettings.UseVisualStyleBackColor = true;
            this.OpenSettings.Click += new System.EventHandler(this.OpenSettings_Click);
            // 
            // Status
            // 
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Status.Location = new System.Drawing.Point(215, 407);
            this.Status.Multiline = true;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Size = new System.Drawing.Size(504, 20);
            this.Status.TabIndex = 9;
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(VK_Group_Edit_Post.Form1);
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(725, 404);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(63, 25);
            this.Log.TabIndex = 10;
            this.Log.Text = "Log";
            this.Log.UseVisualStyleBackColor = true;
            this.Log.Click += new System.EventHandler(this.Log_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 437);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.OpenSettings);
            this.Controls.Add(this.StopThread);
            this.Controls.Add(this.StartThread);
            this.Controls.Add(this.AddPost);
            this.Controls.Add(this.ItemPost);
            this.Controls.Add(this.DeletePost);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VK Group Auto Post";
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button DeletePost;
        private System.Windows.Forms.BindingSource form1BindingSource;
        public System.Windows.Forms.ListBox ItemPost;
        public System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Button AddPost;
        private System.Windows.Forms.Button StartThread;
        private System.Windows.Forms.Button StopThread;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.Button OpenSettings;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.Button Log;
    }
}

