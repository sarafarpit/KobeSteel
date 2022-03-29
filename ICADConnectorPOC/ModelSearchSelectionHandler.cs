//-------------------------------------------------------------------------------------------------------------
/* This file is responsible for User interaction
 * 
 * Date            Editor                Comments
 * 02-Nov-2021     Arpit Saraf           Initial version

 */
//----------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICADConnectorPOC
{
    class ModelSearchSelectionHandler
    {
        public ModelSearchSelectionHandler(ModelSearch1 parent)
        {
        }
        public void sendString(string arg1, string arg2 = null)
        {
            // We are interested in selection messages only
            if (arg1.StartsWith("{\"event\":\"selection\",\"source\":\"X3DSEAR_AP\""))
            {
                
                String jsonString = arg1;
                SelectionObject deserializedProduct = JsonConvert.DeserializeObject<SelectionObject>(jsonString);
                if (deserializedProduct != null)
                {
                    Console.WriteLine(deserializedProduct.eventProp);
                    if (deserializedProduct.content.data.items.Count > 0)
                    {
                        Console.WriteLine(deserializedProduct.content.data.items[0].objectId);
                        System.IO.File.WriteAllText(Config.XMLDIRNAME + "\\temp.txt", deserializedProduct.content.data.items[0].objectId);
                    }
                }


                if (arg2 == null)
                    Console.WriteLine("[WEB->C# from MS] arg1=" + arg1);
                else
                    Console.WriteLine("[WEB->C# from MS] arg1=" + arg1 + " arg2=" + arg2);

            }
        }
    }
}

