using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICADConnectorPOC
{
    class Config
    {
        public static string XMLDIRNAME = "D:\\work_dsi\\KobeSteel\\XML\\";
        public static string IEFEXEPATH = "D:\\Program Files\\Dassault Systemes\\B423xcadconnectors\\win_b64\\code\\bin\\";
        public static string LOGINXML = "00_loginEx_Request0.xml";
        public static string LOGOUTXML = "01_logout_Request0.xml";
        public static string CHECKINXML = "2021-12-06_16.41.27_checkinEx_Request0.xml";//This in future need to be removed if checkin is to be done dynamically
        public static string TRANSIENTXML = "2021-12-14_15.02.06.128.000_GetCasTransientInfoCmd_Request.xml";//"03_getcastransientinfo_Request0.xml";
        public static string DSGSCEF = "dscef"; // javascript object
        public static string CHECKOUTXML = "01_checkoutEx_Single_CAA_Document_Request0.xml";//This in future need to be removed if checkout is to be done dynamically
    }
}
