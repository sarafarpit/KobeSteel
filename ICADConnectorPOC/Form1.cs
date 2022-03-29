//-------------------------------------------------------------------------------------------------------------
/* This file is responsible for User interaction
 * 
 * Date            Editor                Comments
 * 02-Nov-2021     Arpit Saraf           Initial version

 */
//----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

//CefSharp
using CefSharp;
using CefSharp.WinForms;
using System.Xml;

namespace ICADConnectorPOC
{
    public partial class Form1 : Form
    {
        XMLCommunication xmlComm = XMLCommunication.getInstance();
        public Form1()
        {
            //string selectedObjectId = System.IO.File.ReadAllText(Config.XMLDIRNAME + "\\temp.txt");
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            button2.Enabled = false;
            btnLogin.Enabled = false;
            btnSearch.Enabled = false;
            btnCheckIn.Enabled = false;
            if (xmlComm.InvokeClient())
            {
                msg("Client Started");
                label1.Text = "Client Socket Program - Server Connected ...";
                btnLogin.Enabled = true;

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string commandReturnData = "";
            textBox1.Text = "Logging in...";
            textBox1.Update();
            if (xmlComm.Login(commandReturnData))
            {
                msg(commandReturnData);
                btnLogin.Enabled = false;
                button2.Enabled = true;
                btnSearch.Enabled = true;
                btnCheckIn.Enabled = true;
                textBox1.Text = "Logged in successfully";
            }
            else
                textBox1.Text = "Loggin failed";
        }

        public void msg(string mesg)
        {
            textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + mesg;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            string commandReturnData = "";
            if (xmlComm.Logout(commandReturnData))
            {
                textBox1.Text = "Client Connection closed requested";
                msg(commandReturnData);
                button2.Enabled = false;
                btnSearch.Enabled = false;
                btnCheckIn.Enabled = false;
                btnLogin.Enabled = true;
            }
            
        }

        private void btnCheckInEvt(object sender, EventArgs e)
        {
            string commandReturnData = "";
            string checkInFileName = Config.CHECKINXML;
            if (xmlComm.CheckIn(checkInFileName, ref commandReturnData))
                msg(commandReturnData);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnDisconnect_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String url = xmlComm.GetTransientTicket();
            //// Start the browser after initialize global component
            //InitializeChromium(url);
            ModelSearch1 modelSearch = new ModelSearch1();
            modelSearch.Show();
            modelSearch.InitializeChromium(url);
            modelSearch.Update();                
        }
    }
}
