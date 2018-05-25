using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections;
using LanMessengerChatRoomBase;
namespace Lan_Messenger
{
    public partial class FormJoinRoom : Form
    {
        public FormJoinRoom()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (txtNick.Text != "")
            {
                if (Global.server.IsVisible(txtNick.Text))
                    OpenRoom();
                else
                    MessageBox.Show("This person is not online ", " Error!");
                //Download source code FREE tai Sharecode.vn
            }
            else
                MessageBox.Show("Please indicate Nick's Room Creator "," Error!");
        }

        // Delegate để UnregisterChannel khi FormChatRoom đóng
        bool ChatRoomClosed = false;
        public void GetValue(Boolean b)
        {
            ChatRoomClosed = b;
            if (ChatRoomClosed)
            {
                ChannelServices.UnregisterChannel(chan);
                chan = null;
            }
        }

        TcpChannel chan;
        private void OpenRoom()
        {
            ArrayList alOnlineUser = new ArrayList();
            FormChatRoom objChatWin;

            if (chan == null)
            {
                chan = new TcpChannel();
                ChannelServices.RegisterChannel(chan, false);
                //Download source code FREE tai Sharecode.vn
                objChatWin = new FormChatRoom();
                objChatWin.MyGetData = new FormChatRoom.GetString(GetValue);
                objChatWin.remoteObj = (SampleObject)Activator.GetObject(typeof(LanMessengerChatRoomBase.SampleObject), "tcp://"+ Global.server.GetIP(txtNick.Text) + ":7070/" + txtNick.Text);

                if (!objChatWin.remoteObj.JoinToChatRoom(Global.username))
                {
                    MessageBox.Show(Global.username + " Signed in! Can lag network, try again later!");
                    ChannelServices.UnregisterChannel(chan);
                    chan = null;
                    objChatWin.Dispose();
                    return;
                }
                objChatWin.key = objChatWin.remoteObj.CurrentKeyNo();
                objChatWin.yourName = Global.username;

                this.Hide();
                objChatWin.Show();
            }
            else
            {
                MessageBox.Show("An error occurred while creating Room Chat, please try again later!");
                ChannelServices.UnregisterChannel(chan);
                chan = null;
            }
        }
    }
}
