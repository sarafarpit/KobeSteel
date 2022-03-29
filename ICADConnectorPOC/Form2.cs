//-------------------------------------------------------------------------------------------------------------
/* This file is responsible for WebInWin UI interaction
 * 
 * Date            Editor                Comments
 * 15-Dec-2021     Arpit Saraf           Initial version

 */
//----------------------------------------------------------------------------------------------------------------

using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ICADConnectorPOC
{
    public partial class ModelSearch1 : Form
    {
        public ChromiumWebBrowser chromeBrowser;
        private ModelSearchSelectionHandler mssh = null;
        private string selectedPhysicalId = "";
        public ModelSearch1()
        {
            InitializeComponent();
        }

        private void ModelSearch1_Load(object sender, EventArgs e)
        {
        }


        public void InitializeChromium(String url)
        {
            CefSettings settings = new CefSettings();
            settings.CefCommandLineArgs.Add("ignore-certificate-errors");
            // Initialize cef with the provided settings
            if (!Cef.IsInitialized)
                Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(url);
            // Add it to the form and fill it to the form window.
            panel1.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;


            // Javascript binding
            mssh = new ModelSearchSelectionHandler(this);
            chromeBrowser.JavascriptObjectRepository.ResolveObject += (sender, e) => {
                if (e.ObjectName == Config.DSGSCEF)
                {
                    var repo = e.ObjectRepository;
                    repo.Register(Config.DSGSCEF, mssh, isAsync: true, options: BindingOptions.DefaultBinder);
                }
            };

            //may be needed on slow connection
            //chromeBrowser.FrameLoadStart += (s, e) =>
            //    chromeBrowser.GetMainFrame().ExecuteJavaScriptAsync($"CefSharp.BindObjectAsync(\"dscef\")");
            chromeBrowser.FrameLoadEnd += (s, e) =>
                chromeBrowser.GetMainFrame().ExecuteJavaScriptAsync($"CefSharp.BindObjectAsync(\"dscef\")");

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cef.Shutdown();
        }

        public void SetPhysicalID(string physcialId)
        {
            selectedPhysicalId = physcialId;
        }
        private void dwnldBtn_Click(object sender, EventArgs e)
        {
            XMLCommunication xmlComm = XMLCommunication.getInstance();
            

            string selectedObjectId = System.IO.File.ReadAllText(Config.XMLDIRNAME + "\\temp.txt");

            //Update Checkout XML
            XmlDocument xml = new XmlDocument();
            xml.Load(Config.XMLDIRNAME + "\\" + Config.CHECKOUTXML);
            XmlNodeList xnList = xml.SelectNodes("command/cadobjectlist/cadobject[@phid]");
            foreach (XmlNode xn in xnList)
            {
                XmlNode xnphid = xn.Attributes.GetNamedItem("phid");
                xnphid.Value = selectedObjectId;
            }
            xml.Save(Config.XMLDIRNAME + "\\" + Config.CHECKOUTXML);

            string commandReturnString = "";
            if (xmlComm.CheckOut(Config.CHECKOUTXML, "", commandReturnString))
                MessageBox.Show("File Downloaded: " + Config.XMLDIRNAME + "\\checkout_files");
        }

        private void cnclBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            this.Update();
        }
    }
}
