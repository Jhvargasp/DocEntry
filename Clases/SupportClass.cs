using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace DocEntry
{
    //To support extra functionality for some components
    public class SupportClass
    {
        //This class is created in order to create some workarounds for some properties of System.Windows.Forms.TabControl
        public class TabControlSupportClass {
            //Only the list of disabled tabs will be contained here
            private static Hashtable TabsDisabled = new Hashtable();

            //To get the current status of a tab into a tabcontrol
            public static void SetTabEnabled(System.Windows.Forms.TabControl TabCtrl, int index, bool value)
            {
                ArrayList lstDisabled;

                if (TabsDisabled.ContainsKey(TabCtrl))
                    lstDisabled = (ArrayList)TabsDisabled[TabCtrl];
                else
                {
                    lstDisabled = new ArrayList();
                    TabsDisabled.Add(TabCtrl, lstDisabled);
                    TabCtrl.Selecting += new TabControlCancelEventHandler(TabControl_Selecting);
                };

                //Tab is being enabled so it must be eliminated from the list
                if ((value) && (lstDisabled.Contains(index)))
                    lstDisabled.Remove(index);

                //Tab is being disabled so it must be added if necessary
                if ((!value) && (!lstDisabled.Contains(index)))
                {
                    lstDisabled.Add(index);
                    TabCtrl.TabPages[index].ForeColor = System.Drawing.Color.Green;
                };

                TabsDisabled[TabCtrl] = lstDisabled;
            }

            //To get the current status of a tab into a tabcontrol
            public static bool GetTabEnabled(System.Windows.Forms.TabControl TabCtrl, int index)
            {
                bool res = true;

                if (TabsDisabled.ContainsKey(TabCtrl))
                {
                    return !((ArrayList)TabsDisabled[TabCtrl]).Contains(index);
                }

                return res;
            }

            //To avoid to select tabs disabled
            private static void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
            {
                if (e.Action == TabControlAction.Selecting)
                {
                    ArrayList lst;
                    TabControl TabCtrl = (TabControl)sender;

                    if (TabsDisabled.ContainsKey(TabCtrl))
                    {
                        lst = (ArrayList)TabsDisabled[TabCtrl];
                        if (lst.Contains(e.TabPageIndex))
                            e.Cancel = true;
                    };
                };
            }
        }
    }
}
