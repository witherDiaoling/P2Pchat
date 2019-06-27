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
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Net.Sockets;
using System.Threading;
using static QQ.TCPsendfile;

namespace QQ
{
    
    public partial class Form2 : Form
    {
        //public delegate DG_TwoParaAndNoReturn<T,T>(T t1, T t2);
        public static string OKorNO = "";
        //传输文件路径
        public string filePath = "";
        //文件长度
        public long  fileLength = 0;
        //文件块数
        public long fileSum = 0;
        //传输的文件名字
        public string fileName = "";
        /// <summary>
        /// 接收的文件名字
        /// </summary>
        public string ReceiveFileName = "";
        /// <summary>
        /// 保存文件路径
        /// </summary>
        public string saveFilePath = "";
        public string NowFriendUID = "";
        public string NowFriendIP = "";
        public string NowFriendNAME = "";
        public static Form2 form2;
        public string FriendIP="";
        public Color panelBack = Color.FromArgb(45, 119, 161);
        public Color nowPanelBack = Color.FromArgb(49,102,181);
        private List<Thread> ThreadsList;
        static int Nums = 0;
        public static Panel[] panels;
        /// <summary>
        /// 在线好友table
        /// </summary>
        public static DataTable friendTable=new DataTable();
        /// <summary>
        /// 创建好友table
        /// </summary>
        /// <param name="cc"></param>
        public void CreateFriendTable()
        {
            friendTable.Columns.Add("friendUID", typeof(string));
            friendTable.Columns.Add("friendName", typeof(string));
            friendTable.Columns.Add("friendIP", typeof(string));

            friendTable.RowDeleted += new DataRowChangeEventHandler(UpdateFriendList);
            friendTable.RowChanged += new DataRowChangeEventHandler(UpdateFriendList);

        }
        /// <summary>
        /// 修改好友table
        /// </summary>
        /// <param name="cc"></param>
        public void ChangeFriendTable(string userName,string userUID,string userIP,string UPorDOWN)
        {
            //textBox1.AppendText("ChangeFriendTable,55\r\n");
            //MessageBox.Show("Fuck you!!!");
            if(UPorDOWN=="UP")
            {
                if (FindFriend(userName,userUID,userIP,UPorDOWN) == false)//如果好友列表中没有此人，则添加
                {
                    DataRow dataRow = friendTable.NewRow();
                    dataRow["friendUID"] = userUID;
                    dataRow["friendName"] = userName;
                    dataRow["friendIP"] = userIP;
                    friendTable.Rows.Add(dataRow);
                }
               
            }
            else
            {
                
                int count = friendTable.Rows.Count;
                //debugDisplay(count.ToString());
                for (int i = 0; i < count; i++)
                {
                    if (friendTable.Rows[i][0].ToString() == userUID)
                    {
                        //textBox1.AppendText("delet,55\r\n");
                        friendTable.Rows[i].Delete();
                    }
                }
               
                
            }
        }
        private delegate void DG_UpdateFriendList(object sender, DataRowChangeEventArgs e);
        /// <summary>
        /// 更新好友列表
        /// </summary>
        public void UpdateFriendList(object sender, DataRowChangeEventArgs e)
        {
            //textBox1.AppendText("UpdateFriendList,92\r\n");
            if (form2.friendsList.InvokeRequired == false)
            {
                int count = friendTable.Rows.Count;
                if (count > 0)
                {
                    RefreshFriendlist();
                    for (int i = 0; i < count; i++)
                    {
                        //textBox1.AppendText("changePanel,103\r\n");
                        CreatePanel(friendTable.Rows[i][1].ToString(), friendTable.Rows[i][0].ToString(), friendTable.Rows[i][2].ToString(), i);
                       
                    }
                   
                }
                if (count == 0)
                {
                    foreach (Control ctrl in friendsList.Controls)
                    {
                        if (ctrl.Name != "NoListPicture" && ctrl.Name != "NoListLabel")
                        {
                            friendsList.Controls.Remove(ctrl);
                        }
                    }
                    NoListPicture.Visible = true;
                    NoListLabel.Visible = true;
                }
            }
            else
            {
                DG_UpdateFriendList dG_UpdateFriendList = new DG_UpdateFriendList(UpdateFriendList);
                form2.friendsList.Invoke(dG_UpdateFriendList,sender,e);
            }
            
            

        }
        private delegate void DG_RefreshFriendlist();
        /// <summary>
        /// 刷新界面中的好友列表
        /// </summary>
        public void RefreshFriendlist()
        {
            if (form2.friendsList.InvokeRequired==false)
            {
                NoListLabel.Parent = this;
                NoListPicture.Parent = this;
                friendsList.Controls.Clear();
                NoListLabel.Parent = friendsList;
                NoListPicture.Parent = friendsList;
            }
            else
            {
                DG_RefreshFriendlist dG_RefreshFriendlist = new DG_RefreshFriendlist(RefreshFriendlist);
                form2.friendsList.Invoke(dG_RefreshFriendlist);
            }

        }
        /// <summary>
        /// 在在线好友table中查找此好友
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userUID"></param>
        /// <param name="userIP"></param>
        /// <param name="UPorDOWN"></param>
        public bool FindFriend(string userName, string userUID, string userIP, string UPorDOWN)
        {
            if(UPorDOWN=="UP")
            {
                int count = friendTable.Rows.Count;
                for (int i = 0; i < count; i++)//遍历table，找到此好友
                {
                    if (friendTable.Rows[0][i].ToString() == userUID)
                    {
                        return true;
                    }
                }
                return false;
            }
            else//如果是下线广播，则好友列表中必定有此好友，无需查找
            {
                return true;
            }
            
        }
        public static void SetDouble(Control cc)
        {
            cc.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(cc, true, null);
        }
        /// <summary>
        /// 广播本机上下线
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userUID"></param>
        /// <param name="userIP"></param>
        public  void LineBroadcast(string userName, string userUID, string userIP, string UPorDN,string needreply)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Broadcast, 10086);//规定本操作执行的端口，规定用于广播的IP地址
            IPEndPoint iepHost = new IPEndPoint(IPAddress.Parse(userIP), 10086);//
            string hostname = Dns.GetHostName();
            byte[] data = Encoding.UTF8.GetBytes(userIP + "," + userUID + "!" + UPorDN + "?" + userName+"@"+needreply);
            socket.Bind(iepHost); //套接字绑定本机ip和端口                                                                                                                                              //需要绑定一块活动的网卡，不然无法发送信息
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            socket.SendTo(data, ipe);
            socket.Shutdown(SocketShutdown.Send);//发送完数据后关闭socket
            socket.Close();
        }
        /// <summary>
        /// 向刚上线的好友定点传输
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userUID"></param>
        /// <param name="userIP"></param>
        public void LineSend(string userName, string userUID, string userIP,string friendIP)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(friendIP), 10086);//规定本操作执行的端口，规定用于广播的IP地址
            IPEndPoint iepHost = new IPEndPoint(IPAddress.Parse(userIP), 10086);//
            string hostname = Dns.GetHostName();
            byte[] data = Encoding.UTF8.GetBytes(userIP + "," + userUID + "!" + "UP" + "?" + userName+"@"+"DONTREPLY");
            socket.Bind(iepHost); //套接字绑定本机ip和端口                                                                                                                                              //需要绑定一块活动的网卡，不然无法发送信息
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            socket.SendTo(data, ipe);
            socket.Shutdown(SocketShutdown.Send);//发送完数据后关闭socket
            socket.Close();
        }
        //页面控件关闭代码
        public void ClosechatRichtextbox()
        {
            if (chatRichTextBox.InvokeRequired == false)
            {
                chatRichTextBox.Visible = false;
            }
            else
            {
                Action action = new Action(ClosechatRichtextbox);
                chatRichTextBox.Invoke(action);
            }
        }
        public void CloseinputRichtextbox()
        {
            if (inputRichTextbox.InvokeRequired == false)
            {
                inputRichTextbox.Visible = false;
            }
            else
            {
                Action action = new Action(CloseinputRichtextbox);
                inputRichTextbox.Invoke(action);
            }
        }
        public void ClosesendChatButton()
        {
            if (sendChatButton.InvokeRequired == false)
            {
                sendChatButton.Visible = false;
            }
            else
            {
                Action action = new Action(ClosesendChatButton);
                sendChatButton.Invoke(action);
            }
        }
        public void showfriendDOWNlabel()
        {
            if (friendDOWNlabel.InvokeRequired == false)
            {
                friendDOWNlabel.Visible = true;
            }
            else
            {
                Action action = new Action(showfriendDOWNlabel);
                friendDOWNlabel.Invoke(action);
            }
        }
        public void showtalkBackground()
        {
            if (talkBackground.InvokeRequired == false)
            {
                talkBackground.Visible = true;
            }
            else
            {
                Action action = new Action(showtalkBackground);
                talkBackground.Invoke(action);
            }
        }
        public void ChangeshowFriendName()
        {
            if (showFriendName.InvokeRequired == false)
            {
                showFriendName.Text="";
                showFriendName.BringToFront();
            }
            else
            {
                Action action = new Action(ChangeshowFriendName);
                showFriendName.Invoke(action);
            }
        }
        public void ClosefriendDOWNlabel()
        {
            if (friendDOWNlabel.InvokeRequired == false)
            {
                timershowDOWN.Start();
            }
            else
            {
                Action action = new Action(ClosefriendDOWNlabel);
                friendDOWNlabel.Invoke(action);
            }
        }
        public void ClosesendFiles()
        {
            if (sendFiles.InvokeRequired == false)
            {
                sendFiles.Visible = false;
            }
            else
            {
                Action action = new Action(ClosesendFiles);
                sendFiles.Invoke(action);
            }
        }
        public void Closelabel2()
        {
            if (label2.InvokeRequired == false)
            {
                label2.Visible = false;
            }
            else
            {
                Action action = new Action(Closelabel2);
                label2.Invoke(action);
            }
        }
        public void CloseFilesend()
        {
            if (form2.InvokeRequired == false)
            {
                form2.Size = new Size(1113, 703);
            }
            else
            {
                Action action = new Action(CloseFilesend);
                form2.Invoke(action);
            }
        }
        public void CloseRequestButton()
        {
            if (requestButton.InvokeRequired == false)
            {
                requestButton.Visible = false;
            }
            else
            {
                Action action = new Action(CloseRequestButton);
                requestButton.Invoke(action);
            }
        }
        public void CloseconformSend()
        {
            if (conformSend.InvokeRequired == false)
            {
                conformSend.Visible = false;
            }
            else
            {
                Action action = new Action(CloseconformSend);
                conformSend.Invoke(action);
            }
        }
        public void ClosefilePathTextbox()
        {
            if (filePathTextbox.InvokeRequired == false)
            {
                filePathTextbox.Text = "";

            }
            else
            {
                Action action = new Action(ClosefilePathTextbox);
                filePathTextbox.Invoke(action);
            }
        }
        //控件切换代码
        public void ShowRequestOKorNOlabel()
        {

            if (RequestOKorNOlabel.InvokeRequired == false)
            {
                RequestOKorNOlabel.Visible = true;
            }
            else
            {
                Action action = new Action(ShowRequestOKorNOlabel);
                RequestOKorNOlabel.Invoke(action);
            }
        }
        public void CloseRequestOKorNOlabel()
        {

            if (RequestOKorNOlabel.InvokeRequired == false)
            {
                RequestOKorNOlabel.Visible = false;

            }
            else
            {
                Action action = new Action(CloseRequestOKorNOlabel);
                RequestOKorNOlabel.Invoke(action);
            }
        }
        public void ShowOKbutton()
        {

            if (OKbutton.InvokeRequired == false)
            {
                OKbutton.Visible = true;
            }
            else
            {
                Action action = new Action(ShowOKbutton);
                OKbutton.Invoke(action);
            }
        }
        public void CloseOKbutton()
        {

            if (OKbutton.InvokeRequired == false)
            {
                OKbutton.Visible = false;
            }
            else
            {
                Action action = new Action(CloseOKbutton);
                OKbutton.Invoke(action);
            }
        }
        public void ShowNObutton()
        {
            if (NObutton.InvokeRequired == false)
            {
                NObutton.Visible = true;
            }
            else
            {
                Action action = new Action(ShowNObutton);
                NObutton.Invoke(action);
            }
        }
        public void CloseNObutton()
        {
            if (NObutton.InvokeRequired == false)
            {
                NObutton.Visible = false;
            }
            else
            {
                Action action = new Action(CloseNObutton);
                NObutton.Invoke(action);
            }
        }
        public void ShowRefuselabel()
        {
            if (showRefuselabel.InvokeRequired == false)
            {
                showRefuselabel.Text = "对方拒绝了你的请求";
                showRefuselabel.Visible = true;
                timerHideRefuselabel.Start();
            }
            else
            {
                Action action = new Action(ShowRefuselabel);
                showRefuselabel.Invoke(action);
            }
        }
        public void ShowRefuselabel2()
        {
            if (showRefuselabel.InvokeRequired == false)
            {
                showRefuselabel.Text = "对方接收了你的请求，请选择文件";
                showRefuselabel.Visible = true;
            }
            else
            {
                Action action = new Action(ShowRefuselabel2);
                showRefuselabel.Invoke(action);
            }
        }
        public void ShowRefuselabel3()
        {
            if (showRefuselabel.InvokeRequired == false)
            {
                showRefuselabel.Text = "等待对方选择文件";
                showRefuselabel.Visible = true;
            }
            else
            {
                Action action = new Action(ShowRefuselabel3);
                showRefuselabel.Invoke(action);
            }
        }
        public void ShowRefuselabel4()
        {
            if (showRefuselabel.InvokeRequired == false)
            {
                showRefuselabel.Text = "正在传输";
                showRefuselabel.Visible = true;
            }
            else
            {
                Action action = new Action(ShowRefuselabel4);
                showRefuselabel.Invoke(action);
            }
        }
        public void ShowselectFIle()
        {
            if (selectFile.InvokeRequired == false)
            {
                selectFile.Visible = true;

            }
            else
            {
                Action action = new Action(ShowselectFIle);
                selectFile.Invoke(action);
            }
        }
        public void ShowrequestButton()
        {
            if (requestButton.InvokeRequired == false)
            {
                requestButton.Visible = true;

            }
            else
            {
                Action action = new Action(ShowrequestButton);
                requestButton.Invoke(action);
            }
        }
        public void CloserequestButton()
        {
            if (requestButton.InvokeRequired == false)
            {
                requestButton.Visible = false;

            }
            else
            {
                Action action = new Action(CloserequestButton);
                requestButton.Invoke(action);
            }
        }
        
        /// <summary>
        /// UDP监听
        /// </summary>
        public  void ListenBroadcast()
        {
            IPEndPoint ipEP1 = new IPEndPoint(IPAddress.Any, 10086);   //IPAddress.any即为所有活动主机
            UdpClient udpReceive = new UdpClient(ipEP1);
            while (true)
            {
                try
                {
                    byte[] bytRecv = udpReceive.Receive(ref ipEP1);//接收远程主机传来的信息
                    string message = Encoding.UTF8.GetString(bytRecv, 0, bytRecv.Length);
                    string IP = message.Substring(0, message.IndexOf(',')); //远程主机的IP
                    string UID = message.Substring(message.IndexOf(',') + 1, message.IndexOf('!') - message.IndexOf(',') - 1);   //远程主机的上下线状态字
                    string UPorDN = message.Substring(message.IndexOf('!') + 1, message.IndexOf('?') - message.IndexOf('!')-1);
                    string Name = message.Substring(message.IndexOf('?') + 1, message.IndexOf('@') - message.IndexOf('?') - 1); 
                    string needReply = message.Substring(message.IndexOf('@') + 1);
                    if (IP==userClass.publicIP)
                    {
                        
                    }
                    else
                    {
                       // textBox1.AppendText("ListenBroadcast,216\r\n");
                        if (needReply=="NEEDREPLY")//需要回复，说明是上线广播
                        {
                            //如果是上线广播，接收到这个广播之后，需要给对方也发送一个广播，证明自己在线
                            LineSend(userClass.publicUsername, userClass.publicUserUID, userClass.publicIP, IP);

                        }
                        ChangeFriendTable(Name, UID, IP, UPorDN);
                        if (UPorDN=="DN")
                        {
                            if (UID==NowFriendUID)
                            {
                                ClosechatRichtextbox();
                                CloseinputRichtextbox();
                                ClosesendChatButton();
                                showfriendDOWNlabel();
                                showtalkBackground();
                                ChangeshowFriendName();
                                ClosesendFiles();
                                ClosefriendDOWNlabel();
                                Closelabel2();
                                CloseFilesend();
                                CloseRequestButton();
                                CloseconformSend();
                                ClosefilePathTextbox();
                                CloseRequestOKorNOlabel();
                                CloseNObutton();
                                CloseOKbutton();
                            }
                        }
                        int count = FriendListpanelCount();
                        if (count != 0)
                        {
                            NoListPicture.Visible = false;
                            NoListLabel.Visible = false;
                        }
                    }
                   
                }
                catch
                {
                    
                }
            }
        }
        /// <summary>
        /// 设置文本对齐位置
        /// </summary>
        /// <param name="message"></param>
        /// <param name="horizontalAlignment"></param>
        public void FormatMessage(string message,HorizontalAlignment horizontalAlignment)
        {
            if (chatRichTextBox.InvokeRequired == false)
            {
                DateTime t = DateTime.Now;
                //获取加入的文本长度
                int BeforeLength = chatRichTextBox.TextLength;
                chatRichTextBox.AppendText(t.ToString(" HH : mm : ss" + "\r\n"));
                chatRichTextBox.AppendText(message + "\r\n");
                int AfterLength = chatRichTextBox.TextLength;

                chatRichTextBox.Select(BeforeLength, AfterLength - BeforeLength);
                chatRichTextBox.SelectionAlignment = horizontalAlignment;
                chatRichTextBox.Select(0, 0);
            }
            else
            {
                Action<string, HorizontalAlignment> action = new Action<string, HorizontalAlignment>(FormatMessage);
                chatRichTextBox.Invoke(action,message,horizontalAlignment);
            }
        }
        public void RefreshInput()
        {
            if (chatRichTextBox.InvokeRequired == false)
            {
                inputRichTextbox.Text = "";
            }
            else
            {
                Action action = new Action(Refreshinformation);
                inputRichTextbox.Invoke(action);
            }
        }
        /// <summary>
        /// 保存聊天记录
        /// </summary>
        /// <param name="message"></param>
        public void SaveRichtextbox()
        {
            if (chatRichTextBox.InvokeRequired == false)
            {
                string directory_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Cytus2/Chatrecord";

                if (Directory.Exists(directory_Path))//判断路径是否存在，该文件夹用于存放账号信息
                {
                    chatRichTextBox.SaveFile(directory_Path + "/" + NowFriendUID + ".RTF");
                }
                else
                {
                    Directory.CreateDirectory(directory_Path);
                    chatRichTextBox.SaveFile(directory_Path + "/" + NowFriendUID + ".RTF");//自动创建文件并保存
                }
            }
            else
            {
                Action action = new Action(SaveRichtextbox);
                chatRichTextBox.Invoke(action);
            }
           
        }
        /// <summary>
        /// 读取聊天记录
        /// </summary>
        public void LodeRichtextbox()
        {
           
            if (chatRichTextBox.InvokeRequired == false)
            {
                string directory_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Cytus2/Chatrecord";
                if (Directory.Exists(directory_Path))
                {
                    if (File.Exists(directory_Path + "/" + NowFriendUID + ".RTF"))//路径存在且文件存在
                    {
                        chatRichTextBox.LoadFile(directory_Path + "/" + NowFriendUID + ".RTF");
                    }
                }
            }
            else
            {
                Action action = new Action(LodeRichtextbox);
                chatRichTextBox.Invoke(action);
            }
        }
        /// <summary>
        /// 保存未读聊天记录
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="message"></param>
        public void SaveallRecord(string UID,string message)
        {
            if(SaveAllrichTextBox.InvokeRequired==false)
            {
                SaveAllrichTextBox.Text = "";
                string directory_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Cytus2/Chatrecord";
                if (Directory.Exists(directory_Path))
                {
                    if (File.Exists(directory_Path + "/" + UID + ".RTF"))//路径存在且文件存在
                    {
                        SaveAllrichTextBox.LoadFile(directory_Path + "/" + UID + ".RTF");
                        DateTime t = DateTime.Now;
                        //获取加入的文本长度
                        int BeforeLength = chatRichTextBox.TextLength;
                        SaveAllrichTextBox.AppendText(t.ToString(" HH : mm : ss" + "\r\n"));
                        SaveAllrichTextBox.AppendText(message + "\r\n");
                        int AfterLength = chatRichTextBox.TextLength;

                        SaveAllrichTextBox.Select(BeforeLength, AfterLength - BeforeLength);
                        SaveAllrichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                        SaveAllrichTextBox.Select(0, 0);
                        SaveAllrichTextBox.SaveFile(directory_Path + "/" + UID + ".RTF");
                    }
                    else
                    {
                        //先创建文件，再读取修改
                        SaveAllrichTextBox.SaveFile(directory_Path + "/" + UID + ".RTF");
                        SaveAllrichTextBox.LoadFile(directory_Path + "/" + UID + ".RTF");
                        DateTime t = DateTime.Now;
                        //获取加入的文本长度
                        int BeforeLength = chatRichTextBox.TextLength;
                        SaveAllrichTextBox.AppendText(t.ToString(" HH : mm : ss" + "\r\n"));
                        SaveAllrichTextBox.AppendText(message + "\r\n");
                        int AfterLength = chatRichTextBox.TextLength;

                        SaveAllrichTextBox.Select(BeforeLength, AfterLength - BeforeLength);
                        SaveAllrichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                        SaveAllrichTextBox.Select(0, 0);
                        SaveAllrichTextBox.SaveFile(directory_Path + "/" + UID + ".RTF");
                    }
                }
                else
                {
                    Directory.CreateDirectory(directory_Path);
                    SaveAllrichTextBox.SaveFile(directory_Path + "/" + UID + ".RTF");
                    SaveAllrichTextBox.LoadFile(directory_Path + "/" + UID + ".RTF");
                    DateTime t = DateTime.Now;
                    //获取加入的文本长度
                    int BeforeLength = chatRichTextBox.TextLength;
                    SaveAllrichTextBox.AppendText(t.ToString(" HH : mm : ss" + "\r\n"));
                    SaveAllrichTextBox.AppendText(message + "\r\n");
                    int AfterLength = chatRichTextBox.TextLength;

                    SaveAllrichTextBox.Select(BeforeLength, AfterLength - BeforeLength);
                    SaveAllrichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                    SaveAllrichTextBox.Select(0, 0);
                    SaveAllrichTextBox.SaveFile(directory_Path + "/" + UID + ".RTF");
                }
            }
            else
            {
                Action<string, string> action = new Action<string,string>(SaveallRecord);
                SaveAllrichTextBox.Invoke(action,UID,message);
            }
        }
        /// <summary>
        /// 显示哪个人有未读消息
        /// </summary>
        public void ShownoRead(string UID)
        {
            if (friendsList.InvokeRequired == false)
            {
                foreach (Control ctrl in friendsList.Controls)
                {
                    if (ctrl is Panel)
                    {

                        foreach (Control control in ctrl.Controls)            //遍历所有控件，直到找到所需要的子控件
                        {
                            if (control.Name== "labelUID")//找到匹配UID的panel
                            {
                                if (control.Text == UID)
                                {
                                    foreach (Control control1 in ctrl.Controls)          //找到noRead子控件，显示未读
                                    {
                                        if (control1.Name == "noRead")
                                        {
                                            control1.Visible = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {

                Action<string> action = new Action<string>(ShownoRead);
                friendsList.Invoke(action, UID);
            }
        }
        /// <summary>
        /// TCP监听程序，并接收信息
        /// </summary>
        private void TCPlisten()
        {

            Socket socketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketListen.Bind(new IPEndPoint(userClass.IPv4Address,54321));//与对方连接
            socketListen.Listen(10);
            while (true)
            {
                try
                {
                    Socket socketWrite = socketListen.Accept();
                    NetworkStream networkStream = new NetworkStream(socketWrite);
                    int length = socketWrite.ReceiveBufferSize;
                    byte[] buffer = new byte[length];
                    //读取流中的数据
                    networkStream.Read(buffer, 0, length);
                    string Allmessage = Encoding.UTF8.GetString(buffer).Trim('\0');
                    string UID = Allmessage.Substring(0, 17);
                    string message = Allmessage.Substring(17);
                    //FormatMessage(message, HorizontalAlignment.Left);
                    //先保存聊天记录
                    SaveallRecord(UID, message);
                    //显示未读
                    if (UID!=NowFriendUID)
                    {
                        ShownoRead(UID);
                    }
                    
                    //再读取聊天记录
                    if (UID==NowFriendUID)//如果目前聊天的人是发来信息的人
                    {
                        LodeRichtextbox();
                    }

                }
                catch (Exception e)
                {

                    MessageBox.Show(e.ToString());
                }
                
            }


        }
        /// <summary>
        /// TCP连接请求,并发送信息
        /// </summary>
        private void SendTCP(string friendIP,string message)
        {
            try
            {
                Socket socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(userClass.publicIP), 54321);
                //socketSend.Bind(iPEndPoint);
                socketSend.Connect(IPAddress.Parse(friendIP), 54321);
                NetworkStream networkstream = new NetworkStream(socketSend);
                //int length = message.Length;
                byte[] buffer = Encoding.UTF8.GetBytes(userClass.publicUserUID+message);
                networkstream.Write(buffer, 0, buffer.Length);
                networkstream.Dispose();
                networkstream.Close();
                socketSend.Close();
                FormatMessage(message, HorizontalAlignment.Right);
                SaveRichtextbox();
                RefreshInput();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
       
        /// <summary>
        /// 监听文件传输请求
        /// </summary>
        public void ListenRequest()
        {
            Socket socketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketListen.Bind(new IPEndPoint(userClass.IPv4Address, 54323));//与对方连接
            socketListen.Listen(10);
            while (true)
            {
                try
                {
                    Socket socketWrite = socketListen.Accept();
                    NetworkStream networkStream = new NetworkStream(socketWrite);
                    int length = socketWrite.ReceiveBufferSize;
                    byte[] buffer = new byte[length];
                    //读取流中的数据
                    networkStream.Read(buffer, 0, length);
                    string message = Encoding.UTF8.GetString(buffer).Trim('\0');
                    if (message=="Request")
                    {
                        CloseRequestButton();
                        ShowRequestOKorNOlabel();
                        ShowOKbutton();
                        ShowNObutton();
                    }
                    if (message=="OK")
                    {

                        CloseRequestButton();
                        ShowRefuselabel2();
                        ShowselectFIle();

                    }
                    if(message=="NO")
                    {
                        ShowRefuselabel();
                        ShowrequestButton();
                    }
                    if (message.Length>8)
                    {

                        string information = message.Substring(0, message.IndexOf('?'));
                        if (information== "Information")
                        {
                            ShowRefuselabel4();
                            string FILELENGTH= message.Substring(message.IndexOf("?")+1, message.IndexOf("!")- message.IndexOf("?")-1);
                            string SUM= message.Substring(message.IndexOf("!")+1,message.IndexOf("/")-message.IndexOf("!") -1);
                            ReceiveFileName = message.Substring(message.IndexOf("/") + 1);
                            fileLength = long.Parse(FILELENGTH);
                            fileSum = long.Parse(SUM);
                            ReceiveFile receiveFile = new ReceiveFile();
                            MessageBox.Show(fileName.ToString() + " " + fileLength + " " + fileSum);
                            receiveFile.ListenReceiveFile(fileLength, fileSum, saveFilePath,ReceiveFileName);
                        }
                    }
                   

                }
                catch (Exception e)
                {

                    MessageBox.Show(e.ToString());

                }
            }
               

        }
        public Form2()
        {
            InitializeComponent();
            form2 = this;
            ThreadsList = new List<Thread>();
           
        }
        void AllareMySon()
        {
            head.Parent = buttonBack;
            close1.Parent = form2;
            Friends.Parent = buttonBack;
            talkList.Parent = buttonBack;
            
            openButtenList.Parent = buttonBack;
            NoListLabel.Parent = friendsList;
            NoListPicture.Parent = friendsList;
        }
        private void Form2_Load(object sender, EventArgs e)//窗口加载执行操作
        {
            Thread UDPListenThread = new Thread(ListenBroadcast);
            UDPListenThread.IsBackground = true;
            Thread TCPListenthread = new Thread(TCPlisten);
            TCPListenthread.IsBackground = true;
            Thread listenRequest = new Thread(ListenRequest);
            listenRequest.IsBackground = true;
            ThreadsList.Add(UDPListenThread); //将新建的线程加入到线程队列中，以便在窗体结束时关闭所有的线程
            ThreadsList.Add(TCPListenthread);
            ThreadsList.Add(listenRequest);
            UDPListenThread.Start();
            TCPListenthread.Start();
            listenRequest.Start();
            
            
            close1.BringToFront();
            //设置本机用户信息
            setUser();
            //设置控件父子关系
            AllareMySon();
            //创建好友表
            CreateFriendTable();
            //上线广播
            LineBroadcast(userClass.publicUsername, userClass.publicUserUID, userClass.publicIP, "UP","NEEDREPLY");
        }

        public void setUser()
        {
            userName.Text = userClass.publicUsername;
            UIDtext.Text = userClass.publicUserUID;
            IPtext.Text = userClass.publicIP;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Button1_Click(object sender, EventArgs e)
        {
            LineBroadcast(userClass.publicUsername, userClass.publicUserUID, userClass.publicIP, "DN","DONTREPLY");
            Environment.Exit(0);
        }
        //以下为窗口拖动代码
        private void BackGround_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        

        private void FriendsList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ButtonBack_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
               ReleaseCapture();
               SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void TalkBackground1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        
        public int FriendListpanelCount()//判断好友列表中是否有panel
        {
            int number = -2;
            foreach(Control ctrl in friendsList.Controls)
            {
                number++;
            }
            return number;
        }

        private delegate void DG_CreatePanel(string uesrName, string userUID, string userIP, int i);
        /// <summary>
        /// 动态创建panel
        /// </summary>
        /// <param name="nums"></param>
        public static void CreatePanel(string uesrName,string userUID,string userIP,int i)
        {
            //Form2.form2.textBox1.AppendText("CreatePanele,395\r\n");
            if (form2.friendsList.InvokeRequired == false)
            {
                string Name = uesrName;
                string UID = userUID;
                string IP = userIP;
                int count = i;
                Panel panel2 = new Panel();
                //panels[i].Name = "panels" + i.ToString();
                SetDouble(panel2);
                form2.friendsList.Controls.Add(panel2);//往好友列表中增加panel
                panel2.Location = new Point(0, count * 100);//标定坐标
                panel2.Size = new Size(330, 100); //标定大小
                panel2.BackColor = Color.Transparent;
                panel2.BringToFront();
                //添加其它子控件
                panel2.Name = "panel" + form2.AddLabels(panel2, count, Name, UID, IP);//把UID作为 panel 唯一标识符
                                                                                      //动态绑定消息处理
                panel2.MouseEnter += new EventHandler(form2.Panels_MouseEnter);
                panel2.MouseLeave += new EventHandler(form2.Panels_MouseLeave);
                panel2.Click += new EventHandler(form2.Panels_Click);
            }
            else
            {
                DG_CreatePanel dG_CreatePanel = new DG_CreatePanel(CreatePanel);
                form2.friendsList.Invoke(dG_CreatePanel,uesrName,userUID,userIP,i);
            }
        }
        private void SetItinformation(string itName,string itUID,string itIP)
        {
            showitUserName.Text = itName;
            showitUID.Text = itUID;
            showitIP.Text = itIP;
        }
        private void Refreshinformation()
        {
            showitUserName.Text = "";
            showitUID.Text = "";
            showitIP.Text = "";
        }
       
        /*
        /// <summary> 
        /// 广播本机下线。
        /// </summary> 
        /// <returns></returns> 
        public static void OfflineBroadcast(string userName, string userUID, string userIP)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep1 = new IPEndPoint(IPAddress.Broadcast, 10086);//接收10086端口发来的广播
            IPEndPoint iepHost = new IPEndPoint(IPAddress.Parse(userIP), 10086);
            string hostname = Dns.GetHostName();
            byte[] data = Encoding.UTF8.GetBytes(userIP + "," + userUID + "," + "DOWN"+","+userName);
            socket.Bind(iepHost);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            socket.SendTo(data, iep1);
            socket.Shutdown(SocketShutdown.Send);//发送完数据后关闭socket
            socket.Close();
        }
        */
        /// <summary>
        /// 窗口切换
        /// </summary>
        private void PanelSwitch()
        {
            talkBackground.Visible = false;
            chatRichTextBox.Visible = true;
            inputRichTextbox.Visible = true;
            sendChatButton.Visible = true;
            sendFiles.Visible = true;
            label2.Visible = true;
        }
        /// <summary>
        /// Panel 组 Click 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panels_Click(object sender, EventArgs e)
        { 
            Panel panel = (Panel)(sender);//获取触发本消息处理的 panel 控件
            foreach (Control ctrl in friendsList.Controls)
            {
                if (ctrl is Panel)
                {
                    
                    //如果找到 panels 组中的某个 panel 名字等于上面 sender 的 panel 名字，那就是它触发了事件
                    if (ctrl.Name == panel.Name)//找到目标 panel
                    {
                        ctrl.BackColor = nowPanelBack;
                        foreach (Control control in ctrl.Controls)            //遍历所有控件，直到找到所需要的子控件
                        {
                            if (control.Name == "labelUserName")
                            {
                                control.BackColor = nowPanelBack;
                                NowFriendNAME = control.Text;
                                showFriendName.Text = control.Text;
                            }
                            if(control.Name == "labelUID")
                            {
                                control.BackColor = nowPanelBack;
                                NowFriendUID = control.Text;
                            }
                            if(control.Name=="labelIP")
                            {
                                control.BackColor = nowPanelBack;
                                NowFriendIP = control.Text;
                                FriendIP = control.Text;
                            }
                            if (control.Name == "noRead")
                            {
                                control.Visible = false;
                            }
                        }

                    }
                    else
                    {
                        ctrl.BackColor = Color.Transparent;
                        foreach (Control control in ctrl.Controls)            //遍历所有控件，直到找到所需要的子控件
                        {
                            if (control.Name == "labelUserName")
                            {
                                control.BackColor = nowPanelBack;
                            }
                            
                        }
                    }
                }
                
            }
            //先清空目前窗口的聊天记录,输入框输入的文本
            chatRichTextBox.Text = "";
            inputRichTextbox.Text = "";
            //显示聊天框
            PanelSwitch();
            //加载历史聊天记录
            LodeRichtextbox();
            //此处设置对方信息
            SetItinformation(NowFriendNAME, NowFriendUID, NowFriendIP);
        }

        /// <summary>
        /// Panel 组 MouseEnter 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panels_MouseEnter(object sender, EventArgs e)//鼠标挪到控件上时修改颜色
        {
            Panel panel = (Panel)(sender);//获取触发本消息处理的 panel 控件
            foreach (Control ctrl in friendsList.Controls)
            {
                if (ctrl is Panel)//判断控件是否是panel类型
                {
                    //如果找到 panels 组中的某个 panel 名字等于上面 sender 的 panel 名字，那就是它触发了事件
                    if (ctrl.Name == panel.Name)
                    {
                        if (ctrl.BackColor!=nowPanelBack)
                        {
                            ctrl.BackColor = panelBack;
                            break;
                        }
                        
                    }
                }
               
            }

        }
        /// <summary>
        /// Panel 组 MouseLeave 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panels_MouseLeave(object sender, EventArgs e)//改变颜色
        {
            Panel panel = (Panel)(sender);//获取触发本消息处理的 panel 控件
            foreach (Control ctrl in friendsList.Controls)
            {
                if (ctrl is Panel)
                {
                    if (ctrl.Name == panel.Name)
                    {
                        if (ctrl.BackColor==panelBack)
                        {
                            ctrl.BackColor = Color.Transparent;
                        }
                    }
                }
            }
        }
        private void Labels_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)(sender);//获取触发本消息处理的 label 控件
            foreach (Control ctrl in friendsList.Controls)
            {
                if (ctrl is Panel)
                {//遍历 panels, 寻找促发该事件的 label 的父 panel。
                    if (ctrl.Controls.Contains(label) == true)
                    {
                        if (ctrl.BackColor != nowPanelBack)
                        {
                            ctrl.BackColor = panelBack;
                            break;
                        }
                    }
                }
            }
        }

        private void Labels_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)(sender);//获取触发本消息处理的 label 控件
            foreach (Control ctrl in friendsList.Controls)
            {
                if (ctrl is Panel)
                {
                    if (ctrl.Controls.Contains(label) == true)
                    {
                        if (ctrl.BackColor == panelBack)
                        {
                            ctrl.BackColor = Color.Transparent;
                        }
                    }
                }
            }
        }
        private void Labels_Click(object sender, EventArgs e)//
        {
            Label label = (Label)(sender);//获取触发本消息处理的 label 控件
            foreach (Control ctrl in friendsList.Controls)
            {
                if (ctrl is Panel)
                {
                    if (ctrl.Controls.Contains(label) == true)
                    {
                        Panels_Click(ctrl, e);
                        break;
                    }
                }
            }
        }

        public string AddLabels(Panel panel, int i, string uesrname, string useruid, string userip)//动态添加好友属性方法
        {
            string Name = uesrname;
            string UID = useruid;
            string IP = userip;
            Label labelStatus = new Label();                        //聊天中指示条
            labelStatus.Name = "labelStatus";
            panel.Controls.Add(labelStatus);
            labelStatus.AutoSize = false;
            labelStatus.Location = new Point(0, 5);
            labelStatus.Size = new Size(6, 90);
            labelStatus.BorderStyle = BorderStyle.None;
            labelStatus.BackColor = Color.FromArgb(0,174,238);
            labelStatus.Text = null;
            SetDouble(labelStatus);

            Label labelUserName = new Label();                                   //显示用户名
            labelUserName.Name = "labelUserName";
            panel.Controls.Add(labelUserName);
            labelUserName.AutoSize = false;
            labelUserName.Location = new Point(11, 38);
            labelUserName.Size = new Size(250, 30);
            labelUserName.BorderStyle = BorderStyle.None;
            labelUserName.BackColor = Color.Transparent;
            labelUserName.ForeColor = Color.White;
            labelUserName.Text = Name;
            labelUserName.Font = new Font("微软雅黑", 14);
            labelUserName.MouseEnter += new EventHandler(form2.Labels_MouseEnter);//动态绑定消息处理
            labelUserName.MouseLeave += new EventHandler(form2.Labels_MouseLeave);
            labelUserName.Click += new EventHandler(form2.Labels_Click);
            SetDouble(labelUserName);

            Label labelUID = new Label();                                   //设置对方UID，但不显示
            labelUID.Name = "labelUID";
            panel.Controls.Add(labelUID);
            labelUID.Text = useruid;
            labelUID.Visible = false;
            SetDouble(labelUID);

            Label labelIP = new Label();                                   //设置显示对方IP，但不显示
            labelIP.Name = "labelIP";
            panel.Controls.Add(labelIP);
            labelIP.Text = userip;
            labelIP.Visible = false;

            Label noRead = new Label();
            noRead.Name = "noRead";
            panel.Controls.Add(noRead);
            noRead.Text = "新消息";
            noRead.Visible = false;
            noRead.Location = new Point(250, 70);
            noRead.Size = new Size(100, 30);
            noRead.ForeColor = Color.FromArgb(245,121,93);
            noRead.Font = new Font("微软雅黑", 12);
            noRead.BackColor = Color.Transparent;
            noRead.BorderStyle = BorderStyle.None;
            noRead.MouseEnter += new EventHandler(form2.Labels_MouseEnter);//动态绑定消息处理
            noRead.MouseLeave += new EventHandler(form2.Labels_MouseLeave);
            noRead.Click += new EventHandler(form2.Labels_Click);
            SetDouble(noRead);


            return labelUID.Text;
        }
        
     

        private void TimerOpen_Tick(object sender, EventArgs e)//页面展开
        {
           
            if(buttonBack.Width==270)
            {

                timerOpen.Stop();
            }
            else
            {
                UIDlabel.Visible = true;
                buttonBack.Width += 20;
                friendsList.Left += 20;
                backGround.Left += 20;
            }
        }

       

        private void OpenButtenList_MouseClick(object sender, MouseEventArgs e)//打开列表
        {
            
            if (buttonBack.Width == 50)
            {
                timerClose.Stop();
                timerOpen.Enabled = true;
                timerOpen.Start();
                IPlabel.Visible = true;
                UIDlabel.Visible = true;
                label1.Visible = true;
                UsernameLabel1.Visible = true;
                IPlabel2.Visible = true;
                UIDLabel2.Visible = true;
            }
            if(buttonBack.Width==270)
            {
                timerOpen.Stop();
                timerClose.Enabled = true;
                timerClose.Start();
                IPlabel.Visible = false;
                UIDlabel.Visible = false;
                label1.Visible = false;
                UsernameLabel1.Visible = false;
                IPlabel2.Visible = false;
                UIDLabel2.Visible = false;
            }
        }

        private void TimerClose_Tick(object sender, EventArgs e)
        {

            if (buttonBack.Width == 50)
            {
                timerClose.Stop();
                timerClose.Enabled = false;
            }
            else
            {
                buttonBack.Width -= 20;
                friendsList.Left -= 20;
                backGround.Left -= 20;
            }
        }

        private void FriendsList_Paint(object sender, PaintEventArgs e)
        {
            Control _Control = (Control)sender;
            ShowScrollBar(_Control.Handle, 0, 0);
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowScrollBar(IntPtr hWnd, int bar, int show);

        private void SendChatButton_Click(object sender, EventArgs e)
        {
            string message = inputRichTextbox.Text;
            if (message=="")
            {
                nomessageLabel.Visible = true;
                timerNomessage.Start();
            }
            else
            {
                SendTCP(NowFriendIP, message);
            }
            
        }

        private delegate void DG_debugDisplay(string message);

        private void ShouFriendName_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void TimershowDOWN_Tick(object sender, EventArgs e)
        {
            friendDOWNlabel.Visible = false;
            timershowDOWN.Stop();
        }

        private void SendChatButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            string message = inputRichTextbox.Text;
            if (message == "")
            {
                nomessageLabel.Visible = true;
                timerNomessage.Start();
            }
            else
            {
                SendTCP(NowFriendIP, message);
            }
        }

        private void InputRichTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((Keys)e.KeyChar == Keys.Enter)
            {
                this.SendChatButton_KeyPress(sender, e);
            }
        }

        private void ChatRichTextBox_TextChanged(object sender, EventArgs e)
        {
            chatRichTextBox.SelectionStart = chatRichTextBox.Text.Length;
            chatRichTextBox.ScrollToCaret();
        }

        private void TimerNomessage_Tick(object sender, EventArgs e)
        {
            nomessageLabel.Visible = false;
            timerNomessage.Stop();
        }

        private void SendFiles_Click(object sender, EventArgs e)
        {
            string length = form2.Size.ToString();
            if (form2.Width==1420)
            {
                form2.Size = new Size(1113, 703);
            }
            else
            {
                form2.Size = new Size(1420, 703);
            }
            
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "请选择要传输的文件";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = System.IO.Path.GetFullPath(openFileDialog.FileName);
                filePathTextbox.Text = filePath;
                //设置发送的文件名字
                fileName= System.IO.Path.GetFileName(openFileDialog.FileName);
                conformSend.Visible = true;
            }
            
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            CloseRequestOKorNOlabel();
            CloseOKbutton();
            CloseNObutton();
           
            OKorNO = "OK";
            ShowRefuselabel3();
            setSavePath.Visible = true;

            SendFile sendFile = new SendFile();
            ReceiveFile receiveFile = new ReceiveFile();
            receiveFile.SendOKorNO(NowFriendIP, "OK");

        }

        private void NObutton_Click(object sender, EventArgs e)
        {
            CloseRequestOKorNOlabel();
            CloseOKbutton();
            CloseNObutton();
            OKorNO = "NO";
            SendFile sendFile = new SendFile();
            ReceiveFile receiveFile = new ReceiveFile();
            receiveFile.SendOKorNO(NowFriendIP, "NO");
        }

        private void RequestButton_Click(object sender, EventArgs e)
        {
            showRefuselabel.Text = "等待对方确认";
            showRefuselabel.Visible = true;
            SendFile sendFile = new SendFile();
            ReceiveFile receive = new ReceiveFile();
            sendFile.SendFileRequest(NowFriendIP);
        }

        private void TimerHideRefuselabel_Tick(object sender, EventArgs e)
        {
            showRefuselabel.Visible = false;
            timerHideRefuselabel.Stop();
        }

        private void ConformSend_Click(object sender, EventArgs e)
        {
            SendFile send = new SendFile();
            ReceiveFile receiveFile = new ReceiveFile();
            send.SendFilestart(NowFriendIP,filePath,fileName);

        }

        private void SetSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.Desktop,//起始文件夹设为桌面
                Description = "选择文件要保存的位置",
                ShowNewFolderButton = true
            };
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)//用户点了确认
            {
                saveFilePath= folderBrowserDialog.SelectedPath;//获取用户选定的保存文件夹
            }
        }

        /*
public void debugDisplay(string message)
{
if (textBox1.InvokeRequired == false)
{
textBox1.AppendText(message + "\r\n");
}
else
{
DG_debugDisplay dG_debugDisplay = new DG_debugDisplay(debugDisplay);
form2.textBox1.Invoke(dG_debugDisplay, message);
}
}

private void Button1_Click_1(object sender, EventArgs e)
{
dataGridView1.DataSource = friendTable;
}
*/
    }

}
