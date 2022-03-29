using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICADConnectorPOC
{
    class SelectionObject
    {

        [JsonProperty("event")]
        public string eventProp { get; set; }

        [JsonProperty("source")]
        public string source { get; set; }

        [JsonProperty("version")]
        public string version { get; set; }

        
        public class Content
        {
            [JsonProperty("protocol")]
            public string protocol { get; set; }

            [JsonProperty("version")]
            public string version { get; set; }

            [JsonProperty("source")]
            public string source { get; set; }

            [JsonProperty("widgetId")]
            public string widgetId { get; set; }

            public class Items
            {
                [JsonProperty("envId")]
                public string envId { get; set; }

                [JsonProperty("serviceId")]
                public string serviceId { get; set; }

                [JsonProperty("source")]
                public string source { get; set; }

                [JsonProperty("contextId")]
                public string contextId { get; set; }

                [JsonProperty("objectId")]
                public string objectId { get; set; }

                [JsonProperty("displayName")]
                public string displayName { get; set; }

                [JsonProperty("displayType")]
                public string displayType { get; set; }

                [JsonProperty("ds6w:cadMaster")]
                public string cadMaster { get; set; }


                [JsonProperty("ds6w:reserved")]
                public string reserved { get; set; }

                [JsonProperty("ds6w:policy")]
                public string policy { get; set; }

                [JsonProperty("ds6w:status")]
                public string status { get; set; }


                [JsonProperty("ds6w:kind")]
                public string kind { get; set; }

                [JsonProperty("ds6wg:revision")]
                public string revision { get; set; }
            }
            public class Data
            {
                [JsonProperty("items")]
                public List<Items> items { get; set; }
            }

            [JsonProperty("data")]
            public Data data { get; set; }
        }

        [JsonProperty("content")]
        public Content content{ get; set; }
    }
}
