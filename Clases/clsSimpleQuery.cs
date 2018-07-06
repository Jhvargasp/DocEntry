using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;

using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using FileNet.Api.Core;
using static FileNet.Api.Core.Factory;
using FileNet.Api.Meta;
using FileNet.Api.Query;
using FileNet.Api.Collection;

namespace DocEntry
{
    public class clsSimpleQuery
    {

        // This class is useful for generating background document
        // queries where there isn't a need for using one of the
        // FNQuery ActiveX controls.  This class encapsulates all the
        // ADO details while providing control over the filter
        // conditions in the query.

        // Instructions for use:
        //    1.  Call BindToLib passing a Library object and a
        //        collection of  headings you want to see in the
        //        IDMListView.  An empty collection implies that no
        //        column headings will be displayed.
        //    2.  Call ExecQuery, passing in the where clause, the
        //        folder constraints, the max number of rows, and
        //        the IDMListView control you want to populate.  A
        //        reminder on the where clause - literal string values
        //        must be bracketed with quotes, e.g. AccountName = 'Bruce'


        //private ADODB.Recordset oRS = null;
        IRepositoryRowSet oRS = null;
        //FSQ20070514. Dead code
        //private ADODB.Connection oMiBD =  null ;
        private ADODB.Command _CmdEjec = null;
        private ADODB.Command CmdEjec
        {
            get
            {
                if (_CmdEjec == null)
                    _CmdEjec = new ADODB.Command();

                return _CmdEjec;
            }
            set
            {
                _CmdEjec = value;
            }
        }

        private string sConnect = String.Empty;
        private string sQuery = String.Empty;
        private IObjectStore oQueryLib = null;
        private FileNet.Api.Collection.IPropertyDescriptionList oPropDescs = null;
        private Collection _cColHeadings = null;
        private Collection cColHeadings
        {
            get
            {
                if (_cColHeadings == null)
                    _cColHeadings = new Collection();

                return _cColHeadings;
            }
            set
            {
                _cColHeadings = value;
            }
        }

        // If we keep the library as a global variable, we can
        // cache data like property descriptions and column headings
        public void BindToLib(IObjectStore oNewLib, Collection pColHeadings, string sClass)
        {
            string[] sClasses = new string[2];

            sClasses[0] = sClass;
            oQueryLib = oNewLib;
            //oPropDescs = (IDMObjects.PropertyDescriptions)oQueryLib.FilterPropertyDescriptions(IDMObjects.idmObjectType.idmObjTypeDocument, sClasses);
            IClassDescription objClassDesc = ClassDescription.FetchInstance(oNewLib, sClass, null); //(IDMObjects.idmObjectType.idmObjTypeDocument, sClasses);
            oPropDescs = objClassDesc.PropertyDescriptions;
            int oTmp = 0;
            //for (int oTmp = 0 To oPropDescs.Count )
            //foreach (object oTmp in pColHeadings.Count)
            {
                // Weed out any bogus labels the caller passed us
                //FSQ20070509. Changed by try..catch
                //On Error Resume Next;
                try
                {
                    //Microsoft.VisualBasic.Collection.KeyValuePair otemp2 =((Microsoft.VisualBasic.Collection.KeyValuePair)oTmp);
                    if (oPropDescs[oTmp] != null)
                    {
                        cColHeadings.Add(oTmp, null, null, null);
                    }
                }
                catch
                {
                    try
                    {
                        cColHeadings.Add(oTmp, null, null, null);
                    }
                    catch { }
                }
            }
        }

        // Private subroutine for building up IDMListView
        private void ShowResults(DataGridView IDMLView, DocEntry.FormMain FormPrinc)
        {
            object oTmp = null;
            bool OnErrorResumeNext = false;
            // Do basic IDMLView initialization
            //FSQ20070521: UPGRADE_WARNING:Couldn't resolve default property of object IDMLView.DefaultLibrary. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //FSQ20070521: UPGRADE_WARNING:Couldn't resolve default property of object oQueryLib. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //IDMLView.DefaultLibrary = oQueryLib;
            //FSQ20070521: UPGRADE_WARNING:Couldn't resolve default property of object IDMLView.ClearItems. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            IDMLView.Rows.Clear();
            // Now do the column header stuff - client told us
            // what to use; empty collection => don't do them
            if (cColHeadings.Count > 0)
            {
                //FSQ20070521: UPGRADE_WARNING:Couldn't resolve default property of object IDMLView.ClearColumnHeaders. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //IDMLView.ClearColumnHeaders(oQueryLib);
                //FSQ20070509. Changed by try..catch
                //On Error Resume Next;
                OnErrorResumeNext = true;
                try
                {
                    foreach (object oTmp2 in cColHeadings)
                    {
                        //FSQ20070521: UPGRADE_WARNING:Couldn't resolve default property of object IDMLView.AddColumnHeader. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //IDMLView.AddColumnHeader(oQueryLib, oPropDescs[oTmp2]);
                    }
                }
                catch { }
                //FSQ20070521: UPGRADE_WARNING:Couldn't resolve default property of object IDMLView.SwitchColumnHeaders. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //IDMLView.SwitchColumnHeaders(oQueryLib);
                //FSQ20070521: UPGRADE_WARNING:Couldn't resolve default property of object IDMLView.View. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //IDMLView.View = IDMListView.idmView.idmViewReport;
            }
            else
            {
                //FSQ20070521: UPGRADE_WARNING:Couldn't resolve default property of object IDMLView.View. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //IDMLView.View = IDMListView.idmView.idmViewList;
            }
            // Now for the easy part - slam in the actual items
            if (!oRS.IsEmpty())
            {
                //FSQ20070521: UPGRADE_WARNING:Couldn't resolve default property of object IDMLView.ClearItems. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //IDMLView.ClearItems();
                foreach (IRepositoryRow row in oRS)
                {
                    //Do While Not oRS.EOF
                    //FSQ20070521: UPGRADE_WARNING:Couldn't resolve default property of object IDMLView.AddItems. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //IDMLView.AddItems(oRS.Fields["ObjSet"].Value, 1);
                    //oTmp = oRS.Fields["TipoDoc"].Value;
                    oTmp = row.Properties.GetProperty("TipoDoc").GetStringValue().ToString();
                //FSQ20070521: UPGRADE_WARNING:Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Convert.IsDBNull(oTmp))
                    {
                        Module1.XTipoDoc = Int32.Parse(oTmp.ToString());
                        //FSQ20070521: UPGRADE_ISSUE:Control CboTipoDoc could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                        for (int i = 0; i <= ((long)(FormPrinc.CboTipoDoc.Items.Count - 1)); i++)
                        {
                            //FSQ20070521: UPGRADE_ISSUE:Control CboTipoDoc could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                            if (((double)VB6.GetItemData(FormPrinc.CboTipoDoc, i)) == Module1.XTipoDoc)
                            {
                                //FSQ20070521: UPGRADE_ISSUE:Control CboTipoDoc could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                //FSQ20070510. Unnecessary, the next line will take care of setting the text
                                //FormPrinc.CboTipoDoc = FormPrinc.CboTipoDoc.List(i);
                                //FSQ20070521: UPGRADE_ISSUE:Control CboTipoDoc could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                FormPrinc.CboTipoDoc.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                    //oTmp = oRS.Fields["Contrato"].Value;
                    oTmp = row.Properties.GetProperty("Contrato").GetStringValue().ToString();
                    //FSQ20070521: UPGRADE_WARNING:Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    if (!Convert.IsDBNull(oTmp))
                    {
                        //FSQ20070521: UPGRADE_ISSUE:Control TxtContrato could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                        FormPrinc.TxtContrato.Text = oTmp.ToString();
                        //FSQ20070521: UPGRADE_ISSUE:Control TxtContrato could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                        FormPrinc.TxtContrato.Visible = true;
                    }
                    //oTmp = oRS.Fields("Folio").Value
                    //If Not IsNull(oTmp) Then
                    //    FormMain.TxtFolioUOC.Text = oTmp
                    //End If
                    //oTmp = oRS.Fields["FolioS403"].Value;
                    oTmp = row.Properties.GetProperty("FolioS403").GetStringValue().ToString();
                    //FSQ20070521: UPGRADE_WARNING:Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    if (!Convert.IsDBNull(oTmp))
                    {
                        //FSQ20070521: UPGRADE_ISSUE:Control TxtFolioS403 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                        FormPrinc.TxtFolioS403.Text = oTmp.ToString();
                        //FSQ20070521: UPGRADE_ISSUE:Control TxtFolioS403 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                        FormPrinc.TxtFolioS403.Visible = true;
                    }
                    //oTmp = oRS.Fields["Linea"].Value;
                    oTmp = row.Properties.GetProperty("Linea").GetStringValue().ToString();
                    //FSQ20070521: UPGRADE_WARNING:Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    if (!Convert.IsDBNull(oTmp))
                    {
                        //FSQ20070521: UPGRADE_ISSUE:Control TxtLinea could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                        FormPrinc.TxtLinea.Text = oTmp.ToString();
                        //FSQ20070521: UPGRADE_ISSUE:Control TxtLinea could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                        FormPrinc.TxtLinea.Visible = true;
                    }
                    //oTmp = oRS.Fields["NumCliente"].Value;
                    oTmp = row.Properties.GetProperty("NumCliente").GetStringValue().ToString();
                    //FSQ20070521: UPGRADE_WARNING:Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    if (!Convert.IsDBNull(oTmp))
                    {
                        //FSQ20070521: UPGRADE_ISSUE:Control TxtCliente could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                        FormPrinc.TxtCliente.Text = oTmp.ToString();
                    }
                    //oTmp = oRS.Fields["Producto"].Value;
                    oTmp = row.Properties.GetProperty("Producto").GetStringValue().ToString();
                    //FSQ20070521: UPGRADE_WARNING:Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    if (!Convert.IsDBNull(oTmp))
                    {
                        Module1.XProd = oTmp;
                    }
                    //oTmp = oRS.Fields["Instrumento"].Value;
                    oTmp = row.Properties.GetProperty("Instrumento").GetStringValue().ToString();
                    //FSQ20070521: UPGRADE_WARNING:Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    if (!Convert.IsDBNull(oTmp))
                    {
                        Module1.XInst = oTmp;
                    }
                    //oTmp = oRS.Fields["XfolioS"].Value;
                    oTmp = row.Properties.GetProperty("XfolioS").GetObjectValue().ToString();
                    //FSQ20070521: UPGRADE_WARNING:Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    if (!Convert.IsDBNull(oTmp))
                    {
                        Module1.XFile = oTmp;
                    }
                    //oTmp = oRS.Fields["CalificaOnDemand"].Value;
                    oTmp = row.Properties.GetProperty("CalificaOnDemand").GetObjectValue().ToString();
                    //FSQ20070521: UPGRADE_WARNING:Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    if (!Convert.IsDBNull(oTmp))
                    {
                        Module1.XCalifOnd = oTmp;
                    }
                    //oRS.MoveNext
                    //Loop
                }
            }
            else
            {
                if (!OnErrorResumeNext)
                {
                    throw new System.Exception((Constants.vbObjectError + 27).ToString() + ", UOCFileNet, " + String.Empty + ", " + null + ", " + null);
                }
                else
                {
                    MessageBox.Show("No se encuentra el Documento en FileNET " + (Constants.vbObjectError + 27), Application.ProductName);
                }
                //End
            }

        }

        // Executes query using passed params, places results in
        // passed IDMListView control
        // Calls must be preceded by a BindToLib
        public void ExecQuery(ref  DataGridView IDMLView, string sWhereClause, string sFolderName, int iMaxRows, DocEntry.FormMain FormPrinc)
        {

            if (oQueryLib != null)
            {
                // Build the string necessary to bind to the database connection
                //sConnect = "provider=FnDBProvider;data source=" + oQueryLib.Name + ";Prompt=4;SystemType=" + ((int)(oQueryLib.SystemType)) + ";";
                // Build the query string

                //sQuery = "SELECT * FROM FnDocument ";
                sQuery = "SELECT * FROM Document ";
                SearchSQL sqlObject = new SearchSQL();
                SearchScope searchScope = new SearchScope(oQueryLib);
                if (sWhereClause.Length > 0)
                {
                    sQuery = sQuery + "WHERE " + sWhereClause;
                }

                // Set up the properties on the record set
                if (oRS != null)
                {
                    oRS = null;
                }
                //Set oMiBD = New ADODB.Connection
                //oMiBD.ConnectionString = sConnect
                //oMiBD.Open
                //oRS = new ADODB.Recordset();
                //FSQ20070521: UPGRADE_WARNING:Couldn't resolve default property of object oRS.ActiveConnection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //oRS.let_ActiveConnection(sConnect);
                //oRS.Properties["SupportsObjSet"].Value = true;
                if (iMaxRows > 0)
                {
                    //oRS.MaxRecords = iMaxRows;
                    sQuery = sQuery + " OPTIONS ( BATCHSIZE " + iMaxRows + " )";
                }
                //oRS.Properties["SearchFolderName"].Value = sFolderName;
                // All set up - pull the trigger
                //oRS.LockType = ADODB.LockTypeEnum.adLockOptimistic;
                //oRS.Open sQuery, oMiBD, adOpenKeyset, , adCmdText
                //oRS.Open sQuery, oMiBD, adOpenKeyset

                //oRS.Open(sQuery, Type.Missing, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockUnspecified, -1);
                sqlObject.SetQueryString(sQuery);
                //sqlObject.SetQueryString(mySQLString);
                oRS = searchScope.FetchRows(sqlObject, null, null, true);
                ShowResults(IDMLView, FormPrinc);
            }
            else
            {
                MessageBox.Show("Must set library!", Application.ProductName);
            }
        }
    }
}