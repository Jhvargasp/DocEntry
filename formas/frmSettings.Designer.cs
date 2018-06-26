using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace DocEntry
{
	partial class frmSettings
	{
	
#region "Upgrade Support "
		private static frmSettings m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSettings DefInstance
		{
			get
			{
				if (m_vb6FormDefInstance == null || m_vb6FormDefInstance.IsDisposed)
				{
					m_InitializingDefInstance = true;
					m_vb6FormDefInstance = new frmSettings();
					m_InitializingDefInstance = false;
				}
				return m_vb6FormDefInstance;
			}
			set
			{
				m_vb6FormDefInstance = value;
			}
		}
		
#endregion 
#region "Windows Form Designer generated code "
		public frmSettings():base(){
			if (m_vb6FormDefInstance == null)
			{
				if (m_InitializingDefInstance)
				{
					m_vb6FormDefInstance = this;
				} else
				{
					try
					{
							//For the start-up form, the first instance created is the default instance.
							if (System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType == this.GetType())
							{
								m_vb6FormDefInstance = this;
							}
						}
					catch 
					{
					}
				}
			}
			//This call is required by the Windows Form Designer.
			InitializeComponent();
		}
	//Form overrides dispose to clean up the component list.
	[System.Diagnostics.DebuggerNonUserCode]
	 protected   override  void  Dispose( bool Disposing)
	{
			if (Disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(Disposing);
	}
	//Required by the Windows Form Designer
	private System.ComponentModel.IContainer components;
	public System.Windows.Forms.ToolTip ToolTip1;
	public  System.Windows.Forms.Button btnCancel;
	public  System.Windows.Forms.Button btnOk;
	public  System.Windows.Forms.TextBox txtResDocClass;
	public  System.Windows.Forms.TextBox txtIMSLibName;
	public  System.Windows.Forms.Button cmdClear;
	public  System.Windows.Forms.Button cmdSave;
	public  System.Windows.Forms.TextBox txtResFolder;
	public  System.Windows.Forms.TextBox txtIMSPassword;
	public  System.Windows.Forms.TextBox txtIMSUser;
	public  System.Windows.Forms.Label Label9;
	public  System.Windows.Forms.Label Label8;
	public  System.Windows.Forms.Label Label3;
	public  System.Windows.Forms.Label Label2;
	public  System.Windows.Forms.Label Label1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSettings));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.txtResDocClass = new System.Windows.Forms.TextBox();
			this.txtIMSLibName = new System.Windows.Forms.TextBox();
			this.cmdClear = new System.Windows.Forms.Button();
			this.cmdSave = new System.Windows.Forms.Button();
			this.txtResFolder = new System.Windows.Forms.TextBox();
			this.txtIMSPassword = new System.Windows.Forms.TextBox();
			this.txtIMSUser = new System.Windows.Forms.TextBox();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Form1";
			this.ClientSize = new System.Drawing.Size(441, 267);
			this.Location = new System.Drawing.Point(4, 23);
			this.Icon = (System.Drawing.Icon) resources.GetObject("frmSettings.Icon");
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.ControlBox = true;
			this.Enabled = true;
			this.KeyPreview = false;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmSettings";
			this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CancelButton = this.btnCancel;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Size = new System.Drawing.Size(97, 41);
			this.btnCancel.Location = new System.Drawing.Point(324, 218);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
			this.btnCancel.CausesValidation = true;
			this.btnCancel.Enabled = true;
			this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnCancel.TabStop = true;
			this.btnCancel.Name = "btnCancel";
			this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnOk.Text = "Ok";
			this.btnOk.Size = new System.Drawing.Size(97, 41);
			this.btnOk.Location = new System.Drawing.Point(224, 218);
			this.btnOk.TabIndex = 8;
			this.btnOk.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.btnOk.BackColor = System.Drawing.SystemColors.Control;
			this.btnOk.CausesValidation = true;
			this.btnOk.Enabled = true;
			this.btnOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnOk.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnOk.TabStop = true;
			this.btnOk.Name = "btnOk";
			this.txtResDocClass.AutoSize = false;
			this.txtResDocClass.Size = new System.Drawing.Size(177, 25);
			this.txtResDocClass.Location = new System.Drawing.Point(192, 160);
			this.txtResDocClass.TabIndex = 5;
			this.txtResDocClass.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtResDocClass.AcceptsReturn = true;
			this.txtResDocClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtResDocClass.BackColor = System.Drawing.SystemColors.Window;
			this.txtResDocClass.CausesValidation = true;
			this.txtResDocClass.Enabled = true;
			this.txtResDocClass.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtResDocClass.HideSelection = true;
			this.txtResDocClass.ReadOnly = false;
			this.txtResDocClass.MaxLength = 0;
			this.txtResDocClass.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtResDocClass.Multiline = false;
			this.txtResDocClass.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtResDocClass.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtResDocClass.TabStop = true;
			this.txtResDocClass.Visible = true;
			this.txtResDocClass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtResDocClass.Name = "txtResDocClass";
			this.txtIMSLibName.AutoSize = false;
			this.txtIMSLibName.Size = new System.Drawing.Size(177, 25);
			this.txtIMSLibName.Location = new System.Drawing.Point(192, 16);
			this.txtIMSLibName.TabIndex = 1;
			this.txtIMSLibName.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIMSLibName.AcceptsReturn = true;
			this.txtIMSLibName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtIMSLibName.BackColor = System.Drawing.SystemColors.Window;
			this.txtIMSLibName.CausesValidation = true;
			this.txtIMSLibName.Enabled = true;
			this.txtIMSLibName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtIMSLibName.HideSelection = true;
			this.txtIMSLibName.ReadOnly = false;
			this.txtIMSLibName.MaxLength = 0;
			this.txtIMSLibName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtIMSLibName.Multiline = false;
			this.txtIMSLibName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtIMSLibName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtIMSLibName.TabStop = true;
			this.txtIMSLibName.Visible = true;
			this.txtIMSLibName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtIMSLibName.Name = "txtIMSLibName";
			this.cmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClear.Text = "Clear settings";
			this.cmdClear.Size = new System.Drawing.Size(97, 41);
			this.cmdClear.Location = new System.Drawing.Point(122, 218);
			this.cmdClear.TabIndex = 7;
			this.cmdClear.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmdClear.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClear.CausesValidation = true;
			this.cmdClear.Enabled = true;
			this.cmdClear.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClear.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClear.TabStop = true;
			this.cmdClear.Name = "cmdClear";
			this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSave.Text = "Save settings";
			this.cmdSave.Size = new System.Drawing.Size(97, 41);
			this.cmdSave.Location = new System.Drawing.Point(20, 218);
			this.cmdSave.TabIndex = 6;
			this.cmdSave.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmdSave.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSave.CausesValidation = true;
			this.cmdSave.Enabled = true;
			this.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSave.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSave.TabStop = true;
			this.cmdSave.Name = "cmdSave";
			this.txtResFolder.AutoSize = false;
			this.txtResFolder.Size = new System.Drawing.Size(177, 25);
			this.txtResFolder.Location = new System.Drawing.Point(192, 125);
			this.txtResFolder.TabIndex = 4;
			this.txtResFolder.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtResFolder.AcceptsReturn = true;
			this.txtResFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtResFolder.BackColor = System.Drawing.SystemColors.Window;
			this.txtResFolder.CausesValidation = true;
			this.txtResFolder.Enabled = true;
			this.txtResFolder.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtResFolder.HideSelection = true;
			this.txtResFolder.ReadOnly = false;
			this.txtResFolder.MaxLength = 0;
			this.txtResFolder.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtResFolder.Multiline = false;
			this.txtResFolder.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtResFolder.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtResFolder.TabStop = true;
			this.txtResFolder.Visible = true;
			this.txtResFolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtResFolder.Name = "txtResFolder";
			this.txtIMSPassword.AutoSize = false;
			this.txtIMSPassword.Size = new System.Drawing.Size(177, 25);
			this.txtIMSPassword.Location = new System.Drawing.Point(192, 86);
			this.txtIMSPassword.TabIndex = 3;
			this.txtIMSPassword.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIMSPassword.AcceptsReturn = true;
			this.txtIMSPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtIMSPassword.BackColor = System.Drawing.SystemColors.Window;
			this.txtIMSPassword.CausesValidation = true;
			this.txtIMSPassword.Enabled = true;
			this.txtIMSPassword.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtIMSPassword.HideSelection = true;
			this.txtIMSPassword.ReadOnly = false;
			this.txtIMSPassword.MaxLength = 0;
			this.txtIMSPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtIMSPassword.Multiline = false;
			this.txtIMSPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtIMSPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtIMSPassword.TabStop = true;
			this.txtIMSPassword.Visible = true;
			this.txtIMSPassword.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtIMSPassword.Name = "txtIMSPassword";
			this.txtIMSUser.AutoSize = false;
			this.txtIMSUser.Size = new System.Drawing.Size(177, 25);
			this.txtIMSUser.Location = new System.Drawing.Point(192, 50);
			this.txtIMSUser.TabIndex = 2;
			this.txtIMSUser.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIMSUser.AcceptsReturn = true;
			this.txtIMSUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtIMSUser.BackColor = System.Drawing.SystemColors.Window;
			this.txtIMSUser.CausesValidation = true;
			this.txtIMSUser.Enabled = true;
			this.txtIMSUser.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtIMSUser.HideSelection = true;
			this.txtIMSUser.ReadOnly = false;
			this.txtIMSUser.MaxLength = 0;
			this.txtIMSUser.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtIMSUser.Multiline = false;
			this.txtIMSUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtIMSUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtIMSUser.TabStop = true;
			this.txtIMSUser.Visible = true;
			this.txtIMSUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtIMSUser.Name = "txtIMSUser";
			this.Label9.Text = "Resume DocClass:";
			this.Label9.Size = new System.Drawing.Size(105, 25);
			this.Label9.Location = new System.Drawing.Point(50, 168);
			this.Label9.TabIndex = 13;
			this.Label9.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label9.BackColor = System.Drawing.SystemColors.Control;
			this.Label9.Enabled = true;
			this.Label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label9.UseMnemonic = true;
			this.Label9.Visible = true;
			this.Label9.AutoSize = false;
			this.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label9.Name = "Label9";
			this.Label8.Text = "IDMIS Library";
			this.Label8.Size = new System.Drawing.Size(89, 25);
			this.Label8.Location = new System.Drawing.Point(48, 24);
			this.Label8.TabIndex = 12;
			this.Label8.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label8.BackColor = System.Drawing.SystemColors.Control;
			this.Label8.Enabled = true;
			this.Label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label8.UseMnemonic = true;
			this.Label8.Visible = true;
			this.Label8.AutoSize = false;
			this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label8.Name = "Label8";
			this.Label3.Text = "Resume Folder:";
			this.Label3.Size = new System.Drawing.Size(89, 25);
			this.Label3.Location = new System.Drawing.Point(50, 133);
			this.Label3.TabIndex = 11;
			this.Label3.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Enabled = true;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Label2.Text = "IDMIS Password:";
			this.Label2.Size = new System.Drawing.Size(89, 25);
			this.Label2.Location = new System.Drawing.Point(48, 96);
			this.Label2.TabIndex = 10;
			this.Label2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.SystemColors.Control;
			this.Label2.Enabled = true;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.Label1.Text = "IDMIS Usercode:";
			this.Label1.Size = new System.Drawing.Size(89, 25);
			this.Label1.Location = new System.Drawing.Point(48, 56);
			this.Label1.TabIndex = 0;
			this.Label1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.Controls.Add(btnCancel);
			this.Controls.Add(btnOk);
			this.Controls.Add(txtResDocClass);
			this.Controls.Add(txtIMSLibName);
			this.Controls.Add(cmdClear);
			this.Controls.Add(cmdSave);
			this.Controls.Add(txtResFolder);
			this.Controls.Add(txtIMSPassword);
			this.Controls.Add(txtIMSUser);
			this.Controls.Add(Label9);
			this.Controls.Add(Label8);
			this.Controls.Add(Label3);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			this.ResumeLayout(false);
			this.PerformLayout();
	}
#endregion 
}
}