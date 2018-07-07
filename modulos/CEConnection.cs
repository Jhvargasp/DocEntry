using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileNet.Api.Core;
using System.IO;
using FileNet.Api.Collection;
using System.Collections;
using FileNet.Api.Util;
using FileNet.Api.Authentication;
using FileNet.Api.Meta;
using static FileNet.Api.Core.Factory;
using System.Windows.Forms;
using FileNet.Api.Query;
using FileNet.Api.Constants;

namespace DocEntry.modulos
{
    public class CEConnection
    {
        private IDomain domain;
        private IObjectStoreSet ost;
        private ArrayList osNames;
        private String domainName;
        private bool isCredetialsEstablished;

        //
        // Constructor
        //
        public CEConnection()
        {
            domain = null;
            ost = null;
            osNames = new ArrayList();
            domainName = null;
            isCredetialsEstablished = false;
        }

        //
        // This method establishes user credentials with the Content Engine on a process basis.
        // Once credentials are established, you can make API calls to CE.
        //
        IObjectStore os;
        IRepositoryRowSet oRS = null;
        public void EstablishCredentials(String userName, String password, String uri, String osName)
        {
            //IConnection  conn = Factory.Connection.GetConnection(uri);
            //Subject subject = UserContext.createSubject(conn, username, password, null);
            //UserContext.get().pushSubject(subject);

            UsernameCredentials cred = new UsernameCredentials(userName, password);
            // now associate this Credentials with the whole process
            ClientContext.SetProcessCredentials(cred);
            IConnection connection = Factory.Connection.GetConnection(uri);
            IDomain domain = Factory.Domain.GetInstance(connection, null);
            isCredetialsEstablished = true;
            os = Factory.ObjectStore.FetchInstance(domain, osName, null);

            //domainName = domain.Name;
            //ost = domain.ObjectStores;
            //SetOSNames();
        }


        //
        // Intializes the ArrayList osNames with object store names.
        //
        private void SetOSNames()
        {
            IEnumerator ie = ost.GetEnumerator();
            while (ie.MoveNext())
            {
                IObjectStore os = (IObjectStore)ie.Current;
                osNames.Add(os.DisplayName);
            }
        }

        //
        // Returns the osNames ArrayList.
        //
        public ArrayList GetOSNames()
        {
            return osNames;
        }

        //
        // Returns the domain (IDomain object).
        //
        public IDomain GetDomain()
        {
            return domain;
        }

        //
        // Returns the domain name.
        //
        public String GetDomainName()
        {
            return domainName;
        }

        //
        // Returns true or false based on whether credentials have been
        // established with CE or not.
        //
        public bool IsCredentialsEstablished()
        {
            return isCredetialsEstablished;
        }

        //
        // Fetches the ObjectStore object using given name.
        //
        public IObjectStore FetchOS(String name)
        {
            //IObjectStore os = Factory.ObjectStore.FetchInstance(domain, name, null);
            return os;
        }

        internal IPropertyDescriptionList getPropertiesDescriptions(IObjectStore oLibrary, string[] asClasses)
        {
            IClassDescription objClassDesc = ClassDescription.FetchInstance(oLibrary, asClasses[0], null);
            //IClassDescription objClassDesc = ClassDescription.FetchInstance(oLibrary, "Document", null);
            return objClassDesc.PropertyDescriptions;

        }

        internal string getCachedFile(IDocument oDocument)
        {
            // Get content elements and iterate list.
            IContentElementList docContentList = oDocument.ContentElements;
            String ret = "";
            System.Collections.IEnumerator iter = docContentList.GetEnumerator();
            while (iter.MoveNext())
            {
                IContentTransfer ct = (IContentTransfer)iter.Current;
                FileStream fout = new FileStream(Path.GetTempPath() + ct.RetrievalName, FileMode.Create);
                int docLen = (int)ct.ContentSize;
                byte[] buf = new byte[docLen];
                Stream stream = (Stream)ct.AccessContentStream();

                stream.Read(buf, 0, docLen);
                fout.Write(buf, 0, docLen);
                fout.Flush();
                stream.Close();
                fout.Close();
                ret = Path.GetTempPath() + ct.RetrievalName;

            }
            return ret;
        }

        public void ExecQuery(ref DataGridView IDMLView, string sWhereClause, string sFolderName, int iMaxRows)//AxIDMListView.AxIDMListView
        {

            if (os != null)
            {
                // Build the string necessary to bind to the database connection
                //sConnect = "provider=FnDBProvider;data source=" + oQueryLib.Name + ";Prompt=4;SystemType=" + ((int)oQueryLib.SystemType) + ";";
                // Build the query string

                String mySQLString = "SELECT * FROM ExpedientesDC  ";
                //String mySQLString = "SELECT * FROM Document  ";
                SearchSQL sqlObject = new SearchSQL();


                // The SearchSQL instance (sqlObject) can then be specified in the 
                // SearchScope parameter list to execute the search. Uses fetchRows to test the SQL 
                // statement.
                SearchScope searchScope = new SearchScope(os);
                String sQuery = "";
                if (sWhereClause.Length > 0)
                {
                    sQuery = "";
                    sQuery = sQuery + "WHERE VersionStatus=1 " + sWhereClause;
                    //sQuery = sQuery + "WHERE VersionStatus=1 ";
                }

                // Set up the properties on the record set
                //if (oRS != null)
                //{
                oRS = null;
                //}
                //Set oMiBD = New ADODB.Connection
                //oMiBD.ConnectionString = sConnect
                //oMiBD.Open
                //oRS = new ADODB.Recordset();

                //oRS.let_ActiveConnection(sConnect);
                //oRS.Properties["SupportsObjSet"].Value = true;
                if (iMaxRows > 0)
                {
                    //searchScope.
                    //oRS.MaxRecords = iMaxRows;
                    sQuery = sQuery + " OPTIONS ( BATCHSIZE " + iMaxRows + " )";
                }
                //oRS.Properties["SearchFolderName"].Value = sFolderName;
                // All set up - pull the trigger
                //oRS.LockType = ADODB.LockTypeEnum.adLockOptimistic;
                //oRS.Open sQuery, oMiBD, adOpenKeyset, , adCmdText
                //oRS.Open sQuery, oMiBD, adOpenKeyset
                //oRS.Open(sQuery, Type.Missing, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockUnspecified, -1);

                try
                {
                    //MessageBox.Show("Query: " + mySQLString + sQuery);
                    sqlObject.SetQueryString(mySQLString + sQuery);
                    //sqlObject.SetQueryString(mySQLString);
                    oRS = searchScope.FetchRows(sqlObject, null, null, true);

                    if (!oRS.IsEmpty()) { 
                        ShowResults(ref IDMLView);
                    }
                    else
                    {
                        MessageBox.Show("No hay resultados para la consulta indicada: " + mySQLString + sQuery);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Must set library!", Application.ProductName);
            }
        }

        private void ShowResults(ref DataGridView iDMLView)
        {
            if (!oRS.IsEmpty())
            {
                int i = 0;
                try
                {
                    foreach (IRepositoryRow row in oRS)
                    {


                        string[] rowData = { row.Properties.GetProperty("Id").GetIdValue().ToString(),
                       row.Properties.GetProperty("XfolioP").GetStringValue(),
                    row.Properties.GetProperty("FolioS403").GetInteger32Value().ToString(),
                    row.Properties.GetProperty("SecLote").GetInteger32Value().ToString(),
                    row.Properties.GetProperty("Instrumento").GetInteger32Value().ToString(),
                    row.Properties.GetProperty("Producto").GetInteger32Value().ToString(),
                    row.Properties.GetProperty("XfolioS").GetInteger32Value().ToString(),
                    row.Properties.GetProperty("CalificaOnDemand").GetInteger32Value().ToString(),
                    row.Properties.GetProperty("FechaOperacion").GetDateTimeValue().ToString(),
                    row.Properties.GetProperty("StatusImagen").GetInteger32Value().ToString(),
                    row.Properties.GetProperty("Status").GetInteger32Value().ToString(),
                    row.Properties.GetProperty("Linea").GetInteger32Value().ToString(),
                    row.Properties.GetProperty("Contrato").GetStringValue(),
                    row.Properties.GetProperty("NumCliente").GetInteger32Value().ToString(),
                    row.Properties.GetProperty("Folio").GetInteger32Value().ToString(),
                    row.Properties.GetProperty("TipoDoc").GetInteger32Value().ToString(),
                    row.Properties.GetProperty("UOC").GetInteger32Value().ToString()
                    
                    //row.Properties.GetProperty("DocumentTitle").GetStringValue()
                            };
                        if (i > 20)
                        {
                            break;
                        }
                        i++;
                        iDMLView.Rows.Add(rowData);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        public String GetContentElement(String id)
        {

            //MessageBox.Show(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            //FileNet.Api.Property.PropertyFilter pf = new FileNet.Api.Property.PropertyFilter();
            //pf.AddIncludeProperty(new FileNet.Api.Property.FilterElement(null, null, null, "Cont", null));

            // Get a document from the version series to be checked for downloads.
            IDocument documentObj = Factory.Document.FetchInstance(os, id, null);

            IContentTransfer cTransfer = (IContentTransfer)documentObj.ContentElements[0];

            String name = cTransfer.RetrievalName;
            Stream stream = cTransfer.AccessContentStream();
            double size = writeContent(stream, Path.GetTempPath() + "/" + name);

            return Path.GetTempPath() + "/" + name;
        }

        private double writeContent(Stream stream, string name)
        {
            byte[] buffer = new byte[4096];
            int bufferSize;
            double size = 0;
            BinaryWriter wr = new BinaryWriter(File.Open(name, FileMode.Create));
            while ((bufferSize = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                size += bufferSize;
                wr.Write(buffer, 0, bufferSize);
            }
            wr.Close();
            stream.Close();
            return size;
        }

        //
        // Files the Containable object (i.e. Document, CustomObject) in
        // specified Folder.
        //
        public  IReferentialContainmentRelationship FileContainable( IContainable c, String folder)
        {
            IFolder f = Factory.Folder.FetchInstance(os, folder, null);
            IReferentialContainmentRelationship rcr = null;
            if (c is IDocument)
                rcr = f.File((IDocument)c, AutoUniqueName.AUTO_UNIQUE, "DocEntryFile", DefineSecurityParentage.DO_NOT_DEFINE_SECURITY_PARENTAGE);
            else
                rcr = f.File((ICustomObject)c, AutoUniqueName.AUTO_UNIQUE, "DocEntryFile", DefineSecurityParentage.DO_NOT_DEFINE_SECURITY_PARENTAGE);
            return rcr;
        }

        public void checkInDoc(IDocument doc)
        {
            doc.Checkin(AutoClassify.AUTO_CLASSIFY, CheckinType.MINOR_VERSION);
            doc.Save(RefreshMode.REFRESH);
            doc.Refresh();
        }

        //
        // Creates the ContentTransfer object from supplied file's
        // content.
        //
        public IContentTransfer CreateContentTransfer(String fileName)
        {
            IContentTransfer ct = null;
            FileInfo fi = new FileInfo(fileName);
            if (ReadContentFromFile(fileName) != null)
            {
                ct = Factory.ContentTransfer.CreateInstance();
                Stream s = new MemoryStream(ReadContentFromFile(fileName));
                ct.SetCaptureSource(s);
                ct.RetrievalName = fi.Name;
            }
            return ct;
        }

        //
        // Creates the ContentElementList from ContentTransfer object.
        //
        public  IContentElementList CreateContentElementList(String fileName)
        {
            IContentElementList cel = null;
            if (CreateContentTransfer(fileName) != null)
            {
                cel = Factory.ContentElement.CreateList();
                IContentTransfer ct = CreateContentTransfer(fileName);
                cel.Add(ct);
            }
            return cel;
        }

        //
        // Reads the content from a file and stores it
        // in a byte array. The byte array will later be
        // used to create ContentTransfer object.
        //
        public byte[] ReadContentFromFile(String fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            long numBytes = fi.Length;
            byte[] buffer = null;
            if (numBytes > 0)
            {
                try
                {
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    buffer = br.ReadBytes((int)numBytes);
                    br.Close();
                    fs.Close();
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.StackTrace);
                }
            }
            return buffer;
        }

    }



}
