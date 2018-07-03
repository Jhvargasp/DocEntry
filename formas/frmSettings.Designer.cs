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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.textWorkplace = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textResUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(324, 281);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(97, 41);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.Control;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOk.Location = new System.Drawing.Point(224, 281);
            this.btnOk.Name = "btnOk";
            this.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnOk.Size = new System.Drawing.Size(97, 41);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtResDocClass
            // 
            this.txtResDocClass.AcceptsReturn = true;
            this.txtResDocClass.BackColor = System.Drawing.SystemColors.Window;
            this.txtResDocClass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtResDocClass.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResDocClass.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtResDocClass.Location = new System.Drawing.Point(192, 160);
            this.txtResDocClass.MaxLength = 0;
            this.txtResDocClass.Name = "txtResDocClass";
            this.txtResDocClass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtResDocClass.Size = new System.Drawing.Size(177, 25);
            this.txtResDocClass.TabIndex = 5;
            // 
            // txtIMSLibName
            // 
            this.txtIMSLibName.AcceptsReturn = true;
            this.txtIMSLibName.BackColor = System.Drawing.SystemColors.Window;
            this.txtIMSLibName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIMSLibName.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIMSLibName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIMSLibName.Location = new System.Drawing.Point(192, 16);
            this.txtIMSLibName.MaxLength = 0;
            this.txtIMSLibName.Name = "txtIMSLibName";
            this.txtIMSLibName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIMSLibName.Size = new System.Drawing.Size(177, 25);
            this.txtIMSLibName.TabIndex = 1;
            // 
            // cmdClear
            // 
            this.cmdClear.BackColor = System.Drawing.SystemColors.Control;
            this.cmdClear.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdClear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdClear.Location = new System.Drawing.Point(122, 281);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdClear.Size = new System.Drawing.Size(97, 41);
            this.cmdClear.TabIndex = 7;
            this.cmdClear.Text = "Clear settings";
            this.cmdClear.UseVisualStyleBackColor = false;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSave.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSave.Location = new System.Drawing.Point(20, 281);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSave.Size = new System.Drawing.Size(97, 41);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "Save settings";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // txtResFolder
            // 
            this.txtResFolder.AcceptsReturn = true;
            this.txtResFolder.BackColor = System.Drawing.SystemColors.Window;
            this.txtResFolder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtResFolder.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResFolder.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtResFolder.Location = new System.Drawing.Point(192, 125);
            this.txtResFolder.MaxLength = 0;
            this.txtResFolder.Name = "txtResFolder";
            this.txtResFolder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtResFolder.Size = new System.Drawing.Size(177, 25);
            this.txtResFolder.TabIndex = 4;
            // 
            // txtIMSPassword
            // 
            this.txtIMSPassword.AcceptsReturn = true;
            this.txtIMSPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtIMSPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIMSPassword.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIMSPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIMSPassword.Location = new System.Drawing.Point(192, 86);
            this.txtIMSPassword.MaxLength = 0;
            this.txtIMSPassword.Name = "txtIMSPassword";
            this.txtIMSPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIMSPassword.Size = new System.Drawing.Size(177, 25);
            this.txtIMSPassword.TabIndex = 3;
            // 
            // txtIMSUser
            // 
            this.txtIMSUser.AcceptsReturn = true;
            this.txtIMSUser.BackColor = System.Drawing.SystemColors.Window;
            this.txtIMSUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIMSUser.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIMSUser.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIMSUser.Location = new System.Drawing.Point(192, 50);
            this.txtIMSUser.MaxLength = 0;
            this.txtIMSUser.Name = "txtIMSUser";
            this.txtIMSUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIMSUser.Size = new System.Drawing.Size(177, 25);
            this.txtIMSUser.TabIndex = 2;
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.SystemColors.Control;
            this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label9.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label9.Location = new System.Drawing.Point(50, 168);
            this.Label9.Name = "Label9";
            this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label9.Size = new System.Drawing.Size(105, 25);
            this.Label9.TabIndex = 13;
            this.Label9.Text = "Resume DocClass:";
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.SystemColors.Control;
            this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label8.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label8.Location = new System.Drawing.Point(48, 24);
            this.Label8.Name = "Label8";
            this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label8.Size = new System.Drawing.Size(89, 25);
            this.Label8.TabIndex = 12;
            this.Label8.Text = "IDMIS Library";
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.SystemColors.Control;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(50, 133);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(89, 25);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "Resume Folder:";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(48, 96);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(89, 25);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "IDMIS Password:";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(48, 56);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(89, 25);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "IDMIS Usercode:";
            // 
            // textWorkplace
            // 
            this.textWorkplace.AcceptsReturn = true;
            this.textWorkplace.BackColor = System.Drawing.SystemColors.Window;
            this.textWorkplace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textWorkplace.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textWorkplace.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textWorkplace.Location = new System.Drawing.Point(192, 239);
            this.textWorkplace.MaxLength = 0;
            this.textWorkplace.Name = "textWorkplace";
            this.textWorkplace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textWorkplace.Size = new System.Drawing.Size(177, 20);
            this.textWorkplace.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(50, 240);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(105, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "URL Workplace:";
            // 
            // textResUrl
            // 
            this.textResUrl.AcceptsReturn = true;
            this.textResUrl.BackColor = System.Drawing.SystemColors.Window;
            this.textResUrl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textResUrl.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textResUrl.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textResUrl.Location = new System.Drawing.Point(192, 200);
            this.textResUrl.MaxLength = 0;
            this.textResUrl.Name = "textResUrl";
            this.textResUrl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textResUrl.Size = new System.Drawing.Size(177, 20);
            this.textResUrl.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(50, 201);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(105, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "URL Soap WS:";
            // 
            // frmSettings
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(441, 355);
            this.Controls.Add(this.textWorkplace);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textResUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtResDocClass);
            this.Controls.Add(this.txtIMSLibName);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtResFolder);
            this.Controls.Add(this.txtIMSPassword);
            this.Controls.Add(this.txtIMSUser);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 23);
            this.Name = "frmSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

	}
        #endregion

        public System.Windows.Forms.TextBox textWorkplace;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textResUrl;
        public System.Windows.Forms.Label label4;
    }
}