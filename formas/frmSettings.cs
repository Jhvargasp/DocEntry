using System.Windows.Forms; 

using System; 

using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace DocEntry
{
	public partial class frmSettings
		: System.Windows.Forms.Form
		{
		
			private void  btnCancel_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Hide();
			}
			
			private void  btnOk_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			
			private void  cmdClear_Click( Object eventSender,  EventArgs eventArgs)
			{
                //AIS-469 FGUEVARA
                //Control oCtrl = null;
                Module1.goPersist.DeleteSettings(Module1.gsAppName, Module1.gsSectionName);
                ClearEntries(this);
			}
			
			public void  cmdRefresh_Click()
			{
					ClearEntries(this);
					Module1.goPersist.GetSettings(Module1.gsAppName, Module1.gsSectionName, this);
			}
			
			private void  cmdSave_Click( Object eventSender,  EventArgs eventArgs)
			{
					Module1.goPersist.SaveSettings(Module1.gsAppName, Module1.gsSectionName, this);
			}
			private void  ClearEntries( frmSettings fFrm)
			{
					//UPGRADE_WARNING:Form property frmSettings.Controls has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
					foreach (Control oCtrl in fFrm.Controls)
					{
						if (oCtrl is TextBox)
						{
							((System.Windows.Forms.TextBox) oCtrl).Text = "";
						}
					}
			}
		}
}