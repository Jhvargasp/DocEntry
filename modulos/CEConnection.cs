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

        internal void executeQuery(IObjectStore oLibrary, string sClass)
        {
            throw new NotImplementedException();
        }
    }

}
