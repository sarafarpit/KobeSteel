using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICADConnectorPOC
{
    class TransientTicket
    {
        private
        String access_token;
        String token_type;
        int expires_in;
        String x3ds_auth_url;
        String x3ds_reauth_url;

        public string Access_token
        {
            get
            {
                return access_token;
            }

            set
            {
                access_token = value;
            }
        }

        public string Token_type
        {
            get
            {
                return token_type;
            }

            set
            {
                token_type = value;
            }
        }

        public int Expires_in
        {
            get
            {
                return expires_in;
            }

            set
            {
                expires_in = value;
            }
        }

        public string X3ds_auth_url
        {
            get
            {
                return x3ds_auth_url;
            }

            set
            {
                x3ds_auth_url = value;
            }
        }

        public string X3ds_reauth_url
        {
            get
            {
                return x3ds_reauth_url;
            }

            set
            {
                x3ds_reauth_url = value;
            }
        }
    }
}
