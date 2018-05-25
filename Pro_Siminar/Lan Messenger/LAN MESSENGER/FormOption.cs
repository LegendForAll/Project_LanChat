using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;
namespace Lan_Messenger
{
    public partial class FormOption : Form
    {
        public FormOption()
        {
            InitializeComponent();
        }

        private void butBuzz_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileopen = new OpenFileDialog();
            fileopen.Title = " Select audio file";
            fileopen.Filter = "Sound Files|*.wav";
            fileopen.InitialDirectory = @"C:\";
            if (fileopen.ShowDialog() == DialogResult.OK)
                txtBuzz.Text = fileopen.FileName.ToString();
        }

        private void butOnoff_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileopen = new OpenFileDialog();
            fileopen.Title = " Select audio file";
            fileopen.Filter = "Sound Files|*.wav";
            fileopen.InitialDirectory = @"C:\";
            if (fileopen.ShowDialog() == DialogResult.OK)
                txtOn.Text = fileopen.FileName.ToString();
        }

        
        private void btnOff_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileopen = new OpenFileDialog();
            fileopen.Title = " Select audio file";
            fileopen.Filter = "Sound Files|*.wav";
            fileopen.InitialDirectory = @"C:\";
            if (fileopen.ShowDialog() == DialogResult.OK)
                txtOff.Text = fileopen.FileName.ToString();
        }

        private void btMessenger_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileopen = new OpenFileDialog();
            fileopen.Title = " Select audio file";
            fileopen.Filter = "Sound Files|*.wav";
            fileopen.InitialDirectory = @"C:\";
            if (fileopen.ShowDialog() == DialogResult.OK)
                txtMessenger.Text = fileopen.FileName.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderopen = new FolderBrowserDialog();
            if (folderopen.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderopen.SelectedPath.ToString();
            }
        }
        private void ghifile(string st0,string st1,string st2,string st3,string st4,string st5)
        {
            FileStream fs = new FileStream("UserSetting.dat", FileMode.Create);
            BinaryWriter w = new BinaryWriter(fs);
            w.Write(st0);
            w.Write(st1);
            w.Write(st2);
            w.Write(st3);
            w.Write(st4);
            w.Write(st5);
            w.Flush();
            fs.Close();
 
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtBuzz.Text == "File not found" || txtOn.Text == "File not found" || txtOff.Text == "File not found" || txtMessenger.Text == "File not found" || txtPath.Text == "Folder not found")
            {
                MessageBox.Show("Please select the path again ", " Error");
            }
            else
            {
                if (File.Exists("UserSetting.dat")) // Nếu đã có sẵn file UserSetting.dat thì đọc ra và so sánh với hiện tại
                {
                    string _logsOption = "1";
                    string[] setting = new string[6]; // Có 6 Options tất cả
                    FileStream fs1 = new FileStream("UserSetting.dat", FileMode.Open);                    
                    BinaryReader w1 = new BinaryReader(fs1);
                    setting[0] = w1.ReadString().ToString();
                    setting[1] = w1.ReadString().ToString();
                    setting[2] = w1.ReadString().ToString();
                    setting[3] = w1.ReadString().ToString();
                    setting[4] = w1.ReadString().ToString();
                    setting[5] = w1.ReadString().ToString();
                    w1.Close();
                    fs1.Close();
                    if (txtBuzz.Text != setting[0])
                    {
                        setting[0] = txtBuzz.Text;
                    }
                    if (txtOn.Text != setting[1])
                    {
                        setting[1] = txtOn.Text;
                    }
                    if (txtOff.Text != setting[2])
                    {
                        setting[2] = txtOff.Text;
                    }
                    if (txtMessenger.Text != setting[3])
                    {
                        setting[3] = txtMessenger.Text;
                    }
                    if (txtPath.Text != setting[4])
                    {
                        setting[4] = txtPath.Text;
                    }

                    
                    if (rbLogSaveall.Checked == true)
                    {
                        _logsOption = "1";
                    }

                    if (rbLogdelSignOut.Checked == true)
                    {
                        _logsOption = "2";
                    }

                    if (rbLognotSave.Checked == true)
                    {
                        _logsOption = "3";
                    }

                    if (_logsOption != setting[5])
                    {
                        setting[5] = _logsOption;
                    }

                    ghifile(setting[0], setting[1], setting[2], setting[3], setting[4], setting[5]);

                }
                else
                {
                    string[] setting = new string[6];
                    if (txtBuzz.Text == "")
                    {
                        setting[0] = "sounds/Call.wav";
                    }
                    else
                    {
                        setting[0] = txtBuzz.Text;
                    }
                    if (txtOn.Text == "")
                    {
                        setting[1] = "sounds/On.wav";
                    }
                    else
                    {
                        setting[1] = txtOn.Text;
                    }
                    if (txtOff.Text == "")
                    {
                        setting[2] = "sounds/Off.wav";
                    }
                    else
                    {
                        setting[2] = txtOff.Text;
                    }
                    if (txtMessenger.Text == "")
                    {
                        setting[3] = "sounds/Mess.wav";
                    }
                    else
                    {
                        setting[3] = txtMessenger.Text;
                    }

                    if (txtPath.Text == "")
                    {
                        setting[4] = "files/";
                    }
                    else
                    {
                        setting[4] = txtPath.Text;
                    }

                    setting[5] = "1";

                    ghifile(setting[0], setting[1], setting[2], setting[3], setting[4], setting[5]);

                }
                this.Close();
            }
            
        }

        private void config_Load(object sender, EventArgs e)
        {
            picPlaybuzz.Image = Image.FromFile("images/btn_Play.png");
            picPlayon.Image = Image.FromFile("images/btn_Play.png");
            picPlayoff.Image = Image.FromFile("images/btn_Play.png");
            picPlaymess.Image = Image.FromFile("images/btn_Play.png");

            if (File.Exists("UserSetting.dat"))
            {
                string[] setting = new string[6];
                FileStream fs1 = new FileStream("UserSetting.dat", FileMode.Open);
                BinaryReader w1 = new BinaryReader(fs1);
                //fs1.Position = 0;
                setting[0] = w1.ReadString().ToString();
                setting[1] = w1.ReadString().ToString();
                setting[2] = w1.ReadString().ToString();
                setting[3] = w1.ReadString().ToString();
                setting[4] = w1.ReadString().ToString();
                setting[5] = w1.ReadString().ToString();
                w1.Close();
                fs1.Close();
                if (!File.Exists(setting[0]))
                {
                    txtBuzz.Text = "File not found";
                }
                else
                {
                    txtBuzz.Text = setting[0];
                }
                if (!File.Exists(setting[1]))
                {
                    txtOn.Text = "File not found";
                }
                else
                {
                    txtOn.Text = setting[1];
                }
                if (!File.Exists(setting[2]))
                {
                    txtOff.Text = "File not found";
                }
                else
                {
                    txtOff.Text = setting[2];
                }
                if (!File.Exists(setting[3]))
                {
                    txtMessenger.Text = "File not found";
                }
                else
                {
                    txtMessenger.Text = setting[3];
                }
                if (!Directory.Exists(setting[4]))
                {
                    txtPath.Text = "File not found";
                }
                else
                {
                    txtPath.Text = setting[4];
                }

                if (setting[5] == "1")
                {
                    rbLogSaveall.Checked = true;
                    rbLognotSave.Checked = false;
                    rbLogdelSignOut.Checked = false;
                }

                if (setting[5] == "2")
                {
                    rbLogSaveall.Checked = false;
                    rbLognotSave.Checked = false;
                    rbLogdelSignOut.Checked = true;
                }

                if (setting[5] == "3")
                {
                    rbLogSaveall.Checked = false;
                    rbLognotSave.Checked = true;
                    rbLogdelSignOut.Checked = false;
                }
            }
            else
            {
               string s0,s1,s2,s3,s4;
                if(!File.Exists(@"sounds/Call.wav"))
                {
                    s0= "File not found";
                }
                else
                    s0 = Path.GetFullPath(@"sounds/Call.wav");
                if (!File.Exists(@"sounds/On.wav"))
                {
                    s1 = "File not found";
                }
                else
                    s1 = Path.GetFullPath(@"sounds/On.wav");
                if (!File.Exists(@"sounds/Off.wav"))
                {
                    s2 = "File not found";
                }
                else
                    s2 = Path.GetFullPath(@"sounds/Off.wav");
                if (!File.Exists(@"sounds/Mess.wav"))
                {
                    s3 = "File not found";
                }
                else
                    s3 = Path.GetFullPath(@"sounds/Mess.wav");
                if(!Directory.Exists(@"files"))
                {
                    s4= "Folder not found";
                }
                else
                    s4 = Path.GetFullPath(@"files");
                txtBuzz.Text = s0;
                txtOn.Text = s1;
                txtOff.Text = s2;
                txtMessenger.Text = s3;
                txtPath.Text = s4;

                // Mặc định là lưu logs chat
                rbLogSaveall.Checked = true;
                rbLognotSave.Checked = false;
                rbLogdelSignOut.Checked = false;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
          
        private void picPlaybuzz_Click(object sender, EventArgs e)
        {
            if (txtBuzz.Text == "File not found")
            {
                MessageBox.Show("Please select the path again ", " Error");
            }
            else
            {
                SoundPlayer play;
                play = new SoundPlayer(txtBuzz.Text);
                play.Play();
            }
        }

        private void picPlayon_Click(object sender, EventArgs e)
        {
            if (txtOn.Text == "File not found")
            {
                MessageBox.Show("Please select the path again ", " Error");
            }
            else
            {
                SoundPlayer play;
                play = new SoundPlayer(txtOn.Text);
                play.Play();
            }
        }

        private void picPlayoff_Click(object sender, EventArgs e)
        {
            if (txtOff.Text == "File not found")
            {
                MessageBox.Show("Please select the path again ", " Error");
            }
            else
            {
                SoundPlayer play;
                play = new SoundPlayer(txtOff.Text);
                play.Play();
            }
        }

        private void picPlaymess_Click(object sender, EventArgs e)
        {
            if (txtMessenger.Text == "File not found")
            {
                MessageBox.Show("Please select the path again "," Error");
            }
            else
            {
                SoundPlayer play;
                play = new SoundPlayer(txtMessenger.Text);
                play.Play();
            }
        }

        private void FormClosing_Click(object sender, FormClosingEventArgs e)
        {
            if (txtBuzz.Text == "File not found" || txtOn.Text == "File not found" || txtOff.Text == "File not found" || txtMessenger.Text == "File not found" || txtPath.Text == "Folder not found")
            {
                MessageBox.Show("Please select the path again "," Error");
                e.Cancel = true;
            }                        
        }
    }
}
