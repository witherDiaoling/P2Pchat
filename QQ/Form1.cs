using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;
using System.Runtime.InteropServices;

namespace QQ
{






    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 双缓冲函数
        /// </summary>
        /// <param name="cc"></param>
        public static void SetDouble(Control cc)
        {
            cc.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(cc, true, null);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            close1.Parent = pictureBoxNO;
            timerCytusno.Start();
        }
        /// <summary>
        /// 给控件设置双缓冲
        /// </summary>
        public void SetDoubleForm()
        {
            SetDouble(close1);
            SetDouble(enRoll);
            SetDouble(inputNumber);
            SetDouble(inputPassword);
            SetDouble(login);
            SetDouble(loginButton2);
            SetDouble(loginPoint);
            SetDouble(loginWarning3);
            SetDouble(pictureBox1);
            SetDouble(pictureBox2);
            SetDouble(pictureBoxNO);
            SetDouble(PointOut);
            SetDouble(returnButton);
            SetDouble(showPassword);
            SetDouble(Success);
            SetDouble(UIDlabel);
            SetDouble(UIDpoint);
            SetDouble(WarningFalse);

        }

        //无边框拖动
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /*private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }*/

        private void TimerCytusno_Tick(object sender, EventArgs e)//开机控件显示
        {
            close1.Parent = pictureBox1;
            pictureBox1.Visible = true;
            pictureBoxNO.Visible = false;
            timerCytusno.Stop();
            timerCytusno.Enabled = false;
        }

        private void PictureBoxNO_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        /// <summary> 
        /// 你们的爸爸真的是我！(○｀ 3′○)（大雾）
        /// </summary> 
        /// <returns></returns> 
        void AllareMySon()
        {
            UIDlabel.Parent = cytus2xuhua7;
            close1.Parent = cytus2xuhua7;
            enRoll.Parent = cytus2xuhua7;
            login.Parent = cytus2xuhua7;
            WarningFalse.Parent = cytus2xuhua7;
            PointOut.Parent = cytus2xuhua7;
            UIDpoint.Parent = cytus2xuhua7;
            returnButton.Parent = cytus2xuhua7;
            loginButton2.Parent = cytus2xuhua7;
            loginPoint.Parent = cytus2xuhua7;
            showPassword.Parent = cytus2xuhua7;
            loginWarning3.Parent = cytus2xuhua7;
            Success.Parent = cytus2xuhua7;
        }

        private void TimerCytus2xuhua_Tick(object sender, EventArgs e)//仿造动态模糊操作
        {
            //pictureBox1.Visible = false;
            if(pictureBox1.Visible==true)
            {
                close1.Parent = Cytus2xuhua1;
                Cytus2xuhua1.Visible = true;
                pictureBox1.Visible = false;
            }
            else if (Cytus2xuhua1.Visible==true)
            {
                close1.Parent = cytus2xuhua2;
                cytus2xuhua2.Visible = true;
                Cytus2xuhua1.Visible = false;
            }
            else if(cytus2xuhua2.Visible==true)
            {
                close1.Parent = cytus2xuhua3;
                cytus2xuhua3.Visible = true;
                cytus2xuhua2.Visible = false;
            }
            else if (cytus2xuhua3.Visible == true)
            {
                close1.Parent = cytus2xuhua4;
                cytus2xuhua4.Visible = true;
                cytus2xuhua3.Visible = false;
            }
            else if (cytus2xuhua4.Visible == true)
            {
                close1.Parent = cytus2xuhua5;
                cytus2xuhua5.Visible = true;
                cytus2xuhua4.Visible = false;
            }
            else if (cytus2xuhua5.Visible == true)
            {
                close1.Parent = cytus2xuhua6;
                cytus2xuhua6.Visible = true;
                cytus2xuhua5.Visible = false;
            }
            else if (cytus2xuhua6.Visible == true)//显示部分控件
            {
                cytus2xuhua7.Visible = true;
                cytus2xuhua6.Visible = false;
                AllareMySon();
                enRoll.Visible = true;
                login.Visible = true;
                //Warning1.Visible = true;
                pictureBox2.Visible = true;
                inputNumber.Visible = true;
                showPassword.Visible = true;
                inputNumber.BringToFront();
                inputPassword.Visible = true;
                inputPassword.BringToFront();
                pictureBox2.Parent = cytus2xuhua7;

                timerCytus2xuhua.Stop();
                timerCytus2xuhua.Enabled = false;
            }

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            timerCytus2xuhua.Start();
        }



        private void Close1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Cytus2xuhua7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void InputNumber_MouseClick(object sender, MouseEventArgs e)//未点击时显示背景文字，点击后隐藏
        {
            if(inputNumber.Text=="用户名")
            {
                inputNumber.Text = "";
                inputNumber.ForeColor = Color.Black;

            }
        }

        private void InputPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if(inputPassword.Text=="密码")
            {
                inputPassword.Text = "";
                inputPassword.ForeColor = Color.Black;
                inputPassword.UseSystemPasswordChar=true;
            }
        }

        private void PictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void InputNumber_Leave(object sender, EventArgs e)
        {
            if(inputNumber.Text=="")
            {
                inputNumber.Text = "用户名";
                inputNumber.ForeColor = Color.Silver;
            }
        }

        private void InputPassword_Leave(object sender, EventArgs e)
        {
            if (inputPassword.Text == "")
            {
                inputPassword.Text = "密码";
                inputPassword.ForeColor = Color.Silver;
                inputPassword.UseSystemPasswordChar = false;
            }
        }

        private void ReSign_MouseClick(object sender, MouseEventArgs e)
        {
            PointOut.Visible = false;
            inputNumber.Text = "用户名";
            inputNumber.ForeColor = Color.Silver;
            inputPassword.Text = "密码";
            inputPassword.ForeColor = Color.Silver;
            inputPassword.UseSystemPasswordChar = false;
            DateTime t = DateTime.Now;
            UIDpoint.Text = t.ToString("yyyyMMddHHmmssfff");
            UIDlabel.Visible = true;
            UIDpoint.Visible = true;
            login.Visible = false;
            WarningFalse.Visible = false;
            enRoll.Visible = false;
            returnButton.Visible = true;
            loginButton2.Visible = true;
            loginPoint.Visible = true;
        }

        private void ReturnButton_MouseClick(object sender, MouseEventArgs e)
        {
            WarningFalse.Visible = false;
            inputNumber.Text = "用户名";
            inputNumber.ForeColor = Color.Silver;
            inputPassword.Text = "密码";
            inputPassword.ForeColor = Color.Silver;
            inputPassword.UseSystemPasswordChar = false;
            UIDlabel.Visible = false;
            UIDpoint.Visible = false;
            login.Visible = true;

            enRoll.Visible = true;
            returnButton.Visible = false;
            loginButton2.Visible = false;
            loginPoint.Visible = false;
        }
        /// <summary>
        ///登录检查
        /// </summary>
        /// <returns></returns>
        private bool checkUsers()
        {
            string directory_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Cytus2/Users";
            DataSet tabel = new DataSet();
            tabel.ReadXml(directory_Path + "/Users.xml");
            foreach (DataRow dataRow in tabel.Tables[0].Rows)
            {
                if (dataRow[0].ToString() == inputNumber.Text && dataRow[1].ToString() == inputPassword.Text)
                {
                    
                    return true;
                }
            }
            return false;
        }
        private string checkUID()
        {
            string directory_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Cytus2/Users";
            DataSet tabel = new DataSet();
            tabel.ReadXml(directory_Path + "/Users.xml");
            foreach (DataRow dataRow in tabel.Tables[0].Rows)
            {
                if (dataRow[0].ToString() == inputNumber.Text && dataRow[1].ToString() == inputPassword.Text)
                {
                    return dataRow[2].ToString();
                }
            }
            return "";
        }
        private void EnRoll_MouseClick(object sender, MouseEventArgs e)//登录按钮
        {
            string directory_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Cytus2/Users";
            if (File.Exists(directory_Path + "/Users.xml"))
            {
                bool FxxkYou = checkUsers();
                if (FxxkYou==true)//如果输入密码正确
                {
                    userClass.publicUsername = inputNumber.Text;
                    userClass.publicUserpassword = inputPassword.Text;
                    userClass.publicUserUID = checkUID();
                    WarningFalse.Visible = false;
                    PointOut.Visible = true;
                    inputNumber.Visible = false;
                    inputPassword.Visible = false;
                    showPassword.Visible = false;
                    login.Visible = false;
                    enRoll.Visible = false;

                    PointOut.Top -= 130;
                    PointOut.Text = "正在登录，这可能需要一点时间。\r\n请坐和放宽。";
                    timerSwitchLabel.Start();
                    timerSwitchForm.Start();
                    
                }
                else
                {
                    WarningFalse.Visible = true;
                    timerWate.Start();
                }
                
            }
            else
            {
                PointOut.Visible = true;
                PointOut.Text = "此电脑上没有账户，请创建一个。";
            }
        }

        private void ResignButton2_MouseClick(object sender, MouseEventArgs e)
        {
            resignSuccess form1 = new resignSuccess();
            
           
            string directory_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Cytus2/Users";

            if (Directory.Exists(directory_Path))//判断路径是否存在，该文件夹用于存放账号信息
            {
                if (File.Exists(directory_Path + "/Users.xml"))//路径存在且文件存在
                {
                    if (inputNumber.Text != "用户名" && inputPassword.Text != "密码")//
                    {
                        loginPoint.Visible = false;
                        Success.Visible = true;
                        CreatXML User = new CreatXML();
                        string username = inputNumber.Text;
                        string password = inputPassword.Text;
                        Success.Visible = true;
                        string UID = UIDpoint.Text;
                        User.addNode(username, password, UID);
                        timerSwitch2.Start();
                    }
                    else
                    {
                        loginPoint.Visible = false;
                        loginWarning3.Visible = true;
                        timerSwitch.Start();
                    }
                }
                else
                {
                    CreatXML User = new CreatXML();
                    if (inputNumber.Text != "用户名" && inputPassword.Text != "密码")
                    {
                        loginPoint.Visible = false;
                        Success.Visible = true;
                        string username = inputNumber.Text;
                        string password = inputPassword.Text;
                        string UID = UIDpoint.Text;
                        User.CreateXmlFile(username, password, UID);
                        timerSwitch2.Start();
                    }
                    else
                    {
                        loginPoint.Visible = false;
                        loginWarning3.Visible = true;
                        timerSwitch.Start();
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(directory_Path);
                CreatXML User = new CreatXML();
                if(inputNumber.Text!="用户名"&&inputPassword.Text!="密码")
                {
                    loginPoint.Visible = false;
                    Success.Visible = true;
                    string username = inputNumber.Text;
                    string password = inputPassword.Text;
                    string UID = UIDpoint.Text;
                    User.CreateXmlFile(username,password,UID);
                    timerSwitch2.Start();
                }
                else
                {
                    loginPoint.Visible = false;
                    loginWarning3.Visible = true;
                    timerSwitch.Start();
                }

            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)//此函数是所有按键被按下时的相应函数

        {

            if (e.KeyCode == Keys.Enter)//判断回车键

            {
                //this.EnRoll_MouseClick(sender);//触发按钮事件
            }

        }
        private void ShowPassword_MouseClick(object sender, MouseEventArgs e)//展示密码
        {
            if(inputPassword.UseSystemPasswordChar==true)
            {
                inputPassword.UseSystemPasswordChar = false;
            }
            else if(inputPassword.UseSystemPasswordChar == false && inputPassword.Text != "密码")
            {
                inputPassword.UseSystemPasswordChar = true;
            }
        }

        private void TimerSwitch_Tick(object sender, EventArgs e)
        {
            WarningFalse.Visible = false;
            loginWarning3.Visible = false;
            loginPoint.Visible = true;
            timerSwitch.Stop();

        }

        private void TimerSwitch2_Tick(object sender, EventArgs e)
        {
            Success.Visible = false;
            inputNumber.Text = "用户名";
            inputNumber.ForeColor = Color.Silver;
            inputPassword.Text = "密码";
            inputPassword.ForeColor = Color.Silver;
            inputPassword.UseSystemPasswordChar = false;
            UIDlabel.Visible = false;
            UIDpoint.Visible = false;
            login.Visible = true;
            WarningFalse.Visible = true;
            enRoll.Visible = true;
            returnButton.Visible = false;
            loginButton2.Visible = false;
            loginPoint.Visible = false;
            WarningFalse.Visible = false;
            timerSwitch2.Stop();
        }

        private void TimerWate_Tick(object sender, EventArgs e)
        {
            WarningFalse.Visible = false;
            timerWate.Stop();
        }

        private void TimerSwitchLabel_Tick(object sender, EventArgs e)//切换提示
        {
            PointOut.Text = "登录成功！";
            timerSwitchLabel.Stop();
        }

        private void TimerSwitchForm_Tick(object sender, EventArgs e)//切换窗口
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
            timerSwitchForm.Stop();
        }

        private void ShowPassword_MouseClick_1(object sender, MouseEventArgs e)
        {
            if(inputPassword.UseSystemPasswordChar==true)
            {
                inputPassword.UseSystemPasswordChar = false;
            }
            else
            {
                inputPassword.UseSystemPasswordChar = true;
            }
            
        }

       

        private void InputPassword_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.EnRoll_KeyPress(sender, e);
            }
        }

        private void EnRoll_KeyPress(object sender, KeyPressEventArgs e)
        {
            string directory_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Cytus2/Users";
            if (File.Exists(directory_Path + "/Users.xml"))
            {
                bool FxxkYou = checkUsers();
                if (FxxkYou==true)//如果输入密码正确
                {
                    userClass.publicUsername = inputNumber.Text;
                    userClass.publicUserpassword = inputPassword.Text;
                    userClass.publicUserUID = checkUID();
                    WarningFalse.Visible = false;
                    PointOut.Visible = true;
                    inputNumber.Visible = false;
                    inputPassword.Visible = false;
                    showPassword.Visible = false;
                    login.Visible = false;
                    enRoll.Visible = false;

                    PointOut.Top -= 130;
                    PointOut.Text = "正在登录，这可能需要一点时间。\r\n请坐和放宽。";
                    timerSwitchLabel.Start();
                    timerSwitchForm.Start();
                    
                }
                else
                {
                    WarningFalse.Visible = true;
                    timerWate.Start();
                }
                
            }
            else
            {
                PointOut.Visible = true;
                PointOut.Text = "此电脑上没有账户，请创建一个。";
            }
        }
    }
    class CreatXML
    {
        public void CreateXmlFile(string username,string password,string uid)
        {

            XmlDocument xmlDoc = new XmlDocument();
            //创建类型声明节点    
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(node);
            //创建根节点    
            XmlNode root = xmlDoc.CreateElement("Users");
            xmlDoc.AppendChild(root);

            XmlNode user1 = xmlDoc.CreateNode(XmlNodeType.Element, "User", null);
            CreateNode(xmlDoc, user1, "USERNAME", username);
            CreateNode(xmlDoc, user1, "PASSWORD", password);
            CreateNode(xmlDoc, user1, "UID", uid);
            root.AppendChild(user1);

            try
            {
                string directory_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Cytus2/Users"; 
                xmlDoc.Save(directory_Path + "/Users.xml");
            }
            catch (Exception e)
            {
                //显示错误信息    

                Console.WriteLine(e.Message);
            }
            //Console.ReadLine();    

        }

        /// <summary>      
        /// 创建节点      
        /// </summary>      
        /// <param name="xmldoc"></param>  xml文档    
        /// <param name="parentnode"></param>父节点      
        /// <param name="name"></param>  节点名    
        /// <param name="value"></param>  节点值    
        ///     
        public void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        {

            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }
        public void addNode(string username, string password, string uid)
        {
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string directory_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Cytus2/Users";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(directory_Path + "/Users.xml");
            XmlNode root = xmlDoc.SelectSingleNode("Users");
            XmlNode newNode = xmlDoc.CreateNode(XmlNodeType.Element, "User", null);
            CreateNode(xmlDoc, newNode, "USERNAME", username);
            CreateNode(xmlDoc, newNode, "PASSWORD", password);
            CreateNode(xmlDoc, newNode, "UID", uid);
            root.AppendChild(newNode);
            xmlDoc.Save(directory_Path + "/Users.xml");
        }
    }

}
