//-------------------------------------------------------------------------------------------------------------
/* This file is responsible for all XML communication utility functions
 * 
 * Date            Editor                Comments
 * 24-Dec-2021     Arpit Saraf           Initial version

 */
//----------------------------------------------------------------------------------------------------------------
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ICADConnectorPOC
{
    class XMLCommunication//Singleton Class
    {
        private
        String dirName;
        String fileName;
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream;
        int processId = 0;
        System.Diagnostics.Process process;
        bool isClientInvoked = false;
        private static XMLCommunication single_instance = null;
        public String s;

        private XMLCommunication()
        {
            s = "XML communications for Connector";
        }

        // Static method
        // Static method to create instance of Singleton class
        public static XMLCommunication getInstance()
        {
            if (single_instance == null)
                single_instance = new XMLCommunication();

            return single_instance;
        }

        public string DirName
        {
            get
            {
                return dirName;
            }

            set
            {
                dirName = value;
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }

        public bool InvokeClient()
        {
            //Initiate IEC client
            string cPath = Config.IEFEXEPATH;
            string filename = Path.Combine(cPath, "IEFClientWorkspaceService.exe");
            string param = Path.Combine(cPath, "config.xml");
            process = System.Diagnostics.Process.Start(filename/*, param*/);
            Thread.Sleep(10000);
            processId = process.Id;
            if (processId != 0)//Client started
            {
                
                //Read the socket port
                string userdirectory = System.Environment.GetEnvironmentVariable("USERPROFILE");
                string text = System.IO.File.ReadAllText(userdirectory + "\\decengine.port");

                // Display the file contents to the console. Variable text is a string.
                System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
                clientSocket.Connect("127.0.0.1", Int16.Parse(text));
                isClientInvoked = true;
                return true;

            }
            return false;
        }
        public bool Login(String commandReturnData)
        {
            String dirName = Config.XMLDIRNAME;
            String fileName = Config.LOGINXML;
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("<?xml version=\"1.0\" ?>\n<request dirname=\"" + dirName + "\" filename=\"" + fileName + "\"/>\n");
            if(!clientSocket.Connected && !isClientInvoked)
            {
                clientSocket = new System.Net.Sockets.TcpClient();
                InvokeClient();
            }
            serverStream = clientSocket.GetStream();
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            //clientSocket.Client.Shutdown(SocketShutdown.Send);
            byte[] inStream = new byte[1002500];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            commandReturnData = System.Text.Encoding.ASCII.GetString(inStream);
            string text = System.IO.File.ReadAllText(dirName + "\\Response.xml");
            if (text.Contains("result=\"success\""))
                return true;
            return false;
        }
        public bool Logout(String commandReturnData)
        {
            String dirName = Config.XMLDIRNAME;
            if (serverStream.CanWrite)
            {
                String fileName = Config.LOGOUTXML;
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes("<?xml version=\"1.0\" ?>\n<request dirname=\"" + dirName + "\" filename=\"" + fileName + "\"/>\n");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
                clientSocket.Client.Shutdown(SocketShutdown.Send);
                byte[] inStream = new byte[1002500];
                serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                commandReturnData = System.Text.Encoding.ASCII.GetString(inStream);
            }
            clientSocket.Close();
            isClientInvoked = false;//Reset 

            string userdirectory = System.Environment.GetEnvironmentVariable("USERPROFILE");
            if (File.Exists(userdirectory + "\\decengine.processid"))
            {
                Process[] process = Process.GetProcesses();
                string text = System.IO.File.ReadAllText(userdirectory + "\\decengine.processid");

                foreach (Process prs in process)
                {
                    if (prs.Id == Int64.Parse(text))
                    {
                        prs.Kill();
                        break;
                    }
                }
                Thread.Sleep(50000);
            }
            string textRes = System.IO.File.ReadAllText(dirName + "\\Response.xml");
            if (textRes.Contains("result=\"success\""))
                return true;
            return false;
        }

        public bool CheckIn(string checkInFileName, ref string commandReturnData)
        {
            String dirName = Config.XMLDIRNAME;
            //String fileName = "02_checkinEx_CAA_Document_Links_Request.xml";
            String fileName = checkInFileName;
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("<?xml version=\"1.0\" ?>\n<request dirname=\"" + dirName + "\" filename=\"" + fileName + "\"/>\n");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            byte[] inStream = new byte[1002500];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            commandReturnData = System.Text.Encoding.ASCII.GetString(inStream);
            string text = System.IO.File.ReadAllText(dirName + "\\Response.xml");
            if (text.Contains("result=\"success\""))
                return true;
            return false;
        }


        public bool CheckOut(string checkOutFileName, string physicalId, string commandReturnData)
        {
            String dirName = Config.XMLDIRNAME;
            //String fileName = "02_checkinEx_CAA_Document_Links_Request.xml";
            String fileName = checkOutFileName;
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("<?xml version=\"1.0\" ?>\n<request dirname=\"" + dirName + "\" filename=\"" + fileName + "\"/>\n");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            byte[] inStream = new byte[1002500];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            commandReturnData = System.Text.Encoding.ASCII.GetString(inStream);
            string text = System.IO.File.ReadAllText(dirName + "\\Response.xml");
            if (text.Contains("result=\"success\""))
                return true;
            return false;
        }

        public String GetTransientTicket()
        {
            String dirName = Config.XMLDIRNAME;
            String fileName = Config.TRANSIENTXML;
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("<?xml version=\"1.0\" ?>\n<request dirname=\"" + dirName + "\" filename=\"" + fileName + "\"/>\n");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            byte[] inStream = new byte[1002500];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            //string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            //msg(returndata);
            string text = System.IO.File.ReadAllText(dirName + "\\Response.xml");
            String jsonString = text.Substring(text.IndexOf('{'), text.IndexOf('}') - text.IndexOf('{') + 1);
            TransientTicket deserializedProduct = JsonConvert.DeserializeObject<TransientTicket>(jsonString);
            return deserializedProduct.X3ds_reauth_url;
        }

    }
}
