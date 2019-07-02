namespace QQ
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerCytusno = new System.Windows.Forms.Timer(this.components);
            this.timerCytus2xuhua = new System.Windows.Forms.Timer(this.components);
            this.inputNumber = new System.Windows.Forms.TextBox();
            this.inputPassword = new System.Windows.Forms.TextBox();
            this.enRoll = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.WarningFalse = new System.Windows.Forms.Label();
            this.loginButton2 = new System.Windows.Forms.Button();
            this.loginPoint = new System.Windows.Forms.Label();
            this.UIDpoint = new System.Windows.Forms.TextBox();
            this.UIDlabel = new System.Windows.Forms.Label();
            this.PointOut = new System.Windows.Forms.Label();
            this.loginWarning3 = new System.Windows.Forms.Label();
            this.timerSwitch = new System.Windows.Forms.Timer(this.components);
            this.Success = new System.Windows.Forms.Label();
            this.timerSwitch2 = new System.Windows.Forms.Timer(this.components);
            this.timerWate = new System.Windows.Forms.Timer(this.components);
            this.timerSwitchLabel = new System.Windows.Forms.Timer(this.components);
            this.timerSwitchForm = new System.Windows.Forms.Timer(this.components);
            this.showPassword = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.close1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cytus2xuhua7 = new System.Windows.Forms.PictureBox();
            this.cytus2xuhua6 = new System.Windows.Forms.PictureBox();
            this.cytus2xuhua5 = new System.Windows.Forms.PictureBox();
            this.cytus2xuhua4 = new System.Windows.Forms.PictureBox();
            this.cytus2xuhua3 = new System.Windows.Forms.PictureBox();
            this.cytus2xuhua2 = new System.Windows.Forms.PictureBox();
            this.Cytus2xuhua1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxNO = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cytus2xuhua7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cytus2xuhua6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cytus2xuhua5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cytus2xuhua4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cytus2xuhua3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cytus2xuhua2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cytus2xuhua1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerCytusno
            // 
            this.timerCytusno.Enabled = true;
            this.timerCytusno.Interval = 1000;
            this.timerCytusno.Tick += new System.EventHandler(this.TimerCytusno_Tick);
            // 
            // timerCytus2xuhua
            // 
            this.timerCytus2xuhua.Interval = 40;
            this.timerCytus2xuhua.Tick += new System.EventHandler(this.TimerCytus2xuhua_Tick);
            // 
            // inputNumber
            // 
            this.inputNumber.BackColor = System.Drawing.Color.White;
            this.inputNumber.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputNumber.ForeColor = System.Drawing.Color.Silver;
            this.inputNumber.Location = new System.Drawing.Point(465, 484);
            this.inputNumber.Name = "inputNumber";
            this.inputNumber.Size = new System.Drawing.Size(655, 47);
            this.inputNumber.TabIndex = 10;
            this.inputNumber.Text = "用户名";
            this.inputNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputNumber.Visible = false;
            this.inputNumber.MouseClick += new System.Windows.Forms.MouseEventHandler(this.InputNumber_MouseClick);
            this.inputNumber.Leave += new System.EventHandler(this.InputNumber_Leave);
            // 
            // inputPassword
            // 
            this.inputPassword.BackColor = System.Drawing.Color.White;
            this.inputPassword.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputPassword.ForeColor = System.Drawing.Color.Silver;
            this.inputPassword.Location = new System.Drawing.Point(465, 564);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.Size = new System.Drawing.Size(655, 47);
            this.inputPassword.TabIndex = 11;
            this.inputPassword.TabStop = false;
            this.inputPassword.Text = "密码";
            this.inputPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputPassword.Visible = false;
            this.inputPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.InputPassword_MouseClick);
            this.inputPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputPassword_KeyPress_1);
            this.inputPassword.Leave += new System.EventHandler(this.InputPassword_Leave);
            // 
            // enRoll
            // 
            this.enRoll.BackColor = System.Drawing.Color.Transparent;
            this.enRoll.FlatAppearance.BorderSize = 0;
            this.enRoll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.enRoll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.enRoll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enRoll.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.enRoll.ForeColor = System.Drawing.Color.Aqua;
            this.enRoll.Location = new System.Drawing.Point(1430, 799);
            this.enRoll.Margin = new System.Windows.Forms.Padding(0);
            this.enRoll.Name = "enRoll";
            this.enRoll.Size = new System.Drawing.Size(156, 78);
            this.enRoll.TabIndex = 15;
            this.enRoll.Text = "登录";
            this.enRoll.UseVisualStyleBackColor = false;
            this.enRoll.Visible = false;
            this.enRoll.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EnRoll_KeyPress);
            this.enRoll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EnRoll_MouseClick);
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.Color.Transparent;
            this.login.FlatAppearance.BorderSize = 0;
            this.login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login.ForeColor = System.Drawing.Color.Aqua;
            this.login.Location = new System.Drawing.Point(0, 799);
            this.login.Margin = new System.Windows.Forms.Padding(0);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(156, 78);
            this.login.TabIndex = 16;
            this.login.Text = "注册";
            this.login.UseVisualStyleBackColor = false;
            this.login.Visible = false;
            this.login.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ReSign_MouseClick);
            // 
            // WarningFalse
            // 
            this.WarningFalse.AutoSize = true;
            this.WarningFalse.BackColor = System.Drawing.Color.Transparent;
            this.WarningFalse.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WarningFalse.ForeColor = System.Drawing.Color.LightSalmon;
            this.WarningFalse.Location = new System.Drawing.Point(631, 655);
            this.WarningFalse.Name = "WarningFalse";
            this.WarningFalse.Size = new System.Drawing.Size(326, 50);
            this.WarningFalse.TabIndex = 18;
            this.WarningFalse.Text = "用户名或密码错误";
            this.WarningFalse.Visible = false;
            // 
            // loginButton2
            // 
            this.loginButton2.BackColor = System.Drawing.Color.Transparent;
            this.loginButton2.FlatAppearance.BorderSize = 0;
            this.loginButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.loginButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.loginButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton2.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginButton2.ForeColor = System.Drawing.Color.Aqua;
            this.loginButton2.Location = new System.Drawing.Point(1430, 799);
            this.loginButton2.Margin = new System.Windows.Forms.Padding(0);
            this.loginButton2.Name = "loginButton2";
            this.loginButton2.Size = new System.Drawing.Size(156, 78);
            this.loginButton2.TabIndex = 21;
            this.loginButton2.Text = "注册";
            this.loginButton2.UseVisualStyleBackColor = false;
            this.loginButton2.Visible = false;
            this.loginButton2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ResignButton2_MouseClick);
            // 
            // loginPoint
            // 
            this.loginPoint.BackColor = System.Drawing.Color.Transparent;
            this.loginPoint.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginPoint.ForeColor = System.Drawing.Color.Aqua;
            this.loginPoint.Location = new System.Drawing.Point(458, 734);
            this.loginPoint.Name = "loginPoint";
            this.loginPoint.Size = new System.Drawing.Size(670, 87);
            this.loginPoint.TabIndex = 22;
            this.loginPoint.Text = "创建账户时，系统会生成一个特有的UID，此UID作为此账号的唯一标识，注册后无法修改";
            this.loginPoint.Visible = false;
            // 
            // UIDpoint
            // 
            this.UIDpoint.BackColor = System.Drawing.Color.White;
            this.UIDpoint.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIDpoint.ForeColor = System.Drawing.Color.Silver;
            this.UIDpoint.Location = new System.Drawing.Point(465, 641);
            this.UIDpoint.Name = "UIDpoint";
            this.UIDpoint.ReadOnly = true;
            this.UIDpoint.Size = new System.Drawing.Size(655, 47);
            this.UIDpoint.TabIndex = 23;
            this.UIDpoint.TabStop = false;
            this.UIDpoint.Text = "UID";
            this.UIDpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UIDpoint.Visible = false;
            this.UIDpoint.WordWrap = false;
            // 
            // UIDlabel
            // 
            this.UIDlabel.AutoSize = true;
            this.UIDlabel.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIDlabel.ForeColor = System.Drawing.Color.Aqua;
            this.UIDlabel.Location = new System.Drawing.Point(340, 652);
            this.UIDlabel.Name = "UIDlabel";
            this.UIDlabel.Size = new System.Drawing.Size(95, 52);
            this.UIDlabel.TabIndex = 24;
            this.UIDlabel.Text = "UID";
            this.UIDlabel.Visible = false;
            // 
            // PointOut
            // 
            this.PointOut.BackColor = System.Drawing.Color.Transparent;
            this.PointOut.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PointOut.ForeColor = System.Drawing.Color.Aqua;
            this.PointOut.Location = new System.Drawing.Point(465, 636);
            this.PointOut.Name = "PointOut";
            this.PointOut.Size = new System.Drawing.Size(655, 96);
            this.PointOut.TabIndex = 26;
            this.PointOut.Text = "此账号不存在";
            this.PointOut.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PointOut.Visible = false;
            // 
            // loginWarning3
            // 
            this.loginWarning3.AutoSize = true;
            this.loginWarning3.BackColor = System.Drawing.Color.Transparent;
            this.loginWarning3.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginWarning3.ForeColor = System.Drawing.Color.Coral;
            this.loginWarning3.Location = new System.Drawing.Point(615, 734);
            this.loginWarning3.Name = "loginWarning3";
            this.loginWarning3.Size = new System.Drawing.Size(364, 50);
            this.loginWarning3.TabIndex = 27;
            this.loginWarning3.Text = "请输入用户名或密码";
            this.loginWarning3.Visible = false;
            // 
            // timerSwitch
            // 
            this.timerSwitch.Interval = 2000;
            this.timerSwitch.Tick += new System.EventHandler(this.TimerSwitch_Tick);
            // 
            // Success
            // 
            this.Success.AutoSize = true;
            this.Success.BackColor = System.Drawing.Color.Transparent;
            this.Success.Font = new System.Drawing.Font("微软雅黑", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Success.ForeColor = System.Drawing.Color.Aqua;
            this.Success.Location = new System.Drawing.Point(525, 734);
            this.Success.Name = "Success";
            this.Success.Size = new System.Drawing.Size(541, 57);
            this.Success.TabIndex = 28;
            this.Success.Text = "注册成功，将返回登录界面";
            this.Success.Visible = false;
            // 
            // timerSwitch2
            // 
            this.timerSwitch2.Interval = 2000;
            this.timerSwitch2.Tick += new System.EventHandler(this.TimerSwitch2_Tick);
            // 
            // timerWate
            // 
            this.timerWate.Interval = 1500;
            this.timerWate.Tick += new System.EventHandler(this.TimerWate_Tick);
            // 
            // timerSwitchLabel
            // 
            this.timerSwitchLabel.Interval = 2000;
            this.timerSwitchLabel.Tick += new System.EventHandler(this.TimerSwitchLabel_Tick);
            // 
            // timerSwitchForm
            // 
            this.timerSwitchForm.Interval = 3000;
            this.timerSwitchForm.Tick += new System.EventHandler(this.TimerSwitchForm_Tick);
            // 
            // showPassword
            // 
            this.showPassword.BackColor = System.Drawing.Color.Transparent;
            this.showPassword.BackgroundImage = global::QQ.Properties.Resources.显示__1_;
            this.showPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showPassword.FlatAppearance.BorderSize = 0;
            this.showPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.showPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.showPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPassword.Location = new System.Drawing.Point(1135, 564);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(55, 47);
            this.showPassword.TabIndex = 25;
            this.showPassword.UseVisualStyleBackColor = false;
            this.showPassword.Visible = false;
            this.showPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowPassword_MouseClick_1);
            // 
            // returnButton
            // 
            this.returnButton.BackColor = System.Drawing.Color.Transparent;
            this.returnButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("returnButton.BackgroundImage")));
            this.returnButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.returnButton.FlatAppearance.BorderSize = 0;
            this.returnButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.returnButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnButton.Location = new System.Drawing.Point(0, 0);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(71, 57);
            this.returnButton.TabIndex = 20;
            this.returnButton.UseVisualStyleBackColor = false;
            this.returnButton.Visible = false;
            this.returnButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ReturnButton_MouseClick);
            // 
            // close1
            // 
            this.close1.BackColor = System.Drawing.Color.Transparent;
            this.close1.BackgroundImage = global::QQ.Properties.Resources.微信图片_20190527004528;
            this.close1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.close1.FlatAppearance.BorderSize = 0;
            this.close1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.close1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.close1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close1.Location = new System.Drawing.Point(1528, 0);
            this.close1.Name = "close1";
            this.close1.Size = new System.Drawing.Size(58, 39);
            this.close1.TabIndex = 14;
            this.close1.UseVisualStyleBackColor = false;
            this.close1.Click += new System.EventHandler(this.Close1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::QQ.Properties.Resources.rayark;
            this.pictureBox2.Location = new System.Drawing.Point(465, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(655, 354);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox2_MouseDown);
            // 
            // cytus2xuhua7
            // 
            this.cytus2xuhua7.BackColor = System.Drawing.Color.Transparent;
            this.cytus2xuhua7.BackgroundImage = global::QQ.Properties.Resources.cytus2_7;
            this.cytus2xuhua7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cytus2xuhua7.Location = new System.Drawing.Point(1, 1);
            this.cytus2xuhua7.Name = "cytus2xuhua7";
            this.cytus2xuhua7.Size = new System.Drawing.Size(1585, 876);
            this.cytus2xuhua7.TabIndex = 8;
            this.cytus2xuhua7.TabStop = false;
            this.cytus2xuhua7.Visible = false;
            this.cytus2xuhua7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Cytus2xuhua7_MouseDown);
            // 
            // cytus2xuhua6
            // 
            this.cytus2xuhua6.BackColor = System.Drawing.Color.Transparent;
            this.cytus2xuhua6.BackgroundImage = global::QQ.Properties.Resources.cytus2_6;
            this.cytus2xuhua6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cytus2xuhua6.Location = new System.Drawing.Point(1, 1);
            this.cytus2xuhua6.Name = "cytus2xuhua6";
            this.cytus2xuhua6.Size = new System.Drawing.Size(1585, 876);
            this.cytus2xuhua6.TabIndex = 7;
            this.cytus2xuhua6.TabStop = false;
            this.cytus2xuhua6.Visible = false;
            // 
            // cytus2xuhua5
            // 
            this.cytus2xuhua5.BackColor = System.Drawing.Color.Transparent;
            this.cytus2xuhua5.BackgroundImage = global::QQ.Properties.Resources.cytus2_5;
            this.cytus2xuhua5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cytus2xuhua5.Location = new System.Drawing.Point(1, 1);
            this.cytus2xuhua5.Name = "cytus2xuhua5";
            this.cytus2xuhua5.Size = new System.Drawing.Size(1585, 876);
            this.cytus2xuhua5.TabIndex = 6;
            this.cytus2xuhua5.TabStop = false;
            this.cytus2xuhua5.Visible = false;
            // 
            // cytus2xuhua4
            // 
            this.cytus2xuhua4.BackColor = System.Drawing.Color.Transparent;
            this.cytus2xuhua4.BackgroundImage = global::QQ.Properties.Resources.cytus2_4;
            this.cytus2xuhua4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cytus2xuhua4.Location = new System.Drawing.Point(1, 1);
            this.cytus2xuhua4.Name = "cytus2xuhua4";
            this.cytus2xuhua4.Size = new System.Drawing.Size(1585, 876);
            this.cytus2xuhua4.TabIndex = 5;
            this.cytus2xuhua4.TabStop = false;
            this.cytus2xuhua4.Visible = false;
            // 
            // cytus2xuhua3
            // 
            this.cytus2xuhua3.BackColor = System.Drawing.Color.Transparent;
            this.cytus2xuhua3.BackgroundImage = global::QQ.Properties.Resources.cytus2_3;
            this.cytus2xuhua3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cytus2xuhua3.Location = new System.Drawing.Point(1, 1);
            this.cytus2xuhua3.Name = "cytus2xuhua3";
            this.cytus2xuhua3.Size = new System.Drawing.Size(1585, 876);
            this.cytus2xuhua3.TabIndex = 4;
            this.cytus2xuhua3.TabStop = false;
            this.cytus2xuhua3.Visible = false;
            // 
            // cytus2xuhua2
            // 
            this.cytus2xuhua2.BackColor = System.Drawing.Color.Transparent;
            this.cytus2xuhua2.BackgroundImage = global::QQ.Properties.Resources.cytus2_2;
            this.cytus2xuhua2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cytus2xuhua2.Location = new System.Drawing.Point(1, 1);
            this.cytus2xuhua2.Name = "cytus2xuhua2";
            this.cytus2xuhua2.Size = new System.Drawing.Size(1585, 876);
            this.cytus2xuhua2.TabIndex = 3;
            this.cytus2xuhua2.TabStop = false;
            this.cytus2xuhua2.Visible = false;
            // 
            // Cytus2xuhua1
            // 
            this.Cytus2xuhua1.BackColor = System.Drawing.Color.Transparent;
            this.Cytus2xuhua1.BackgroundImage = global::QQ.Properties.Resources.cytus2_1;
            this.Cytus2xuhua1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cytus2xuhua1.Location = new System.Drawing.Point(1, 1);
            this.Cytus2xuhua1.Name = "Cytus2xuhua1";
            this.Cytus2xuhua1.Size = new System.Drawing.Size(1585, 876);
            this.Cytus2xuhua1.TabIndex = 2;
            this.Cytus2xuhua1.TabStop = false;
            this.Cytus2xuhua1.Visible = false;
            // 
            // pictureBoxNO
            // 
            this.pictureBoxNO.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxNO.BackgroundImage = global::QQ.Properties.Resources.cytus2_no;
            this.pictureBoxNO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxNO.Location = new System.Drawing.Point(1, 1);
            this.pictureBoxNO.Name = "pictureBoxNO";
            this.pictureBoxNO.Size = new System.Drawing.Size(1585, 876);
            this.pictureBoxNO.TabIndex = 1;
            this.pictureBoxNO.TabStop = false;
            this.pictureBoxNO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxNO_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::QQ.Properties.Resources._20180308093852_93151;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1585, 876);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.enRoll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(1588, 879);
            this.Controls.Add(this.Success);
            this.Controls.Add(this.loginWarning3);
            this.Controls.Add(this.PointOut);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.UIDlabel);
            this.Controls.Add(this.UIDpoint);
            this.Controls.Add(this.loginPoint);
            this.Controls.Add(this.loginButton2);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.WarningFalse);
            this.Controls.Add(this.login);
            this.Controls.Add(this.enRoll);
            this.Controls.Add(this.close1);
            this.Controls.Add(this.inputPassword);
            this.Controls.Add(this.inputNumber);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cytus2xuhua7);
            this.Controls.Add(this.cytus2xuhua6);
            this.Controls.Add(this.cytus2xuhua5);
            this.Controls.Add(this.cytus2xuhua4);
            this.Controls.Add(this.cytus2xuhua3);
            this.Controls.Add(this.cytus2xuhua2);
            this.Controls.Add(this.Cytus2xuhua1);
            this.Controls.Add(this.pictureBoxNO);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cytus2xuhua7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cytus2xuhua6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cytus2xuhua5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cytus2xuhua4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cytus2xuhua3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cytus2xuhua2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cytus2xuhua1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerCytusno;
        private System.Windows.Forms.PictureBox pictureBoxNO;
        private System.Windows.Forms.Timer timerCytus2xuhua;
        private System.Windows.Forms.PictureBox Cytus2xuhua1;
        private System.Windows.Forms.PictureBox cytus2xuhua2;
        private System.Windows.Forms.PictureBox cytus2xuhua3;
        private System.Windows.Forms.PictureBox cytus2xuhua4;
        private System.Windows.Forms.PictureBox cytus2xuhua5;
        private System.Windows.Forms.PictureBox cytus2xuhua6;
        private System.Windows.Forms.PictureBox cytus2xuhua7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox inputNumber;
        private System.Windows.Forms.TextBox inputPassword;
        private System.Windows.Forms.Button close1;
        private System.Windows.Forms.Button enRoll;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label WarningFalse;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Button loginButton2;
        private System.Windows.Forms.Label loginPoint;
        private System.Windows.Forms.TextBox UIDpoint;
        private System.Windows.Forms.Label UIDlabel;
        private System.Windows.Forms.Button showPassword;
        private System.Windows.Forms.Label PointOut;
        private System.Windows.Forms.Label loginWarning3;
        private System.Windows.Forms.Timer timerSwitch;
        private System.Windows.Forms.Label Success;
        private System.Windows.Forms.Timer timerSwitch2;
        private System.Windows.Forms.Timer timerWate;
        private System.Windows.Forms.Timer timerSwitchLabel;
        private System.Windows.Forms.Timer timerSwitchForm;
    }
}

