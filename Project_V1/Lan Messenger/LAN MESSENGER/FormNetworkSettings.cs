using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.IO;

namespace Lan_Messenger
{
	/// <summary>
	/// Summary description for FormNetworkSettings.
	/// </summary>
	public class FormNetworkSettings : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox txtIP;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
        private Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormNetworkSettings()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNetworkSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Địa chỉ IP của Server :";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(138, 48);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(180, 20);
            this.txtIP.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnOK.Location = new System.Drawing.Point(184, 83);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(64, 24);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnCancel.Location = new System.Drawing.Point(254, 83);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Khai báo địa chỉ của máy chủ lắng nghe các kết nối đến từ Client.";
            // 
            // FormNetworkSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(343, 119);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormNetworkSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thiết lập mạng";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormNetworkSettings_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			switch(MessageBox.Show("Bạn có chắc chắn muốn thay đổi thiết lập mạng không? Bạn sẻ cần phải đăng nhập trở lại.","Thay đổi thiết lập?",MessageBoxButtons.YesNoCancel))
			{
				case DialogResult.Yes:
					FileStream fs = new FileStream("NetSetting.Dat",FileMode.Create);
					BinaryWriter bw = new BinaryWriter(fs);
					bw.Write(txtIP.Text);
					bw.Close();
					fs.Close();
					return; 
					break;
				case DialogResult.No:
					this.DialogResult=DialogResult.None;
					break;
                case DialogResult.Cancel:
                    this.DialogResult = DialogResult.Cancel;
                    break;                    
			}
		}

		private void FormNetworkSettings_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.DialogResult==DialogResult.None)
				e.Cancel=true;
		}


    }
}
