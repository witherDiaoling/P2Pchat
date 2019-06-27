namespace QQ
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.friendsList = new System.Windows.Forms.Panel();
            this.NoListLabel = new System.Windows.Forms.Label();
            this.NoListPicture = new System.Windows.Forms.PictureBox();
            this.backGround = new System.Windows.Forms.Panel();
            this.nomessageLabel = new System.Windows.Forms.Label();
            this.sendFiles = new System.Windows.Forms.Button();
            this.friendDOWNlabel = new System.Windows.Forms.Label();
            this.showFriendName = new System.Windows.Forms.Label();
            this.sendChatButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.inputRichTextbox = new System.Windows.Forms.RichTextBox();
            this.chatRichTextBox = new System.Windows.Forms.RichTextBox();
            this.talkBackground = new System.Windows.Forms.PictureBox();
            this.SaveAllrichTextBox = new System.Windows.Forms.RichTextBox();
            this.timerOpen = new System.Windows.Forms.Timer(this.components);
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.buttonBack = new System.Windows.Forms.Panel();
            this.showitUID = new System.Windows.Forms.TextBox();
            this.showitIP = new System.Windows.Forms.TextBox();
            this.UIDLabel2 = new System.Windows.Forms.Label();
            this.IPlabel2 = new System.Windows.Forms.Label();
            this.UsernameLabel1 = new System.Windows.Forms.Label();
            this.showitUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IPtext = new System.Windows.Forms.TextBox();
            this.IPlabel = new System.Windows.Forms.Label();
            this.UIDlabel = new System.Windows.Forms.Label();
            this.UIDtext = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.head = new System.Windows.Forms.PictureBox();
            this.timershowDOWN = new System.Windows.Forms.Timer(this.components);
            this.timerNomessage = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.conformSend = new System.Windows.Forms.Button();
            this.filePathTextbox = new System.Windows.Forms.TextBox();
            this.showRefuselabel = new System.Windows.Forms.Label();
            this.requestButton = new System.Windows.Forms.Button();
            this.NObutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.RequestOKorNOlabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.selectFile = new System.Windows.Forms.Button();
            this.sendFileLbael = new System.Windows.Forms.Label();
            this.close1 = new System.Windows.Forms.Button();
            this.openButtenList = new System.Windows.Forms.Button();
            this.talkList = new System.Windows.Forms.Button();
            this.Friends = new System.Windows.Forms.Button();
            this.timerHideRefuselabel = new System.Windows.Forms.Timer(this.components);
            this.setSavePath = new System.Windows.Forms.Button();
            this.friendsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoListPicture)).BeginInit();
            this.backGround.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.talkBackground)).BeginInit();
            this.buttonBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.head)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // friendsList
            // 
            this.friendsList.AutoScroll = true;
            this.friendsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(53)))), ((int)(((byte)(82)))));
            this.friendsList.Controls.Add(this.NoListLabel);
            this.friendsList.Controls.Add(this.NoListPicture);
            this.friendsList.Location = new System.Drawing.Point(68, 1);
            this.friendsList.Name = "friendsList";
            this.friendsList.Size = new System.Drawing.Size(456, 876);
            this.friendsList.TabIndex = 2;
            this.friendsList.Paint += new System.Windows.Forms.PaintEventHandler(this.FriendsList_Paint);
            this.friendsList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FriendsList_MouseDown);
            // 
            // NoListLabel
            // 
            this.NoListLabel.AutoSize = true;
            this.NoListLabel.Font = new System.Drawing.Font("微软雅黑", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NoListLabel.ForeColor = System.Drawing.Color.White;
            this.NoListLabel.Location = new System.Drawing.Point(131, 438);
            this.NoListLabel.Name = "NoListLabel";
            this.NoListLabel.Size = new System.Drawing.Size(197, 57);
            this.NoListLabel.TabIndex = 23;
            this.NoListLabel.Text = "列表为空";
            // 
            // NoListPicture
            // 
            this.NoListPicture.BackColor = System.Drawing.Color.Transparent;
            this.NoListPicture.BackgroundImage = global::QQ.Properties.Resources.robo002;
            this.NoListPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NoListPicture.InitialImage = null;
            this.NoListPicture.Location = new System.Drawing.Point(109, 225);
            this.NoListPicture.Name = "NoListPicture";
            this.NoListPicture.Size = new System.Drawing.Size(231, 210);
            this.NoListPicture.TabIndex = 22;
            this.NoListPicture.TabStop = false;
            // 
            // backGround
            // 
            this.backGround.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.backGround.Controls.Add(this.nomessageLabel);
            this.backGround.Controls.Add(this.sendFiles);
            this.backGround.Controls.Add(this.friendDOWNlabel);
            this.backGround.Controls.Add(this.showFriendName);
            this.backGround.Controls.Add(this.sendChatButton);
            this.backGround.Controls.Add(this.label2);
            this.backGround.Controls.Add(this.inputRichTextbox);
            this.backGround.Controls.Add(this.chatRichTextBox);
            this.backGround.Controls.Add(this.talkBackground);
            this.backGround.Controls.Add(this.SaveAllrichTextBox);
            this.backGround.Location = new System.Drawing.Point(527, 1);
            this.backGround.Name = "backGround";
            this.backGround.Size = new System.Drawing.Size(956, 876);
            this.backGround.TabIndex = 20;
            this.backGround.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackGround_MouseDown);
            // 
            // nomessageLabel
            // 
            this.nomessageLabel.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nomessageLabel.ForeColor = System.Drawing.Color.White;
            this.nomessageLabel.Location = new System.Drawing.Point(678, 762);
            this.nomessageLabel.Name = "nomessageLabel";
            this.nomessageLabel.Size = new System.Drawing.Size(276, 47);
            this.nomessageLabel.TabIndex = 32;
            this.nomessageLabel.Text = "不能发送空白消息";
            this.nomessageLabel.Visible = false;
            // 
            // sendFiles
            // 
            this.sendFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.sendFiles.BackgroundImage = global::QQ.Properties.Resources.文件;
            this.sendFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sendFiles.FlatAppearance.BorderSize = 0;
            this.sendFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.sendFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.sendFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendFiles.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sendFiles.ForeColor = System.Drawing.Color.White;
            this.sendFiles.Location = new System.Drawing.Point(722, 812);
            this.sendFiles.Name = "sendFiles";
            this.sendFiles.Size = new System.Drawing.Size(80, 54);
            this.sendFiles.TabIndex = 30;
            this.sendFiles.UseVisualStyleBackColor = false;
            this.sendFiles.Visible = false;
            this.sendFiles.Click += new System.EventHandler(this.SendFiles_Click);
            // 
            // friendDOWNlabel
            // 
            this.friendDOWNlabel.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.friendDOWNlabel.ForeColor = System.Drawing.Color.White;
            this.friendDOWNlabel.Location = new System.Drawing.Point(375, 501);
            this.friendDOWNlabel.Name = "friendDOWNlabel";
            this.friendDOWNlabel.Size = new System.Drawing.Size(372, 47);
            this.friendDOWNlabel.TabIndex = 29;
            this.friendDOWNlabel.Text = "对方已下线，无法发送消息";
            this.friendDOWNlabel.Visible = false;
            // 
            // showFriendName
            // 
            this.showFriendName.BackColor = System.Drawing.Color.Transparent;
            this.showFriendName.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showFriendName.ForeColor = System.Drawing.Color.White;
            this.showFriendName.Location = new System.Drawing.Point(0, 1);
            this.showFriendName.Name = "showFriendName";
            this.showFriendName.Size = new System.Drawing.Size(954, 47);
            this.showFriendName.TabIndex = 24;
            this.showFriendName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showFriendName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShouFriendName_MouseDown);
            // 
            // sendChatButton
            // 
            this.sendChatButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.sendChatButton.BackgroundImage = global::QQ.Properties.Resources.发送__1_;
            this.sendChatButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sendChatButton.FlatAppearance.BorderSize = 0;
            this.sendChatButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.sendChatButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.sendChatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendChatButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sendChatButton.ForeColor = System.Drawing.Color.White;
            this.sendChatButton.Location = new System.Drawing.Point(828, 812);
            this.sendChatButton.Name = "sendChatButton";
            this.sendChatButton.Size = new System.Drawing.Size(80, 54);
            this.sendChatButton.TabIndex = 28;
            this.sendChatButton.UseVisualStyleBackColor = false;
            this.sendChatButton.Visible = false;
            this.sendChatButton.Click += new System.EventHandler(this.SendChatButton_Click);
            this.sendChatButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendChatButton_KeyPress);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(117)))));
            this.label2.Location = new System.Drawing.Point(0, 649);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1054, 1);
            this.label2.TabIndex = 27;
            this.label2.Visible = false;
            // 
            // inputRichTextbox
            // 
            this.inputRichTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.inputRichTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputRichTextbox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputRichTextbox.ForeColor = System.Drawing.Color.White;
            this.inputRichTextbox.Location = new System.Drawing.Point(0, 650);
            this.inputRichTextbox.Name = "inputRichTextbox";
            this.inputRichTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.inputRichTextbox.Size = new System.Drawing.Size(954, 159);
            this.inputRichTextbox.TabIndex = 26;
            this.inputRichTextbox.Text = "";
            this.inputRichTextbox.Visible = false;
            this.inputRichTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputRichTextbox_KeyPress);
            // 
            // chatRichTextBox
            // 
            this.chatRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.chatRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatRichTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chatRichTextBox.ForeColor = System.Drawing.Color.White;
            this.chatRichTextBox.Location = new System.Drawing.Point(0, 48);
            this.chatRichTextBox.Name = "chatRichTextBox";
            this.chatRichTextBox.ReadOnly = true;
            this.chatRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.chatRichTextBox.Size = new System.Drawing.Size(956, 600);
            this.chatRichTextBox.TabIndex = 25;
            this.chatRichTextBox.Text = "";
            this.chatRichTextBox.Visible = false;
            this.chatRichTextBox.TextChanged += new System.EventHandler(this.ChatRichTextBox_TextChanged);
            // 
            // talkBackground
            // 
            this.talkBackground.BackColor = System.Drawing.Color.Transparent;
            this.talkBackground.BackgroundImage = global::QQ.Properties.Resources.CytusII;
            this.talkBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.talkBackground.InitialImage = null;
            this.talkBackground.Location = new System.Drawing.Point(155, 196);
            this.talkBackground.Name = "talkBackground";
            this.talkBackground.Size = new System.Drawing.Size(658, 414);
            this.talkBackground.TabIndex = 18;
            this.talkBackground.TabStop = false;
            this.talkBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TalkBackground1_MouseDown);
            // 
            // SaveAllrichTextBox
            // 
            this.SaveAllrichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.SaveAllrichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SaveAllrichTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveAllrichTextBox.ForeColor = System.Drawing.Color.White;
            this.SaveAllrichTextBox.Location = new System.Drawing.Point(0, 48);
            this.SaveAllrichTextBox.Name = "SaveAllrichTextBox";
            this.SaveAllrichTextBox.ReadOnly = true;
            this.SaveAllrichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.SaveAllrichTextBox.Size = new System.Drawing.Size(1054, 600);
            this.SaveAllrichTextBox.TabIndex = 31;
            this.SaveAllrichTextBox.Text = "";
            this.SaveAllrichTextBox.Visible = false;
            // 
            // timerOpen
            // 
            this.timerOpen.Interval = 10;
            this.timerOpen.Tick += new System.EventHandler(this.TimerOpen_Tick);
            // 
            // timerClose
            // 
            this.timerClose.Interval = 10;
            this.timerClose.Tick += new System.EventHandler(this.TimerClose_Tick);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.buttonBack.Controls.Add(this.showitUID);
            this.buttonBack.Controls.Add(this.showitIP);
            this.buttonBack.Controls.Add(this.UIDLabel2);
            this.buttonBack.Controls.Add(this.IPlabel2);
            this.buttonBack.Controls.Add(this.UsernameLabel1);
            this.buttonBack.Controls.Add(this.showitUserName);
            this.buttonBack.Controls.Add(this.label1);
            this.buttonBack.Controls.Add(this.IPtext);
            this.buttonBack.Controls.Add(this.IPlabel);
            this.buttonBack.Controls.Add(this.UIDlabel);
            this.buttonBack.Controls.Add(this.UIDtext);
            this.buttonBack.Controls.Add(this.userName);
            this.buttonBack.Controls.Add(this.head);
            this.buttonBack.Location = new System.Drawing.Point(1, 1);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(67, 876);
            this.buttonBack.TabIndex = 27;
            // 
            // showitUID
            // 
            this.showitUID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.showitUID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.showitUID.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showitUID.ForeColor = System.Drawing.Color.White;
            this.showitUID.Location = new System.Drawing.Point(90, 659);
            this.showitUID.Multiline = true;
            this.showitUID.Name = "showitUID";
            this.showitUID.ReadOnly = true;
            this.showitUID.Size = new System.Drawing.Size(270, 32);
            this.showitUID.TabIndex = 38;
            this.showitUID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // showitIP
            // 
            this.showitIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.showitIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.showitIP.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showitIP.ForeColor = System.Drawing.Color.White;
            this.showitIP.Location = new System.Drawing.Point(90, 591);
            this.showitIP.Multiline = true;
            this.showitIP.Name = "showitIP";
            this.showitIP.ReadOnly = true;
            this.showitIP.Size = new System.Drawing.Size(247, 32);
            this.showitIP.TabIndex = 37;
            this.showitIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UIDLabel2
            // 
            this.UIDLabel2.AutoSize = true;
            this.UIDLabel2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIDLabel2.ForeColor = System.Drawing.Color.White;
            this.UIDLabel2.Location = new System.Drawing.Point(18, 657);
            this.UIDLabel2.Name = "UIDLabel2";
            this.UIDLabel2.Size = new System.Drawing.Size(66, 32);
            this.UIDLabel2.TabIndex = 36;
            this.UIDLabel2.Text = "UID:";
            this.UIDLabel2.Visible = false;
            // 
            // IPlabel2
            // 
            this.IPlabel2.AutoSize = true;
            this.IPlabel2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IPlabel2.ForeColor = System.Drawing.Color.White;
            this.IPlabel2.Location = new System.Drawing.Point(27, 591);
            this.IPlabel2.Name = "IPlabel2";
            this.IPlabel2.Size = new System.Drawing.Size(43, 32);
            this.IPlabel2.TabIndex = 35;
            this.IPlabel2.Text = "IP:";
            this.IPlabel2.Visible = false;
            // 
            // UsernameLabel1
            // 
            this.UsernameLabel1.AutoSize = true;
            this.UsernameLabel1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UsernameLabel1.ForeColor = System.Drawing.Color.White;
            this.UsernameLabel1.Location = new System.Drawing.Point(3, 515);
            this.UsernameLabel1.Name = "UsernameLabel1";
            this.UsernameLabel1.Size = new System.Drawing.Size(96, 32);
            this.UsernameLabel1.TabIndex = 34;
            this.UsernameLabel1.Text = "用户名:";
            this.UsernameLabel1.Visible = false;
            // 
            // showitUserName
            // 
            this.showitUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.showitUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.showitUserName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showitUserName.ForeColor = System.Drawing.Color.White;
            this.showitUserName.Location = new System.Drawing.Point(90, 515);
            this.showitUserName.Multiline = true;
            this.showitUserName.Name = "showitUserName";
            this.showitUserName.ReadOnly = true;
            this.showitUserName.Size = new System.Drawing.Size(247, 33);
            this.showitUserName.TabIndex = 33;
            this.showitUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 46);
            this.label1.TabIndex = 32;
            this.label1.Text = "对方信息";
            this.label1.Visible = false;
            // 
            // IPtext
            // 
            this.IPtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.IPtext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IPtext.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IPtext.ForeColor = System.Drawing.Color.White;
            this.IPtext.Location = new System.Drawing.Point(67, 87);
            this.IPtext.Multiline = true;
            this.IPtext.Name = "IPtext";
            this.IPtext.ReadOnly = true;
            this.IPtext.Size = new System.Drawing.Size(247, 32);
            this.IPtext.TabIndex = 31;
            // 
            // IPlabel
            // 
            this.IPlabel.AutoSize = true;
            this.IPlabel.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IPlabel.ForeColor = System.Drawing.Color.White;
            this.IPlabel.Location = new System.Drawing.Point(18, 87);
            this.IPlabel.Name = "IPlabel";
            this.IPlabel.Size = new System.Drawing.Size(43, 32);
            this.IPlabel.TabIndex = 30;
            this.IPlabel.Text = "IP:";
            this.IPlabel.Visible = false;
            // 
            // UIDlabel
            // 
            this.UIDlabel.AutoSize = true;
            this.UIDlabel.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIDlabel.ForeColor = System.Drawing.Color.White;
            this.UIDlabel.Location = new System.Drawing.Point(3, 126);
            this.UIDlabel.Name = "UIDlabel";
            this.UIDlabel.Size = new System.Drawing.Size(66, 32);
            this.UIDlabel.TabIndex = 29;
            this.UIDlabel.Text = "UID:";
            this.UIDlabel.Visible = false;
            // 
            // UIDtext
            // 
            this.UIDtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.UIDtext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UIDtext.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIDtext.ForeColor = System.Drawing.Color.White;
            this.UIDtext.Location = new System.Drawing.Point(67, 128);
            this.UIDtext.Multiline = true;
            this.UIDtext.Name = "UIDtext";
            this.UIDtext.ReadOnly = true;
            this.UIDtext.Size = new System.Drawing.Size(293, 32);
            this.UIDtext.TabIndex = 28;
            // 
            // userName
            // 
            this.userName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.userName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userName.ForeColor = System.Drawing.Color.White;
            this.userName.Location = new System.Drawing.Point(90, 26);
            this.userName.Multiline = true;
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            this.userName.Size = new System.Drawing.Size(150, 33);
            this.userName.TabIndex = 27;
            // 
            // head
            // 
            this.head.BackColor = System.Drawing.Color.Transparent;
            this.head.BackgroundImage = global::QQ.Properties.Resources.aroma;
            this.head.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.head.Location = new System.Drawing.Point(3, 3);
            this.head.Name = "head";
            this.head.Size = new System.Drawing.Size(67, 73);
            this.head.TabIndex = 26;
            this.head.TabStop = false;
            // 
            // timershowDOWN
            // 
            this.timershowDOWN.Interval = 1500;
            this.timershowDOWN.Tick += new System.EventHandler(this.TimershowDOWN_Tick);
            // 
            // timerNomessage
            // 
            this.timerNomessage.Interval = 1000;
            this.timerNomessage.Tick += new System.EventHandler(this.TimerNomessage_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(43)))));
            this.panel1.Controls.Add(this.setSavePath);
            this.panel1.Controls.Add(this.conformSend);
            this.panel1.Controls.Add(this.filePathTextbox);
            this.panel1.Controls.Add(this.showRefuselabel);
            this.panel1.Controls.Add(this.requestButton);
            this.panel1.Controls.Add(this.NObutton);
            this.panel1.Controls.Add(this.OKbutton);
            this.panel1.Controls.Add(this.RequestOKorNOlabel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.selectFile);
            this.panel1.Controls.Add(this.sendFileLbael);
            this.panel1.Location = new System.Drawing.Point(1484, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 876);
            this.panel1.TabIndex = 28;
            // 
            // conformSend
            // 
            this.conformSend.BackColor = System.Drawing.Color.Transparent;
            this.conformSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.conformSend.FlatAppearance.BorderSize = 0;
            this.conformSend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.conformSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.conformSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conformSend.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.conformSend.ForeColor = System.Drawing.Color.White;
            this.conformSend.Location = new System.Drawing.Point(141, 657);
            this.conformSend.Name = "conformSend";
            this.conformSend.Size = new System.Drawing.Size(126, 61);
            this.conformSend.TabIndex = 41;
            this.conformSend.Text = "发送";
            this.conformSend.UseVisualStyleBackColor = false;
            this.conformSend.Visible = false;
            this.conformSend.Click += new System.EventHandler(this.ConformSend_Click);
            // 
            // filePathTextbox
            // 
            this.filePathTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(43)))));
            this.filePathTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filePathTextbox.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filePathTextbox.ForeColor = System.Drawing.Color.White;
            this.filePathTextbox.Location = new System.Drawing.Point(18, 566);
            this.filePathTextbox.Multiline = true;
            this.filePathTextbox.Name = "filePathTextbox";
            this.filePathTextbox.ReadOnly = true;
            this.filePathTextbox.Size = new System.Drawing.Size(379, 72);
            this.filePathTextbox.TabIndex = 40;
            // 
            // showRefuselabel
            // 
            this.showRefuselabel.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showRefuselabel.ForeColor = System.Drawing.Color.White;
            this.showRefuselabel.Location = new System.Drawing.Point(62, 320);
            this.showRefuselabel.Name = "showRefuselabel";
            this.showRefuselabel.Size = new System.Drawing.Size(300, 80);
            this.showRefuselabel.TabIndex = 39;
            this.showRefuselabel.Text = "对方拒绝了你的请求";
            this.showRefuselabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.showRefuselabel.Visible = false;
            // 
            // requestButton
            // 
            this.requestButton.BackColor = System.Drawing.Color.Transparent;
            this.requestButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.requestButton.FlatAppearance.BorderSize = 0;
            this.requestButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.requestButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.requestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.requestButton.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.requestButton.ForeColor = System.Drawing.Color.White;
            this.requestButton.Location = new System.Drawing.Point(141, 724);
            this.requestButton.Name = "requestButton";
            this.requestButton.Size = new System.Drawing.Size(136, 61);
            this.requestButton.TabIndex = 38;
            this.requestButton.Text = "发送请求";
            this.requestButton.UseVisualStyleBackColor = false;
            this.requestButton.Click += new System.EventHandler(this.RequestButton_Click);
            // 
            // NObutton
            // 
            this.NObutton.BackColor = System.Drawing.Color.Transparent;
            this.NObutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NObutton.FlatAppearance.BorderSize = 0;
            this.NObutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.NObutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.NObutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NObutton.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NObutton.ForeColor = System.Drawing.Color.White;
            this.NObutton.Location = new System.Drawing.Point(253, 403);
            this.NObutton.Name = "NObutton";
            this.NObutton.Size = new System.Drawing.Size(90, 49);
            this.NObutton.TabIndex = 37;
            this.NObutton.Text = "拒绝";
            this.NObutton.UseVisualStyleBackColor = false;
            this.NObutton.Visible = false;
            this.NObutton.Click += new System.EventHandler(this.NObutton_Click);
            // 
            // OKbutton
            // 
            this.OKbutton.BackColor = System.Drawing.Color.Transparent;
            this.OKbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OKbutton.FlatAppearance.BorderSize = 0;
            this.OKbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.OKbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.OKbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKbutton.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OKbutton.ForeColor = System.Drawing.Color.White;
            this.OKbutton.Location = new System.Drawing.Point(56, 403);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(90, 49);
            this.OKbutton.TabIndex = 36;
            this.OKbutton.Text = "接收";
            this.OKbutton.UseVisualStyleBackColor = false;
            this.OKbutton.Visible = false;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // RequestOKorNOlabel
            // 
            this.RequestOKorNOlabel.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RequestOKorNOlabel.ForeColor = System.Drawing.Color.White;
            this.RequestOKorNOlabel.Location = new System.Drawing.Point(32, 273);
            this.RequestOKorNOlabel.Name = "RequestOKorNOlabel";
            this.RequestOKorNOlabel.Size = new System.Drawing.Size(365, 38);
            this.RequestOKorNOlabel.TabIndex = 35;
            this.RequestOKorNOlabel.Text = "对方要传输文件，是否接收";
            this.RequestOKorNOlabel.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QQ.Properties.Resources.文件1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(46, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 56);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // selectFile
            // 
            this.selectFile.BackColor = System.Drawing.Color.Transparent;
            this.selectFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.selectFile.FlatAppearance.BorderSize = 0;
            this.selectFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.selectFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.selectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFile.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectFile.ForeColor = System.Drawing.Color.White;
            this.selectFile.Location = new System.Drawing.Point(84, 791);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(259, 59);
            this.selectFile.TabIndex = 33;
            this.selectFile.Text = "选择文件";
            this.selectFile.UseVisualStyleBackColor = false;
            this.selectFile.Visible = false;
            this.selectFile.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // sendFileLbael
            // 
            this.sendFileLbael.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sendFileLbael.ForeColor = System.Drawing.Color.White;
            this.sendFileLbael.Location = new System.Drawing.Point(125, 8);
            this.sendFileLbael.Name = "sendFileLbael";
            this.sendFileLbael.Size = new System.Drawing.Size(152, 47);
            this.sendFileLbael.TabIndex = 33;
            this.sendFileLbael.Text = "文件传输";
            // 
            // close1
            // 
            this.close1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.close1.BackgroundImage = global::QQ.Properties.Resources.Close;
            this.close1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.close1.FlatAppearance.BorderSize = 0;
            this.close1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.close1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.close1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close1.Location = new System.Drawing.Point(1396, 1);
            this.close1.Name = "close1";
            this.close1.Size = new System.Drawing.Size(87, 45);
            this.close1.TabIndex = 19;
            this.close1.UseVisualStyleBackColor = false;
            this.close1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // openButtenList
            // 
            this.openButtenList.BackColor = System.Drawing.Color.Transparent;
            this.openButtenList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.openButtenList.FlatAppearance.BorderSize = 0;
            this.openButtenList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.openButtenList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.openButtenList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openButtenList.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.openButtenList.ForeColor = System.Drawing.Color.White;
            this.openButtenList.Image = ((System.Drawing.Image)(resources.GetObject("openButtenList.Image")));
            this.openButtenList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openButtenList.Location = new System.Drawing.Point(-10, 816);
            this.openButtenList.Name = "openButtenList";
            this.openButtenList.Size = new System.Drawing.Size(371, 62);
            this.openButtenList.TabIndex = 25;
            this.openButtenList.Text = "详细信息";
            this.openButtenList.UseVisualStyleBackColor = false;
            this.openButtenList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OpenButtenList_MouseClick);
            // 
            // talkList
            // 
            this.talkList.BackColor = System.Drawing.Color.Transparent;
            this.talkList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.talkList.FlatAppearance.BorderSize = 0;
            this.talkList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.talkList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.talkList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.talkList.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.talkList.ForeColor = System.Drawing.Color.Transparent;
            this.talkList.Image = global::QQ.Properties.Resources.聊天2;
            this.talkList.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.talkList.Location = new System.Drawing.Point(-10, 181);
            this.talkList.Name = "talkList";
            this.talkList.Size = new System.Drawing.Size(371, 66);
            this.talkList.TabIndex = 22;
            this.talkList.Text = "聊天";
            this.talkList.UseVisualStyleBackColor = false;
            // 
            // Friends
            // 
            this.Friends.BackColor = System.Drawing.Color.Transparent;
            this.Friends.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Friends.FlatAppearance.BorderSize = 0;
            this.Friends.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Friends.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.Friends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Friends.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Friends.ForeColor = System.Drawing.Color.White;
            this.Friends.Image = ((System.Drawing.Image)(resources.GetObject("Friends.Image")));
            this.Friends.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Friends.Location = new System.Drawing.Point(-10, 274);
            this.Friends.Name = "Friends";
            this.Friends.Size = new System.Drawing.Size(371, 66);
            this.Friends.TabIndex = 1;
            this.Friends.Text = "联系人";
            this.Friends.UseVisualStyleBackColor = false;
            // 
            // timerHideRefuselabel
            // 
            this.timerHideRefuselabel.Interval = 2000;
            this.timerHideRefuselabel.Tick += new System.EventHandler(this.TimerHideRefuselabel_Tick);
            // 
            // setSavePath
            // 
            this.setSavePath.BackColor = System.Drawing.Color.Transparent;
            this.setSavePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.setSavePath.FlatAppearance.BorderSize = 0;
            this.setSavePath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.setSavePath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.setSavePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setSavePath.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setSavePath.ForeColor = System.Drawing.Color.White;
            this.setSavePath.Location = new System.Drawing.Point(68, 791);
            this.setSavePath.Name = "setSavePath";
            this.setSavePath.Size = new System.Drawing.Size(278, 59);
            this.setSavePath.TabIndex = 42;
            this.setSavePath.Text = "选择保存路径";
            this.setSavePath.UseVisualStyleBackColor = false;
            this.setSavePath.Visible = false;
            this.setSavePath.Click += new System.EventHandler(this.SetSavePath_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(1893, 879);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.close1);
            this.Controls.Add(this.openButtenList);
            this.Controls.Add(this.talkList);
            this.Controls.Add(this.Friends);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.friendsList);
            this.Controls.Add(this.backGround);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.friendsList.ResumeLayout(false);
            this.friendsList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoListPicture)).EndInit();
            this.backGround.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.talkBackground)).EndInit();
            this.buttonBack.ResumeLayout(false);
            this.buttonBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.head)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Friends;
        private System.Windows.Forms.Panel friendsList;
        private System.Windows.Forms.PictureBox talkBackground;
        private System.Windows.Forms.Button close1;
        private System.Windows.Forms.Panel backGround;
        private System.Windows.Forms.Button talkList;
        private System.Windows.Forms.Timer timerOpen;
        private System.Windows.Forms.PictureBox NoListPicture;
        private System.Windows.Forms.Label NoListLabel;
        private System.Windows.Forms.Button openButtenList;
        private System.Windows.Forms.Timer timerClose;
        private System.Windows.Forms.PictureBox head;
        private System.Windows.Forms.Panel buttonBack;
        private System.Windows.Forms.Label UIDlabel;
        private System.Windows.Forms.TextBox UIDtext;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox IPtext;
        private System.Windows.Forms.Label IPlabel;
        private System.Windows.Forms.TextBox showitUID;
        private System.Windows.Forms.TextBox showitIP;
        private System.Windows.Forms.Label UIDLabel2;
        private System.Windows.Forms.Label IPlabel2;
        private System.Windows.Forms.Label UsernameLabel1;
        private System.Windows.Forms.TextBox showitUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox inputRichTextbox;
        private System.Windows.Forms.Button sendChatButton;
        public System.Windows.Forms.RichTextBox chatRichTextBox;
        private System.Windows.Forms.Label showFriendName;
        private System.Windows.Forms.Label friendDOWNlabel;
        private System.Windows.Forms.Timer timershowDOWN;
        private System.Windows.Forms.Button sendFiles;
        public System.Windows.Forms.RichTextBox SaveAllrichTextBox;
        private System.Windows.Forms.Timer timerNomessage;
        private System.Windows.Forms.Label nomessageLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button selectFile;
        private System.Windows.Forms.Label sendFileLbael;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button NObutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Label RequestOKorNOlabel;
        private System.Windows.Forms.Button requestButton;
        private System.Windows.Forms.Label showRefuselabel;
        private System.Windows.Forms.Timer timerHideRefuselabel;
        private System.Windows.Forms.TextBox filePathTextbox;
        private System.Windows.Forms.Button conformSend;
        private System.Windows.Forms.Button setSavePath;
    }
}