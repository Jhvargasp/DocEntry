using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace DocEntry
{
    public partial class FormMain
    {

        #region "Upgrade Support "
        private static FormMain m_vb6FormDefInstance;
        private static bool m_InitializingDefInstance;
        public static FormMain DefInstance
        {
            get
            {
                if (m_vb6FormDefInstance == null || m_vb6FormDefInstance.IsDisposed)
                {
                    m_InitializingDefInstance = true;
                    m_vb6FormDefInstance = new FormMain();                   
                    m_vb6FormDefInstance.Closed += new System.EventHandler(m_vb6FormDefInstance.releaseResources);
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
        public FormMain()
            : base()
        {
            //This call is required by the Windows Form Designer.


            InitializeComponent();
            Form_Initialize_Renamed();
        }
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode]
        protected override void Dispose(bool Disposing)
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
        public AxScanLibCtl.AxImgScan ImgScan1;
        // linea comentada por referencia a objetos errados.
        //AIS319 - DVega: Llamada a referencia no valida.
        //public  AxGEAR81Lib.AxGear81_ Gear1;
        public System.Windows.Forms.TextBox TxtCliente;
        public System.Windows.Forms.TextBox TxtContrato;
        public System.Windows.Forms.TextBox TxtLinea;
        public System.Windows.Forms.TextBox TxtFolioS403;
        public System.Windows.Forms.ComboBox CboTipoDoc;
        public System.Windows.Forms.TextBox TxtFolioUOC;
        public System.Windows.Forms.ComboBox CboUOC;
        public System.Windows.Forms.Label LblCliente;
        public System.Windows.Forms.Label LblContrato;
        public System.Windows.Forms.Label LblLinea;
        public System.Windows.Forms.Label LblFolioS403;
        public System.Windows.Forms.Label TxtTipoDoc;
        public System.Windows.Forms.Label LblFolioUOC;
        public System.Windows.Forms.Label LblUoc;
        public System.Windows.Forms.Panel SSPanel1;
        private System.Windows.Forms.TabPage _SSTab1_TabPage0;
        //public AxIDMListView.AxIDMListView IDMListView1;
        private System.Windows.Forms.TabPage _SSTab1_TabPage1;
        public System.Windows.Forms.TabControl SSTab1;
        public System.Windows.Forms.Button BtnSalvar;
        public System.Windows.Forms.Button BtnPrint;
        public System.Windows.Forms.Button BtnFileNET;
        public System.Windows.Forms.Button BtnScanear;
        public System.Windows.Forms.Button BtnCancel;
        public System.Windows.Forms.Button BtnRestart;
        public System.Windows.Forms.Button BtnDone;
        public System.Windows.Forms.GroupBox X;
        public System.Windows.Forms.OpenFileDialog CommonDialog1;
        public System.Windows.Forms.Button BtnCancelar;
        public System.Windows.Forms.Button BtnOkInserta;
        public System.Windows.Forms.Button BtnInsertPag;
        public System.Windows.Forms.Button BtnDeletePage;
        public System.Windows.Forms.Button BtnZoomOut;
        public System.Windows.Forms.Button BtnZoomIn;
        public System.Windows.Forms.Button BtnRotate;
        public System.Windows.Forms.Button BtnRotateLeft;
        public System.Windows.Forms.GroupBox Frame1;
        public System.Windows.Forms.Button BtnNext;
        public System.Windows.Forms.Button BtnPrevious;
        public System.Windows.Forms.Button BtnDelete;
        public AxAdminLibCtl.AxImgAdmin ImgAdmin1;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough]


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BtnPrint = new System.Windows.Forms.Button();
            this.BtnFileNET = new System.Windows.Forms.Button();
            this.BtnScanear = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnRestart = new System.Windows.Forms.Button();
            this.BtnDone = new System.Windows.Forms.Button();
            this.BtnInsertPag = new System.Windows.Forms.Button();
            this.BtnDeletePage = new System.Windows.Forms.Button();
            this.BtnZoomOut = new System.Windows.Forms.Button();
            this.BtnZoomIn = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnPrevious = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.CboResol = new System.Windows.Forms.ComboBox();
            this.BtnPDFtoTIFF = new System.Windows.Forms.Button();
            this.BtnSaveas = new System.Windows.Forms.Button();
            this.SSTab1 = new System.Windows.Forms.TabControl();
            this._SSTab1_TabPage0 = new System.Windows.Forms.TabPage();
            this.SSPanel1 = new System.Windows.Forms.Panel();
            this.TxtCliente = new System.Windows.Forms.TextBox();
            this.TxtContrato = new System.Windows.Forms.TextBox();
            this.TxtLinea = new System.Windows.Forms.TextBox();
            this.TxtFolioS403 = new System.Windows.Forms.TextBox();
            this.CboTipoDoc = new System.Windows.Forms.ComboBox();
            this.TxtFolioUOC = new System.Windows.Forms.TextBox();
            this.CboUOC = new System.Windows.Forms.ComboBox();
            this.LblCliente = new System.Windows.Forms.Label();
            this.LblContrato = new System.Windows.Forms.Label();
            this.LblLinea = new System.Windows.Forms.Label();
            this.LblFolioS403 = new System.Windows.Forms.Label();
            this.TxtTipoDoc = new System.Windows.Forms.Label();
            this.LblFolioUOC = new System.Windows.Forms.Label();
            this.LblUoc = new System.Windows.Forms.Label();
            this._SSTab1_TabPage1 = new System.Windows.Forms.TabPage();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.X = new System.Windows.Forms.GroupBox();
            this.Frame1 = new System.Windows.Forms.GroupBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnOkInserta = new System.Windows.Forms.Button();
            this.BtnRotate = new System.Windows.Forms.Button();
            this.BtnRotateLeft = new System.Windows.Forms.Button();
            this.CommonDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.LblMsg = new System.Windows.Forms.Label();
            this.SPCont = new System.Windows.Forms.SplitContainer();
            this.viewImage1 = new ViewImages.ViewImage();
            //this.ViewerCtrl1 = new AxIDMViewerCtrl.AxIDMViewerCtrl();
            //this.ViewerCtrl2 = new AxIDMViewerCtrl.AxIDMViewerCtrl();
            this.ImgScan1 = new AxScanLibCtl.AxImgScan();
            //this.IDMListView1 = new AxIDMListView.AxIDMListView();
            this.ImgAdmin1 = new AxAdminLibCtl.AxImgAdmin();
            this.SSTab1.SuspendLayout();
            this._SSTab1_TabPage0.SuspendLayout();
            this.SSPanel1.SuspendLayout();
            this._SSTab1_TabPage1.SuspendLayout();
            this.X.SuspendLayout();
            this.Frame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SPCont)).BeginInit();
            this.SPCont.Panel1.SuspendLayout();
            this.SPCont.Panel2.SuspendLayout();
            this.SPCont.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)(this.ViewerCtrl1)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.ViewerCtrl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgScan1)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.IDMListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgAdmin1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnPrint
            // 
            this.BtnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.BtnPrint.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnPrint.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrint.Image")));
            this.BtnPrint.Location = new System.Drawing.Point(314, 8);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnPrint.Size = new System.Drawing.Size(42, 39);
            this.BtnPrint.TabIndex = 38;
            this.BtnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.BtnPrint, "Imprimir Imágen Activa");
            this.BtnPrint.UseVisualStyleBackColor = false;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnFileNET
            // 
            this.BtnFileNET.BackColor = System.Drawing.SystemColors.Control;
            this.BtnFileNET.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnFileNET.BackgroundImage")));
            this.BtnFileNET.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnFileNET.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnFileNET.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFileNET.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnFileNET.Location = new System.Drawing.Point(4, 10);
            this.BtnFileNET.Name = "BtnFileNET";
            this.BtnFileNET.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnFileNET.Size = new System.Drawing.Size(64, 37);
            this.BtnFileNET.TabIndex = 18;
            this.BtnFileNET.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.BtnFileNET, "Imagen FileNET");
            this.BtnFileNET.UseVisualStyleBackColor = false;
            this.BtnFileNET.Click += new System.EventHandler(this.BtnFileNET_Click);
            // 
            // BtnScanear
            // 
            this.BtnScanear.BackColor = System.Drawing.SystemColors.Control;
            this.BtnScanear.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnScanear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnScanear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnScanear.Image = ((System.Drawing.Image)(resources.GetObject("BtnScanear.Image")));
            this.BtnScanear.Location = new System.Drawing.Point(75, 9);
            this.BtnScanear.Name = "BtnScanear";
            this.BtnScanear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnScanear.Size = new System.Drawing.Size(40, 38);
            this.BtnScanear.TabIndex = 11;
            this.BtnScanear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.BtnScanear, "Scaner Imagen");
            this.BtnScanear.UseVisualStyleBackColor = false;
            this.BtnScanear.Click += new System.EventHandler(this.BtnScanear_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancel.Image")));
            this.BtnCancel.Location = new System.Drawing.Point(362, 8);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnCancel.Size = new System.Drawing.Size(43, 39);
            this.BtnCancel.TabIndex = 10;
            this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.BtnCancel, "Cancel/Exit");
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnRestart
            // 
            this.BtnRestart.BackColor = System.Drawing.SystemColors.Control;
            this.BtnRestart.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnRestart.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRestart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnRestart.Image = ((System.Drawing.Image)(resources.GetObject("BtnRestart.Image")));
            this.BtnRestart.Location = new System.Drawing.Point(118, 9);
            this.BtnRestart.Name = "BtnRestart";
            this.BtnRestart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnRestart.Size = new System.Drawing.Size(40, 38);
            this.BtnRestart.TabIndex = 9;
            this.BtnRestart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.BtnRestart, "FaxSys");
            this.BtnRestart.UseVisualStyleBackColor = false;
            this.BtnRestart.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // BtnDone
            // 
            this.BtnDone.BackColor = System.Drawing.SystemColors.Control;
            this.BtnDone.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnDone.Enabled = false;
            this.BtnDone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnDone.Image = ((System.Drawing.Image)(resources.GetObject("BtnDone.Image")));
            this.BtnDone.Location = new System.Drawing.Point(162, 8);
            this.BtnDone.Name = "BtnDone";
            this.BtnDone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnDone.Size = new System.Drawing.Size(38, 39);
            this.BtnDone.TabIndex = 8;
            this.BtnDone.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.BtnDone, "Guardar Imágen");
            this.BtnDone.UseVisualStyleBackColor = false;
            this.BtnDone.Click += new System.EventHandler(this.BtnDone_Click);
            // 
            // BtnInsertPag
            // 
            this.BtnInsertPag.BackColor = System.Drawing.SystemColors.Control;
            this.BtnInsertPag.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnInsertPag.Enabled = false;
            this.BtnInsertPag.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInsertPag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnInsertPag.Image = ((System.Drawing.Image)(resources.GetObject("BtnInsertPag.Image")));
            this.BtnInsertPag.Location = new System.Drawing.Point(201, 12);
            this.BtnInsertPag.Name = "BtnInsertPag";
            this.BtnInsertPag.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnInsertPag.Size = new System.Drawing.Size(38, 38);
            this.BtnInsertPag.TabIndex = 13;
            this.BtnInsertPag.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.BtnInsertPag, "Insertar Páginas");
            this.BtnInsertPag.UseVisualStyleBackColor = false;
            this.BtnInsertPag.Click += new System.EventHandler(this.BtnInsertPag_Click);
            // 
            // BtnDeletePage
            // 
            this.BtnDeletePage.BackColor = System.Drawing.SystemColors.Control;
            this.BtnDeletePage.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnDeletePage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeletePage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnDeletePage.Image = ((System.Drawing.Image)(resources.GetObject("BtnDeletePage.Image")));
            this.BtnDeletePage.Location = new System.Drawing.Point(151, 12);
            this.BtnDeletePage.Name = "BtnDeletePage";
            this.BtnDeletePage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnDeletePage.Size = new System.Drawing.Size(35, 38);
            this.BtnDeletePage.TabIndex = 6;
            this.BtnDeletePage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.BtnDeletePage, "Borrar Página");
            this.BtnDeletePage.UseVisualStyleBackColor = false;
            this.BtnDeletePage.Click += new System.EventHandler(this.BtnDeletePage_Click);
            // 
            // BtnZoomOut
            // 
            this.BtnZoomOut.BackColor = System.Drawing.SystemColors.Control;
            this.BtnZoomOut.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnZoomOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnZoomOut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("BtnZoomOut.Image")));
            this.BtnZoomOut.Location = new System.Drawing.Point(118, 13);
            this.BtnZoomOut.Name = "BtnZoomOut";
            this.BtnZoomOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnZoomOut.Size = new System.Drawing.Size(33, 37);
            this.BtnZoomOut.TabIndex = 5;
            this.BtnZoomOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.BtnZoomOut, "Zoom Out");
            this.BtnZoomOut.UseVisualStyleBackColor = false;
            this.BtnZoomOut.Click += new System.EventHandler(this.BtnZoomOut_Click);
            // 
            // BtnZoomIn
            // 
            this.BtnZoomIn.BackColor = System.Drawing.SystemColors.Control;
            this.BtnZoomIn.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnZoomIn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnZoomIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("BtnZoomIn.Image")));
            this.BtnZoomIn.Location = new System.Drawing.Point(83, 13);
            this.BtnZoomIn.Name = "BtnZoomIn";
            this.BtnZoomIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnZoomIn.Size = new System.Drawing.Size(35, 37);
            this.BtnZoomIn.TabIndex = 4;
            this.BtnZoomIn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.BtnZoomIn, "Zoom In");
            this.BtnZoomIn.UseVisualStyleBackColor = false;
            this.BtnZoomIn.Click += new System.EventHandler(this.BtnZoomIn_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.BackColor = System.Drawing.SystemColors.Control;
            this.BtnNext.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnNext.Enabled = false;
            this.BtnNext.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnNext.Image = ((System.Drawing.Image)(resources.GetObject("BtnNext.Image")));
            this.BtnNext.Location = new System.Drawing.Point(0, 0);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnNext.Size = new System.Drawing.Size(45, 39);
            this.BtnNext.TabIndex = 16;
            this.BtnNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.BtnNext, "Next Doc");
            this.BtnNext.UseVisualStyleBackColor = false;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnPrevious
            // 
            this.BtnPrevious.BackColor = System.Drawing.SystemColors.Control;
            this.BtnPrevious.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnPrevious.Enabled = false;
            this.BtnPrevious.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrevious.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrevious.Image")));
            this.BtnPrevious.Location = new System.Drawing.Point(45, 0);
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnPrevious.Size = new System.Drawing.Size(45, 39);
            this.BtnPrevious.TabIndex = 17;
            this.BtnPrevious.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.BtnPrevious, "Previous Doc");
            this.BtnPrevious.UseVisualStyleBackColor = false;
            this.BtnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(0, 0);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(92, 25);
            this.BtnDelete.TabIndex = 19;
            this.ToolTip1.SetToolTip(this.BtnDelete, "Borra Imágen Activa");
            this.BtnDelete.Visible = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // CboResol
            // 
            this.CboResol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboResol.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboResol.FormattingEnabled = true;
            this.CboResol.Items.AddRange(new object[] {
            "200",
            "300",
            "400"});
            this.CboResol.Location = new System.Drawing.Point(247, 17);
            this.CboResol.Name = "CboResol";
            this.CboResol.Size = new System.Drawing.Size(54, 24);
            this.CboResol.TabIndex = 39;
            this.ToolTip1.SetToolTip(this.CboResol, "Resolución de la imágen");
            // 
            // BtnPDFtoTIFF
            // 
            this.BtnPDFtoTIFF.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnPDFtoTIFF.BackgroundImage")));
            this.BtnPDFtoTIFF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPDFtoTIFF.Location = new System.Drawing.Point(335, 12);
            this.BtnPDFtoTIFF.Name = "BtnPDFtoTIFF";
            this.BtnPDFtoTIFF.Size = new System.Drawing.Size(69, 36);
            this.BtnPDFtoTIFF.TabIndex = 16;
            this.ToolTip1.SetToolTip(this.BtnPDFtoTIFF, "convertir un archivo PDF a TIFF");
            this.BtnPDFtoTIFF.UseVisualStyleBackColor = true;
            this.BtnPDFtoTIFF.Click += new System.EventHandler(this.BtnPDFtoTIFF_Click);
            // 
            // BtnSaveas
            // 
            this.BtnSaveas.BackColor = System.Drawing.SystemColors.Control;
            this.BtnSaveas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSaveas.BackgroundImage")));
            this.BtnSaveas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSaveas.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnSaveas.Enabled = false;
            this.BtnSaveas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnSaveas.Location = new System.Drawing.Point(201, 8);
            this.BtnSaveas.Name = "BtnSaveas";
            this.BtnSaveas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnSaveas.Size = new System.Drawing.Size(38, 39);
            this.BtnSaveas.TabIndex = 40;
            this.BtnSaveas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.BtnSaveas, "Guardar Imágen cómo");
            this.BtnSaveas.UseVisualStyleBackColor = false;
            this.BtnSaveas.Click += new System.EventHandler(this.BtnSaveas_Click);
            // 
            // SSTab1
            // 
            this.SSTab1.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.SSTab1.Controls.Add(this._SSTab1_TabPage0);
            this.SSTab1.Controls.Add(this._SSTab1_TabPage1);
            this.SSTab1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSTab1.ItemSize = new System.Drawing.Size(42, 18);
            this.SSTab1.Location = new System.Drawing.Point(2, 0);
            this.SSTab1.Multiline = true;
            this.SSTab1.Name = "SSTab1";
            this.SSTab1.SelectedIndex = 0;
            this.SSTab1.Size = new System.Drawing.Size(587, 112);
            this.SSTab1.TabIndex = 21;
            // 
            // _SSTab1_TabPage0
            // 
            this._SSTab1_TabPage0.Controls.Add(this.SSPanel1);
            this._SSTab1_TabPage0.Location = new System.Drawing.Point(4, 4);
            this._SSTab1_TabPage0.Name = "_SSTab1_TabPage0";
            this._SSTab1_TabPage0.Size = new System.Drawing.Size(561, 104);
            this._SSTab1_TabPage0.TabIndex = 0;
            this._SSTab1_TabPage0.Text = "Criterios";
            // 
            // SSPanel1
            // 
            this.SSPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.SSPanel1.Controls.Add(this.TxtCliente);
            this.SSPanel1.Controls.Add(this.TxtContrato);
            this.SSPanel1.Controls.Add(this.TxtLinea);
            this.SSPanel1.Controls.Add(this.TxtFolioS403);
            this.SSPanel1.Controls.Add(this.CboTipoDoc);
            this.SSPanel1.Controls.Add(this.TxtFolioUOC);
            this.SSPanel1.Controls.Add(this.CboUOC);
            this.SSPanel1.Controls.Add(this.LblCliente);
            this.SSPanel1.Controls.Add(this.LblContrato);
            this.SSPanel1.Controls.Add(this.LblLinea);
            this.SSPanel1.Controls.Add(this.LblFolioS403);
            this.SSPanel1.Controls.Add(this.TxtTipoDoc);
            this.SSPanel1.Controls.Add(this.LblFolioUOC);
            this.SSPanel1.Controls.Add(this.LblUoc);
            this.SSPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SSPanel1.Location = new System.Drawing.Point(0, 0);
            this.SSPanel1.Name = "SSPanel1";
            this.SSPanel1.Size = new System.Drawing.Size(561, 104);
            this.SSPanel1.TabIndex = 22;
            // 
            // TxtCliente
            // 
            this.TxtCliente.AcceptsReturn = true;
            this.TxtCliente.BackColor = System.Drawing.SystemColors.Window;
            this.TxtCliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtCliente.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCliente.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtCliente.Location = new System.Drawing.Point(77, 35);
            this.TxtCliente.MaxLength = 12;
            this.TxtCliente.Name = "TxtCliente";
            this.TxtCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtCliente.Size = new System.Drawing.Size(89, 20);
            this.TxtCliente.TabIndex = 29;
            this.TxtCliente.TextChanged += new System.EventHandler(this.TxtCliente_TextChanged);
            this.TxtCliente.Enter += new System.EventHandler(this.TxtCliente_Enter);
            // 
            // TxtContrato
            // 
            this.TxtContrato.AcceptsReturn = true;
            this.TxtContrato.BackColor = System.Drawing.SystemColors.Window;
            this.TxtContrato.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtContrato.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContrato.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtContrato.Location = new System.Drawing.Point(77, 69);
            this.TxtContrato.MaxLength = 12;
            this.TxtContrato.Name = "TxtContrato";
            this.TxtContrato.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtContrato.Size = new System.Drawing.Size(89, 20);
            this.TxtContrato.TabIndex = 28;
            this.TxtContrato.TextChanged += new System.EventHandler(this.TxtContrato_TextChanged);
            this.TxtContrato.Enter += new System.EventHandler(this.TxtContrato_Enter);
            // 
            // TxtLinea
            // 
            this.TxtLinea.AcceptsReturn = true;
            this.TxtLinea.BackColor = System.Drawing.SystemColors.Window;
            this.TxtLinea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtLinea.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLinea.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtLinea.Location = new System.Drawing.Point(282, 35);
            this.TxtLinea.MaxLength = 4;
            this.TxtLinea.Name = "TxtLinea";
            this.TxtLinea.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtLinea.Size = new System.Drawing.Size(51, 20);
            this.TxtLinea.TabIndex = 27;
            this.TxtLinea.TextChanged += new System.EventHandler(this.TxtLinea_TextChanged);
            this.TxtLinea.Enter += new System.EventHandler(this.TxtLinea_Enter);
            // 
            // TxtFolioS403
            // 
            this.TxtFolioS403.AcceptsReturn = true;
            this.TxtFolioS403.BackColor = System.Drawing.SystemColors.Window;
            this.TxtFolioS403.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtFolioS403.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFolioS403.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtFolioS403.Location = new System.Drawing.Point(282, 69);
            this.TxtFolioS403.MaxLength = 4;
            this.TxtFolioS403.Name = "TxtFolioS403";
            this.TxtFolioS403.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtFolioS403.Size = new System.Drawing.Size(51, 20);
            this.TxtFolioS403.TabIndex = 26;
            this.TxtFolioS403.TextChanged += new System.EventHandler(this.TxtFolioS403_TextChanged);
            this.TxtFolioS403.Enter += new System.EventHandler(this.TxtFolioS403_Enter);
            // 
            // CboTipoDoc
            // 
            this.CboTipoDoc.BackColor = System.Drawing.SystemColors.Window;
            this.CboTipoDoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.CboTipoDoc.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoDoc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CboTipoDoc.Location = new System.Drawing.Point(77, 4);
            this.CboTipoDoc.Name = "CboTipoDoc";
            this.CboTipoDoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CboTipoDoc.Size = new System.Drawing.Size(462, 20);
            this.CboTipoDoc.Sorted = true;
            this.CboTipoDoc.TabIndex = 25;
            this.CboTipoDoc.SelectedIndexChanged += new System.EventHandler(this.CboTipoDoc_SelectedIndexChanged);
            this.CboTipoDoc.Click += new System.EventHandler(this.CboTipoDoc_Click);
            // 
            // TxtFolioUOC
            // 
            this.TxtFolioUOC.AcceptsReturn = true;
            this.TxtFolioUOC.BackColor = System.Drawing.SystemColors.Window;
            this.TxtFolioUOC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtFolioUOC.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFolioUOC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtFolioUOC.Location = new System.Drawing.Point(460, 69);
            this.TxtFolioUOC.MaxLength = 18;
            this.TxtFolioUOC.Name = "TxtFolioUOC";
            this.TxtFolioUOC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtFolioUOC.Size = new System.Drawing.Size(77, 20);
            this.TxtFolioUOC.TabIndex = 24;
            this.TxtFolioUOC.TextChanged += new System.EventHandler(this.TxtFolioUOC_TextChanged);
            this.TxtFolioUOC.Enter += new System.EventHandler(this.TxtFolioUOC_Enter);
            // 
            // CboUOC
            // 
            this.CboUOC.BackColor = System.Drawing.SystemColors.Window;
            this.CboUOC.Cursor = System.Windows.Forms.Cursors.Default;
            this.CboUOC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboUOC.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboUOC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CboUOC.Items.AddRange(new object[] {
            "4519",
            "4520",
            "4521",
            "2557",
            "3236"});
            this.CboUOC.Location = new System.Drawing.Point(459, 35);
            this.CboUOC.Name = "CboUOC";
            this.CboUOC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CboUOC.Size = new System.Drawing.Size(79, 22);
            this.CboUOC.TabIndex = 23;
            // 
            // LblCliente
            // 
            this.LblCliente.BackColor = System.Drawing.SystemColors.Window;
            this.LblCliente.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCliente.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblCliente.Location = new System.Drawing.Point(21, 43);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblCliente.Size = new System.Drawing.Size(57, 12);
            this.LblCliente.TabIndex = 36;
            this.LblCliente.Text = "Cliente :";
            this.LblCliente.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblContrato
            // 
            this.LblContrato.AutoSize = true;
            this.LblContrato.BackColor = System.Drawing.SystemColors.Window;
            this.LblContrato.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblContrato.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblContrato.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblContrato.Location = new System.Drawing.Point(17, 75);
            this.LblContrato.Name = "LblContrato";
            this.LblContrato.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblContrato.Size = new System.Drawing.Size(61, 14);
            this.LblContrato.TabIndex = 35;
            this.LblContrato.Text = "Contrato :";
            this.LblContrato.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblLinea
            // 
            this.LblLinea.BackColor = System.Drawing.SystemColors.Window;
            this.LblLinea.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblLinea.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLinea.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblLinea.Location = new System.Drawing.Point(232, 43);
            this.LblLinea.Name = "LblLinea";
            this.LblLinea.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblLinea.Size = new System.Drawing.Size(51, 14);
            this.LblLinea.TabIndex = 34;
            this.LblLinea.Text = "Línea :";
            this.LblLinea.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblFolioS403
            // 
            this.LblFolioS403.AutoSize = true;
            this.LblFolioS403.BackColor = System.Drawing.SystemColors.Window;
            this.LblFolioS403.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblFolioS403.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFolioS403.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblFolioS403.Location = new System.Drawing.Point(222, 76);
            this.LblFolioS403.Name = "LblFolioS403";
            this.LblFolioS403.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblFolioS403.Size = new System.Drawing.Size(61, 14);
            this.LblFolioS403.TabIndex = 33;
            this.LblFolioS403.Text = "FolioS403:";
            this.LblFolioS403.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TxtTipoDoc
            // 
            this.TxtTipoDoc.AutoSize = true;
            this.TxtTipoDoc.BackColor = System.Drawing.SystemColors.Window;
            this.TxtTipoDoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.TxtTipoDoc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTipoDoc.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TxtTipoDoc.Location = new System.Drawing.Point(9, 6);
            this.TxtTipoDoc.Name = "TxtTipoDoc";
            this.TxtTipoDoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtTipoDoc.Size = new System.Drawing.Size(71, 14);
            this.TxtTipoDoc.TabIndex = 32;
            this.TxtTipoDoc.Text = "Tipo Docto :";
            // 
            // LblFolioUOC
            // 
            this.LblFolioUOC.AutoSize = true;
            this.LblFolioUOC.BackColor = System.Drawing.SystemColors.Window;
            this.LblFolioUOC.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblFolioUOC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFolioUOC.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblFolioUOC.Location = new System.Drawing.Point(397, 76);
            this.LblFolioUOC.Name = "LblFolioUOC";
            this.LblFolioUOC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblFolioUOC.Size = new System.Drawing.Size(62, 14);
            this.LblFolioUOC.TabIndex = 31;
            this.LblFolioUOC.Text = "Folio UOC:";
            this.LblFolioUOC.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblUoc
            // 
            this.LblUoc.BackColor = System.Drawing.SystemColors.Window;
            this.LblUoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblUoc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUoc.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblUoc.Location = new System.Drawing.Point(423, 43);
            this.LblUoc.Name = "LblUoc";
            this.LblUoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblUoc.Size = new System.Drawing.Size(36, 14);
            this.LblUoc.TabIndex = 30;
            this.LblUoc.Text = "UOC :";
            this.LblUoc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _SSTab1_TabPage1
            // 
//            this._SSTab1_TabPage1.Controls.Add(this.IDMListView1);
            this._SSTab1_TabPage1.Location = new System.Drawing.Point(4, 4);
            this._SSTab1_TabPage1.Name = "_SSTab1_TabPage1";
            this._SSTab1_TabPage1.Size = new System.Drawing.Size(561, 104);
            this._SSTab1_TabPage1.TabIndex = 1;
            this._SSTab1_TabPage1.Text = "Asignación";
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.BackColor = System.Drawing.SystemColors.Control;
            this.BtnSalvar.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnSalvar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalvar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnSalvar.Location = new System.Drawing.Point(498, 3);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnSalvar.Size = new System.Drawing.Size(91, 25);
            this.BtnSalvar.TabIndex = 20;
            this.BtnSalvar.Text = "Guardar Imágen";
            this.BtnSalvar.UseVisualStyleBackColor = false;
            this.BtnSalvar.Visible = false;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // X
            // 
            this.X.BackColor = System.Drawing.SystemColors.Window;
            this.X.Controls.Add(this.BtnSaveas);
            this.X.Controls.Add(this.CboResol);
            this.X.Controls.Add(this.BtnPrint);
            this.X.Controls.Add(this.BtnFileNET);
            this.X.Controls.Add(this.BtnScanear);
            this.X.Controls.Add(this.BtnCancel);
            this.X.Controls.Add(this.BtnRestart);
            this.X.Controls.Add(this.BtnDone);
            this.X.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X.ForeColor = System.Drawing.SystemColors.ControlText;
            this.X.Location = new System.Drawing.Point(595, 52);
            this.X.Name = "X";
            this.X.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.X.Size = new System.Drawing.Size(417, 53);
            this.X.TabIndex = 7;
            this.X.TabStop = false;
            // 
            // Frame1
            // 
            this.Frame1.BackColor = System.Drawing.SystemColors.Window;
            this.Frame1.Controls.Add(this.BtnPDFtoTIFF);
            this.Frame1.Controls.Add(this.BtnCancelar);
            this.Frame1.Controls.Add(this.BtnOkInserta);
            this.Frame1.Controls.Add(this.BtnInsertPag);
            this.Frame1.Controls.Add(this.BtnDeletePage);
            this.Frame1.Controls.Add(this.BtnZoomOut);
            this.Frame1.Controls.Add(this.BtnZoomIn);
            this.Frame1.Controls.Add(this.BtnRotate);
            this.Frame1.Controls.Add(this.BtnRotateLeft);
            this.Frame1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame1.Location = new System.Drawing.Point(595, -1);
            this.Frame1.Name = "Frame1";
            this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frame1.Size = new System.Drawing.Size(417, 54);
            this.Frame1.TabIndex = 0;
            this.Frame1.TabStop = false;
            this.Frame1.Text = "Página";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnCancelar.Enabled = false;
            this.BtnCancelar.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnCancelar.Location = new System.Drawing.Point(276, 12);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnCancelar.Size = new System.Drawing.Size(44, 38);
            this.BtnCancelar.TabIndex = 15;
            this.BtnCancelar.Text = "Cancel";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnOkInserta
            // 
            this.BtnOkInserta.BackColor = System.Drawing.SystemColors.Control;
            this.BtnOkInserta.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnOkInserta.Enabled = false;
            this.BtnOkInserta.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOkInserta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnOkInserta.Location = new System.Drawing.Point(238, 12);
            this.BtnOkInserta.Name = "BtnOkInserta";
            this.BtnOkInserta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnOkInserta.Size = new System.Drawing.Size(39, 38);
            this.BtnOkInserta.TabIndex = 14;
            this.BtnOkInserta.Text = "OK";
            this.BtnOkInserta.UseVisualStyleBackColor = false;
            this.BtnOkInserta.Click += new System.EventHandler(this.BtnOkInserta_Click);
            // 
            // BtnRotate
            // 
            this.BtnRotate.BackColor = System.Drawing.SystemColors.Control;
            this.BtnRotate.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnRotate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRotate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnRotate.Image = ((System.Drawing.Image)(resources.GetObject("BtnRotate.Image")));
            this.BtnRotate.Location = new System.Drawing.Point(38, 13);
            this.BtnRotate.Name = "BtnRotate";
            this.BtnRotate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnRotate.Size = new System.Drawing.Size(34, 37);
            this.BtnRotate.TabIndex = 3;
            this.BtnRotate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnRotate.UseVisualStyleBackColor = false;
            this.BtnRotate.Click += new System.EventHandler(this.BtnRotate_Click);
            // 
            // BtnRotateLeft
            // 
            this.BtnRotateLeft.BackColor = System.Drawing.SystemColors.Control;
            this.BtnRotateLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnRotateLeft.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRotateLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnRotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("BtnRotateLeft.Image")));
            this.BtnRotateLeft.Location = new System.Drawing.Point(4, 13);
            this.BtnRotateLeft.Name = "BtnRotateLeft";
            this.BtnRotateLeft.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnRotateLeft.Size = new System.Drawing.Size(34, 37);
            this.BtnRotateLeft.TabIndex = 1;
            this.BtnRotateLeft.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnRotateLeft.UseVisualStyleBackColor = false;
            this.BtnRotateLeft.Click += new System.EventHandler(this.BtnRotateLeft_Click);
            // 
            // LblMsg
            // 
            this.LblMsg.AutoSize = true;
            this.LblMsg.BackColor = System.Drawing.Color.White;
            this.LblMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblMsg.Enabled = false;
            this.LblMsg.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMsg.ForeColor = System.Drawing.Color.Black;
            this.LblMsg.Location = new System.Drawing.Point(392, 409);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(306, 25);
            this.LblMsg.TabIndex = 24;
            this.LblMsg.Text = "Espere por favor .... guardando Imágen";
            this.LblMsg.Visible = false;
            // 
            // SPCont
            // 
            this.SPCont.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SPCont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SPCont.Location = new System.Drawing.Point(2, 111);
            this.SPCont.Name = "SPCont";
            // 
            // SPCont.Panel1
            // 
            this.SPCont.Panel1.Controls.Add(this.viewImage1);
//            this.SPCont.Panel1.Controls.Add(this.ViewerCtrl1);
            // 
            // SPCont.Panel2
            // 
  //          this.SPCont.Panel2.Controls.Add(this.ViewerCtrl2);
            this.SPCont.Panel2Collapsed = true;
            this.SPCont.Size = new System.Drawing.Size(1010, 607);
            this.SPCont.SplitterDistance = 25;
            this.SPCont.SplitterWidth = 2;
            this.SPCont.TabIndex = 26;
            // 
            // viewImage1
            // 
            this.viewImage1.AutoScroll = true;
            this.viewImage1.AutoSize = true;
            this.viewImage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewImage1.Location = new System.Drawing.Point(0, 0);
            this.viewImage1.Name = "viewImage1";
            this.viewImage1.pArchivo = "";
            this.viewImage1.Size = new System.Drawing.Size(1006, 603);
            this.viewImage1.TabIndex = 27;
            // 
            // ViewerCtrl1
            // 
            /*
            this.ViewerCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewerCtrl1.Enabled = true;
            this.ViewerCtrl1.Location = new System.Drawing.Point(0, 0);
            this.ViewerCtrl1.Name = "ViewerCtrl1";
            this.ViewerCtrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ViewerCtrl1.OcxState")));
            this.ViewerCtrl1.Size = new System.Drawing.Size(1006, 603);
            this.ViewerCtrl1.TabIndex = 26;
            // 
            // ViewerCtrl2
            // 
            this.ViewerCtrl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewerCtrl2.Enabled = true;
            this.ViewerCtrl2.Location = new System.Drawing.Point(0, 0);
            this.ViewerCtrl2.Name = "ViewerCtrl2";
            this.ViewerCtrl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ViewerCtrl2.OcxState")));
            this.ViewerCtrl2.Size = new System.Drawing.Size(92, 96);
            this.ViewerCtrl2.TabIndex = 13;
            this.ViewerCtrl2.Visible = false;
            */
            // 
            // ImgScan1
            // 
            this.ImgScan1.Enabled = true;
            this.ImgScan1.Location = new System.Drawing.Point(11, 658);
            this.ImgScan1.Name = "ImgScan1";
            this.ImgScan1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ImgScan1.OcxState")));
            this.ImgScan1.Size = new System.Drawing.Size(61, 47);
            this.ImgScan1.TabIndex = 0;
            this.ImgScan1.ScanStarted += new System.EventHandler(this.ImgScan1_ScanStarted);
            this.ImgScan1.ScanDone += new System.EventHandler(this.ImgScan1_ScanDone);
            // 
            // IDMListView1
            // 
            /*
            this.IDMListView1.Location = new System.Drawing.Point(3, 4);
            this.IDMListView1.Name = "IDMListView1";
            this.IDMListView1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("IDMListView1.OcxState")));
            this.IDMListView1.Size = new System.Drawing.Size(555, 97);
            this.IDMListView1.TabIndex = 37;
            this.IDMListView1.DblClick += new System.EventHandler(this.IDMListView1_DblClick);
            */
            // 
            // ImgAdmin1
            // 
            this.ImgAdmin1.Enabled = true;
            this.ImgAdmin1.Location = new System.Drawing.Point(6, 393);
            this.ImgAdmin1.Name = "ImgAdmin1";
            this.ImgAdmin1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ImgAdmin1.OcxState")));
            this.ImgAdmin1.Size = new System.Drawing.Size(49, 27);
            this.ImgAdmin1.TabIndex = 23;
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1017, 720);
            this.Controls.Add(this.LblMsg);
            this.Controls.Add(this.SPCont);
//            this.Controls.Add(this.ImgScan1);
            this.Controls.Add(this.SSTab1);
            this.Controls.Add(this.BtnSalvar);
            this.Controls.Add(this.X);
            this.Controls.Add(this.Frame1);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnPrevious);
            this.Controls.Add(this.BtnDelete);
//            this.Controls.Add(this.ImgAdmin1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 23);
            this.Name = "FormMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrada de Documentos a FileNET .Net";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closed += new System.EventHandler(this.FormMain_Closed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SSTab1.ResumeLayout(false);
            this._SSTab1_TabPage0.ResumeLayout(false);
            this.SSPanel1.ResumeLayout(false);
            this.SSPanel1.PerformLayout();
            this._SSTab1_TabPage1.ResumeLayout(false);
            this.X.ResumeLayout(false);
            this.Frame1.ResumeLayout(false);
            this.SPCont.Panel1.ResumeLayout(false);
            this.SPCont.Panel1.PerformLayout();
            this.SPCont.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SPCont)).EndInit();
            this.SPCont.ResumeLayout(false);
            //((System.ComponentModel.ISupportInitialize)(this.ViewerCtrl1)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.ViewerCtrl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgScan1)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.IDMListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgAdmin1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label LblMsg;
        private System.Windows.Forms.SplitContainer SPCont;
        //public AxIDMViewerCtrl.AxIDMViewerCtrl ViewerCtrl2;
        //public AxIDMViewerCtrl.AxIDMViewerCtrl ViewerCtrl1;
        private ViewImages.ViewImage viewImage1;
        private System.Windows.Forms.ComboBox CboResol;
        private System.Windows.Forms.Button BtnPDFtoTIFF;
        public System.Windows.Forms.Button BtnSaveas;
        

    }
}