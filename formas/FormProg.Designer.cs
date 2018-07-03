using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace DocEntry
{
	partial class FormProg
	{
	
#region "Upgrade Support "
		private static FormProg m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static FormProg DefInstance
		{
			get
			{
				if (m_vb6FormDefInstance == null || m_vb6FormDefInstance.IsDisposed)
				{
					m_InitializingDefInstance = true;
					m_vb6FormDefInstance = new FormProg();
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
		public FormProg():base(){
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
	//public  AxComCtl2.AxAnimation Animation1;
	public  System.Windows.Forms.TextBox Text1;
	public  System.Windows.Forms.Label txtMax;
	public  System.Windows.Forms.Label txtMin;
	public  System.Windows.Forms.Label Label1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProg));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        //this.Animation1 = new AxComCtl2.AxAnimation();
        this.Text1 = new System.Windows.Forms.TextBox();
        this.txtMax = new System.Windows.Forms.Label();
        this.txtMin = new System.Windows.Forms.Label();
        this.Label1 = new System.Windows.Forms.Label();
        //((System.ComponentModel.ISupportInitialize)(this.Animation1)).BeginInit();
        this.SuspendLayout();
        // 
        // Animation1
        // 
        /*
        this.Animation1.Location = new System.Drawing.Point(200, 48);
        this.Animation1.Name = "Animation1";
        this.Animation1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Animation1.OcxState")));
        this.Animation1.Size = new System.Drawing.Size(137, 41);
        this.Animation1.TabIndex = 3;
        */
        // 
        // Text1
        // 
        this.Text1.AcceptsReturn = true;
        this.Text1.BackColor = System.Drawing.SystemColors.Window;
        this.Text1.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Text1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Text1.ForeColor = System.Drawing.SystemColors.WindowText;
        this.Text1.Location = new System.Drawing.Point(128, 104);
        this.Text1.MaxLength = 0;
        this.Text1.Name = "Text1";
        this.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Text1.Size = new System.Drawing.Size(321, 41);
        this.Text1.TabIndex = 1;
        // 
        // txtMax
        // 
        this.txtMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.txtMax.Cursor = System.Windows.Forms.Cursors.Default;
        this.txtMax.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtMax.ForeColor = System.Drawing.SystemColors.ControlText;
        this.txtMax.Location = new System.Drawing.Point(416, 64);
        this.txtMax.Name = "txtMax";
        this.txtMax.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtMax.Size = new System.Drawing.Size(33, 17);
        this.txtMax.TabIndex = 2;
        this.txtMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // txtMin
        // 
        this.txtMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.txtMin.Cursor = System.Windows.Forms.Cursors.Default;
        this.txtMin.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtMin.ForeColor = System.Drawing.SystemColors.ControlText;
        this.txtMin.Location = new System.Drawing.Point(128, 64);
        this.txtMin.Name = "txtMin";
        this.txtMin.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtMin.Size = new System.Drawing.Size(33, 17);
        this.txtMin.TabIndex = 4;
        // 
        // Label1
        // 
        this.Label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
        this.Label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Label1.Location = new System.Drawing.Point(32, 112);
        this.Label1.Name = "Label1";
        this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Label1.Size = new System.Drawing.Size(73, 25);
        this.Label1.TabIndex = 0;
        this.Label1.Text = "Uploading:";
        // 
        // FormProg
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.ClientSize = new System.Drawing.Size(508, 173);
        //this.Controls.Add(this.Animation1);
        this.Controls.Add(this.Text1);
        this.Controls.Add(this.txtMax);
        this.Controls.Add(this.txtMin);
        this.Controls.Add(this.Label1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Location = new System.Drawing.Point(4, 23);
        this.Name = "FormProg";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Text = "Performing Document Committal...";
        //((System.ComponentModel.ISupportInitialize)(this.Animation1)).EndInit();
        this.ResumeLayout(false);

	}
#endregion 
}
}