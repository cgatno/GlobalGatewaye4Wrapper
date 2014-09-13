using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GlobalGatewaye4RESTWrapper
{
    public class MerchantTerminal
    {
        private readonly string mGatewayID;
        private readonly string mTerminalPassword;
        private readonly string mHMACKeyID;

        private const string REQUEST_BASE_URL_DEMO = "https://api.demo.globalgatewaye4.firstdata.com";
        private const string REQUEST_BASE_URL = "https://api.globalgatewaye4.firstdata.com";
        private const string REQUEST_ENDPOINT_URI = "/transaction/v14";

        private const string NEW_LINE_CHAR = "\n";

        private const string REQUEST_METHOD = "POST";
        private const string REQUEST_TYPE = "application/xml";

        private const string TIMESTAMP_FORMAT_STRING = "yyyy-MM-ddTHH:mm:ssZ";
        private DateTime mLastTransactionUTCTimestamp;

        private readonly HMAC mEncryptionClient;

        public MerchantTerminal(string GatewayID, string TerminalPassword, string HMACKeyID, string HMACKey)
        {
            mGatewayID = GatewayID;
            mTerminalPassword = TerminalPassword;
            mHMACKeyID = HMACKeyID;
            mEncryptionClient = new HMACSHA1(Encoding.UTF8.GetBytes(HMACKey));
        }

        private void WriteMerchantXMLBlob(XmlWriter writer)
        {
            writer.WriteElementString("ExactID", mGatewayID);
            writer.WriteElementString("Password", mTerminalPassword);
        }

    }
}
