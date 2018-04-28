using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lan_Messenger
{
	/// <summary>
	/// Summary description for FormAddContact.
	/// </summary>
	public class FormAddContact : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtContact;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnCancel;
        private Panel panel1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public FormAddContact()
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
                    //Download source code FREE tai Sharecode.vn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddContact));
            this.label1 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(19, 51);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(261, 20);
            this.txtContact.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnAdd.Location = new System.Drawing.Point(96, 87);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 24);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnCancel.Location = new System.Drawing.Point(192, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 15);
            this.panel1.TabIndex = 6;
            // 
            // FormAddContact
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(292, 123);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddContact";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Friend...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormAddContact_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if(Global.username==txtContact.Text)
			{
				MessageBox.Show("Bạn không thể thêm chính bạn vào danh sách được!");
				txtContact.Text="";
				this.DialogResult=DialogResult.None;
				return;
			}
			if(Global.server.AddContact(Global.username,txtContact.Text))
			{
				return;
			}
			else
			{
                //Download source code FREE tai Sharecode.vn
                // Global.server.GetContacts(Global.username) lấy mảng danh sách các Contact của người dùng hiện tại
                bool check = false; // Biến cờ để xác định sự tồn tại của User                
                foreach (object o in Global.server.GetContacts(Global.username))
                    if (o.ToString() == txtContact.Text) 
                    {
                        check = true;                        
                        break;
                    }
                if (check) MessageBox.Show("Người dùng này đã có trong danh sách bạn bè của bạn");
                else
                    MessageBox.Show("Người dùng này không tồn tại trong cơ sở dữ liệu!");
				this.DialogResult=DialogResult.None;
			}
		}

		private void FormAddContact_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.DialogResult==DialogResult.None)
				e.Cancel=true;
		}
	}
}
