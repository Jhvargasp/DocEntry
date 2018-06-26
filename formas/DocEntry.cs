using System.Globalization;
using Microsoft.VisualBasic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging; 
using System.Windows.Forms;
using System;

//ImageGear Accusoft
using ImageGear;
using ImageGear.Core;
using ImageGear.Formats;
using ImageGear.Processing;
using ImageGear.Display;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using Microsoft.VisualBasic.Devices;
using ReadQR;


namespace DocEntry
{

    public partial class FormMain
        : System.Windows.Forms.Form
    {

        bool NavForward = false;
        public string DirWinTemp = String.Empty;
        int RotateAmount = 0;
        private int BandeInsert = 0;
        private byte Bande = 0;
        int CommCount = 0; // Count of docs marked for committal
        //private AxIDMViewerCtrl.AxIDMViewerCtrl ViewerCtrlX;

        //FileStream fs;
        //Bitmap srcBmp;
        //int totalPages = 0;
        //int currentPage = 0;

        private void SetLVHeaders(Collection cHeadings, Collection cPropNames)
        {
            string[] asClasses = new string[2];

            //asClasses(0) = gfSettings.txtResDocClass
            asClasses[0] = "ExpedientesDC";

            //Set goPropDescs = oLibrary.FilterPropertyDescriptions(idmObjTypeDocument, _
            //'asClasses)
            //Module1.goPropDescs = (IDMObjects.PropertyDescriptions)Module1.oLibrary.FilterPropertyDescriptions(IDMObjects.idmObjectType.idmObjTypeDocument, asClasses);
            Module1.goPropDescs = Module1.oLibrary.FilterPropertyDescriptions(IDMObjects.idmObjectType.idmObjTypeDocument, asClasses);
            IDMListView1.ClearColumnHeaders(Module1.oLibrary);
            IDMListView1.ClearItems();
            foreach (IDMObjects.PropertyDescription oPropDesc in Module1.goPropDescs)
            {
                if (oPropDesc.Name.Substring(0, Math.Min(oPropDesc.Name.Length, 2)) != "F_" && (oPropDesc.Name == "UOC" || oPropDesc.Name == "Folio" || oPropDesc.Name == "Contrato" || oPropDesc.Name == "NumCliente" || oPropDesc.Name == "Linea" || oPropDesc.Name == "TipoDoc" || oPropDesc.Name == "FolioS403" || oPropDesc.Name == "Producto" || oPropDesc.Name == "Instrumento" || oPropDesc.Name == "XfolioS" || oPropDesc.Name == "CalificaOnDemand"))
                {
                    if (Bande == 0)
                    {
                        IDMListView1.AddColumnHeader(Module1.oLibrary, oPropDesc, Type.Missing, Type.Missing, Type.Missing);
                        cHeadings.Add(oPropDesc.Label, null, null, null);
                        cPropNames.Add(oPropDesc.Name, null, null, null);
                    }
                }
            }
            Bande = 1;
            IDMListView1.SwitchColumnHeaders(Module1.oLibrary);
        }

        private void Valida_Controles()
        {
            Module1.XTipoDoc = 999;
            TxtContrato.Visible = false;
            TxtLinea.Visible = false;
            TxtFolioS403.Visible = false;
            TxtContrato.Text = String.Empty;
            TxtLinea.Text = String.Empty;
            TxtFolioS403.Text = String.Empty;
            if (CboTipoDoc.SelectedIndex > -1)
            {
                Module1.XTipoDoc = VB6.GetItemData(CboTipoDoc, CboTipoDoc.SelectedIndex);
                switch (Module1.XTipoDoc)
                {
                    case 80:
                    case 87:
                    case 32:
                    case 104:
                    case 85:
                    case 111:
                    case 113:
                    case 90:
                    case 88:
                    case 92:
                    case 89:
                    case 91:
                    case 93:
                        TxtContrato.Visible = true;
                        TxtLinea.Visible = true;
                        break;
                    case 81:
                    case 196:
                    case 197:
                    case 198:
                    case 101:
                    case 100:
                        TxtContrato.Visible = true;
                        TxtLinea.Visible = true;
                        TxtFolioS403.Visible = true;
                        break;
                    case 86:
                    case 97:
                    case 99:
                    case 107:
                    case 96:
                        TxtContrato.Visible = true;
                        TxtFolioS403.Visible = true;
                        break;
                    case 1:
                    case 7:
                    case 108:
                    case 147:
                        TxtContrato.Visible = false;
                        TxtLinea.Visible = false;
                        TxtFolioS403.Visible = false;
                        break;
                    default:
                        TxtContrato.Visible = true;
                        TxtLinea.Visible = true;
                        TxtFolioS403.Visible = true;
                        break;
                }
            }
        }
        
        private object Llena_TipoDocto()
        {
            string REGISTROACTUAL = String.Empty;
            string DescDoc = String.Empty;
            int PosFin = 0;
            int PosIni = 0;
            string TipDoc = String.Empty;
            string Archivo = Module1.DirConf + "DocEntry.ini";
            CboTipoDoc.Items.Clear();
            FileSystem.FileOpen(1, Archivo, OpenMode.Input, OpenAccess.Default, OpenShare.Default, -1);

            while (!FileSystem.EOF(1))
            {
                REGISTROACTUAL = FileSystem.LineInput(1);
                PosIni = 1;
                PosFin = Strings.InStr(PosIni, REGISTROACTUAL, "|", CompareMethod.Text);
                TipDoc = Strings.Mid(REGISTROACTUAL, PosIni, PosFin - 1);
                PosIni = PosFin + 1;
                PosFin = REGISTROACTUAL.Length;
                DescDoc = Strings.Mid(REGISTROACTUAL, PosIni, PosFin + 1);
                CboTipoDoc.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(DescDoc, (int)Conversion.Val(TipDoc)));
            };
            FileSystem.FileClose(1);
            return null;
        }

        private object Llena_UOCs()
        {
            string REGISTROACTUAL = String.Empty;
           
            string Archivo = Module1.DirConf + "UOCs.ini";
            if (File.Exists(Archivo))
            {
                FileSystem.FileOpen(1, Archivo, OpenMode.Input, OpenAccess.Default, OpenShare.Default, -1);
                CboUOC.Items.Clear();
                while (!FileSystem.EOF(1))
                {
                    REGISTROACTUAL = FileSystem.LineInput(1);
                    CboUOC.Items.Add(REGISTROACTUAL);
                }
                FileSystem.FileClose(1);
            }
            return null;
        }

        private bool ConnectToLibraries()
        {
            bool result = false;
            try
            {
                RestoreSettings(false);
                // Make sure we have some valid library ID's
                if (Module1.gfSettings.txtIMSLibName.Text == "")
                {
                    RestoreSettings(true);
                }
                if (Module1.gfSettings.txtIMSLibName.Text == "")
                {
                    MessageBox.Show(this, "You must first set the runtime parameters!", Application.ProductName);
                    return false;
                }
                // We may have been here before, so clean up any old library
                // connections
                if (Module1.gbISLogOff)
                {
                    Module1.oLibrary.Logoff();
                }
                Module1.oLibrary = null;

                // Hook up to the IMS library
                Module1.oLibrary.SystemType = IDMObjects.idmSysTypeOptions.idmSysTypeIS;
                Module1.oLibrary.Name = Module1.gfSettings.txtIMSLibName.Text;
                if (!Module1.oLibrary.GetState(IDMObjects.idmLibraryState.idmLibraryLoggedOn))
                {
                    Module1.oLibrary.Logon(Module1.gfSettings.txtIMSUser, Module1.gfSettings.txtIMSPassword, Type.Missing, IDMObjects.idmLibraryLogon.idmLogonOptNoUI);
                    Module1.gbISLogOff = true;
                    result = true;
                }
                else
                {
                    Module1.gbISLogOff = false;
                    if (IDMObjects.idmLibraryState.idmLibraryLoggedOn != IDMObjects.idmLibraryState.idmLibraryLoggedOn)
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                        Module1.gbISLogOff = true;
                    }
                }

            }
            catch (Exception excep)
            {

                MessageBox.Show(this, excep.Message, Application.ProductName);
                result = false;
            }
            return result;
        }
        // Routine for restoring Registry settings dealing with
        // IDMLibrary information
        private void RestoreSettings(bool bForceUi)
        {
            if (bForceUi)
            {
                Module1.gfSettings.ShowDialog();
            }
            else
            {
                Module1.goPersist.GetSettings(Module1.gsAppName, Module1.gsSectionName, Module1.gfSettings);
            }
        }

        public void LoadFiles(byte Index)
        {
            bool ErrHandler = false;
            string FileNameList = String.Empty;
            string Pathpart = String.Empty;
            // Trap cancel as an error
            try
            {
                switch (Index)
                {
                    case 0:
                        ErrHandler = true;
                        CommonDialog1.ShowReadOnly = false;
                        CommonDialog1.Multiselect = true;
                        CommonDialog1.Filter = "Documentos (*.pdf, *.tif, *.tiff)|*.tif;*.tiff;*.pdf";

                        // Specify default filter 
                        CommonDialog1.FilterIndex = 1;
                        // Display the Open dialog box 
                        if (CommonDialog1.ShowDialog() != DialogResult.OK)
                            throw new Exception("User cancel operation");
                        // Display name of selected file
                        if (CommonDialog1.FileName != string.Empty) {
                            
                            //AVG Ini Sept-2015
                            if (!this.isTifDocument(CommonDialog1.FileName.Trim()))
                            {
                                Computer MyComputer = new Computer();
                                MyComputer.FileSystem.CurrentDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\ReadQR";
                                ReadQR.Program.TipoConvPDF = ReadQR.Program.ArchivePDFtoArchiveTiff;
                                ReadQR.Program.ArchivePDForTIFF = CommonDialog1.FileName.Trim();
                                ReadQR.Program.RutaAppWork = Path.GetDirectoryName(Application.ExecutablePath) + "\\ReadQR";
                                ReadQR.Program.ProcessQRs = 1;
                                ReadQR.Program.MuestraForma();  
                                MyComputer.FileSystem.CurrentDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                                string temp = CommonDialog1.SafeFileName.Substring(0, CommonDialog1.SafeFileName.Length - 3) + "tif";
                                temp = Module1.TmpImg + "ImgWork\\" + temp;
                                if (File.Exists(temp)) 
                                {
                                    CommonDialog1.FileName = temp;
                                }
                            }
                            //AVG Fin Sept-2015
                            ImgAdmin1.Image = null;
                            Module1.DocList[Index].fileName = "";
                            if (ImgScan1.Image != string.Empty) {
                                ImgScan1.Image = string.Empty;
                            }
                            if ( ViewerCtrl2.Visible ==  false)
                            {
                                ViewerCtrl1.PageNumber = 1;
                                ViewerCtrl1.DocumentFilename = ""; //String.Empty;
                                Module1.TotalDocs = 0;
                                CommCount = 0;
                                Module1.XArchivo = Module1.TmpImg + "img1.tif";
                                BandeInsert = 0;
                            }
                            else
                            {
                                ViewerCtrl2.DocumentFilename = ""; //String.Empty;
                                ViewerCtrl2.PageNumber = 1;
                                Module1.XArchivo = Module1.TmpImg + "img2.tif";
                            }

                            if (File.Exists(Module1.XArchivo))
                            {                                
                                try { File.Delete(Module1.XArchivo); }
                                catch { }
                            }
                            try { File.Copy(CommonDialog1.FileName, Module1.XArchivo); }
                            catch { }
                            FileNameList = Module1.XArchivo;
                        }
                        return;
                        break;
                    case 1:
                            if (BandeInsert == 0)
                            {
                                FileNameList = Module1.TmpImg + "img1.tif";
                                Module1.XArchivo = Module1.TmpImg + "img1.tif";
                            }
                            else
                            {
                                Module1.XArchivo = Module1.TmpImg + "img2.tif";
                            }
                        return;
                        break;
                        
                    case 2:
                        FileNameList = Module1.XArchivo;
                        Module1.XArchivo = Module1.TmpImg + "img1.tif";
                        if (File.Exists(FileNameList)) {                            
                            if (File.Exists(Module1.XArchivo))
                            {
                                try { File.Delete(Module1.XArchivo); }
                                catch { }
                            }
                            try {File.Copy(FileNameList, Module1.XArchivo); }
                            catch { }
                            try { File.Delete(FileNameList); }
                            catch { }
                        }
                        FileNameList = Module1.XArchivo;
                        return;
                        break;
                    case 3:
                        FileNameList = Module1.DocList[0].fileName;
                        break;
                    case 4:
                        if (BandeInsert == 0)
                        {
                            FileNameList = Module1.TmpImg + "img1.tif";
                            Module1.XArchivo = Module1.TmpImg + "img1.tif";
                        }
                        else
                        {
                            Module1.XArchivo = Module1.TmpImg + "img2.tif";
                        }
                        return;
                        break;

                    case 5:
                        switch (BandeInsert)
                        {
                            case 0:
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                Application.DoEvents();
                                Application.DoEvents();
                                //if (File.Exists(Module1.DocList[inx].fileName))
                                if (File.Exists(Module1.XArchivo))
                                {
                                    //fs = File.Open(Module1.XArchivo, FileMode.Open);
                                    //srcBmp = ((Bitmap)Bitmap.FromStream(fs));
                                    //totalPages =  Convert.ToInt32(srcBmp.SelectActiveFrame(FrameDimension.Page, currentPage));
                                    //uxPicture.Image = srcBmp; 

                                    if (File.Exists(Module1.TmpImg + "VisalImg.tmp"))
                                    {
                                        File.Delete(Module1.TmpImg + "VisalImg.tmp"); 
                                    }
                                    viewImage1.CloseDocument();
                                    File.Copy(Module1.XArchivo, Module1.TmpImg + "VisalImg.tmp");
                                    viewImage1.pArchivo = Module1.TmpImg + "VisalImg.tmp";
                                    viewImage1.LoadDocument();
                                    
                                    ViewerCtrl1.DocumentFilename = "";
                                    ViewerCtrl1.BeginInit();
                                    ViewerCtrl1.Clear();
                                    ViewerCtrl1.PageNumber = 1;                                     
                                    ViewerCtrl1.DocumentFilename = Module1.XArchivo;
                                    RotateAmount = 0;
                                    ViewerCtrl1.Rotation = 0;
                                    //ViewerCtrl1.Brightness = (IDMViewerCtrl.idmBrightness)IDMObjects.idmBrightness.idmBrightnessDarker;
                                    ViewerCtrl1.Refresh();

                                    if (Module1.TipoOper != 7)
                                    {
                                        AdjustButtons(0);
                                    }
                                    BandeInsert = 1;
                                    BtnInsertPag.Enabled = true;
                                }
                                                                
                                break;
                            case 7:
                                FileNameList = Module1.XArchivo;
                                break;
                            default:
                                if (BandeInsert == 1 && Module1.XArchivo.Trim().Length > 0)
                                {
                                    if (File.Exists(Module1.XArchivo))
                                    {
                                        ViewerCtrl2.DocumentFilename = "";
                                        ViewerCtrl2.BeginInit();
                                        ViewerCtrl2.Clear();
                                        ViewerCtrl2.PageNumber = 1;
                                        ViewerCtrl2.DocumentFilename = Module1.XArchivo;
                                        RotateAmount = 0;
                                        ViewerCtrl2.Rotation = 0;
                                        //ViewerCtrl2.Brightness = (IDMViewerCtrl.idmBrightness)IDMObjects.idmBrightness.idmBrightnessDarker;
                                        ViewerCtrl2.Refresh();
                                        BtnOkInserta.Enabled = true;
                                        BtnCancelar.Enabled = true;
                                    }
                                    AdjustButtons(1);
                                }
                                break;
                        }
                        
                        return;
                        break;

                }
                
                // We may have multiple names, separated by null
                int NullOffset = (int)(FileNameList.IndexOf(Strings.Chr(0)) + 1);
                int inx = 0;
                Module1.TotalDocs = 0;
                CommCount = 0;
                if (NullOffset > 0)
                {
                    Pathpart = FileNameList.Substring(0, Math.Min(FileNameList.Length, NullOffset - 1)) + "\\";
                    FileNameList = Strings.Mid(FileNameList, NullOffset + 1, 0);
                    while (FileNameList.Length > 0)
                    {

                        NullOffset = (int)(FileNameList.IndexOf(Strings.Chr(0)) + 1);
                        if (NullOffset > 0)
                        {
                            Module1.DocList[inx].fileName = Pathpart + FileNameList.Substring(0, Math.Min(FileNameList.Length, NullOffset - 1));
                            Module1.DocList[inx].CommitFlag = CommitValues.UnDecided;
                            Module1.TotalDocs++;
                            FileNameList = Strings.Mid(FileNameList, NullOffset + 1, 0);
                        }
                        else
                        {
                            Module1.DocList[inx].fileName = Pathpart + FileNameList;
                            Module1.DocList[inx].CommitFlag = CommitValues.UnDecided;
                            Module1.TotalDocs++;
                            FileNameList = "";
                        }
                        if (inx == Module1.ArraySz)
                        {
                            Module1.ArraySz = 2 * Module1.ArraySz;
                            DocInfo[] redimAux = new DocInfo[Module1.ArraySz + 1];
                            Array.Copy(Module1.DocList, redimAux, Math.Min(Module1.DocList.Length, redimAux.Length));
                            Module1.DocList = redimAux;
                            Module1.FinalList = new IDMObjects.Document[Module1.ArraySz + 1];
                            Module1.FolderList = new string[Module1.ArraySz + 1];
                        }
                        inx++;
                    }
                }
                else
                {
                    Module1.TotalDocs++;
                    Module1.DocList[0].fileName = FileNameList;
                    Module1.DocList[0].CommitFlag = CommitValues.UnDecided;
                    BtnInsertPag.Enabled = true;
                }

            }
            catch (Exception excep)
            {
                if (!ErrHandler)
                {
                    //throw excep;
                }

                if (ErrHandler)
                {

                    //User pressed the Cancel button
                    //He may already have Docs loaded up, so leave them
                    // alone
                    return;
                }
            }
        }

        private void AdjustButtons(int DocInx)
        {
            if (ViewerCtrl1.IsOperationSupported(IDMViewerCtrl.idmDocumentOperation.idmOpZoomInOut))
            {
                BtnZoomIn.Enabled = true;
                BtnZoomOut.Enabled = true;
                BtnRotateLeft.Enabled = true;
                BtnRotate.Enabled = true;
            }
            else
            {
                BtnZoomIn.Enabled = false;
                BtnZoomOut.Enabled = false;
                BtnRotateLeft.Enabled = false;
                BtnRotate.Enabled = false;
            }
            BtnRotate.Enabled = ViewerCtrl1.IsOperationSupported(IDMViewerCtrl.idmDocumentOperation.idmOpRotation);
            BtnDone.Enabled = true;
            BtnPrint.Enabled = true;
            //AVG Ini Setp-2015
            BtnSaveas.Enabled = true;
            //AVG Fin Setp-2015
            int Pag = ViewerCtrl1.Pages.Count;
            if (Pag > 1)
            {
               BtnDeletePage.Enabled = true;
            }
            else
            {
               BtnDeletePage.Enabled = false;
            }

            if (BandeInsert == 1)
            {
                if (Module1.XArchivo.Trim().Length > 0)
                {
                    
                    BtnOkInserta.Enabled = true;
                    BtnCancelar.Enabled = true;
                }
            }
            else
            {
                BtnOkInserta.Enabled = false;
                BtnCancelar.Enabled = false;
            }

            if (Module1.DocList[DocInx].CommitFlag == CommitValues.Commit)
            {
                // BtnCommit.Caption = "Decommit"
                //ImgCommitState.Picture = LoadPicture(HomeDirectory + "\Checkmrk.ico")
            }
            else
            {
                if (Module1.DocList[DocInx].CommitFlag == CommitValues.DontCommit)
                {
                    // BtnCommit.Caption = "Commit"
                    //ImgCommitState.Picture = LoadPicture(HomeDirectory + "\X.ico")
                }
                else
                {
                    // BtnCommit.Caption = "Commit"
                    //ImgCommitState.Picture = LoadPicture(HomeDirectory + "\Question.ico")
                }
            }

        }

        private void SaveDocument(int inx)
        {
                string[] sClasses = new string[1];
                //sClasses(0) = gfSettings.txtResDocClass
                sClasses[0] = "ExpedientesDC";
                //Set goPropDescs = oLibrary.FilterPropertyDescriptions(idmObjTypeDocument, _
                //'    sClasses)
                //On Error Resume Next
                //Module1.goPropDescs = (IDMObjects.PropertyDescriptions)Module1.oLibrary.FilterPropertyDescriptions(IDMObjects.idmObjectType.idmObjTypeDocument, sClasses);
                Module1.goPropDescs =  Module1.oLibrary.FilterPropertyDescriptions(IDMObjects.idmObjectType.idmObjTypeDocument, sClasses);
                //On Error Resume Next
                Module1.oDocument = (IDMObjects.Document)Module1.oLibrary.CreateObject(IDMObjects.idmObjectType.idmObjTypeDocument, sClasses[0], Type.Missing, Type.Missing, Type.Missing);
                //If Not goPropDescs("Cliente").GetState(idmPropReadOnly) Then
                if (Module1.XFecha.Length > 0)
                {
                    Module1.oDocument.Properties[Module1.goPropDescs["FechaOperacion"].Name].Value = Module1.XFecha;
                }
                if (!Module1.goPropDescs["NumCliente"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                {
                    if (Conversion.Val(TxtCliente.Text) > 0 && TxtCliente.Text.Trim().Length > 0)
                    {
                        Module1.oDocument.Properties[Module1.goPropDescs["NumCliente"].Name].Value = TxtCliente.Text.Trim();
                    }
                }
                if (!Module1.goPropDescs["Folio"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                {
                    if (Conversion.Val(TxtFolioUOC.Text) > 0 && TxtFolioUOC.Text.Trim().Length > 0)
                    {
                        Module1.oDocument.Properties[Module1.goPropDescs["Folio"].Name].Value = TxtFolioUOC.Text.Trim();
                    }
                }
                if (!Module1.goPropDescs["TipoDoc"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                {
                    if (CboTipoDoc.SelectedIndex > -1)
                    {
                        Module1.oDocument.Properties[Module1.goPropDescs["TipoDoc"].Name].Value = Module1.XTipoDoc; //CboTipoDoc.ItemData(CboTipoDoc.ListIndex)
                    }
                }
                if (!Module1.goPropDescs["UOC"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                {
                    if (Conversion.Val(CboUOC.Text) > 0 && CboUOC.Text.Trim().Length > 0)
                    {
                        Module1.oDocument.Properties[Module1.goPropDescs["UOC"].Name].Value = CboUOC.Text.Trim();
                    }
                }
                if (!Module1.goPropDescs["Contrato"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                {
                    if (Conversion.Val(TxtContrato.Text) > 0 && TxtContrato.Text.Trim().Length > 0)
                    {
                        Module1.oDocument.Properties[Module1.goPropDescs["Contrato"].Name].Value = TxtContrato.Text.Trim();
                    }
                }
                if (!Module1.goPropDescs["Linea"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                {
                    if (Conversion.Val(TxtLinea.Text) > 0 && TxtLinea.Text.Trim().Length > 0)
                    {
                        Module1.oDocument.Properties[Module1.goPropDescs["Linea"].Name].Value = TxtLinea.Text.Trim();
                    }
                }
                if (!Module1.goPropDescs["FolioS403"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                {
                    if (Conversion.Val(TxtFolioS403.Text) > 0 && TxtFolioS403.Text.Trim().Length > 0)
                    {
                        Module1.oDocument.Properties[Module1.goPropDescs["FolioS403"].Name].Value = TxtFolioS403.Text.Trim();
                    }
                }
                if (!Module1.goPropDescs["Status"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                {
                    Module1.oDocument.Properties[Module1.goPropDescs["Status"].Name].Value = 1;
                }
                if (!Module1.goPropDescs["Producto"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                {
                    if (!Convert.IsDBNull(Module1.XProd) && Strings.Len(Module1.XProd) > 0)
                    {
                        Module1.oDocument.Properties[Module1.goPropDescs["Producto"].Name].Value = Module1.XProd;
                    }
                }
                if (!Module1.goPropDescs["Instrumento"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                {
                    if (!Convert.IsDBNull(Module1.XInst) && Strings.Len(Module1.XInst) > 0)
                    {
                        Module1.oDocument.Properties[Module1.goPropDescs["Instrumento"].Name].Value = Module1.XInst;
                    }
                }
                if (!Module1.goPropDescs["XfolioS"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                {
                    if (!Convert.IsDBNull(Module1.XFile) && Strings.Len(Module1.XFile) > 0)
                    {
                        //oDocument.Properties(goPropDescs("XfilioS").Name).Value = XFile
                    }
                }
                if (!Module1.goPropDescs["CalificaOnDemand"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                {
                    if (!Convert.IsDBNull(Module1.XCalifOnd) && Strings.Len(Module1.XCalifOnd) > 0)
                    {
                        Module1.oDocument.Properties[Module1.goPropDescs["CalificaOnDemand"].Name].Value = Module1.XCalifOnd;
                    }
                }
                if (!Module1.goPropDescs["F_PAGES"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                {
                    Module1.oDocument.Properties[Module1.goPropDescs["F_PAGES"].Name].Value = ViewerCtrl1.Pages.Count;
                }
                //AVG Ini Sept-2015
                if (!Module1.goPropDescs["XfolioP"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                {
                    if (Conversion.Val(Module1.XSubFolio) > 0 && Module1.XSubFolio.Trim().Length > 0)
                    {
                        Module1.oDocument.Properties[Module1.goPropDescs["XfolioP"].Name].Value = Module1.XSubFolio;
                    }
                }
                //AVG Fin Sept-2015
                Module1.FinalList[Module1.CurrentDocInx] = Module1.oDocument;
                if (Module1.DocList[Module1.CurrentDocInx].CommitFlag == CommitValues.Commit)
                {
                    // Changed our mind - decommit
                    Module1.DocList[Module1.CurrentDocInx].CommitFlag = CommitValues.DontCommit;
                    // Clean up doc and properties
                    Module1.FinalList[Module1.CurrentDocInx] = null;
                    Module1.FolderList[Module1.CurrentDocInx] = "";
                    CommCount--;
                }
                else
                {
                    //PropertyForm.Tag = "0"
                    //PropertyForm.Show vbModal
                    //If PropertyForm.Tag = "1" Then
                    Module1.DocList[Module1.CurrentDocInx].CommitFlag = CommitValues.Commit;
                    CommCount++;
                    //Else
                    // the user cancelled out of the property stuff
                    //    DocList(CurrentDocInx).CommitFlag = UnDecided
                    //End If

                }
                CommCount = 1;
                //***************************************************************************


                // Enable the following tabs for editing
                IDMObjects.idmTabSelect tabSel = (IDMObjects.idmTabSelect)(((int)IDMObjects.idmTabSelect.idmTabSelectGeneral) ^ ((int)IDMObjects.idmTabSelect.idmTabSelectDocPreview));

                Module1.oDocument.SetPropertiesDialogEditMode(tabSel, true);

                // Disable the following tabs for editing
                tabSel = (IDMObjects.idmTabSelect)(((int)IDMObjects.idmTabSelect.idmTabSelectSecurity) ^ ((int)IDMObjects.idmTabSelect.idmTabSelectProperties));
                Module1.oDocument.SetPropertiesDialogEditMode(tabSel, false);

                //*****************************************************************************
                Module1.FolderList[Module1.CurrentDocInx] = "";
                Module1.DocList[Module1.CurrentDocInx].CommitFlag = CommitValues.Commit;
                //AdjustButtons(Module1.CurrentDocInx);
                //if (Module1.TotalDocs > 1)
                //{
                //    if (NavForward)
                //    {
                //        BtnNext_Click(BtnNext, new EventArgs());
                //    }
                //    else
                //    {
                //        BtnPrevious_Click(BtnPrevious, new EventArgs());
                //    }
                //}
                //BtnNext.Enabled = true;
        }

        private void LoadDocument(int inx)
        {
            bool OnErrorResumeNext = false;
            switch (BandeInsert)
            {
                case 0:
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Application.DoEvents();
                    Application.DoEvents(); 
                    //if (File.Exists(Module1.DocList[inx].fileName))
                    if (File.Exists(Module1.XArchivo))
                    {
                        ViewerCtrl1.BeginInit();
                        ViewerCtrl1.Clear();
                        ViewerCtrl1.PageNumber = 1;
                        ViewerCtrl1.DocumentFilename = Module1.XArchivo;
                        RotateAmount = 0;
                        ViewerCtrl1.Rotation = 0;
                        //ViewerCtrl1.Brightness = (IDMViewerCtrl.idmBrightness)IDMObjects.idmBrightness.idmBrightnessDarker;
                        ViewerCtrl1.Refresh();
                        BandeInsert = 1;                     
                    }
                    break;

                default:
                    if (BandeInsert == 1 && Module1.XArchivo.Trim().Length > 0)
                    {
                        if (File.Exists(Module1.XArchivo))
                        {
                            ViewerCtrl2.BeginInit();
                            ViewerCtrl2.Clear();
                            ViewerCtrl2.PageNumber = 1;
                            ViewerCtrl2.DocumentFilename = Module1.XArchivo;                        
                            RotateAmount = 0;
                            ViewerCtrl2.Rotation = 0;
                            //ViewerCtrl2.Brightness = (IDMViewerCtrl.idmBrightness)IDMObjects.idmBrightness.idmBrightnessDarker;
                            ViewerCtrl2.Refresh();
                            BtnOkInserta.Enabled = true;
                            BtnCancelar.Enabled = true;
                        }
                    }
                    break;
            }

            try { AdjustButtons(inx); }
            catch (Exception e1) { if (!OnErrorResumeNext)throw e1; }

            try { SaveDocument(inx); }
            catch (Exception e2) { if (!OnErrorResumeNext)throw e2; }

        }


        private void BtnCommit_Click()
        {
            if (Module1.DocList[Module1.CurrentDocInx].CommitFlag == CommitValues.Commit)
            {
                // Changed our mind - decommit
                Module1.DocList[Module1.CurrentDocInx].CommitFlag = CommitValues.DontCommit;
                // Clean up doc and properties
                Module1.FinalList[Module1.CurrentDocInx] = null;
                Module1.FolderList[Module1.CurrentDocInx] = "";
                CommCount--;
            }
            else
            {
                //PropertyForm.Tag = "0"
                //PropertyForm.Show vbModall
                //If PropertyForm.Tag = "1" Then
                Module1.DocList[Module1.CurrentDocInx].CommitFlag = CommitValues.Commit;
                CommCount++;
                //Else
                // the user cancelled out of the property stuff
                //    DocList(CurrentDocInx).CommitFlag = UnDecided
                //End If
            }
            AdjustButtons(Module1.CurrentDocInx);
            if (Module1.TotalDocs > 1)
            {
                if (NavForward)
                {
                    BtnNext_Click(BtnNext, new EventArgs());
                }
                else
                {
                    BtnPrevious_Click(BtnPrevious, new EventArgs());
                }
            }
        }

        private void BtnCancel_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close(); 
        }

        private void Pause(int Secs)
        {
            double Start = DateTime.Now.TimeOfDay.TotalSeconds;

            while (DateTime.Now.TimeOfDay.TotalSeconds < Start + Secs)
            {
                Application.DoEvents();
            };
        }

        private void BtnCancelar_Click(Object eventSender, EventArgs eventArgs)
        {
            BandeInsert = 0;
            //ViewerCtrl1.Width = (int)VB6.TwipsToPixelsX(14595);
            ViewerCtrl2.Visible = false;
            //ViewerCtrl2.Left = (int)VB6.TwipsToPixelsX(14625);
            //ViewerCtrl2.Width = (int)VB6.TwipsToPixelsX(525);
            //ViewerCtrl2.Height = (int)VB6.TwipsToPixelsY(9300);
            SPCont.SplitterDistance = SPCont.Size.Width - 25;
            SPCont.Panel2Collapsed = true;
            if (ViewerCtrl2.DocumentFilename != string.Empty) {
                Module1.XArchivo = ViewerCtrl2.DocumentFilename;
                ViewerCtrl2.DocumentFilename = String.Empty;
                ViewerCtrl1.Refresh();
                try { File.Delete(Module1.XArchivo); }
                catch { }
            }

            BandeInsert = 0;
            LoadFiles(1);
            LoadFiles(5);
            return;

            if (ViewerCtrl1.DocumentFilename != string.Empty)
            {
                Module1.XArchivo = ViewerCtrl1.DocumentFilename;
            }
            else
            {
                Module1.XArchivo = String.Empty;
            }

            if (Module1.TipoOper == 1)
            {
                LoadFiles(2);
            }
            else
            {
                LoadFiles(1);
            }
            if (Module1.TotalDocs > 0)
            {
                Module1.CurrentDocInx = 0;
                //AIS320 - DVega: Quitamos Ref porque los argumentos a la funcion no pasan por referencia.
                LoadDocument(Module1.CurrentDocInx);
                BtnPrevious.Enabled = false;
                NavForward = true;
                if (Module1.TotalDocs > 1)
                {
                    BtnNext.Enabled = true;
                    BtnDeletePage.Enabled = true;
                }
                else
                {
                    BtnNext.Enabled = false;
                    BtnDeletePage.Enabled = false;
                }
                BtnDone.Enabled = true;
                //AVG Ini Setp-2015
                BtnSaveas.Enabled = true;
                //AVG Fin Setp-2015

            }
            BtnOkInserta.Enabled = false;
            BtnCancelar.Enabled = false;

            //Fin de cambio
        }

        private void BtnDelete_Click(Object eventSender, EventArgs eventArgs)
        {
            if (MessageBox.Show(this, "Estas Seguro de Borrar la Imágen de FileNET ?", "¿Barrar Archivo?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Module1.oDocument.Delete();
                this.Close();
            }
        }

        private void BtnDeletePage_Click(Object eventSender, EventArgs eventArgs)
        {
            int Pags = ViewerCtrl1.Pages.Count;
            if (Pags > 1)
            {
                int Pag = ViewerCtrl1.PageNumber;

                //ViewerCtrl1.DocumentFilename = Module1.XArchivo;                
                ViewerCtrl1.Refresh();
                ViewerCtrl1.Update(); 
                ViewerCtrl1.Clear();
                ViewerCtrl1.Update();
                ViewerCtrl1.Refresh();
                ViewerCtrl1.BeginInit();
                ViewerCtrl1.DocumentFilename = "";
                ViewerCtrl1.Update();
                ViewerCtrl1.Refresh();
                ImgAdmin1.Image = Module1.XArchivo;
                ViewerCtrl1.PageNumber = 1;
                ImgAdmin1.DeletePages(Pag, 1);
                Pause(1); 
                Application.DoEvents();
                Application.DoEvents();
                //ViewerCtrl1.DocumentFilename = Module1.XArchivo;
                ImgAdmin1.Image = null;
                ViewerCtrl1.DocumentFilename = "";
                ViewerCtrl1.DocumentFilename = Module1.XArchivo;
                ViewerCtrl1.Update();
                ViewerCtrl1.Refresh();
                Pags = ViewerCtrl1.Pages.Count;
                if (File.Exists(Module1.TmpImg + "VisalImg.tmp"))
                {
                    File.Delete(Module1.TmpImg + "VisalImg.tmp");
                }
                viewImage1.CloseDocument();
                File.Copy(Module1.XArchivo, Module1.TmpImg + "VisalImg.tmp");
                viewImage1.pArchivo = Module1.TmpImg + "VisalImg.tmp";
                viewImage1.LoadDocument();
                viewImage1.SetPage(Pags); 
                if (Pags > 1)
                {
                    if (Pag >= Pags)
                    {
                        ViewerCtrl1.PageNumber = Pags;
                    }
                    else
                    {
                        ViewerCtrl1.PageNumber = Pag;
                    }
                }
                else
                {
                    ViewerCtrl1.PageNumber = 1;
                }
                if (Pags > 1)
                {
                    BtnDeletePage.Enabled = true;
                }
                else
                {
                    BtnDeletePage.Enabled = false;
                }
            }
            else
            {
                BtnDeletePage.Enabled = false;
            }
        }

        private void BtnDone_Click(Object eventSender, EventArgs eventArgs)
        {
            string Temp = String.Empty;
            int inx = 0;
            IDMObjects.Folder oFolder;
            oFolder = new IDMObjects.Folder();
            IDMObjects.Library oLib;
            oLib = new IDMObjects.Library();
            //IDMObjects.Folder oFolder = null;
            //IDMObjects.Library oLib = null;

            if ((Conversion.Val(TxtFolioUOC.Text) == 0 || Conversion.Val(TxtCliente.Text) == 0 || CboTipoDoc.SelectedIndex == -1) && Module1.TipoOper != 1 && Module1.TipoOper != 7)
            {
                MessageBox.Show(this, "Favor de teclear el Folio Uoc, Cliente, Tipo Documento como minimo", Application.ProductName);
                return;
            }
            if (CboTipoDoc.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Favor de teclear Tipo Documento ", Application.ProductName);
                return;
            }

            //this.Visible = false;  
          
            /*Module1.CommitForm.Animation1.Open(Module1.HomeDirectory + "\\commit.avi");
            Module1.CommitForm.Show();
            Module1.CommitForm.txtMin.Text = "0";
            Module1.CommitForm.txtMax.Text = ((int)(CommitValues.Commit)).ToString();
            Module1.CommitForm.Activate();*/

            LblMsg.Visible = true;
            LblMsg.Text = "Espere por favor .... Preparando Imágen";

            Frame1.Enabled = false;
            X.Enabled = false;
            Application.DoEvents();
            Application.DoEvents();


            ViewerCtrl1.BeginInit();
            ViewerCtrl1.Update();
            ViewerCtrl1.Refresh();
            ViewerCtrl1.BeginInit();
            try
            {
                ViewerCtrl1.Clear();
            }
            catch { }
            ViewerCtrl1.DocumentFilename = "";
            ViewerCtrl1.Clear();
            ViewerCtrl1.Update();
            ViewerCtrl1.Refresh();
            ViewerCtrl1.BeginInit();
            ViewerCtrl1.Visible = false;


            BandeInsert = 0;
            LoadFiles(1);
            LoadFiles(7);
            LblMsg.Text = "Espere por favor .... guardando Indíces";
            if (Module1.TotalDocs > 0)
            {
                Module1.CurrentDocInx = 0;
                SaveDocument(Module1.CurrentDocInx);
            }



            try
            {
                for (inx = 0; inx <= Module1.TotalDocs - 1; inx++)
                {
                    //SaveDocument(inx);
                    if (Module1.DocList[inx].CommitFlag == CommitValues.Commit)
                    {
                        //Module1.CommitForm.ProgressBar1.Value = Module1.CommitForm.ProgressBar1.Value + 1;
                        //if (FileSystem.FileLen(Module1.DocList[inx].fileName) > 950000)
                        //{
                        Application.DoEvents();
                        //ParticionaImg(Module1.XArchivo);
                        LblMsg.Text = "Espere por favor .... Validando Imágen";
                        // AVG Ini 08-06-2014
                        if (Module1.TipoOper != 7)
                        {
                            ParteImg(Module1.XArchivo);
                        }
                        // AVG Fin 08-06-2014
                        Application.DoEvents();                        
                        /*Module1.CommitForm.Text1.Text = Module1.DocList[inx].fileName;                        
                        Module1.CommitForm.Activate();
                        Module1.CommitForm.Animation1.Play();*/
                        LblMsg.Text = "Espere por favor .... guardando Imágen";
                        if (Module1.gbISLogOff)
                        {
                            //MsgBox "salva docto"
                            Module1.oDocument.SaveNew(Module1.XArchivo, IDMObjects.idmSaveNewOptions.idmDocSaveNewKeep); 
                            //Module1.FinalList[inx].SaveNew(Module1.XArchivo, IDMObjects.idmSaveNewOptions.idmDocSaveNewKeep);

                            //Call FinalList(inx).SaveNew(DocList(inx).fileName, idmDocSaveNewConfirmationUI + _
                            //'idmDocSaveNewKeep)

                            //MsgBox "salvado docto"
                            //  Call FinalList(inx).SaveNew(DocList(inx).FileName)
                            if (Module1.FolderList[inx] != "")
                            {
                                oFolder = (IDMObjects.Folder)Module1.oLibrary.GetObject(IDMObjects.idmObjectType.idmObjTypeFolder, Module1.FolderList[inx], null, null, null);
                                oFolder.File(Module1.FinalList[inx]);
                            }

                        }
                        else
                        {
                            Pause(2);
                        }
                        
                        /*Module1.CommitForm.Animation1.Stop();*/

                        Module1.FinalList[inx] = null;
                    }
                }
                LblMsg.Visible = false;
                if (Module1.TipoOper != 7)
                {
                    MessageBox.Show(this, "Operación Completa", Application.ProductName);
                }
                if (File.Exists(Module1.TmpImg + "img1.tif"))
                {
                    try { File.Delete(Module1.TmpImg + "img1.tif"); }
                    catch { }
                }
                if (File.Exists(Module1.TmpImg + "img2.tif"))
                {
                    try { File.Delete(Module1.TmpImg + "img2.tif"); }
                    catch { }
                }
                if (Module1.SalirReg == 1 && Module1.TipoOper != 1 && Module1.TipoOper != 7)
                {                   
                    this.Visible = true;
                    ViewerCtrl1.DocumentFilename = String.Empty;
                    ViewerCtrl2.DocumentFilename = String.Empty;
                    ImgAdmin1.Image = null;
                    TxtFolioUOC.Text = String.Empty;
                    Module1.DocList[inx].fileName = "";
                    Module1.TotalDocs = 0;
                    CommCount = 0;
                    Module1.CurrentDocInx = 0;
                    ImgScan1.Image = String.Empty;
                    string tempRefParam = Module1.TmpImg + "Img*.tif";
                    Module1.KillFile(ref tempRefParam);
                    if (File.Exists(Module1.XArchivo))
                    {
                        try {
                            File.Delete(Module1.XArchivo);
                        }
                        catch { }
                    }
                    try
                    {
                        Module1.goPropDescs = null;
                    }
                    catch { }

                    try { Module1.oDocument = null; }
                    catch { }
                    BandeInsert = 0;
                    BtnInsertPag.Enabled = false;
                    BtnOkInserta.Enabled = false;
                    BtnCancelar.Enabled = false;
                    Module1.FinalList[Module1.CurrentDocInx] = null;

                    Module1.oLibrary = null;

                    oLib = (IDMObjects.Library)((IDMObjects.IFnNeighborhoodDual)Module1.oNeighborhood).get_DefaultLibrary(); // Toma la librería default                        
                    MyLogon(oLib); // Hace LOGON a librería

                    if (!(oLib.GetState(IDMObjects.idmLibraryState.idmLibraryLoggedOn)))
                    {
                        MessageBox.Show(this, "Error en logon a librería", Application.ProductName);
                        Module1.gbISLogOff = false;
                        Environment.Exit(0);

                    }
                    else
                    {
                        Module1.gbISLogOff = true;
                        Module1.oLibrary = oLib; // Hace la librería global por flexibilidad
                    }


                    BtnDone.Enabled = false;
                    //AVG Ini Setp-2015
                    BtnSaveas.Enabled = false;
                    //AVG Fin Setp-2015

                    IDMListView1.ClearItems();
                    Module1.XProd = DBNull.Value;
                    Module1.XInst = DBNull.Value;
                    Module1.XCalifOnd = DBNull.Value;
                    Module1.XFile = DBNull.Value;
                    return;
                }
                if (Module1.TipoOper != 7)
                {
                    //if (MessageBox.Show(this, "Deseas Borrar el Archivo :" + Module1.XArchivo, "¿Barrar Archivo?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    //{
                    //    Temp = Module1.XArchivo;
                    //    this.ViewerCtrl1.Clear();
                    //    try { File.Delete(Module1.XArchivo); }
                    //    catch { }
                    //    Temp = (Temp.IndexOf('.') + 1).ToString();
                    //    Module1.XArchivo = Module1.XArchivo.Substring(0, int.Parse(Temp)) + "rcv";
                    //    try { File.Delete(Module1.XArchivo); }
                    //    catch { }
                    //    Temp = Module1.XArchivo1;
                    //    try { File.Delete(Module1.XArchivo1); }
                    //    catch { }
                    //    Temp = (Temp.IndexOf('.') + 1).ToString();
                    //    Module1.XArchivo1 = Module1.XArchivo.Substring(0, int.Parse(Temp)) + "rcv";
                    //    try { File.Delete(Module1.XArchivo1); }
                    //    catch { }
                    //}
                }

                string tempRefParam1 = Module1.TmpImg + "*.tif";
                Module1.KillFile(ref tempRefParam1); 
                this.Visible = true;
                this.Close();
                return;
            }
            catch (System.Runtime.InteropServices.COMException e1)
            {
                Microsoft.VisualBasic.Information.Err().Number = e1.ErrorCode;
                Microsoft.VisualBasic.Information.Err().Source = e1.Source;
                Microsoft.VisualBasic.Information.Err().Description = e1.Message;
            }
            catch { }
            finally
            {
                //Errs: 
                /*Module1.ShowError();
                this.Visible = true;
                this.Dispose(); */
                Environment.Exit(0);
                /*Module1.CommitForm.Close();
                Module1.CommitForm = null;*/
                //Unload Me
            }
            //Fin de cmabio
        }

        private void BtnFileNET_Click(Object eventSender, EventArgs eventArgs)
        {
            Collection cHeadings = new Collection();
            string sWhere = String.Empty;
            string sClass = String.Empty;
            clsSimpleQuery oQuery = new clsSimpleQuery();
            if (MessageBox.Show(this, "Deberá guardar la imágen cuando la termine de editarla, porque se borrará de FileNET.", "¿Desea Continuar?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (Conversion.Val(TxtFolioUOC.Text) == 0 && Conversion.Val(TxtCliente.Text) == 0)
                {
                    MessageBox.Show(this, "Favor de teclear el Folio Uoc y/ó Cliente, como minimo", Application.ProductName);
                    return;
                }
                IDMListView1.ClearItems();
                //IDMListView2.ClearItems
                ViewerCtrl1.Clear();
                //ShowAnnotations.Value = 0
                sWhere = "F_DOCTYPE = 'IMAGE'";
                sWhere = sWhere + " AND F_DOCCLASSNAME = 'ExpedientesDC'";
                if (Double.Parse(CboUOC.Text) > 0)
                {
                    sWhere = sWhere + " AND UOC = '" + CboUOC.Text + "'";
                }
                //Since we're looking at annotations, just grab images
                if (Conversion.Val(TxtCliente.Text) > 0 && TxtCliente.Text.Trim().Length > 0)
                {
                    sWhere = sWhere + " AND NumCliente = '" + TxtCliente.Text + "'";
                }
                if (Conversion.Val(TxtFolioUOC.Text) > 0 && TxtFolioUOC.Text.Trim().Length > 0)
                {
                    //If XFolio > 0 Then
                    Module1.XFolio = TxtFolioUOC.Text;
                    sWhere = sWhere + " AND Folio = '" + TxtFolioUOC.Text + "'";
                }
                if (Conversion.Val(TxtContrato.Text) > 0 && TxtContrato.Text.Trim().Length > 0)
                {
                    sWhere = sWhere + " AND Contrato = '" + TxtContrato.Text + "'";
                }
                if (Conversion.Val(TxtLinea.Text) > 0 && TxtLinea.Text.Trim().Length > 0)
                {
                    sWhere = sWhere + " AND Linea = '" + TxtLinea.Text + "'";
                }
                //MsgBox "swhere :" & sWhere
                sClass = Module1.gfSettings.txtResDocClass.Text;
                Module1.gcHeadings = new Collection();
                Module1.gcPropNames = new Collection();
                SetLVHeaders(Module1.gcHeadings, Module1.gcPropNames);
                Module1.clsQuery.BindToLib(Module1.oLibrary, Module1.gcHeadings, sClass);
                Cursor = Cursors.WaitCursor;
                Module1.clsQuery.ExecQuery(ref this.IDMListView1, sWhere, "", 20, (DocEntry.FormMain)this);
                //SSPanel2.Visible = False
                Cursor = Cursors.Arrow;
                if (IDMListView1.CountItems() > 0)
                {
                    Artinsoft.VB6.Gui.SSTabHelper.SetTabEnabled(SSTab1, 1, true);
                    SSTab1.SelectedIndex = 1;
                    BandeInsert = 0;
                    Module1.XArchivo = String.Empty;
                }
                //Rotar = 0
                //BtnDelete.Visible = False

                BtnPrint.Enabled = false;
                //        If IDMListView1.CountItems > 0 Then
                //            IDMListView1.SelectItem (1)
                //            IDMListView1_DblClick
                //            'BtnDelete.Visible = True
                //            BtnPrint.Visible = True
                //            Call LoadFiles(2)
                //            If TotalDocs > 0 Then
                //                oDocument.Delete
                //                Call LoadDocument(0)
                //                BtnPrevious.Enabled = False
                //                NavForward = True
                //                If TotalDocs > 1 Then
                //                    BtnNext.Enabled = True
                //                Else
                //                    BtnNext.Enabled = False
                //                End If
                //                BtnDone.Enabled = True
                //            End If
                //        End If
            }
        }

        private void BtnInsertPag_Click(Object eventSender, EventArgs eventArgs)
        {
            BandeInsert = 1;
            //ViewerCtrl1.Width = (int)VB6.TwipsToPixelsX(7300);
            //ViewerCtrl2.Visible = true;
            //ViewerCtrl2.Left = (int)VB6.TwipsToPixelsX(7350);
            //ViewerCtrl2.Width = (int)VB6.TwipsToPixelsX(7300);
            //ViewerCtrl2.Height = (int)VB6.TwipsToPixelsY(9300);
            SPCont.SplitterDistance = SPCont.Size.Width / 2;
            SPCont.Panel2Collapsed = false;
            BtnCancelar.Enabled = true;
            BtnDone.Enabled = false;
            //AVG Ini Setp-2015
            BtnSaveas.Enabled = false;
            //AVG Fin Setp-2015

        }

        private void BtnNext_Click(Object eventSender, EventArgs eventArgs)
        {
            Module1.CurrentDocInx++;
            if (Module1.CurrentDocInx > Module1.TotalDocs - 2)
            {
                BtnNext.Enabled = false;
                NavForward = false;
            }
            else
            {
                NavForward = true;
            }
            BtnPrevious.Enabled = true;

            //AIS320 - DVega: Quitamos Ref porque los argumentos a la funcion no pasan por referencia.
            LoadDocument(Module1.CurrentDocInx);
        }


        private void ParteImg(string NomArchivo)
        {
            LblMsg.Text = "Espere por favor .... Validando Imágen";
            int X;
            int Y;
            int i;
            int Bande = 0;
            Cursor.Current = Cursors.WaitCursor;
            ImGearDocument igDocument;
            igDocument = new ImGearDocument();
            int resolucion = 96000;
            int XResolution = Int32.Parse(CboResol.Text.ToString());   
            try
            {
                using (FileStream stream = new FileStream(NomArchivo, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    ImageGear.Core.ImGearLicense.SetSolutionName("Banamex");
                    ImageGear.Core.ImGearLicense.SetSolutionKey((uint)0xDF4F2A7C, (uint)0xFFF24DAD, (uint)0x3C23EFCE, (uint)0x77EE247F);
                    ImageGear.Core.ImGearLicense.SetOEMLicenseKey("1.0.EhemHZSiI8zDW6vNQ6XgQZd8GyHiamOBGwQhpBvhOVnZHNIiH6XbG6WZIbIAGivmGynYe6QNzbW8SBpBxwSyWBGhpmONvBxNX6aYOmpmQZzmIyz8xgehpiaDGbOAXVX8OhaiWAnwayHYxDemeieyvgXyeYWYWZQZOmXwWDWZXDv8GNnYIYzBpwXYpidNzZe6zbeAamXBIgdwzbxYxVImpiGBGYXZHZnBXwdDxiQBaBQYQVxYOiW6QVpDvDv6pZIVdheDGheiOYQNQyeAOgeBdAXZODeNeyGmOwIBaVnZGDGBODHmpin6HbSDvhpiSyIZawe6dwIDvDIQOHy");
                    igDocument = ImGearFileFormats.LoadDocument(stream, 0, -1);
                }
            }
            catch (Exception E) { }
            igDocument.Metadata.Format = ImGearMetadataFormats.TIF;
            igDocument.Metadata.TIFF.Compression = ImageGear.Formats.TIF.ImGearTIFFCompression.GROUP_4;
            string ArchTemp = Module1.TmpImg + "ArcTemp.tif";

            if (File.Exists(ArchTemp))
            {
                try
                {
                    File.Delete(ArchTemp);
                }
                catch { }
            }
            try
            {
                for (i = 0; i < igDocument.Pages.Count; i++)
                {
                    Bande = 0;
                    resolucion = 96000;
                    XResolution = Int32.Parse(CboResol.Text.ToString());   
                    if (igDocument.Pages[i].DIB.ImageResolution.Units != ImGearResolutionUnits.INCHES)
                    {
                        igDocument.Pages[i].DIB.ImageResolution.ConvertUnits(ImGearResolutionUnits.INCHES);
                    }

                    if ((igDocument.Pages[i].DIB.ImageResolution.XNumerator >= resolucion)
                        || (igDocument.Pages[i].DIB.ImageResolution.YNumerator >= resolucion))
                    {
                        X = 1728;
                        Y = 2148;
                        XResolution = 600;
                        Bande = 1;
                        ImGearReductionOptions igReductionOptions = new ImGearReductionOptions();
                        igReductionOptions.Octree.MaxColors = 256;
                        igReductionOptions.Octree.FastRemap = true;
                        igReductionOptions.Octree.ErrorDiffusion = true;

                        if (igDocument.Pages[i].DIB.ImageResolution.XNumerator >= resolucion)
                        {
                            igDocument.Pages[i].DIB.ImageResolution.XNumerator = XResolution;
                        }
                        if (igDocument.Pages[i].DIB.ImageResolution.YNumerator >= resolucion)
                        {
                            igDocument.Pages[i].DIB.ImageResolution.YNumerator = XResolution;
                        }
                        if (igDocument.Pages[i].DIB.BitDepth == 1)
                        {
                            ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearGrayScaleInterpolationOptions(50));
                        }
                        else
                        {
                            ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearNoneInterpolationOptions());
                        }

                        if (igDocument.Pages[i].DIB.BitDepth > 1)
                        {
                            //ImGearRasterProcessing.Reduce((ImGearRasterPage)igDocument.Pages[i],
                            //    new ImGearColorSpace(ImGearColorSpaceIDs.I), new int[] { 24 }, ImGearReductionMethods.OCTREE, igReductionOptions);

                            ImGearRasterProcessing.Reduce((ImGearRasterPage)igDocument.Pages[i],
                                                            new ImGearColorSpace(ImGearColorSpaceIDs.I), new int[] { 1 }, ImGearReductionMethods.BAYER, new ImGearReductionOptions());

                        };
                    }
                    else
                    {
                        resolucion = 200;
                        if ((igDocument.Pages[i].DIB.ImageResolution.XNumerator >= resolucion)
                            || (igDocument.Pages[i].DIB.ImageResolution.YNumerator >= resolucion))
                        {
                            X = igDocument.Pages[i].DIB.Width;
                            Y = igDocument.Pages[i].DIB.Height;
                            Bande = 1;
                            if (igDocument.Pages[i].DIB.ImageResolution.XNumerator >= resolucion)
                            {
                                igDocument.Pages[i].DIB.ImageResolution.XNumerator = XResolution;
                            }
                            if (igDocument.Pages[i].DIB.ImageResolution.YNumerator >= resolucion)
                            {
                                igDocument.Pages[i].DIB.ImageResolution.YNumerator = XResolution;
                            }
                            if (igDocument.Pages[i].DIB.BitDepth == 1)
                                ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearGrayScaleInterpolationOptions(50));
                            else
                                ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearNoneInterpolationOptions());

                            if (igDocument.Pages[i].DIB.BitDepth > 1)
                            {
                                ImGearRasterProcessing.Reduce((ImGearRasterPage)igDocument.Pages[i],
                                    new ImGearColorSpace(ImGearColorSpaceIDs.I), new int[] { 1 }, ImGearReductionMethods.BAYER, new ImGearReductionOptions());
                            }
                        }
                        else
                        {
                            if ((igDocument.Pages[i].DIB.BitDepth > 1) && (Bande == 0))
                            {
                                ImGearRasterProcessing.Reduce((ImGearRasterPage)igDocument.Pages[i],
                                    new ImGearColorSpace(ImGearColorSpaceIDs.I), new int[] { 1 }, ImGearReductionMethods.BAYER, new ImGearReductionOptions());
                            }
                            //X = igDocument.Pages[i].DIB.Width;
                            //Y = igDocument.Pages[i].DIB.Height;
                            //if (igDocument.Pages[i].DIB.BitDepth == 1)
                            //    ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearGrayScaleInterpolationOptions(50));
                            //else
                            //   ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearNoneInterpolationOptions());
                        }
                    }

                    using (FileStream stream = new FileStream(ArchTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Write))
                    {
                        ImGearFileFormats.SavePage(igDocument.Pages[i], stream, i, ImGearSavingModes.APPEND, ImGearSavingFormats.TIF_G4);
                    }
                    Application.DoEvents();
                    Application.DoEvents();
                }
            }
            catch { }
            try
            {
                ImgScan1.Image = String.Empty;
            }
            catch { }
            try
            {
                ImgAdmin1.Image = String.Empty;
            }
            catch { }
            //catch (Exception ER1) { }
            //try { ViewerCtrl1.DocumentFilename = String.Empty; }
            //catch { }
            try
            {
                File.Copy(ArchTemp, NomArchivo, true);
            }
            catch { }
            try
            {
                File.Delete(ArchTemp);
            }
            catch { }
            Module1.XArchivo = NomArchivo;
            LblMsg.Text = "Espere por favor .... guardando Imágen";
            Cursor.Current = Cursors.Default;
        }

        private void ParteImg2(string NomArchivo)
        {
            LblMsg.Text = "Espere por favor .... Validando Imágen";
            int X;
            int Y;
            int i;
            Cursor.Current = Cursors.WaitCursor;
            ImGearDocument igDocument;
            igDocument = new ImGearDocument();
            try
            {
                using (FileStream stream = new FileStream(NomArchivo, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    //NOTA:  El segmento marcado será eliminado cuando se tenga a disposición la licencia de la aplicación, 
                    //       al ser un trial se le debe de agregar lo siguiente:
                    //Eliminar
                    ImageGear.Core.ImGearLicense.SetSolutionName("Banamex");
                    //unchecked
                    //{
                    ImageGear.Core.ImGearLicense.SetSolutionKey((uint)0xDF4F2A7C, (uint)0xFFF24DAD, (uint)0x3C23EFCE, (uint)0x77EE247F);
                    //}
                    ImageGear.Core.ImGearLicense.SetOEMLicenseKey("1.0.EhemHZSiI8zDW6vNQ6XgQZd8GyHiamOBGwQhpBvhOVnZHNIiH6XbG6WZIbIAGivmGynYe6QNzbW8SBpBxwSyWBGhpmONvBxNX6aYOmpmQZzmIyz8xgehpiaDGbOAXVX8OhaiWAnwayHYxDemeieyvgXyeYWYWZQZOmXwWDWZXDv8GNnYIYzBpwXYpidNzZe6zbeAamXBIgdwzbxYxVImpiGBGYXZHZnBXwdDxiQBaBQYQVxYOiW6QVpDvDv6pZIVdheDGheiOYQNQyeAOgeBdAXZODeNeyGmOwIBaVnZGDGBODHmpin6HbSDvhpiSyIZawe6dwIDvDIQOHy");
                    igDocument = ImGearFileFormats.LoadDocument(stream, 0, -1);
                }
            }
            catch (Exception E) { }
            igDocument.Metadata.Format = ImGearMetadataFormats.TIF;
            igDocument.Metadata.TIFF.Compression = ImageGear.Formats.TIF.ImGearTIFFCompression.GROUP_4;
            string ArchTemp = Module1.TmpImg + "ArcTemp.tif";

            if (File.Exists(ArchTemp))
            {
                try
                {
                    File.Delete(ArchTemp);
                }
                catch { }
            }
            try
            {
                for (i = 0; i < igDocument.Pages.Count; i++)
                {
                    if (igDocument.Pages[i].DIB.ImageResolution.Units != ImGearResolutionUnits.INCHES)
                    {
                        igDocument.Pages[i].DIB.ImageResolution.ConvertUnits(ImGearResolutionUnits.INCHES);
                    }
                    if ((igDocument.Pages[i].DIB.ImageResolution.XNumerator > 50)
                        || (igDocument.Pages[i].DIB.ImageResolution.YNumerator > 50))
                    {
                        X = 1728;
                        Y = 2148;

                        ImGearReductionOptions igReductionOptions = new ImGearReductionOptions();
                        igReductionOptions.Octree.MaxColors = 256;
                        igReductionOptions.Octree.FastRemap = true;
                        igReductionOptions.Octree.ErrorDiffusion = true;                        
                        ////Apply the reduction using Octree to get a 4-bit index image.
                        ////ImGearRasterProcessing.Reduce(igRasterPage, new ImGearColorSpace(ImGearColorSpaceIDs.I),
                        ////    new int[] { 24 }, ImGearReductionMethods.OCTREE, igReductionOptions);

                        if (igDocument.Pages[i].DIB.ImageResolution.XNumerator > 50)
                        {
                            igDocument.Pages[i].DIB.ImageResolution.XNumerator = 600;
                        }
                        if (igDocument.Pages[i].DIB.ImageResolution.YNumerator > 50)
                        {
                            igDocument.Pages[i].DIB.ImageResolution.YNumerator = 600;
                        }
                        if (igDocument.Pages[i].DIB.BitDepth == 1) {
                            ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearGrayScaleInterpolationOptions(50));
                        }
                        else
                        {
                            ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearNoneInterpolationOptions());                             
                        }

                        if (igDocument.Pages[i].DIB.BitDepth > 1)
                        {
                            //ImGearRasterProcessing.Reduce((ImGearRasterPage)igDocument.Pages[i],
                            //    new ImGearColorSpace(ImGearColorSpaceIDs.I), new int[] { 24 }, ImGearReductionMethods.OCTREE, igReductionOptions);

                            ImGearRasterProcessing.Reduce((ImGearRasterPage)igDocument.Pages[i],
                                                            new ImGearColorSpace(ImGearColorSpaceIDs.I), new int[] { 1 }, ImGearReductionMethods.BAYER, new ImGearReductionOptions());
                          
                        };
                    }
                    else
                    {
                        
                        X = 1728;
                        Y = 2148;
                        ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearNoneInterpolationOptions());
                        if (igDocument.Pages[i].DIB.BitDepth > 1)
                        {
                            ImGearRasterProcessing.Reduce((ImGearRasterPage)igDocument.Pages[i],
                                new ImGearColorSpace(ImGearColorSpaceIDs.I), new int[] { 1 }, ImGearReductionMethods.BAYER, new ImGearReductionOptions());
                        }
                        
                        //X = igDocument.Pages[i].DIB.Width;
                        //Y = igDocument.Pages[i].DIB.Height;
                        //if (igDocument.Pages[i].DIB.BitDepth == 1)
                        //    ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearGrayScaleInterpolationOptions(50));
                        //else
                        //   ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearNoneInterpolationOptions());
                    }

                    using (FileStream stream = new FileStream(ArchTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Write))
                    {
                        ImGearFileFormats.SavePage(igDocument.Pages[i], stream, i, ImGearSavingModes.APPEND, ImGearSavingFormats.TIF_G4);
                    }
                    Application.DoEvents();
                    Application.DoEvents();
                }
            }
            catch { }
            try
            {
                ImgScan1.Image = String.Empty;
            }
            catch { }
            try
            {
                ImgAdmin1.Image = String.Empty;
            }
            catch { }
            //catch (Exception ER1) { }
            //try { ViewerCtrl1.DocumentFilename = String.Empty; }
            //catch { }
            try
            {
                File.Copy(ArchTemp, NomArchivo, true);
            }
            catch { }
            try
            {
                File.Delete(ArchTemp);
            }
            catch { }
            Module1.XArchivo = NomArchivo;
            LblMsg.Text = "Espere por favor .... guardando Imágen";
            Cursor.Current = Cursors.Default;
        }

        
        private void BtnOkInserta_Click(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            string ArchFin = ViewerCtrl1.DocumentFilename.ToString();
            //AxAdminLibCtl.AxImgAdmin ImgAdminX;
            //ImgAdminX = new AxAdminLibCtl.AxImgAdmin();
            //ImgAdminX = ImgAdmin1;


            Application.DoEvents();
            Application.DoEvents();
            BandeInsert = 0;
            ViewerCtrl1.WPZoomMode = IDMViewerCtrl.idmWPZoomMode.idmWPZoomModeOriginal;
            ViewerCtrl2.WPZoomMode = IDMViewerCtrl.idmWPZoomMode.idmWPZoomModeOriginal;
            ViewerCtrl1.ZoomMode = IDMViewerCtrl.idmZoomMode.idmZoomModeFitToHeight;
            ViewerCtrl2.ZoomMode = IDMViewerCtrl.idmZoomMode.idmZoomModeFitToHeight; 
            //ViewerCtrl1.Width = (int)VB6.TwipsToPixelsX(14595);
            SPCont.SplitterDistance = SPCont.Size.Width - 25 ;
            SPCont.Panel2Collapsed = true;
            ViewerCtrl2.Visible = false;
            //ViewerCtrl2.Left = (int)VB6.TwipsToPixelsX(14625);
            //ViewerCtrl2.Width = (int)VB6.TwipsToPixelsX(525);
            //ViewerCtrl2.Height = (int)VB6.TwipsToPixelsY(9300);

            int Pag = ViewerCtrl1.PageNumber;
            int Pag1 = ViewerCtrl2.Pages.Count;
            if (ViewerCtrl1.DocumentFilename != string.Empty && ViewerCtrl2.DocumentFilename != string.Empty) {
                string ArchTemp = Module1.TmpImg + "ArcTemp.tif";                
                Module1.XArchivo = ViewerCtrl2.DocumentFilename;
                    ViewerCtrl1.BeginInit();
                    try {                        
                        ViewerCtrl1.PageNumber = Pag; 
                    } catch { }                                        
                    ViewerCtrl1.Update();
                    ViewerCtrl1.Refresh();
                    ViewerCtrl1.BeginInit();
                    
                    try {
                        ViewerCtrl1.Clear();                                                 
                    } catch { }
                    ViewerCtrl1.DocumentFilename = "";
                    ViewerCtrl1.Clear();                      
                    ViewerCtrl1.Update();
                    ViewerCtrl1.Refresh();
                    ViewerCtrl1.BeginInit();
                    ViewerCtrl2.DocumentFilename = "";                    
                    ViewerCtrl2.Update();
                    ViewerCtrl2.Refresh();
                    ViewerCtrl2.Clear();
                    ViewerCtrl2.BeginInit();
                    Application.DoEvents();
                    Application.DoEvents();
                //} catch { }
                if (File.Exists(ArchTemp))
                {
                    try
                    {
                        File.Delete(ArchTemp);
                    }
                    catch { }
                }
                try
                {
                    File.Copy(ArchFin, ArchTemp, true);
                    Application.DoEvents();
                    Application.DoEvents();
                } catch { }               
                //ImgAdmin1.Image = null;
                //ImgScan1.Image = string.Empty;
                //*try {


                //} catch { }
                ImgAdmin1.Image = ArchTemp;
                //ImgAdmin1.Refresh();
                Application.DoEvents();
                Application.DoEvents();
                if (File.Exists(Module1.XArchivo)) {
                    try
                    {
                        Application.DoEvents();
                        ImgAdmin1.Insert(Module1.XArchivo, 1, Pag + 1, Pag1);
                        ImgAdmin1.Image = null;
                        Application.DoEvents();
                        Application.DoEvents();
                    } catch { }
                }                
                Application.DoEvents();
                Application.DoEvents();
                try
                {
                    File.Copy(ArchTemp, ArchFin, true);
                } catch { }

                Application.DoEvents();
                Application.DoEvents();

               

                try
                {
                    File.Delete(ArchTemp);
                } catch { }
            }
            Application.DoEvents();
            Application.DoEvents();
            BtnOkInserta.Enabled = false;
            BtnCancelar.Enabled = false;
            //ImgAdminX = null;
            Module1.XArchivo = ArchFin;
            //ViewerCtrl1.Refresh();
            //ViewerCtrl2.Refresh(); 
            Pause(2);
            LoadFiles(1);
            BandeInsert = 0;
            LoadFiles(5);
            /* if (Module1.TotalDocs > 0)
            {
                Module1.CurrentDocInx = 0;
                LoadDocument(Module1.CurrentDocInx);
            }*/
            BandeInsert = 0;
        }

        private void BtnPrevious_Click(Object eventSender, EventArgs eventArgs)
        {
            Module1.CurrentDocInx--;
            if (Module1.CurrentDocInx == 0)
            {
                BtnPrevious.Enabled = false;
                NavForward = true;
            }
            else
            {
                NavForward = false;
            }
            //AIS320 - DVega: Quitamos Ref porque los argumentos a la funcion no pasan por referencia.
            LoadDocument(Module1.CurrentDocInx);

        }

        private void BtnPrint_Click(Object eventSender, EventArgs eventArgs)
        {
            //ViewerCtrl1.LocalPrint.DoPrint(true);
        }

        private void BtnRestart_Click(Object eventSender, EventArgs eventArgs)
        {
            if ((Conversion.Val(TxtFolioUOC.Text) == 0 || Conversion.Val(TxtCliente.Text) == 0 || CboTipoDoc.SelectedIndex == -1) && Module1.TipoOper != 1)
            {
                MessageBox.Show(this, "Favor de teclear el Folio Uoc, Cliente, Tipo Documento como minimo", Application.ProductName);
                return;
            }
            LoadFiles(0);
            LoadFiles(5);
            //if (Module1.TotalDocs > 0)
            //{
            //    Module1.CurrentDocInx = 0;
            //    LoadDocument(Module1.CurrentDocInx);
            //}
                //BtnPrevious.Enabled = false;
                //NavForward = true;
                //if (Module1.TotalDocs > 1)
                //{
                //    BtnNext.Enabled = true;
                //    BtnDeletePage.Enabled = true;
                //}
                //else
                //{
                //    BtnNext.Enabled = false;

                //    //BtnDeletePage.Enabled = false;
                //}
                BtnDone.Enabled = !BtnOkInserta.Enabled;
        }

        private void BtnRotate_Click(Object eventSender, EventArgs eventArgs)
        {
            RotateAmount += 90;
            if (RotateAmount == 360)
            {
                RotateAmount = 0;
            }
            if (BandeInsert == 0)
            {
                ViewerCtrl1.Rotation = (short)RotateAmount;
            }
            else
            {
                ViewerCtrl2.Rotation = (short)RotateAmount;
            }
            ViewerCtrl1.Rotation = (short)RotateAmount;
            viewImage1.FlitVertical(); 
        }

        private void BtnRotateLeft_Click(Object eventSender, EventArgs eventArgs)
        {
            RotateAmount -= 90;
            if (RotateAmount < 0)
            {
                RotateAmount = 360 + RotateAmount;
            }
            if (BandeInsert == 0)
            {
                ViewerCtrl1.Rotation = (short)RotateAmount;
            }
            else
            {
                ViewerCtrl2.Rotation = (short)RotateAmount;
            }
            ViewerCtrl1.Rotation = (short)RotateAmount;
            viewImage1.FlitHorizontal(); 
        }

        private void BtnSalvar_Click(Object eventSender, EventArgs eventArgs)
        {
            Module1.oDocument.Save();
            //IDMListView.ClearItems
            //IDMViewerCtrl1.Document = oDocument
        }

        private void BtnScanear_Click(Object eventSender, EventArgs eventArgs)
        {
            if ((Conversion.Val(TxtFolioUOC.Text) == 0 || Conversion.Val(TxtCliente.Text) == 0 || CboTipoDoc.SelectedIndex == -1) && Module1.TipoOper != 1)
            {
                MessageBox.Show(this, "Favor de teclear el Folio Uoc, Cliente, Tipo Documento como minimo", Application.ProductName);
                return;
            }
            ImgScan1_ScanStarted(eventSender, new EventArgs());
            

        }

        private void BtnZoomIn_Click(Object eventSender, EventArgs eventArgs)
        {
            if (BandeInsert == 0)
            {
                ViewerCtrl1.ZoomIn();
            }
            else
            {
                ViewerCtrl2.ZoomIn();
            }
            ViewerCtrl1.ZoomIn();
            viewImage1.ZoomIn(); 
        }

        private void BtnZoomOut_Click(Object eventSender, EventArgs eventArgs)
        {
            if (BandeInsert == 0)
            {
                ViewerCtrl1.ZoomOut();
            }
            else
            {
                ViewerCtrl2.ZoomOut();
            }
            ViewerCtrl1.ZoomOut();
            viewImage1.ZoomOut(); 
        }

        private void CboTipoDoc_Click(Object eventSender, EventArgs eventArgs)
        {
            Valida_Controles();
        }

        private void CboTipoDoc_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            CboTipoDoc_Click(eventSender, eventArgs);
        }

        private void Form_Initialize_Renamed()
        {
            
            //if (String.IsNullOrEmpty(Module1.CommandLine))
            Module1.CommandLine = Interaction.Command().Trim(); //Trim(UCase(Command()))
            //MsgBox CommandLine
            Module1.XTipoDoc = 1; // Instrunción default para Consulta
            Module1.UOC = 4519;
            Module1.XFolio = "451919001";
            Module1.XFecha = DateTime.Now.ToString("MM/dd/yyyy");
            Bande = 0;
            Module1.SalirReg = 1;
            Module1.TipoOper = 0;
            Module1.XArchivo = String.Empty;

        }

        private void FormMain_Load(Object eventSender, EventArgs eventArgs)
        {
            //Dim oLib As New IDMObjects.Library
            Module1.oLibraries = (IDMObjects.ObjectSet)Module1.oNeighborhood.Libraries;
            IDMObjects.Library oLib = (IDMObjects.Library)Activator.CreateInstance(Type.GetTypeFromProgID("idmObjects.Library"));
            oLib.SystemType = IDMObjects.idmSysTypeOptions.idmSysTypeIS;
            byte Bande = 0;            
            this.WindowState = FormWindowState.Maximized;
            Module1.DocList[0].fileName = "";
            Module1.TotalDocs = 0;
            CommCount = 0;
            BandeInsert = 0;

            Module1.gbISLogOff = false;
            CboResol.SelectedIndex = 0;

            //DirWinTemp = "C:\\APPS\\CreditoEmpresarial\\";  
            if (File.Exists(Module1.TmpImg + "img1.tif")) 
            {
                try { File.Delete(Module1.TmpImg  + "img1.tif"); }
                catch { }
            }
            if (File.Exists(Module1.TmpImg + "img2.tif"))
            {
                try { File.Delete(Module1.TmpImg + "Img2.tif"); }
                catch { }
            }

            //AVG Ini Sept-2015
            string tempRefParam = Module1.TmpImg  + "*.tif";
            bool Borrados = KillFile(ref tempRefParam) != 0;
            if (!Borrados)
            {
                FileSystem.PrintLine(1, "No pude borrar imagenes existentes ImgTiff");
            }
            tempRefParam = Module1.TmpImg + "*.tmp";
            Borrados = KillFile(ref tempRefParam) != 0;
            if (!Borrados)
            {
                FileSystem.PrintLine(1, "No pude borrar imagenes existentes Imgtmp");
            }
            Llena_Parametros(1);
            //AVG Fin Sept-2015

            string Libreria = Module1.fncParmIniGet("C406090", "FileNET", Module1.DirConf + "C406090.ini");

            if (Libreria == string.Empty)
            {
                MessageBox.Show(this, "No se encuentra el archivo de inicio de FileNET", Application.ProductName);
                oLib = null;
                Environment.Exit(0);
                
                //throw new Module1.ExitEnvironmentException();

            }

            //Set oLibraries = oNeighborhood.Libraries
            //Dim oLib As IDMObjects.Library
            //If Not ConnectToLibraries Then
            //    RestoreSettings (True)
            //Else
            //    If gbISLogOff = False Then
            //        End
            //    End If
            //End If

            //oLib.SystemType = idmSysTypeIS
            //Set oLib = oNeighborhood.DefaultLibrary     'Toma la librería default

            int Count = (int)Module1.oLibraries.Count;

            for (int i = 1; i <= Count; i++)
            {
                if ((((IDMObjects.Library)Module1.oLibraries[i]).Name) == "DefaultIMS:" + Libreria)
                {
                    Bande = 1;
                    oLib = (IDMObjects.Library)Module1.oLibraries[i];
                    break;
                }
            }

            if (Bande == 0)
            {
                oLib.Name = Libreria;
            }

            //AVG Ini Sept-2015
            //Llena_Parametros();
            Llena_Parametros(2);
            //AVG Fin Sept-2015

            if (Module1.TipoOper == 0)
            {
                MessageBox.Show(this, "Parámetros No decuados para Ejecutar el Programa", Application.ProductName);
                oLib = null;
                this.Close();
                Environment.Exit(0);
            }
            MyLogon(oLib); // Hace LOGON a librería
            if (!(oLib.GetState(IDMObjects.idmLibraryState.idmLibraryLoggedOn)))
            {
                MessageBox.Show(this, "Error en logon a librería", Application.ProductName);
                Module1.gbISLogOff = false;
                Environment.Exit(0);
                
                //throw new Module1.ExitEnvironmentException();

            }
            else
            {
                Module1.gbISLogOff = true;
                Module1.oLibrary = oLib; // Hace la librería global por flexibilidad
            }

            Artinsoft.VB6.Gui.SSTabHelper.SetTabEnabled(SSTab1, 1, false);

            Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
            Llena_TipoDocto();

            //AVG Ini 25-04-2012
            Llena_UOCs();
            //AVG Fin 25-04-2012

            TxtFolioUOC.Text = Module1.XFolio;

            if (Module1.TipoOper == 1 || Module1.TipoOper == 7)
            {
                CboTipoDoc.SelectedIndex = -1;
                for (int i = 0; i <= CboTipoDoc.Items.Count - 1; i++)
                {
                    if (VB6.GetItemData(CboTipoDoc, i) == Module1.XTipoDoc)
                    {
                        CboTipoDoc.Text = VB6.GetItemString(CboTipoDoc, i);
                        CboTipoDoc.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i <= CboUOC.Items.Count - 1; i++)
                {
                    if (CboUOC.Items[i].ToString() == Module1.UOC.ToString())
                    {
                        CboUOC.Text = CboUOC.Items[i].ToString();
                        CboUOC.SelectedIndex = i;
                        break;
                    }
                }

            
                if (Module1.XArchivo.Trim().Length > 0)
                {
                    BtnDone.Enabled = true;
                    BtnDeletePage.Enabled = false;
                    //AVG Ini Setp-2015
                    BtnSaveas.Enabled = true;
                    //AVG Fin Setp-2015

                }
                else
                {
                    BtnDone.Enabled = false;
                    BtnDeletePage.Enabled = false;
                    //AVG Ini Setp-2015
                    BtnSaveas.Enabled = false;
                    //AVG Fin Setp-2015
                }

                BtnZoomIn.Enabled = false;
                BtnZoomOut.Enabled = false;
                BtnRotateLeft.Enabled = false;
                BtnRotate.Enabled = false;
                BtnPrint.Enabled = false;
                CboTipoDoc.Enabled = false;
                CboUOC.Enabled = false;
                TxtFolioUOC.Enabled = false;


                if (File.Exists(Module1.XArchivo.Trim()))            
                { 
                    if (Module1.XArchivo.Trim().Length > 0)
                    {
                        LoadFiles(2);
                        BandeInsert = 0;
                        LoadFiles(1);
                        // AVG Ini 08-Jun-2014
                        if (Module1.TipoOper == 7)
                        {
                            ParteImg2(Module1.XArchivo);                                                
                        }
                        // AVG Fin 08-Jun-2014
                        LoadFiles(5);
                        if (Module1.TipoOper == 7)
                        {
                            Module1.SalirReg = 1;
                            BtnDone_Click(BtnDone, eventArgs); 
                        }
                    }
                }

            }
            else
            {
                Valida_Controles();
                BtnDeletePage.Enabled = false;
                BtnPrint.Enabled = false;
            }
            SSTab1.SelectedIndex = 0;
            Module1.XProd = DBNull.Value;
            Module1.XInst = DBNull.Value;
            Module1.XCalifOnd = DBNull.Value;
            Module1.XFile = DBNull.Value;
            oLib = null;

            this.WindowState = FormWindowState.Maximized;

        }

        private void FormMain_Closed(Object eventSender, EventArgs eventArgs)
        {
            //Unload PropertyForm
            Module1.oErrManager = null;
            if (Module1.oLibrary.GetState(IDMObjects.idmLibraryState.idmLibraryLoggedOn))
            {
                Module1.oLibrary.Logoff();
            }
            Module1.XArchivo = Module1.TmpImg + "img1.tif";
            try
            {
                File.Delete(Module1.XArchivo);
            } catch { }
            Module1.XArchivo = Module1.TmpImg + "img2.tif";
            try
            {
                File.Delete(Module1.XArchivo);
            }
            catch { }
            this.Dispose(); 
        }

        
        private void releaseResources(Object eventSender, EventArgs eventArgs)
        {
            m_vb6FormDefInstance = null;
        }
        
        private void IDMListView1_DblClick(object sender, EventArgs e)
        {
            string Cade1 = String.Empty;
            string Cade = String.Empty;
            string cade2 = String.Empty;
            byte PosPunto = 0;
            if (IDMListView1.SelectedItem != null)
            {
                Module1.oDocument = (IDMObjects.Document)IDMListView1.SelectedItem;
                BtnPrint.Enabled = true;
                ViewerCtrl1.Document = Module1.oDocument;

                if (MessageBox.Show(this, "Desea Editar la Imagen Seleccionada ?", Application.ProductName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Cade = Module1.oDocument.GetCachedFile(0, "", null);
                    cade2 = Cade;
                    Cade1 = Module1.GetFileName(ref cade2);
                    PosPunto = (byte)Cade1.IndexOf(".FOB");
                    Cade1 = Module1.TmpImg + Cade1.Substring(0, Math.Min(Cade1.Length, PosPunto)) + ".tif";
                    if (File.Exists(Cade1))
                    {
                        try
                        {
                            File.Delete(Cade1);  
                        }
                        catch { }
                    }
                    // Copia el archivo de cache a Ubicacion de trabajo
                    try
                    {
                        File.Copy(Cade, Cade1, true);
                    } catch { }
                    //ViewerCtrl1.Brightness = (IDMViewerCtrl.idmBrightness)IDMObjects.idmBrightness.idmBrightnessDarker;
                    ViewerCtrl1.Rotation = 0;
                    Module1.XArchivo = Cade1;
                    LoadFiles(2);
                    BandeInsert = 0;
                    LoadFiles(1);
                    LoadFiles(5);
                    Module1.oDocument.Delete();
                    if (File.Exists(Cade1))
                    {
                        try
                        {
                            File.Delete(Cade1);
                        }
                        catch { }
                    }
                    return;

                    //if (Module1.TotalDocs > 0)
                    //{                       
                    //    int tempRefParam = 0;
                    //    LoadDocument(tempRefParam);
                    //    BtnPrevious.Enabled = false;
                    //    NavForward = true;
                    //    BtnNext.Enabled = Module1.TotalDocs > 1;
                    //    BtnDone.Enabled = true;
                    //    BtnDeletePage.Enabled = true;
                    //}
                    //else
                    //{
                    //    ViewerCtrl1.Document = null;
                    //    BtnDeletePage.Enabled = false;
                    //}
                }
            }
            else
            {
                BtnPrint.Enabled = false;
            }
        }

        private void ImgScan1_ScanDone(Object eventSender, EventArgs eventArgs)
        {
            //FSQ20070510. Changed by try..catch
            //On Error Resume Next;
            Application.DoEvents();
            Application.DoEvents();
            try { ImgScan1.CloseScanner(); }
            catch { }
            Pause(2);
            Application.DoEvents();
            Application.DoEvents();
            ImgScan1.Image = String.Empty; 
            //On Error Resume Next
            //ImgScan1.ResetScanner
            //ImgScan1.StopScan
            //ImgScan1.ScanTo = FileOnly
            LoadFiles(5);

            /*if (Module1.TotalDocs > 0)
            {
                Module1.CurrentDocInx = 0;
                LoadDocument(Module1.CurrentDocInx);
            }*/
        }

        private void ImgScan1_ScanStarted(object sender, EventArgs e)
        {
            Application.DoEvents();
            Application.DoEvents();
            ImgAdmin1.Image = string.Empty;
            ImgScan1.Image = string.Empty;
            if (BandeInsert == 0)
            {
                ViewerCtrl1.DocumentFilename = String.Empty;
                Module1.DocList[0].fileName = "";
                Module1.TotalDocs = 0;
                CommCount = 0;
            }
            else
            {
                ViewerCtrl2.DocumentFilename = String.Empty;
            }

            if ((BandeInsert ==0 ) && ViewerCtrl2.DocumentFilename == String.Empty && ViewerCtrl2.Visible == false)
            {
                Module1.XArchivo = Module1.TmpImg + "img1.tif";               
            }
            else
            {
                Module1.XArchivo = Module1.TmpImg + "img2.tif";
            }
            if (File.Exists(Module1.XArchivo))
            {
                try
                {
                    File.Delete(Module1.XArchivo);
                }
                catch { }
            }

            ImgScan1.ShowSelectScanner();
            ImgScan1.OpenScanner();

            BtnDeletePage.Enabled = true;
            ImgScan1.Image = Module1.XArchivo;
            ImgScan1.MultiPage = true;
            ImgScan1.ScanTo = ScanLibCtl.ScanToConstants.DisplayAndFile;
            try
            {
                ImgScan1.StartScan();
            }  catch { }
        }

        private void TxtCliente_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            double dbNumericTemp = 0;
            if (!Double.TryParse(TxtCliente.Text, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) && TxtCliente.Text.Trim().Length > 0)
            {
                MessageBox.Show(this, "Debe escribir Números", "SRYCD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCliente.Text = String.Empty;
            }
        }

        private void TxtCliente_Enter(Object eventSender, EventArgs eventArgs)
        {
            TxtCliente.SelectionStart = 0;
            TxtCliente.SelectionLength = (int)TxtCliente.Text.Length;
        }

        private void TxtContrato_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            double dbNumericTemp = 0;
            if (!Double.TryParse(TxtContrato.Text, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) && TxtContrato.Text.Trim().Length > 0)
            {
                MessageBox.Show(this, "Debe escribir Números", "SRYCD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtContrato.Text = String.Empty;
            }
        }

        private void TxtContrato_Enter(Object eventSender, EventArgs eventArgs)
        {
            TxtContrato.SelectionStart = 0;
            TxtContrato.SelectionLength = (int)TxtContrato.Text.Length;
        }

        private void TxtFolioS403_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            double dbNumericTemp = 0;
            if (!Double.TryParse(TxtFolioS403.Text, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) && TxtFolioS403.Text.Trim().Length > 0)
            {
                MessageBox.Show(this, "Debe escribir Números", "SRYCD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFolioS403.Text = String.Empty;
            }
        }

        private void TxtFolioS403_Enter(Object eventSender, EventArgs eventArgs)
        {
            TxtFolioS403.SelectionStart = 0;
            TxtFolioS403.SelectionLength = (int)TxtFolioS403.Text.Length;
        }

        private void TxtFolioUOC_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            double dbNumericTemp = 0;
            if (!Double.TryParse(TxtFolioUOC.Text, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) && TxtFolioUOC.Text.Trim().Length > 0)
            {
                MessageBox.Show(this, "Debe escribir Números", "SRYCD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFolioUOC.Text = String.Empty;
            }
        }

        private void TxtFolioUOC_Enter(Object eventSender, EventArgs eventArgs)
        {
            TxtFolioUOC.SelectionStart = 0;
            TxtFolioUOC.SelectionLength = (int)TxtFolioUOC.Text.Length;
        }

        private void TxtLinea_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            double dbNumericTemp = 0;
            if (!Double.TryParse(TxtLinea.Text, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) && TxtLinea.Text.Trim().Length > 0)
            {
                MessageBox.Show(this, "Debe escribir Números", "SRYCD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtLinea.Text = String.Empty;
            }
        }

        private void TxtLinea_Enter(Object eventSender, EventArgs eventArgs)
        {
            TxtLinea.SelectionStart = 0;
            TxtLinea.SelectionLength = (int)TxtLinea.Text.Length;
        }

        private double SizePagina()
        {
            // Guarda la PAGINA cargada en el control como un archivo temporal para medir su Size
            // y los regresa como respuesta de la funcion
            string ArchTrab = Module1.TmpImg + "\\SizeTest.tif";
            FileSystem.FileOpen(99, ArchTrab, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
            FileSystem.FileClose(99);
            File.Delete(ArchTrab); //Borra archivo de trabajo
            //Gear1.SaveImage = ArchTrab;
            return (new FileInfo(ArchTrab)).Length;
        }

        private void ParticionaImg(string NomArchivo)
        {
            int X, Y, i;
            Cursor.Current = Cursors.WaitCursor;                        
            ImGearDocument igDocument;
            igDocument = new ImGearDocument();
            //FSQSABORIO 20080128. Try..catch agregado ya que en VB6 no se lanza excepcion cuando el archivo no existe
            try
            {
                using (FileStream stream = new FileStream(NomArchivo, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    //NOTA:  El segmento marcado será eliminado cuando se tenga a disposición la licencia de la aplicación, 
                    //       al ser un trial se le debe de agregar lo siguiente:
                    //Eliminar
                    ImageGear.Core.ImGearLicense.SetSolutionName("Banamex");
                    //unchecked
                    //{
                    ImageGear.Core.ImGearLicense.SetSolutionKey((uint)0xDF4F2A7C, (uint)0xFFF24DAD, (uint)0x3C23EFCE, (uint)0x77EE247F);
                    //}
                    ImageGear.Core.ImGearLicense.SetOEMLicenseKey("1.0.EhemHZSiI8zDW6vNQ6XgQZd8GyHiamOBGwQhpBvhOVnZHNIiH6XbG6WZIbIAGivmGynYe6QNzbW8SBpBxwSyWBGhpmONvBxNX6aYOmpmQZzmIyz8xgehpiaDGbOAXVX8OhaiWAnwayHYxDemeieyvgXyeYWYWZQZOmXwWDWZXDv8GNnYIYzBpwXYpidNzZe6zbeAamXBIgdwzbxYxVImpiGBGYXZHZnBXwdDxiQBaBQYQVxYOiW6QVpDvDv6pZIVdheDGheiOYQNQyeAOgeBdAXZODeNeyGmOwIBaVnZGDGBODHmpin6HbSDvhpiSyIZawe6dwIDvDIQOHy");
                    //FSQSABORIO 20080128. Esta linea si debe mantenerse
                    igDocument = ImGearFileFormats.LoadDocument(stream, 0, -1);
                }
            }
            catch(Exception E) { }
            igDocument.Metadata.Format = ImGearMetadataFormats.TIF;
            igDocument.Metadata.TIFF.Compression = ImageGear.Formats.TIF.ImGearTIFFCompression.GROUP_4;
            string ArchTemp = Module1.TmpImg + "ArcTemp.tif";

            if (File.Exists(ArchTemp))
            {
                try
                {
                    File.Delete(ArchTemp);
                }
                catch { }
            }
            try
            {
                for (i = 0; i < igDocument.Pages.Count; i++)
                {
                    if (igDocument.Pages[i].DIB.ImageResolution.Units != ImGearResolutionUnits.INCHES)
                    {
                        igDocument.Pages[i].DIB.ImageResolution.ConvertUnits(ImGearResolutionUnits.INCHES);
                    }
                    if ((igDocument.Pages[i].DIB.ImageResolution.XNumerator > 200)
                        || (igDocument.Pages[i].DIB.ImageResolution.YNumerator > 200))
                    {
                        X = igDocument.Pages[i].DIB.Width;
                        Y = igDocument.Pages[i].DIB.Height;

                        if (igDocument.Pages[i].DIB.ImageResolution.XNumerator > 200)
                        {
                            igDocument.Pages[i].DIB.ImageResolution.XNumerator = 200;
                        }
                        if (igDocument.Pages[i].DIB.ImageResolution.YNumerator > 200)
                        {
                            igDocument.Pages[i].DIB.ImageResolution.YNumerator = 200;
                        }
                        if (igDocument.Pages[i].DIB.BitDepth == 1)
                            ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearGrayScaleInterpolationOptions(50));
                        else
                            ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearNoneInterpolationOptions());

                        if (igDocument.Pages[i].DIB.BitDepth > 1)
                        {
                            ImGearRasterProcessing.Reduce((ImGearRasterPage)igDocument.Pages[i],
                                new ImGearColorSpace(ImGearColorSpaceIDs.I), new int[] { 1 }, ImGearReductionMethods.BAYER, new ImGearReductionOptions());
                        };
                    }
                    else
                    {
                        if (igDocument.Pages[i].DIB.BitDepth > 1)
                        {
                            ImGearRasterProcessing.Reduce((ImGearRasterPage)igDocument.Pages[i],
                                new ImGearColorSpace(ImGearColorSpaceIDs.I), new int[] { 1 }, ImGearReductionMethods.BAYER, new ImGearReductionOptions());
                        }
                        //X = igDocument.Pages[i].DIB.Width;
                        //Y = igDocument.Pages[i].DIB.Height;
                        //if (igDocument.Pages[i].DIB.BitDepth == 1)
                        //    ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearGrayScaleInterpolationOptions(50));
                        //else
                        //   ImGearProcessing.Resize(igDocument.Pages[i], X, Y, new ImGearNoneInterpolationOptions());
                    }

                    using (FileStream stream = new FileStream(ArchTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Write))
                    {
                        ImGearFileFormats.SavePage(igDocument.Pages[i], stream, i, ImGearSavingModes.APPEND, ImGearSavingFormats.TIF_G4);
                    }
                    Application.DoEvents();
                    Application.DoEvents();
                }
            }
            catch { }
            try
            {
                ImgScan1.Image = String.Empty;
            } catch {}
            try
            {
                ImgAdmin1.Image = String.Empty;
            } catch { }
            //catch (Exception ER1) { }
            //try { ViewerCtrl1.DocumentFilename = String.Empty; }
            //catch { }
            try
            {
                File.Copy(ArchTemp, NomArchivo, true);
            }
            catch { }
            try
            {
                File.Delete(ArchTemp);
            }
            catch { }
            Module1.XArchivo = NomArchivo;
            Cursor.Current = Cursors.Default;
        }

  
        private void MyLogon(IDMObjects.Library oLibrary)
        {
            try
            { // Enable error-handling routine.
                if (!(oLibrary.GetState(IDMObjects.idmLibraryState.idmLibraryLoggedOn)))
                {
                    //Module1.ObtPassSapuf();
                    if (Module1.Pass_Sapuf.Trim().Length > 0)
                    {
                        //UPGRADE_WARNING:Casting 'int' to Enum may cause different behaviour. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FF8AAC19-CE56-4016-821F-92D4B80111D8"'
                        oLibrary.Logon("c406_090", Module1.Pass_Sapuf, "", (IDMObjects.idmLibraryLogon)Module1.dmLogonOptNoUI);
                    }
                }
            }
            catch
            { // Exit to avoid handler.		
                //Print #1, "Librería no disponible : "; Time; Err.Description & Err.Number				
                //MsgBox Err.Description & Err.Number
            }
        }

        private void Llena_Parametros(byte opc)
        {
            int Temp1 = 0;
            int Temp2 = 0;
            string Temp3 = String.Empty;
            // CommandLine= U4519uD81d(13)¿08/03/2005?@d:\607732_1.tif&[1]
            if (Module1.CommandLine.ToString().Trim().Length > 0)
            {
                 switch (opc)
                 {
                    case 1:
                        if (Module1.CommandLine.ToString().IndexOf('{') >= 0)
                        {
                            Temp1 = (Module1.CommandLine.ToString().IndexOf('{') + 1);
                            Temp2 = (Module1.CommandLine.ToString().IndexOf('}', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                Module1.Pass_Sapuf = Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                                if (Temp1 > 2)
                                {
                                    Module1.CommandLine = Strings.Mid(Module1.CommandLine.ToString(), 1, Temp1 - 1);
                                }
                                else
                                {
                                    Module1.CommandLine = Strings.Mid(Module1.CommandLine.ToString(), Temp2 + 1, Module1.CommandLine.Length - Temp2);
                                }
                            }
                        }
                        if (Module1.CommandLine.ToString().IndexOf('[') >= 0 && Module1.CommandLine.ToString().IndexOf(']') >= 0)
                        {
                            Temp1 = (Module1.CommandLine.ToString().IndexOf('[') + 1);
                            Temp2 = (Module1.CommandLine.ToString().IndexOf(']', Temp1) + 1);
                            if (Temp2 > Temp1)
                            {
                                Temp3 = Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                                if (Conversion.Val(Temp3) > 0)
                                {
                                    Module1.TipoOper = Byte.Parse(Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1));
                                }
                            }

                        }
                       break;

                default:

                    if (Module1.CommandLine.ToString().IndexOf('U') >= 0 && Module1.CommandLine.ToString().IndexOf('u') >= 0)
                    {
                        Temp1 = (Module1.CommandLine.ToString().IndexOf('U') + 1);
                        Temp2 = (Module1.CommandLine.ToString().IndexOf('u', Temp1) + 1);
                        if (Temp2 > Temp1)
                        {
                            Temp3 = Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            if (Conversion.Val(Temp3) > 0)
                            {
                                Module1.UOC = Int32.Parse(Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1));
                            }
                        }
                        //MsgBox "UOC :" & UOC
                    }
                    if (Module1.CommandLine.ToString().IndexOf('D') >= 0 && Module1.CommandLine.ToString().IndexOf('d') >= 0)
                    {
                        Temp1 = (Module1.CommandLine.ToString().IndexOf('D') + 1);
                        Temp2 = (Module1.CommandLine.ToString().IndexOf('d', Temp1) + 1);
                        if (Temp2 > Temp1)
                        {
                            Temp3 = Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            if (Conversion.Val(Temp3) > 0)
                            {
                                Module1.XTipoDoc = Int32.Parse(Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1));
                            }
                        }
                        //MsgBox "Tipo Docto :" & XTipoDoc
                    }
                    if (Module1.CommandLine.ToString().IndexOf('(') >= 0 && Module1.CommandLine.ToString().IndexOf(')') >= 0)
                    {
                        Temp1 = (Module1.CommandLine.ToString().IndexOf('(') + 1);
                        Temp2 = (Module1.CommandLine.ToString().IndexOf(')', Temp1) + 1);
                        if (Temp2 > Temp1)
                        {
                            Temp3 = Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            if (Conversion.Val(Temp3) > 0)
                            {
                                Module1.XFolio = Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }
                        }
                        //MsgBox " Folio :" & XFolio
                    }
                    if (Module1.CommandLine.ToString().IndexOf('¿') >= 0 && Module1.CommandLine.ToString().IndexOf('?') >= 0)
                    {
                        Temp1 = (Module1.CommandLine.ToString().IndexOf('¿') + 1);
                        Temp2 = (Module1.CommandLine.ToString().IndexOf('?', Temp1) + 1);
                        if (Temp2 > Temp1)
                        {
                            Temp3 = Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            if (Temp3.Length > 0)
                            {
                                Module1.XFecha = Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }
                        }
                        //MsgBox " Fecha :" & XFecha
                    }
                    if (Module1.CommandLine.ToString().IndexOf('@') >= 0 && Module1.CommandLine.ToString().IndexOf('&') >= 0)
                    {
                        Temp1 = (Module1.CommandLine.ToString().IndexOf('@') + 1);
                        Temp2 = (Module1.CommandLine.ToString().IndexOf('&', Temp1) + 1);
                        if (Temp2 > Temp1)
                        {
                            Temp3 = Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            if (Temp3.Length > 0)
                            {
                                Module1.XArchivo = Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                                Module1.XArchivo1 = Module1.XArchivo;
                            }
                        }
                        //MsgBox " Archivo :" & XArchivo
                    }
                    //AVG Ini Setp-2015
                    if (Module1.CommandLine.ToString().IndexOf('¡') >= 0 && Module1.CommandLine.ToString().IndexOf('!') >= 0)
                    {
                        Temp1 = (Module1.CommandLine.ToString().IndexOf('¡') + 1);
                        Temp2 = (Module1.CommandLine.ToString().IndexOf('!', Temp1) + 1);
                        if (Temp2 > Temp1)
                        {
                            Temp3 = Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            if (Conversion.Val(Temp3) > 0)
                            {
                                Module1.XSubFolio = Strings.Mid(Module1.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }
                        }
                        //MsgBox " SubFolio :" & XSubFolio
                    }
                    //AVG Fin Setp-2015
                    break;
                }
            }
            else
            {
                Module1.XArchivo = String.Empty;
            }
        }

        public void setData(string args)
        {
            Module1.CommandLine = args;
            Module1.HomeDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            // These arrays will be resized after files are loaded...
            Module1.ArraySz = Module1.InitArraySz;
            Module1.DocList = new DocInfo[Module1.ArraySz + 1];
            Module1.FinalList = new IDMObjects.Document[Module1.ArraySz + 1];
            Module1.FolderList = new string[Module1.ArraySz + 1];
        }

        private void BtnPDFtoTIFF_Click(object sender, EventArgs e)
        {
            //Computer MyComputer = new Computer();
            //MyComputer.FileSystem.CurrentDirectory = Module1.HomeDirectory + "\\ReadQR";
            //ReadQR.Program.TipoConvPDF = ReadQR.Program.ArchivePDFtoArchiveTiff;            
            //ReadQR.Program.RutaAppWork = Module1.HomeDirectory + "\\ReadQR";
            //ReadQR.Program.MuestraForma();            
            //MyComputer.FileSystem.CurrentDirectory = Module1.HomeDirectory;
            Computer MyComputer = new Computer();
            MyComputer.FileSystem.CurrentDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\ReadQR";
            ReadQR.Program.TipoConvPDF = ReadQR.Program.ArchivePDFtoArchiveTiff;
            ReadQR.Program.ArchivePDForTIFF = string.Empty; 
            ReadQR.Program.RutaAppWork = Path.GetDirectoryName(Application.ExecutablePath) + "\\ReadQR";
            ReadQR.Program.MuestraForma();
            MyComputer.FileSystem.CurrentDirectory = Path.GetDirectoryName(Application.ExecutablePath);

        }

        static private int KillFile(ref  string sFileSpec)
        {
            int result = 0;

            string sFileName = String.Empty;
            string sDirName = String.Empty;
            string Msg = String.Empty;
            DialogResult iResult = (DialogResult)0;
            try
            {
                sDirName = sParsePath(sFileSpec);
                sFileName = FileSystem.Dir(sFileSpec, Microsoft.VisualBasic.FileAttribute.Normal);

                while (!string.IsNullOrEmpty(sFileName))
                {
                    try
                    {
                        File.Delete(sDirName + sFileName);
                        sFileName = FileSystem.Dir(sFileSpec, FileAttribute.Normal);
                    }
                    catch
                    {
                        sFileName = string.Empty;
                    }

                };

                return -1;
            }
            catch
            {
                switch (Information.Err().Number)
                {
                    case 53:
                    case 70:
                        Msg = "Disco protegido contra escritura. Desprotéjalo para poder borrar.";
                        MessageBox.Show(Msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new Exception("'Resume' not supported");
                        break;
                    case 75:
                        (new FileInfo(sDirName + sFileName)).Attributes = 0;
                        throw new Exception("'Resume' not supported");
                        break;
                    default:
                        iResult = MessageBox.Show("Error: [" + Conversion.ErrorToString(0) + "]", "Atención", MessageBoxButtons.OK | MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        result = 0;
                        break;
                }
            }
            return result;
        }

        static private string sParsePath(string sPathIn)
        {

            int i = 0;

            for (i = sPathIn.Length; i >= 1; i--)
            {
                if ((":\\").IndexOf(sPathIn[i - 1].ToString()) >= 0)
                {
                    break;
                }
            }
            return sPathIn.Substring(0, Math.Min(sPathIn.Length, i));

        }

        //AVG Ini Sept-2015
        private void BtnSaveas_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "TIF files (*.tif)|*.tif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();
            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                try 
                {
                    if (File.Exists( saveFileDialog1.FileName)) 
                    {
                        File.Delete(saveFileDialog1.FileName); 
                    }
                }
                catch {}
                File.Copy(Module1.XArchivo, saveFileDialog1.FileName);
                MessageBox.Show(this, "Archivo copiado : " + saveFileDialog1.FileName, Application.ProductName);
            }
        }

        private bool isTifDocument(string nameFile)
        {
            bool result = false;
            string[] parts = nameFile.Split('.');
            if (parts.Length > 1)
            {
                if (parts[parts.Length - 1].Equals("tif") || parts[parts.Length - 1].Equals("tiff"))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
        //AVG Fin Sept-2015
    }
}
