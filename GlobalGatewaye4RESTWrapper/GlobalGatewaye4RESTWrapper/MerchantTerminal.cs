using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        private readonly HMAC mHMACEncryptionClient;

        public MerchantTerminal(string GatewayID, string TerminalPassword, string HMACKeyID, string HMACKey)
        {
            mGatewayID = GatewayID;
            mTerminalPassword = TerminalPassword;
            mHMACKeyID = HMACKeyID;
            mHMACEncryptionClient = new HMACSHA1(Encoding.UTF8.GetBytes(HMACKey));
        }

        private void WriteMerchantXMLBlob(XmlWriter writer)
        {
            writer.WriteElementString("ExactID", mGatewayID);
            writer.WriteElementString("Password", mTerminalPassword);
        }

        public bool IsDemo { get; set; }

        public TransactionResponse ProcessTransaction(Transaction Transaction)
        {
            // Generate transaction XML
            const string TRANSACTION_TAG = "Transaction";
            StringBuilder outputBuilder = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8
                };
            using (XmlWriter writer = XmlWriter.Create(outputBuilder, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(TRANSACTION_TAG);
                WriteMerchantXMLBlob(writer);
                Transaction.WriteTransactionXMLBlob(writer);
                writer.WriteEndElement();
            }

            // SHA1 encrypt final XML data
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] XMLByte = encoder.GetBytes(outputBuilder.ToString());
            SHA1CryptoServiceProvider SHA1Encrypter = new SHA1CryptoServiceProvider();
            string SHA1Hash = BitConverter.ToString(SHA1Encrypter.ComputeHash(XMLByte)).Replace("-", "");
            string XMLHashed = SHA1Hash.ToLower();

            // Set the last transaction time now since we are going to be using it
            mLastTransactionUTCTimestamp = DateTime.UtcNow;

            // Format hashed data
            string hashedData = REQUEST_METHOD + NEW_LINE_CHAR + REQUEST_TYPE + NEW_LINE_CHAR + XMLHashed + NEW_LINE_CHAR + 
                mLastTransactionUTCTimestamp.ToString(TIMESTAMP_FORMAT_STRING) + NEW_LINE_CHAR + REQUEST_ENDPOINT_URI;

            // HMAC encrypt data
            byte[] HMACData = mHMACEncryptionClient.ComputeHash(Encoding.UTF8.GetBytes(hashedData));
            string base64Hash = Convert.ToBase64String(HMACData);

            // Get the endpoint URL ready
            string endpointURL = (IsDemo ? REQUEST_BASE_URL_DEMO : REQUEST_BASE_URL) + REQUEST_ENDPOINT_URI;

            // Generate the web request
            HttpWebRequest gatewayRequest = (HttpWebRequest)WebRequest.Create(endpointURL);
            gatewayRequest.Method = REQUEST_METHOD;
            gatewayRequest.Method = REQUEST_TYPE;
            gatewayRequest.Accept = "*/*";
            gatewayRequest.Headers.Add("x-gge4-date", mLastTransactionUTCTimestamp.ToString(TIMESTAMP_FORMAT_STRING));
            gatewayRequest.Headers.Add("x-gge4-content-sha1", XMLHashed);
            gatewayRequest.Headers.Add("Authorization", "GGE4_API " + mHMACKeyID + ":" + base64Hash);
            gatewayRequest.ContentLength = outputBuilder.ToString().Length;

            // Write/send the request body data
            using (StreamWriter streamWriter = new StreamWriter(gatewayRequest.GetRequestStream()))
            {
                streamWriter.Write(outputBuilder.ToString());
            }

            // Get the response string and load up a TransactionResponse class to return
            TransactionResponse resp;
            try
            {
                using (HttpWebResponse gatewayResponse = (HttpWebResponse)gatewayRequest.GetResponse())
                {
                    using (StreamReader responseStream = new StreamReader(gatewayResponse.GetResponseStream()))
                    {
                        resp = new TransactionResponse(responseStream.ReadToEnd());
                    }
                }
                return resp;
            }
            catch (WebException ex)
            {

                throw ex;
            }
        }
    }
}
