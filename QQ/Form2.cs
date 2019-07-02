using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static QQ.TCPsendfile;

namespace QQ
{

    public partial class Form2 : Form
    {
        public static long Number = 0;
        //public delegate DG_TwoParaAndNoReturn<T,T>(T t1, T t2);
        public static string OKorNO = "";
        /// <summary>
        /// 传输的文件路径
        /// </summary>
        public string filePath = "";
        /// <summary>
        /// 文件长度
        /// </summary>
        public long fileLength = 0;
        /// <summary>
        /// 文件总块数
        /// </summary>
        public long fileSum = 0;
        /// <summary>
        /// 传输的文件名字
        /// </summary>
        public string fileName = "";
        /// <summary>
        /// 接收的文件名字
        /// </summary>
        public string ReceiveFileName = "";
        /// <summary>
        /// 保存文件路径
        /// </summary>
        public string saveFilePath = "";
        /// <summary>
        /// 发送文件传输百分比
        /// </summary>
        public double SendPercentage = 0;
        /// <summary>
        /// 接收文件传输百分比
        /// </summary>
        public double ReceivePercentage = 0;
        /// <summary>
        /// 显示文件是否传输完成
        /// </summary>
        public bool sendComplete = false;
        /// <summary>
        /// 接收文件路径
        /// </summary>
        public string ReceiveFilePath = "";
        /// <summary>
        /// 指示现在是否正在传输文件
        /// </summary>
        public bool SendTrueORFalse = false;
        /// <summary>
        /// 文件传输是否中断
        /// </summary>
        public bool SendStoptrueORfalse = false;
        /// <summary>
        /// 现在正在传输的好友的IP
        /// </summary>
        public string NowSendfileIP = "";
        /// <summary>
        /// 指示程序现在是发送还是接收
        /// </summary>
        public string FiletransferType = "";
        /// <summary>
        /// 之前文件传输到第几块
        /// </summary>
        public long PassNumber = 0;
        /// <summary>
        /// 现在选定的好友的UID
        /// </summary>
        public string NowFriendUID = "";
        /// <summary>
        /// 现在选定的好友的IP
        /// </summary>
        public string NowFriendIP = "";
        /// <summary>
        /// 现在选定的好友的名字
        /// </summary>
        public string NowFriendNAME = "";
        public static Form2 form2;
        public string FriendIP = "";
        public Color panelBack = Color.FromArgb(45, 119, 161);
        public Color nowPanelBack = Color.FromArgb(49, 102, 181);
        private List<Thread> ThreadsList;
        public static Panel[] panels;
        /// <summary>
        /// 在线好友table
        /// </summary>
        public static DataTable friendTable = new DataTable();

        #region
        /// <summary>
        /// 双缓冲函数
        /// </summary>

        public void SetDoubleControls()
        {
            SetDouble(backGround);
            SetDouble(baifenbiLabel);
            SetDouble(button1);
            SetDouble(button2);
            SetDouble(button3);
            SetDouble(button4);
            SetDouble(button5);
            SetDouble(deleteRecord);
            SetDouble(buttonBack);
            SetDouble(changeNamePasswordbutton);
            SetDouble(ChangeNametextBox);
            SetDouble(Changepanel);
            SetDouble(ChangePasswordtextbox);
            SetDouble(ChangeShowUID);
            SetDouble(chatRichTextBox);
            SetDouble(close1);
            SetDouble(conformSend);
            SetDouble(fileLengthLabel);
            SetDouble(FilePanel);
            SetDouble(filePathTextbox);
            SetDouble(friendDOWNlabel);
            SetDouble(friendsList);
            SetDouble(head);
            SetDouble(inputRichTextbox);
            SetDouble(IPlabel);
            SetDouble(IPlabel2);
            SetDouble(IPtext);
            SetDouble(label1);
            SetDouble(label2);
            SetDouble(label3);
            SetDouble(label4);
            SetDouble(label5);
            SetDouble(label6);
            SetDouble(label7);
            SetDouble(label8);
            SetDouble(label9);
            SetDouble(NObutton);
            SetDouble(NoListLabel);
            SetDouble(NoListPicture);
            SetDouble(nomessageLabel);
            SetDouble(OKbutton);
            SetDouble(openButtenList);
            SetDouble(openReceivePathpanel);
            SetDouble(PercentagePanel);
            SetDouble(pictureBox1);
            SetDouble(progressBar1);
            SetDouble(requestButton);
            SetDouble(RequestOKorNOlabel);
            SetDouble(SaveAllrichTextBox);
            SetDouble(selectFile);
            SetDouble(sendChatButton);
            SetDouble(sendFilecancel);
            SetDouble(sendFileLbael);
            SetDouble(sendFiles);
            SetDouble(sendFriendName);
            SetDouble(setSavePath);
            SetDouble(showitIP);
            SetDouble(showitUID);
            SetDouble(showitUserName);
            SetDouble(showRefuselabel);
            SetDouble(speedLabel);
            SetDouble(stopSendButton);
            SetDouble(talkBackground);
            SetDouble(UIDlabel);
            SetDouble(UIDLabel2);
            SetDouble(UIDtext);
            SetDouble(userName);
            SetDouble(UsernameLabel1);
            SetDouble(YiwanchengLabel);
            SetDouble(zhengzai);



        }
        #endregion
        /// <summary>
        /// 创建好友table
        /// </summary>
        /// <param name="cc"></param>
        public void CreateFriendTable()//创建在线好友表
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
        public void ChangeFriendTable(string userName, string userUID, string userIP, string UPorDOWN)
        {
            //textBox1.AppendText("ChangeFriendTable,55\r\n");
            //MessageBox.Show("Fuck you!!!");
            if (UPorDOWN == "UP")
            {
                if (FindFriend(userName, userUID, userIP, UPorDOWN) == false)//如果好友列表中没有此人，则添加
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
            if (form2.friendsList.InvokeRequired == false)
            {
                int count = friendTable.Rows.Count;
                if (count > 0)
                {
                    //刷新好友列表
                    RefreshFriendlist();
                    for (int i = 0; i < count; i++)
                    {
                        //动态创建panel
                        CreatePanel(friendTable.Rows[i][1].ToString(), friendTable.Rows[i][0].ToString(), friendTable.Rows[i][2].ToString(), i);
                    }
                }
                if (count == 0)//如果在线好友列表中不存在好友，则删除所有panel
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
                form2.friendsList.Invoke(dG_UpdateFriendList, sender, e);
            }
        }
        private delegate void DG_RefreshFriendlist();
        /// <summary>
        /// 刷新界面中的好友列表
        /// </summary>
        public void RefreshFriendlist()
        {
            if (form2.friendsList.InvokeRequired == false)
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
        /// 查找好友
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public string FindFriendIPbyUID(string UID)
        {
            foreach (DataRow dataRow in friendTable.Rows)
            {
                if (dataRow[0].ToString() == UID)
                {
                    return dataRow[2].ToString();
                }
            }
            return "";
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
            if (UPorDOWN == "UP")
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
        public void LineBroadcast(string userName, string userUID, string userIP, string UPorDN, string needreply)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Broadcast, 54320);//规定本操作执行的端口，规定用于广播的IP地址
            IPEndPoint iepHost = new IPEndPoint(IPAddress.Parse(userIP), 54320);//
            string hostname = Dns.GetHostName();
            byte[] data = Encoding.UTF8.GetBytes(userIP + "," + userUID + "!" + UPorDN + "?" + userName + "@" + needreply);
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
        public void LineSend(string userName, string userUID, string userIP, string friendIP)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(friendIP), 54320);//规定本操作执行的端口，规定用于广播的IP地址
            IPEndPoint iepHost = new IPEndPoint(IPAddress.Parse(userIP), 54320);//
            string hostname = Dns.GetHostName();
            byte[] data = Encoding.UTF8.GetBytes(userIP + "," + userUID + "!" + "UP" + "?" + userName + "@" + "DONTREPLY");
            //套接字绑定本机ip和端口 
            socket.Bind(iepHost);                                                                                                                                     //需要绑定一块活动的网卡，不然无法发送信息
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            //发送数据
            socket.SendTo(data, ipe);
            //发送完数据后关闭socket
            socket.Shutdown(SocketShutdown.Send);
            socket.Close();
        }
        #region
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
                showFriendName.Text = "";
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
                showRefuselabel.Text = "对方接收了你的请求，等待对方选择保存路径";
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
                showRefuselabel.Text = "选择路径，选择后无法修改";
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
        public void ShowRefuselabel5()
        {
            if (showRefuselabel.InvokeRequired == false)
            {
                showRefuselabel.Text = "对方已选择好路径，请选择文件";
                showRefuselabel.Visible = true;
            }
            else
            {
                Action action = new Action(ShowRefuselabel5);
                showRefuselabel.Invoke(action);
            }
        }
        public void ShowRefuselabel6()
        {
            if (showRefuselabel.InvokeRequired == false)
            {
                showRefuselabel.Text = "正在传输";
                showRefuselabel.Visible = true;
            }
            else
            {
                Action action = new Action(ShowRefuselabel6);
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
        public void CloseRefuselabel()
        {
            if (showRefuselabel.InvokeRequired == false)
            {
                showRefuselabel.Visible = false;

            }
            else
            {
                Action action = new Action(CloseRefuselabel);
                showRefuselabel.Invoke(action);
            }
        }
        public void ClosesetSavePath()
        {
            if (setSavePath.InvokeRequired == false)
            {
                setSavePath.Visible = false;

            }
            else
            {
                Action action = new Action(ClosesetSavePath);
                setSavePath.Invoke(action);
            }
        }
        public void ShowPercentagepanel()
        {
            if (PercentagePanel.InvokeRequired == false)
            {
                ReceivePercentage = 0;
                PercentagePanel.Visible = true;
                baifenbiLabel.Text = "0" + "%";
                progressBar1.Value = 0;
                timerRecivePercentage.Start();
                timerspeed.Start();
            }
            else
            {
                Action action = new Action(ShowPercentagepanel);
                PercentagePanel.Invoke(action);
            }
        }
        public void ClosePercentagepanel()
        {
            if (PercentagePanel.InvokeRequired == false)
            {
                baifenbiLabel.Text = "0" + "%";
                progressBar1.Value = 0;
                PercentagePanel.Visible = false;
            }
            else
            {
                Action action = new Action(ClosePercentagepanel);
                PercentagePanel.Invoke(action);
            }
        }
        public void RefreshFilePathTextbox()
        {
            if (filePathTextbox.InvokeRequired == false)
            {
                filePathTextbox.Text = "";
            }
            else
            {
                Action action = new Action(RefreshFilePathTextbox);
                filePathTextbox.Invoke(action);
            }
        }
        public void ShowopenRecivePathpanel()
        {
            if (openReceivePathpanel.InvokeRequired == false)
            {
                openReceivePathpanel.Visible = true;
                openReceivePathpanel.BringToFront();
            }
            else
            {
                Action action = new Action(ShowopenRecivePathpanel);
                openReceivePathpanel.Invoke(action);
            }
        }
        public void CloseopenRecivePathpanel()
        {
            if (openReceivePathpanel.InvokeRequired == false)
            {
                openReceivePathpanel.Visible = false;
            }
            else
            {
                Action action = new Action(CloseopenRecivePathpanel);
                openReceivePathpanel.Invoke(action);
            }
        }
        public void ChangeForm2Size()
        {

            if (form2.InvokeRequired == false)
            {
                form2.Size = new Size(1420, 703);
            }
            else
            {
                Action action = new Action(ChangeForm2Size);
                form2.Invoke(action);
            }
        }
        public void ClosesendfilesButton()
        {
            if (sendFiles.InvokeRequired == false)
            {
                sendFiles.Visible = false;
            }
            else
            {
                Action action = new Action(ClosesendfilesButton);
                sendFiles.Invoke(action);
            }
        }
        public void ShowsendfilesButton()
        {
            if (sendFiles.InvokeRequired == false)
            {
                sendFiles.Visible = true;
            }
            else
            {
                Action action = new Action(ShowsendfilesButton);
                sendFiles.Invoke(action);
            }
        }
        public void ShowsendFilecancel()
        {
            if (sendFilecancel.InvokeRequired == false)
            {
                sendFilecancel.Visible = true;
            }
            else
            {
                Action action = new Action(ShowsendFilecancel);
                sendFilecancel.Invoke(action);
            }
        }
        public void ShowstopsendButton()
        {
            if (stopSendButton.InvokeRequired == false)
            {
                stopSendButton.Visible = true;
            }
            else
            {
                Action action = new Action(ShowstopsendButton);
                stopSendButton.Invoke(action);
            }
        }
        public void ClosestopsendButton()
        {
            if (stopSendButton.InvokeRequired == false)
            {
                stopSendButton.Visible = false;
            }
            else
            {
                Action action = new Action(ClosestopsendButton);
                stopSendButton.Invoke(action);
            }
        }
        public void ClosesendFilecancel()
        {
            if (sendFilecancel.InvokeRequired == false)
            {
                timerReceiveStopSwitch.Start();
            }
            else
            {
                Action action = new Action(ClosesendFilecancel);
                sendFilecancel.Invoke(action);
            }
        }
        public void ShowrequestButton1()
        {
            if (requestButton.InvokeRequired == false)
            {
                requestButton.Visible = true;
            }
            else
            {
                Action action = new Action(ShowrequestButton1);
                requestButton.Invoke(action);
            }
        }
        public void ShowfilelengthLabel(long filelength)
        {
            if (fileLengthLabel.InvokeRequired == false)
            {
                if (filelength > 1024 * 1024)
                {
                    long length = filelength / (1024 * 1024);
                    fileLengthLabel.Text = "文件大小:" + length.ToString() + "MB";
                    fileLengthLabel.Visible = true;
                }
                else
                {
                    long length = filelength / 1024;
                    fileLengthLabel.Text = "文件大小:" + length.ToString() + "KB";
                    fileLengthLabel.Visible = true;
                }

            }
            else
            {
                Action<long> action = new Action<long>(ShowfilelengthLabel);
                fileLengthLabel.Invoke(action, filelength);
            }
        }
        public void ClosefilelengthLabel()
        {
            if (fileLengthLabel.InvokeRequired == false)
            {
                fileLengthLabel.Visible = false;
            }
            else
            {
                Action action = new Action(ClosefilelengthLabel);
                fileLengthLabel.Invoke(action);
            }
        }
        #endregion
        /// <summary>
        /// UDP监听
        /// </summary>
        public void ListenBroadcast()
        {
            IPEndPoint ipEP1 = new IPEndPoint(IPAddress.Any, 54320);   //IPAddress.any即为所有活动主机
            UdpClient udpReceive = new UdpClient(ipEP1);
            while (true)
            {
                try
                {
                    byte[] bytRecv = udpReceive.Receive(ref ipEP1);//接收远程主机传来的信息
                    string message = Encoding.UTF8.GetString(bytRecv, 0, bytRecv.Length);
                    string IP = message.Substring(0, message.IndexOf(',')); //远程主机的IP
                    string UID = message.Substring(message.IndexOf(',') + 1, message.IndexOf('!') - message.IndexOf(',') - 1); //对方UID
                    string UPorDN = message.Substring(message.IndexOf('!') + 1, message.IndexOf('?') - message.IndexOf('!') - 1);//上线或者下线
                    string Name = message.Substring(message.IndexOf('?') + 1, message.IndexOf('@') - message.IndexOf('?') - 1);//对方名字
                    string needReply = message.Substring(message.IndexOf('@') + 1);//是否需要回复
                    if (IP == userClass.publicIP)//如果收到的广播是本机IP，不做任何事
                    {

                    }
                    else
                    {
                        // textBox1.AppendText("ListenBroadcast,216\r\n");
                        if (needReply == "NEEDREPLY")//需要回复，说明是上线广播
                        {
                            //如果是上线广播，接收到这个广播之后，需要给对方也发送一个广播，证明自己在线
                            LineSend(userClass.publicUsername, userClass.publicUserUID, userClass.publicIP, IP);

                        }
                        ChangeFriendTable(Name, UID, IP, UPorDN);
                        if (UPorDN == "DN")
                        {
                            if (UID == NowFriendUID)
                            {
                                //控件切换
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
        public void FormatMessage(string message, HorizontalAlignment horizontalAlignment)
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
                chatRichTextBox.Invoke(action, message, horizontalAlignment);
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
        public void SaveallRecord(string UID, string message)
        {
            if (SaveAllrichTextBox.InvokeRequired == false)
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
                Action<string, string> action = new Action<string, string>(SaveallRecord);
                SaveAllrichTextBox.Invoke(action, UID, message);
            }
        }
        /// <summary>
        /// 显示哪个人有未读消息
        /// </summary>
        public void ShownoRead(string UID, string newMessageORfileRequest)
        {
            if (friendsList.InvokeRequired == false)
            {
                foreach (Control ctrl in friendsList.Controls)//遍历好友列表中所有的控件
                {
                    if (ctrl is Panel)//如果该控件是panel类型
                    {

                        foreach (Control control in ctrl.Controls)            //遍历所有控件，直到找到所需要的子控件
                        {
                            if (control.Name == "labelUID")//找到匹配UID的panel
                            {
                                if (control.Text == UID)
                                {
                                    foreach (Control control1 in ctrl.Controls)          //找到noRead子控件，显示未读
                                    {
                                        if (control1.Name == "noRead")
                                        {
                                            control1.Text = newMessageORfileRequest;
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

                Action<string, string> action = new Action<string, string>(ShownoRead);
                friendsList.Invoke(action, UID, newMessageORfileRequest);
            }
        }
        /// <summary>
        /// TCP监听程序，并接收信息
        /// </summary>
        private void TCPlisten()
        {
            //开启监听
            Socket socketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketListen.Bind(new IPEndPoint(userClass.IPv4Address, 54321));//与对方连接
            socketListen.Listen(10);
            while (true)
            {
                try
                {
                    //获取监听到的连接
                    Socket socketWrite = socketListen.Accept();
                    //创建网络流
                    NetworkStream networkStream = new NetworkStream(socketWrite);
                    //获取长度
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
                    if (UID != NowFriendUID)
                    {
                        ShownoRead(UID, "新信息");
                    }

                    //再读取聊天记录
                    if (UID == NowFriendUID)//如果目前聊天的人是发来信息的人
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
        private void SendTCP(string friendIP, string message)
        {
            try
            {
                Socket socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //绑定对方
                socketSend.Connect(IPAddress.Parse(friendIP), 54321);
                //设置网络流
                NetworkStream networkstream = new NetworkStream(socketSend);
                //将要发送的字符串转换为字节数组
                byte[] buffer = Encoding.UTF8.GetBytes(userClass.publicUserUID + message);
                //写入网络流
                networkstream.Write(buffer, 0, buffer.Length);
                //关闭网络流和套接字
                networkstream.Dispose();
                networkstream.Close();
                socketSend.Close();
                FormatMessage(message, HorizontalAlignment.Right);
                //清除输入框
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
            //开启监听
            Socket socketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketListen.Bind(new IPEndPoint(userClass.IPv4Address, 54323));//与对方连接
            socketListen.Listen(10);
            while (true)
            {
                try
                {
                    //获取监听到的连接
                    Socket socketWrite = socketListen.Accept();
                    NetworkStream networkStream = new NetworkStream(socketWrite);
                    int length = socketWrite.ReceiveBufferSize;
                    byte[] buffer = new byte[length];
                    //读取流中的数据
                    networkStream.Read(buffer, 0, length);
                    string message = Encoding.UTF8.GetString(buffer).Trim('\0');
                    if (message.Length == 29 && message.Substring(0, 3) == "UID")//判断是否是请求信号
                    {
                        string UID = message.Substring(4, 17);
                        if (UID == NowFriendUID)//如果请求的信息是目前正在聊天的好友发的
                        {
                            if (SendTrueORFalse == false)//如果程序没有在发送文件，则可以显示
                            {
                                ChangeForm2Size();
                                CloseRequestButton();
                                ShowRequestOKorNOlabel();
                                ShowOKbutton();
                                ShowNObutton();
                            }
                            else//如果正在传输数据，直接发送拒绝信号
                            {
                                ReceiveFile receiveFile = new ReceiveFile();
                                string friendIP = FindFriendIPbyUID(UID);
                                receiveFile.SendOKorNO(friendIP, "NO");
                            }
                        }
                        else
                        {
                            if (SendTrueORFalse == true)//发送拒绝信号
                            {
                                ReceiveFile receiveFile = new ReceiveFile();
                                string friendIP = FindFriendIPbyUID(UID);
                                receiveFile.SendOKorNO(friendIP, "NO");
                            }
                            else
                            {
                                ShownoRead(UID, "文件传输请求");
                            }

                        }
                    }
                    if (message == "OK")//判断是否是同意传输信号
                    {
                        //对方允许发送，隐藏聊天框中的文件发送按钮，此时无法与其他人发送文件
                        NowSendfileIP = NowFriendIP;
                        ClosesendfilesButton();
                        SendTrueORFalse = true;
                        CloseRequestButton();
                        ShowRefuselabel2();
                    }
                    if (message == "NO")//判断是否是拒绝传输信号
                    {
                        ShowRefuselabel();
                        ShowrequestButton();
                    }
                    if (message == "SetPathOK")//判断是否是已经设置好路径信号
                    {
                        ShowRefuselabel5();
                        ShowselectFIle();
                    }
                    if (message == "StopSend")//判断是否是停止发送文件信号
                    {
                        SendStoptrueORfalse = true;
                    }
                    if (message.Length > 10 && message.Substring(0, 3) != "UID")//判断是否是文件信息信号，并开始接收文件
                    {
                        FiletransferType = "Receive";
                        string information = message.Substring(0, message.IndexOf('?'));
                        if (information == "Information")
                        {
                            ShowRefuselabel4();
                            //获取文件长度和总块数
                            string FILELENGTH = message.Substring(message.IndexOf("?") + 1, message.IndexOf("!") - message.IndexOf("?") - 1);
                            string SUM = message.Substring(message.IndexOf("!") + 1, message.IndexOf("/") - message.IndexOf("!") - 1);
                            ReceiveFileName = message.Substring(message.IndexOf("/") + 1);
                            fileLength = long.Parse(FILELENGTH);
                            fileSum = long.Parse(SUM);
                            ShowfilelengthLabel(fileLength);
                            //显示取消传输按钮
                            ShowstopsendButton();
                            //切换控件
                            ShowRefuselabel6();
                            ClosesetSavePath();
                            ShowPercentagepanel();
                            //接收线程作为后台线程
                            ReciveBackground.RunWorkerAsync();
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
        /// <summary>
        /// 设置控件的父子关系
        /// </summary>
        void SetSon()
        {
            Changepanel.Parent = form2;
            fileLengthLabel.Parent = FilePanel;
            PercentagePanel.Parent = FilePanel;
            openReceivePathpanel.Parent = FilePanel;
            head.Parent = buttonBack;
            close1.Parent = form2;

            openButtenList.Parent = buttonBack;
            NoListLabel.Parent = friendsList;
            NoListPicture.Parent = friendsList;
        }
        private void Form2_Load(object sender, EventArgs e)//窗口加载执行操作
        {
            //监听UDP广播线程
            Thread UDPListenThread = new Thread(ListenBroadcast);
            UDPListenThread.IsBackground = true;
            //TCP聊天监听线程
            Thread TCPListenthread = new Thread(TCPlisten);
            TCPListenthread.IsBackground = true;
            //TCP文件发送监听线程
            Thread listenRequest = new Thread(ListenRequest);
            listenRequest.IsBackground = true;
            ThreadsList.Add(UDPListenThread); //将新建的线程加入到线程队列中，以便在窗体结束时关闭所有的线程
            ThreadsList.Add(TCPListenthread);
            ThreadsList.Add(listenRequest);
            UDPListenThread.Start();
            TCPListenthread.Start();
            listenRequest.Start();

            //给所有控件加入双缓冲
            SetDoubleControls();
            close1.BringToFront();
            //设置本机用户信息
            setUser();
            //设置控件父子关系
            SetSon();
            //创建好友表
            CreateFriendTable();
            //上线广播
            LineBroadcast(userClass.publicUsername, userClass.publicUserUID, userClass.publicIP, "UP", "NEEDREPLY");
        }

        public void setUser()
        {
            userName.Text = userClass.publicUsername;
            UIDtext.Text = userClass.publicUserUID;
            IPtext.Text = userClass.publicIP;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            if (SendTrueORFalse == false)//如果文件正在传输，则不能关闭程序
            {
                LineBroadcast(userClass.publicUsername, userClass.publicUserUID, userClass.publicIP, "DN", "DONTREPLY");
                Environment.Exit(0);
            }
            else
            {
                notifyIconWarning.ShowBalloonTip(1000, "警告", "要关闭程序，请先关闭文件传输", ToolTipIcon.Warning);
            }

        }
        //以下为窗口拖动代码
        //窗口拖动相关代码
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void BackGround_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void ButtonBack_MouseDown_1(object sender, MouseEventArgs e)
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
            foreach (Control ctrl in friendsList.Controls)
            {
                number++;
            }
            return number;
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

        private delegate void DG_CreatePanel(string uesrName, string userUID, string userIP, int i);
        /// <summary>
        /// 动态创建panel
        /// </summary>
        /// <param name="nums"></param>
        public static void CreatePanel(string uesrName, string userUID, string userIP, int i)
        {
            if (form2.friendsList.InvokeRequired == false)
            {
                string Name = uesrName;
                string UID = userUID;
                string IP = userIP;
                int count = i;
                Panel panel2 = new Panel();
                SetDouble(panel2);
                form2.friendsList.Controls.Add(panel2);//往好友列表中增加panel
                panel2.Location = new Point(0, count * 100);//标定坐标
                panel2.Size = new Size(380, 100); //标定大小
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
                form2.friendsList.Invoke(dG_CreatePanel, uesrName, userUID, userIP, i);
            }
        }
        /// <summary>
        /// 设置当前正在聊天的好友的信息
        /// </summary>
        /// <param name="itName"></param>
        /// <param name="itUID"></param>
        /// <param name="itIP"></param>
        private void SetItinformation(string itName, string itUID, string itIP)
        {
            showitUserName.Text = itName;
            showitUID.Text = itUID;
            showitIP.Text = itIP;
        }
        /// <summary>
        /// 刷新好友信息
        /// </summary>
        private void Refreshinformation()
        {
            showitUserName.Text = "";
            showitUID.Text = "";
            showitIP.Text = "";
        }

        /// <summary>
        /// 窗口切换
        /// </summary>
        private void PanelSwitch()
        {
            talkBackground.Visible = false;
            chatRichTextBox.Visible = true;
            inputRichTextbox.Visible = true;
            sendChatButton.Visible = true;
            label2.Visible = true;
        }
        /// <summary>
        /// Panel 组 Click 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panels_Click(object sender, EventArgs e)
        {
            string newMessageORsendFilerequest = "";
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
                                sendFriendName.Text = control.Text;
                            }
                            if (control.Name == "labelUID")
                            {
                                control.BackColor = nowPanelBack;
                                NowFriendUID = control.Text;
                            }
                            if (control.Name == "labelIP")
                            {
                                control.BackColor = nowPanelBack;
                                NowFriendIP = control.Text;
                                FriendIP = control.Text;
                            }
                            if (control.Name == "noRead")
                            {
                                control.Visible = false;
                                newMessageORsendFilerequest = control.Text;
                                control.Text = "";

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
                                control.BackColor = Color.Transparent;
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
            if (SendTrueORFalse == false)//如果现在程序没在传输文件，则可以打开传输按钮框
            {
                sendFiles.Visible = true;
            }
            //加载历史聊天记录
            LodeRichtextbox();
            //此处设置对方信息
            SetItinformation(NowFriendNAME, NowFriendUID, NowFriendIP);
            if (newMessageORsendFilerequest == "文件传输请求")
            {
                requestButton.Visible = false;
                OKbutton.Visible = true;
                NObutton.Visible = true;
                RequestOKorNOlabel.Visible = true;
                form2.Size = new Size(1420, 703);
            }
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
                        if (ctrl.BackColor != nowPanelBack)
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
                        if (ctrl.BackColor == panelBack)
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
            labelStatus.BackColor = Color.FromArgb(0, 174, 238);
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
            noRead.Text = "";
            noRead.Visible = false;
            noRead.Location = new Point(170, 70);
            noRead.Size = new Size(130, 50);
            noRead.ForeColor = Color.FromArgb(245, 121, 93);
            noRead.Font = new Font("微软雅黑", 13);
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

            if (buttonBack.Width == 290)
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
                changeNamePasswordbutton.Visible = true;
                deleteRecord.Visible = true;
            }
            if (buttonBack.Width == 290)
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
                changeNamePasswordbutton.Visible = false;
                deleteRecord.Visible = false;
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
        /// <summary>
        /// 取消水平滚动条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if ((Keys)e.KeyChar == Keys.Enter)
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

        private void SendFiles_Click(object sender, EventArgs e)//打开发送文件窗口
        {
            string length = form2.Size.ToString();
            if (form2.Width == 1420)
            {
                form2.Size = new Size(1113, 703);
            }
            else
            {

                zhengzai.Visible = true;
                sendFriendName.Visible = true;
                sendFriendName.Text = NowFriendNAME;
                requestButton.Visible = true;
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
                fileName = System.IO.Path.GetFileName(openFileDialog.FileName);
                conformSend.Visible = true;
            }

        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            ClosesendfilesButton();
            CloseRequestOKorNOlabel();
            CloseOKbutton();
            CloseNObutton();
            SendTrueORFalse = true;
            NowSendfileIP = NowFriendIP;
            OKorNO = "OK";
            ShowRefuselabel3();
            setSavePath.Visible = true;

            SendFile sendFile = new SendFile();
            ReceiveFile receiveFile = new ReceiveFile();
            string SendFriendIP = NowSendfileIP;
            receiveFile.SendOKorNO(SendFriendIP, "OK");

        }

        private void NObutton_Click(object sender, EventArgs e)
        {
            CloseRequestOKorNOlabel();
            CloseOKbutton();
            CloseNObutton();
            ShowrequestButton();
            OKorNO = "NO";
            SendFile sendFile = new SendFile();
            ReceiveFile receiveFile = new ReceiveFile();
            string SendFriendIP = NowFriendIP;
            receiveFile.SendOKorNO(SendFriendIP, "NO");
        }

        private void RequestButton_Click(object sender, EventArgs e)
        {
            showRefuselabel.Text = "等待对方确认";
            showRefuselabel.Visible = true;
            SendFile sendFile = new SendFile();
            ReceiveFile receive = new ReceiveFile();
            string SendFriendIP = NowFriendIP;
            sendFile.SendFileRequest(SendFriendIP);
        }

        private void TimerHideRefuselabel_Tick(object sender, EventArgs e)
        {
            showRefuselabel.Visible = false;
            timerHideRefuselabel.Stop();
        }

        private void ConformSend_Click(object sender, EventArgs e)//确认发送文件
        {
            //将传输类别设置为发送
            FiletransferType = "Send";
            ShowRefuselabel6();
            //发送百分比置零
            SendPercentage = 0;
            PercentagePanel.Visible = true;
            conformSend.Visible = false;
            selectFile.Visible = false;
            stopSendButton.Visible = true;
            timerSendPercentage.Start();
            timerspeed.Start();
            SendTrueORFalse = true;
            sendFiles.Visible = false;
            //后台启动发送
            SendBackground.RunWorkerAsync();
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
                showRefuselabel.Text = "等待对方选择文件";
                saveFilePath = folderBrowserDialog.SelectedPath;//获取用户选定的保存文件夹
                filePathTextbox.Text = "保存路径：" + saveFilePath;
                ReceiveFilePath = saveFilePath;
                setSavePath.Visible = false;
                SendFile sendFile = new SendFile();
                sendFile.SendFilePathOK(NowFriendIP);
            }
        }

        private void TimerSendPercentage_Tick(object sender, EventArgs e)//发送方发送百分比
        {
            baifenbiLabel.Text = SendPercentage.ToString("#0.00") + "%";
            progressBar1.Value = (int)SendPercentage;

            if (SendPercentage == 100)
            {
                timerSendPercentage.Stop();
            }
        }

        private void TimerRecivePercentage_Tick(object sender, EventArgs e)//接收方接收百分比
        {
            baifenbiLabel.Text = ReceivePercentage.ToString("#0.00") + "%";
            progressBar1.Value = (int)ReceivePercentage;

            if (ReceivePercentage == 100)
            {
                timerSendPercentage.Stop();
            }
        }

        private void SendBackground_DoWork(object sender, DoWorkEventArgs e)
        {

            SendFile send = new SendFile();
            ReceiveFile receiveFile = new ReceiveFile();
            string SendFriendIP = NowSendfileIP;
            FileInfo fileInfo = new FileInfo(filePath);
            //文件长度
            long FileLength = fileInfo.Length;
            fileLength = FileLength;
            fileSum = FileLength / 1400;
            ShowfilelengthLabel(FileLength);
            send.SendFilestart(SendFriendIP, filePath, fileName, ref SendPercentage, ref SendStoptrueORfalse);
            if (SendStoptrueORfalse == true)
            {
                send.SendStop(SendFriendIP);
            }
        }

        private void SendBackground_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)//发送工作完成后
        {
            ClosefilelengthLabel();
            if (SendStoptrueORfalse == true)//判断是否是被中断的
            {
                SendPercentage = 0;
                sendFilecancel.Visible = true;
                stopSendButton.Visible = false;
                timerSendSuccessSwitch.Start();
                SendStoptrueORfalse = false;
                SendTrueORFalse = false;
                timerSendPercentage.Stop();
            }
            else
            {
                label10.Text = ((double)fileLength / ((double)(1024 * 1024))).ToString("#0.00") + "MB" + "/" + ((double)fileLength / ((double)(1024 * 1024))).ToString("#0.00") + "MB";
                SendPercentage = 0;
                SendStoptrueORfalse = false;
                stopSendButton.Visible = false;
                SendTrueORFalse = false;
                ShowsendfilesButton();
                timerSendSuccessSwitch.Start();
                timerSendPercentage.Stop();
            }
        }

        private void ReciveBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            ReceiveFile receiveFile = new ReceiveFile();
            receiveFile.ListenReceiveFile(fileLength, fileSum, saveFilePath, ReceiveFileName, ref ReceivePercentage, ref SendStoptrueORfalse);

        }
        private void Button1_Click_3(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ReceiveFilePath);
            showRefuselabel.Visible = false;
            filePathTextbox.Text = "";
            openReceivePathpanel.Visible = false;
            PercentagePanel.Visible = false;
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            showRefuselabel.Visible = false;
            openReceivePathpanel.Visible = false;
            PercentagePanel.Visible = false;
            filePathTextbox.Text = "";
        }

        private void ReciveBackground_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)//接收工作完成
        {
            ClosefilelengthLabel();
            if (SendStoptrueORfalse == true)//判断是否是被中断的
            {

                ShowsendFilecancel();
                CloseRefuselabel();
                SendStoptrueORfalse = false;
                SendTrueORFalse = false;
                CloseopenRecivePathpanel();
                ClosestopsendButton();
                ShowsendfilesButton();
                RefreshFilePathTextbox();
                ClosePercentagepanel();
                ClosesendFilecancel();
                ShowrequestButton1();
                ReceivePercentage = 0;
                timerRecivePercentage.Stop();
            }
            else
            {

                CloseRefuselabel();
                SendStoptrueORfalse = false;
                SendTrueORFalse = false;
                ShowsendfilesButton();
                ClosestopsendButton();
                RefreshFilePathTextbox();
                ShowopenRecivePathpanel();
                ClosePercentagepanel();
                ClosesendFilecancel();
                ShowrequestButton1();
                ReceivePercentage = 0;
                timerRecivePercentage.Stop();
            }
        }


        private void TimerSendSuccessSwitch_Tick(object sender, EventArgs e)
        {
            sendFilecancel.Visible = false;
            filePathTextbox.Text = "";
            PercentagePanel.Visible = false;
            showRefuselabel.Visible = false;
            requestButton.Visible = true;
            timerSendSuccessSwitch.Stop();
        }

        private void StopSendButton_Click(object sender, EventArgs e)
        {
            if (FiletransferType == "Send")
            {
                SendStoptrueORfalse = true;
                stopSendButton.Visible = false;
            }
            else
            {
                stopSendButton.Visible = false;
                SendFile sendFile = new SendFile();
                sendFile.SendStop(NowSendfileIP);

            }
        }

        private void TimersetSendStop_Tick(object sender, EventArgs e)
        {
            SendStoptrueORfalse = true;
            timersetSendStop.Stop();
        }

        private void TimerReceiveStopSwitch_Tick(object sender, EventArgs e)
        {
            sendFilecancel.Visible = false;
            timerReceiveStopSwitch.Stop();
        }

        private void TimerReceiveStopSwitch1_Tick(object sender, EventArgs e)
        {
            requestButton.Visible = true;
            timerReceiveStopSwitch1.Stop();
        }
        private void Button4_Click(object sender, EventArgs e)//窗口最小化
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Timerspeed_Tick(object sender, EventArgs e)//实时显示速度
        {
            double NowByte = (Number - PassNumber) * 1400;
            PassNumber = Number;
            if (Number!=0&&fileSum!=0)
            {
                label10.Text = (((double)Number * 1400) / (1024 * 1024)).ToString("#0.00") + "MB" + "/" + ((double)fileLength / ((double)(1024 * 1024))).ToString("#0.00") + "MB";
            }
            if (NowByte > 1024 * 1024)
            {
                double speed = (NowByte / (1024 * 1024)) * 2;
                speedLabel.Text = speed.ToString("#0.00") + "MB/s";
            }
            else if (1024 < NowByte && NowByte < 1024 * 1024)
            {
                double speed = (NowByte / (1024)) * 2;
                speedLabel.Text = speed.ToString("#0.00") + "KB/s";
            }
            else if (0 < NowByte && NowByte < 1024)
            {
                double speed = NowByte * 2;
                speedLabel.Text = speed.ToString() + "B/s";
            }
            else
            {
                double speed = 0;
                speedLabel.Text = speed.ToString() + "B/s";
            }

            if (FiletransferType == "Send" && SendPercentage == 100)
            {
                timerspeed.Stop();
            }
            if (FiletransferType == "Receive" && ReceivePercentage == 100)
            {
                timerspeed.Stop();
            }
        }

        private void ChangeNamePasswordbutton_Click(object sender, EventArgs e)
        {
            ChangeShowUID.Text = userClass.publicUserUID;
            ChangeNametextBox.Text = userClass.publicUsername;
            ChangePasswordtextbox.Text = userClass.publicUserpassword;
            Changepanel.Visible = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Changepanel.Visible = false;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string directory_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Cytus2/Users";
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(directory_Path + "/Users.xml");

            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                if (dataRow[2].ToString() == ChangeShowUID.Text)
                {
                    dataRow[0] = ChangeNametextBox.Text;
                    dataRow[1] = ChangePasswordtextbox.Text;
                    userClass.publicUsername = ChangeNametextBox.Text;
                    userClass.publicUserpassword = ChangePasswordtextbox.Text;
                    userName.Text = ChangeNametextBox.Text;
                }
            }
            dataSet.WriteXml(directory_Path + "/Users.xml");
            Changepanel.Visible = false;
        }

        private void Button6_Click(object sender, EventArgs e)//清除所有聊天记录
        {
            string directory_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Cytus2/Chatrecord";
            if (Directory.Exists(directory_Path))
            {

                foreach (string f in Directory.GetFileSystemEntries(directory_Path))
                {

                    if (File.Exists(f))
                    {
                        //如果有子文件删除文件
                        File.Delete(f);
                        Console.WriteLine(f);
                    }

                }
            }
            chatRichTextBox.Text = "";
            deleteSuccessLabel.Visible = true;
            timerdeleteSuccess.Start();
        }

        private void TimerdeleteSuccess_Tick(object sender, EventArgs e)
        {
            deleteSuccessLabel.Visible = false;
            timerdeleteSuccess.Stop();
        }


    }
}
