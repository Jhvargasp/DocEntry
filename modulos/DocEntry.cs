using System.Threading;
using Microsoft.VisualBasic;

using System.Windows.Forms;

using System.IO;


using System;

using System.Runtime.InteropServices;

using Microsoft.Win32;

using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using FileNet.Api.Core;

namespace DocEntry
{
    public enum CommitValues
    {
        UnDecided = -1,
        DontCommit = 0,
        Commit = 1
    }
    public struct DocInfo
    {
        public CommitValues CommitFlag;
        public string fileName;
    }
    public class Module1
    {
        
        //public class ExitEnvironmentException : Exception { }

        public const IDMObjects.idmLibraryLogon dmLogonOptNoUI = 0; // Do not display a user interface.
        public const int idmLogonOptServerNetworkNoUI = 16; // (&H10)   Log on in server mode and use network logon credentials; do not display a user interface.
        public const int idmLogonOptServerNoUI = 8; // Log on in server mode; do not display a user interface.
        public const int idmLogonOptUseNetworkNoUI = 2; // Use network logon credentials; do not display a user interface.
        public const int idmLogonOptUseNetworkWithUI = 4; // Use network logon credentials; display a user interface.
        public const int idmLogonOptWithUI = 1; // Display a logon user interface.


        /* Avg  Ini 14/01/20109 */
        public static string DirWork = string.Empty;
        public static string DirLog = string.Empty;
        public static string DirConf = string.Empty;
        public static string TmpImg = string.Empty;
        /* Avg  Fin 14/01/20109 */

        static private clsSimpleQuery _clsQuery;
        static public clsSimpleQuery clsQuery
        {
            get
            {
                if (_clsQuery == null)
                    _clsQuery = new clsSimpleQuery();
                return _clsQuery;
            }
            set
            {
                _clsQuery = value;
            }
        }

        static private IDMObjects.Neighborhood _oNeighborhood;
        static public IDMObjects.Neighborhood oNeighborhood
        {
            get
            {
                if (_oNeighborhood == null)
                    _oNeighborhood = new IDMObjects.Neighborhood();

                return _oNeighborhood;
            }
            set
            {
                _oNeighborhood = value;
            }
        }

        static private IDMObjects.ObjectSet _oLibraries;
        static public IDMObjects.ObjectSet oLibraries
        {
            get
            {
                if (_oLibraries == null)
                    _oLibraries = new IDMObjects.ObjectSet();
                return _oLibraries;
            }
            set
            {
                _oLibraries = value;
            }
        }

        //static private IDMObjects.Document _oDocument;
        static private IDocument _oDocument;
        // static public IDMObjects.Document oDocument
        static public IDocument oDocument
        {
            get
            {
                /*if (_oDocument == null)
                    _oDocument = new IDMObjects.Document();
                    */
                return _oDocument;
            }
            set
            {
                _oDocument = value;
            }
        }

        //static private IDMObjects.Library _oLibrary;
        static private IObjectStore _oLibrary;
        //static public IDMObjects.Library oLibrary
        static public IObjectStore oLibrary
        {
            get
            {
                //if (_oLibrary == null)
                  //  _oLibrary = new IDMObjects.Library();

                return _oLibrary;
            }
            set
            {
                _oLibrary = value;
            }
        }

        //static public IDMObjects.PropertyDescriptions goPropDescs; 
        static public FileNet.Api.Collection.IPropertyDescriptionList goPropDescs = null;

        static public bool gbISLogOff = false;

        static private frmSettings _gfSettings;
        static public frmSettings gfSettings
        {
            get
            {
                if (_gfSettings == null)
                    _gfSettings = new frmSettings();
                return _gfSettings;
            }
            set
            {
                _gfSettings = value;
            }
        }

        static private clsRegPersist _goPersist;
        static public clsRegPersist goPersist
        {
            get
            {
                if (_goPersist == null)
                    _goPersist = new clsRegPersist();

                return _goPersist;
            }
            set
            {
                _goPersist = value;
            }
        }

        public const string gsAppName = "Sistema de Registro y Custodia de Doctos";
        public const string gsSectionName = "FileNET";
        static public Collection gcHeadings;

        static public Collection _gcPropNames;
        static public Collection gcPropNames
        {
            get
            {
                if (_gcPropNames == null)
                    _gcPropNames = new Collection();
                return _gcPropNames;
            }
            set
            {
                _gcPropNames = value;
            }
        }

        static public object XCalifOnd = DBNull.Value;
        static public string CommandLine = String.Empty;
        static public object Ctox = null;
        static public long UOC = 0;
        static public byte TipoOper = 0;        
        static public object XInst = DBNull.Value;
        static public object XFile = DBNull.Value;
        static public object XProd = DBNull.Value;
        /******************************************/
        static public string XFolio = String.Empty;
        static public string XFecha = String.Empty;
        static public int XTipoDoc = 0;
        static public string XArchivo = String.Empty;
        static public string XArchivo1 = String.Empty;
        static public byte SalirReg = 0;
        static public byte VarCom = 0;

        public const int InitArraySz = 50; //  Initial size of DocList, FinalList
        static public int ArraySz = 0; //  Current array sizes
        static public DocInfo[] DocList; //  Primary array of selected filenames for browsing
        static public string[] FolderList; //  Optional folder for each document
        //static public IDMObjects.Document[] FinalList; //  Final array of FN DocObjects to be committed
        static public IDocument[] FinalList; //  Final array of FN DocObjects to be committed
        static public int TotalDocs = 0; //  Number of docs in DocList        
        // Use form variables to insulate code from form name changes

        //AVG Ini Setp-2015
        static public string XSubFolio = String.Empty;
        //AVG Fin Setp-2015

        static private FormMain _MainForm;
        static public FormMain MainForm
        {
            get
            {
                if (_MainForm == null)
                    _MainForm = new FormMain();

                return _MainForm;
            }
            set
            {
                _MainForm = value;
            }
        }

        //Public PropertyForm As New FormProperty

        static private FormProg _CommitForm = null;
        static public FormProg CommitForm
        {
            get
            {
                if (_CommitForm == null)
                    _CommitForm = new FormProg();

                return _CommitForm;
            }
            set
            {
                _CommitForm = value;
            }
        }

        /*
        static private IDMError.ErrorManager _oErrManager = null;
        static public IDMError.ErrorManager oErrManager
        {
            get
            {
                if (_oErrManager == null)
                    _oErrManager = new IDMError.ErrorManager();

                return _oErrManager;
            }
            set
            {
                _oErrManager = value;
            }
        }
        */
        static public string HomeDirectory = String.Empty; //  Home directory for finding icons
        //Public oLibrary As IDMObjects.Library   ' Current library in use

        static public int CurrentDocInx = 0; //  Current offset into DocList
        static public bool Online = false; //  Allows offline debugging
        static public string Pass_Sapuf = String.Empty;

        static public void ShowError()
        {
            /*
            int iCnt = 0;
            //Exit Sub
            Dim oErrCollect As idmError.ErrorManager
            IDMError.Errors oErrCollect = (IDMError.Errors)oErrManager.Errors;
            if (oErrCollect.Count > 1)
            {
                iCnt = 1;
                foreach (IDMError.Error oError in oErrCollect)
                {
                    MessageBox.Show("Error " + iCnt.ToString() + ": " + oError.Description + " : " + oError.Number.ToString("X"), Application.ProductName); iCnt++;
                }
            }
            else
            {
                if (oErrCollect.Count == 1)
                {
                    //oErrManager.ShowErrorDialog();
                    
                }
                else
                {
                    if (Information.Err().Number != 0)
                    {
                        MessageBox.Show(Information.Err().Description + " : " + Information.Err().Number.ToString(), Application.ProductName);
                    }
                }
            }*/
        }

        static public string FormatDataType(IDMObjects.idmTypeID TypeID)
        {
            switch (TypeID)
            {
                case IDMObjects.idmTypeID.idmTypeArray:
                    return "Array";
                case IDMObjects.idmTypeID.idmTypeBoolean:
                    return "Boolean";
                case IDMObjects.idmTypeID.idmTypeByte:
                    return "Byte";
                case IDMObjects.idmTypeID.idmTypeCharacter:
                    return "Character";
                case IDMObjects.idmTypeID.idmTypeCurrency:
                    return "Currency";
                case IDMObjects.idmTypeID.idmTypeDate:
                    return "Date";
                case IDMObjects.idmTypeID.idmTypeDouble:
                    return "Double";
                case IDMObjects.idmTypeID.idmTypeEmpty:
                    return "Empty";
                case IDMObjects.idmTypeID.idmTypeError:
                    return "Error";
                case IDMObjects.idmTypeID.idmTypeGuid:
                    return "GUID";
                case IDMObjects.idmTypeID.idmTypeLong:
                    return "Long";
                case IDMObjects.idmTypeID.idmTypeNull:
                    return "NULL";
                case IDMObjects.idmTypeID.idmTypeObject:
                    return "Object";
                case IDMObjects.idmTypeID.idmTypeShort:
                    return "Short";
                case IDMObjects.idmTypeID.idmTypeSingle:
                    return "Single";
                case IDMObjects.idmTypeID.idmTypeString:
                    return "String";
                case IDMObjects.idmTypeID.idmTypeUnknown:
                    return "Unknown";
                case IDMObjects.idmTypeID.idmTypeUnsignedLong:
                    return "Unsigned Long";
                case IDMObjects.idmTypeID.idmTypeUnsignedShort:
                    return "Unsigned Short";
                case IDMObjects.idmTypeID.idmTypeVariant:
                    return "Variant";
            }
            return "";
        }

        
        /*static int counter = 0;
        public static void Mostrar(String args)
        {
            Thread thr = new Thread(new ThreadStart(delegate { doRun(args); }));
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
        }
        static void doRun(String args)
        {
            AppDomain domain = AppDomain.CreateDomain("FrmFileNET" + counter++);
            Type t = typeof(FormMain);
            FormMain proxy = (FormMain)domain.CreateInstanceAndUnwrap(t.Assembly.FullName, t.FullName);
            proxy.setData(args);
            try
            {
                proxy.ShowDialog();
            }
            catch (ExitEnvironmentException ex)
            {
                FormMain.DefInstance = null; ;
            }
            AppDomain.Unload(domain);
        }

       /*
       /* public void Mostrar(string arg)
        {
            HomeDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            // These arrays will be resized after files are loaded...
            ArraySz = InitArraySz;
            DocList = new DocInfo[ArraySz + 1];
            FinalList = new IDMObjects.Document[ArraySz + 1];
            FolderList = new string[ArraySz + 1];

            //FSQ20070510. Code Unnecessary
            //FSQ20070521. UPGRADE_ISSUE:Load statement is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"'
            //Load(MainForm);
            Module1.CommandLine = arg;
            try
            {
                if (TotalDocs > 0)
                {
                    FormMain.DefInstance.Show();
                }
                else
                {
                    FormMain.DefInstance.Show();
                    //Unload MainForm
                }
            } catch(ExitEnvironmentException ex)
            {
                {
                    FormMain.DefInstance = null;
                }

            }
        }
        */

        /* Avg  Ini 14/01/20109 */

        public static string LeeRegistry(string NomAplicacion, string LlaveRegistry)
        {
            RegistryKey Key;
            string RutaRegistry = "Software\\Banamex" + "\\" + NomAplicacion.Trim();
            string[] ValoresReg;
            string LlaveBuscada = string.Empty;

            try
            {
                Key = Registry.CurrentUser.OpenSubKey(RutaRegistry);
                ValoresReg = Key.GetValueNames();

                foreach (string ValorReg in ValoresReg)
                {
                    if (ValorReg == LlaveRegistry)
                    {
                        LlaveBuscada = Key.GetValue(ValorReg).ToString().Trim();
                        break;
                    }
                }
                if (LlaveBuscada.IndexOf("%ALLUSERSPROFILE%") == 0)
                {
                    string Cade = string.Empty;
                    Cade = LlaveBuscada.Substring(LlaveBuscada.IndexOf("\\", 2));
                    LlaveBuscada = Cade;
                    Cade = Environment.GetEnvironmentVariable("ALLUSERSPROFILE");
                    LlaveBuscada = Cade + LlaveBuscada;
                }
                return LlaveBuscada;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return string.Empty;
            }
        }

            /*
        public static string LeeRegistry(string NomAplicacion, string SubNomApl, string LlaveRegistry)
        {
            RegistryKey Key;
            string RutaRegistry = "Software\\Banamex" + "\\" + NomAplicacion.Trim() + "\\" + SubNomApl.Trim();
            string[] ValoresReg;
            string LlaveBuscada = string.Empty;

            try
            {
                Key = Registry.CurrentUser.OpenSubKey(RutaRegistry);
                ValoresReg = Key.GetValueNames();

                foreach (string ValorReg in ValoresReg)
                {
                    if (ValorReg == LlaveRegistry)
                    {
                        LlaveBuscada = Key.GetValue(ValorReg).ToString().Trim();
                        break;
                    }
                }

                return LlaveBuscada;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return string.Empty;
            }
        }
            */
        public static Boolean EscribeRegistry(string NomAplicacion, string LlaveRegistry, object ValorKey)
        {
            RegistryKey Key;
            string RutaRegistry = "Software\\Banamex" + "\\" + NomAplicacion.Trim();
            string LlaveBuscada = string.Empty;

            try
            {
                Key = Registry.CurrentUser.CreateSubKey(RutaRegistry);
                Key.SetValue(LlaveRegistry, ValorKey);
                Key.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

            /*
        public static Boolean EscribeRegistry(string NomAplicacion, string SubNomApl, string LlaveRegistry, object ValorKey)
        {
            RegistryKey Key;
            string RutaRegistry = "Software\\Banamex" + "\\" + NomAplicacion.Trim() + "\\" + SubNomApl.Trim();
            string LlaveBuscada = string.Empty;

            try
            {
                Key = Registry.CurrentUser.CreateSubKey(RutaRegistry);
                Key.SetValue(LlaveRegistry, ValorKey);
                Key.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        */

        public static void ValidaRegistry(string NomAplicacion, string LlaveRegistry, object ValorKey)
        {
            RegistryKey Key;
            string RutaRegistry = "Software\\Banamex" + "\\" + NomAplicacion.Trim();
            string[] ValoresReg;
            string LlaveBuscada = string.Empty;

            try
            {
                Key = Registry.CurrentUser.OpenSubKey(RutaRegistry);
                ValoresReg = Key.GetValueNames();

                foreach (string ValorReg in ValoresReg)
                {
                    if (ValorReg == LlaveRegistry)
                    {
                        LlaveBuscada = Key.GetValue(ValorReg).ToString().Trim();
                        break;
                    }
                }

                if (LlaveBuscada.Length == 0)
                {
                    EscribeRegistry(NomAplicacion, LlaveRegistry, ValorKey);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                EscribeRegistry("C406_000", "NumApp", "C406_000");
            }
        }

        
            /* Avg  Fin 14/01/20109 */


        [STAThread()]
        static public void Main()
        {
            HomeDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            // These arrays will be resized after files are loaded...
            ArraySz = InitArraySz;
            DocList = new DocInfo[ArraySz + 1];
            //FinalList = new IDMObjects.Document[ArraySz + 1];
            FolderList = new string[ArraySz + 1];
           
            //Load(MainForm);

            //AVG Ini 14-01/2010
            ValidaRegistry("C406_000", "DirWork", "%ALLUSERSPROFILE%\\Application Data\\C406_000\\");
            DirWork = LeeRegistry("C406_000", "DirWork");
            ValidaRegistry("C406_000", "DirLog", "Logs\\");
            DirLog = DirWork + LeeRegistry("C406_000", "DirLog");
            ValidaRegistry("C406_000", "DirConf", "Conf\\");
            DirConf = DirWork + LeeRegistry("C406_000", "DirConf");            
            ValidaRegistry("C406_000", "TmpImg", "TmpImg\\");
            TmpImg = DirWork + LeeRegistry("C406_000", "TmpImg");
            //AVG Ini 14-01/2010


            if (TotalDocs > 0)
            {
                Application.Run(MainForm);
            }
            else
            {
                Application.Run(MainForm);
                //Unload MainForm
            }
        }

        public static string GetWindowsDir()
        {

            return System.Environment.GetEnvironmentVariable("WinDir") + "\\";

            //string WinDir = new String(' ', 20);
            //int Res = (int)API.KERNEL.GetWindowsDirectory(WinDir, 20);
            //string File = WinDir.Substring(0, Math.Min(WinDir.Length, WinDir.IndexOf(Strings.Chr(0))));
            //return File.Trim() + "\\";

        }

        /*
        public static string GetWindowsSysDir()
        {


            string WinSysDir = new String(' ', 20);
            long Res =  API.KERNEL.GetSystemDirectory(WinSysDir, 20);
            string File = WinSysDir.Substring(0, Math.Min(WinSysDir.Length, WinSysDir.IndexOf(Strings.Chr(0))));
            return File.Trim() + "\\";

        }
        */
        public static string GetDirName(ref  string ScanString)
        {

            int PosSave = 0;
            int ExitWhile = -1;
            int Pos = 1;

            while (ExitWhile == (-1))
            {
                Pos = (int)Strings.InStr(Pos, ScanString, "\\", (CompareMethod)0);
                if (Pos == 0)
                {
                    continue;
                }
                else
                {
                    Pos++;
                    PosSave = Pos - 1;
                }
            };
            return ScanString.Substring(0, Math.Min(ScanString.Length, PosSave));

        }

        public static string GetFileName(ref  string ScanString)
        {

            int PosSave = 0;
            bool ExitWhile = true;
            int Pos = 1;


            while (ExitWhile)
            {
                Pos = (int)Strings.InStr(Pos, ScanString, "\\", (CompareMethod)0);
                if (Pos == 0)
                {
                    break;
                }
                else
                {
                    Pos++;
                    PosSave = Pos - 1;
                }
            };
            return ScanString.Substring(PosSave).Trim();

        }

        public static string sGetTempFile(string sPrefix)
        {
            string result = String.Empty;

            // PARA 32 BITS

#if Win32



            // La vía de acceso será el directorio de Windows
            string lpszPath = GetWindowsDir();

            // Se establece el prefijo del archivo temporal
            string lpPrefixString = sPrefix;

            // Si wUnique no es 0, se añadirá al nombre del archivo temporal
            // Si vale 0 se utiliza la hora catual para crear un número para añadir al prefijo

            int wUnique = 0;

            // Incializa la variable del nombre de archivo
            string lpTempFileName = new String(' ', 100);

            //result = API.KERNEL.GetTempFileName(lpszPath, lpPrefixString, wUnique, lpTempFileName).ToString();

            // Obtiene el nombre del archivo
            result = lpTempFileName.Substring(0, lpTempFileName.IndexOf(Strings.Chr(0)));

#else
			
			//FSQ20070521. UPGRADE_TODO: #If #EndIf block was not upgraded because the expression Else did not evaluate to True or was not evaluated. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"'
			
			// PARA 16 BITS
            string sTempFileName = new String(' ', 100);
            int R = API.KERNEL.GetTempFileName(null, sPrefix, 0, sTempFileName);
			result = sTempFileName.Substring(0, sTempFileName.Trim().Length - 1);
			
#endif

            return result;
        }

        public static int DirExist(string FN)
        {
            //FSQ20070510. Changed by try..catch
            //On Error Resume Next;

            try { FN = sFixDirString(FN).ToUpper(); }
            catch { }

            // Devuelve 0 (False) si no existe y -1 (True) si existe

            // En todos los directorios hay una entrada NUL

            if (FileSystem.Dir(FN + "NUL", Microsoft.VisualBasic.FileAttribute.Normal) == "")
            { //  DIR$="" significa que no lo ha encontrado
                return 0;
            }
            else
            {
                return -1;
            }

        }

        public static string sFixDirString(string sInComming)
        {


            string sTemp = sInComming;

            if (!sTemp.EndsWith("\\"))
            {
                return sTemp + "\\";
            }
            else
            {
                return sTemp;
            }

        }

        public static bool KillFile(ref  string sFileSpec)
        {
            string sFileName = String.Empty;
            string sDirName = String.Empty;
            string Msg = String.Empty;
            DialogResult iResult = (DialogResult)0;

            //FSQ20070510. On error and resume code was rewritten to try..catch to match behavior
            try
            {
                sDirName = sParsePath(ref sFileSpec);
                sFileName = FileSystem.Dir(sFileSpec, Microsoft.VisualBasic.FileAttribute.Normal);
            }
            catch
            {
                switch (Information.Err().Number)
                {
                    case 53:
                    case 70:
                        Msg = "Disco protegido contra escritura. Desprotéjalo para poder borrar.";
                        MessageBox.Show(Msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 75:
                        (new FileInfo(sDirName + sFileName)).Attributes = 0;

                        break;
                    default:
                        iResult = MessageBox.Show("Error: [" + Conversion.ErrorToString(0) + "]", "Atención", MessageBoxButtons.OK | MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return false;
                }
            }


            while ((sFileName != null) && (sFileName != ""))
            {
                try
                {
                    File.Delete(sDirName + sFileName);
                    sFileName = FileSystem.Dir();
                }
                catch
                {
                    switch (Information.Err().Number)
                    {
                        case 53:
                        case 70:
                            Msg = "Disco protegido contra escritura. Desprotéjalo para poder borrar.";
                            MessageBox.Show(Msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 75:
                            (new FileInfo(sDirName + sFileName)).Attributes = 0;

                            break;
                        default:
                            //iResult = MessageBox.Show("Error: [" + Conversion.ErrorToString(0) + "]", "Atención", MessageBoxButtons.OK | MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            return false;
                    }
                }
            };

            return true;
        }

        public static string sParsePath(ref  string sPathIn)
        {

            int i = 0;

            for (i = sPathIn.Length; i >= 1; i--)
            {
                if ((":\\").IndexOf(sPathIn[(i - 1)].ToString()) >= 0)
                {
                    break;
                }
            }
            return sPathIn.Substring(0, Math.Min(sPathIn.Length, i));

        }

        static public void GetDirectory(ref  string sFilePath, ref  string sDirectory, ref  string sFileName)
        {
            for (int lIndex = sFilePath.Length; lIndex >= 1; lIndex--)
            {
                if (sFilePath[(lIndex - 1)].ToString() == "\\")
                {
                    sFileName = sFilePath.Substring(sFilePath.Length - (Math.Min(sFilePath.Length, sFilePath.Length - lIndex)));
                    sDirectory = sFilePath.Substring(0, Math.Min(sFilePath.Length, lIndex - 1)); //  Remove last Slash character
                    break;
                }
            }

        }

        public static string fncParmIniGet(string stanza, string keyname, string inifile)
        {
            string theResult = String.Empty;
            string @Default = "";
            string result = new String(' ', 255);
            int rc = (int)1;//API.KERNEL.GetPrivateProfileString(stanza, keyname, @Default, ref result, result.Length, inifile);
            if (rc != 0)
            {
                theResult = result.Trim();
                if (theResult.Length > 1)
                {
                    theResult = theResult.Substring(0, Math.Min(theResult.Length, rc));//theResult.Length - 1));
                }
            }
            else
            {
                theResult = "";
            }
            return theResult;
        }

       /* static public void ObtPassSapuf()
        {

            //FSQ20070510. Replaced by a direct reference to the type
            //object mClassSAPUF = Activator.CreateInstance(Type.GetTypeFromProgID("Tuxserver.ClassSAPUF"));
            //TuxServer.ClassSAPUF mClassSAPUF;
            string DirWinTemp = "C:\\APPS\\CreditoEmpresarial\\";

            //FSQ20070510. Replaced by a direct reference to the type
            //mClassSAPUF = new TuxServer.ClassSAPUF();
            //mClassSAPUF = Activator.CreateInstance(Type.GetTypeFromProgID("Tuxserver.ClassSAPUF"));
            DirWinTemp = "C:\\APPS\\CreditoEmpresarial\\";

            string VTemp = fncParmIniGet("C406090", "pSAPUF_MAQDEST", DirWinTemp + "C406090.ini");
            //FSQ20070521. UPGRADE_WARNING:Couldn't resolve default property of object mClassSAPUF.pSAPUF_MAQDEST. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mClassSAPUF.pSAPUF_MAQDEST = VTemp;
            VTemp = fncParmIniGet("C406090", "pSAPUF_USUDEST", DirWinTemp + "C406090.ini");
            //FSQ20070521. UPGRADE_WARNING:Couldn't resolve default property of object mClassSAPUF.pSAPUF_USUDEST. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mClassSAPUF.pSAPUF_USUDEST = VTemp;
            VTemp = fncParmIniGet("C406090", "pSAPUF_TIPDEST", DirWinTemp + "C406090.ini");
            //FSQ20070521. UPGRADE_WARNING:Couldn't resolve default property of object mClassSAPUF.pSAPUF_TIPDEST. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mClassSAPUF.pSAPUF_TIPDEST = VTemp;
            VTemp = fncParmIniGet("C406090", "pSAPUF_APLDEST", DirWinTemp + "C406090.ini");
            //FSQ20070521. UPGRADE_WARNING:Couldn't resolve default property of object mClassSAPUF.pSAPUF_APLDEST. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mClassSAPUF.pSAPUF_APLDEST = VTemp;
            VTemp = fncParmIniGet("C406090", "pSAPUF_APLORIG", DirWinTemp + "C406090.ini");
            //FSQ20070521. UPGRADE_WARNING:Couldn't resolve default property of object mClassSAPUF.pSAPUF_APLORIG. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mClassSAPUF.pSAPUF_APLORIG = VTemp;
            VTemp = fncParmIniGet("C406090", "pSAPUF_BASEDATO", DirWinTemp + "C406090.ini");
            //FSQ20070521. UPGRADE_WARNING:Couldn't resolve default property of object mClassSAPUF.pSAPUF_BASEDATO. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mClassSAPUF.pSAPUF_BASEDATO = VTemp;
            VTemp = fncParmIniGet("C406090", "pSAPUF_TIMER", DirWinTemp + "C406090.ini");
            //FSQ20070521. UPGRADE_WARNING:Couldn't resolve default property of object mClassSAPUF.pSAPUF_TIMER. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mClassSAPUF.pSAPUF_TIMER = VTemp;
            VTemp = fncParmIniGet("C406090", "pSAPUF_OPERACION", DirWinTemp + "C406090.ini");
            //FSQ20070521. UPGRADE_WARNING:Couldn't resolve default property of object mClassSAPUF.pSAPUF_OPERACION. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mClassSAPUF.pSAPUF_OPERACION = VTemp;
            //FSQ20070521. UPGRADE_WARNING:Couldn't resolve default property of object mClassSAPUF.pSAPUF_PASS. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mClassSAPUF.pSAPUF_PASS = null;

            //    mClassSAPUF.pSAPUF_MAQDEST = "ucapmty2"
            //    mClassSAPUF.pSAPUF_USUDEST = "c406_090"
            //    mClassSAPUF.pSAPUF_TIPDEST = "AP"
            //    mClassSAPUF.pSAPUF_APLDEST = "Filenet"
            //    mClassSAPUF.pSAPUF_APLORIG = "c406_090"
            //    mClassSAPUF.pSAPUF_BASEDATO = ""
            //    mClassSAPUF.pSAPUF_PASS = Empty
            //    mClassSAPUF.pSAPUF_OPERACION = "11"
            //    mClassSAPUF.pSAPUF_TIMER = "9999"

            //FSQ20070521. UPGRADE_WARNING:Couldn't resolve default property of object mClassSAPUF.ObtenPass_SAPUF. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //Pass_Sapuf = (string)mClassSAPUF.ObtenPass_SAPUF();            
            Pass_Sapuf = mClassSAPUF.ObtenPass_SAPUF();

            mClassSAPUF = null;
            //MsgBox Pass_Sapuf
        }*/
    }
}