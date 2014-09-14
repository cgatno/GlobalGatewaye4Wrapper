using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GlobalGatewaye4RESTWrapper
{
    public class TransactionResponse
    {
        // Response field names
        private const string TRANSACTION_ERROR_TAG = "Transaction_Error";
        private const string TRANSACTION_APPROVED_TAG = "Transaction_Approved";
        private const string EXACT_RESPONSE_CODE_TAG = "Exact_Resp_code";
        private const string EXACT_MESSAGE_TAG = "Exact_Message";
        private const string BANK_RESPONSE_CODE_TAG = "Bank_Resp_code";
        private const string BANK_MESSAGE_TAG = "Bank_Message";
        private const string BANK_RESPONSE_CODE_2_TAG = "Bank_Resp_code_2";
        private const string TRANSACTION_TAG_TAG = "Transaction_Tag";
        private const string AUTHORIZATION_NUMBER_TAG = "Authorization_Num";
        private const string SEQUENCE_NUMBER_TAG = "SequenceNo";
        // TODO: AVS response code class
        private const string AVS_RESPONSE_TAG = "AVS";
        // TODO: CVV2 response code class
        private const string CVV2_RESPONSE_TAG = "CVV2";
        private const string AVS_RETRIEVAL_REFERENCE_NUMBER_TAG = "Retrieval_Ref_No";
        private const string MERCHANT_NAME_TAG = "MerchantName";
        private const string MERCHANT_ADDRESS_TAG = "MerchantAddress";
        private const string MERCHANT_CITY_TAG = "MerchantCity";
        private const string MERCHANT_STATE_TAG = "MerchantProvince";
        private const string MERCHANT_COUNTRY_TAG = "MerchantCountry";
        private const string MERCHANT_ZIP_CODE_TAG = "MerchantPostal";
        private const string MERCHANT_URL_TAG = "MerchantURL";
        private const string CUSTOMER_TRANSACTION_RECORD_TAG = "CTR";
        private const string CURRENT_BALANCE_TAG = "CurrentBalance";
        private const string PREVIOUS_BALANCE_TAG = "PreviousBalance";

        // Response properties
        public readonly bool TransactionError;
        public readonly bool TransactionApproved;
        public readonly string ExactResponseCode;
        public readonly string ExactMessage;
        public readonly string BankResponseCode;
        public readonly string BankMessage;
        public readonly string BankResponseCode2;
        public readonly string TransactionTag;
        public readonly string AuthorizationNumber;
        public readonly string SequenceNumber;
        public readonly string AVSResponse;
        public readonly string CVV2Response;
        public readonly string AVSRetrievalReferenceNumber;
        public readonly string MerchantName;
        public readonly string MerchantAddress;
        public readonly string MerchantCity;
        public readonly string MerchantState;
        public readonly string MerchantCountry;
        public readonly string MerchantZipCode;
        public readonly string MerchantURL;
        public readonly string CustomerTransactionRecord;
        public readonly decimal CurrentBalance;
        public readonly decimal PreviousBalance;

        public TransactionResponse(string ResponseString)
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(ResponseString)))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        try
                        {
                            switch (reader.Name)
                            {
                                case TRANSACTION_ERROR_TAG:
                                    TransactionError = reader.ReadElementContentAsBoolean();
                                    break;
                                case TRANSACTION_APPROVED_TAG:
                                    TransactionApproved = reader.ReadElementContentAsBoolean();
                                    break;
                                case EXACT_RESPONSE_CODE_TAG:
                                    ExactResponseCode = reader.ReadElementContentAsString();
                                    break;
                                case EXACT_MESSAGE_TAG:
                                    ExactMessage = reader.ReadElementContentAsString();
                                    break;
                                case BANK_RESPONSE_CODE_TAG:
                                    BankResponseCode = reader.ReadElementContentAsString();
                                    break;
                                case BANK_MESSAGE_TAG:
                                    BankMessage = reader.ReadElementContentAsString();
                                    break;
                                case BANK_RESPONSE_CODE_2_TAG:
                                    BankResponseCode2 = reader.ReadElementContentAsString();
                                    break;
                                case TRANSACTION_TAG_TAG:
                                    TransactionTag = reader.ReadElementContentAsString();
                                    break;
                                case AUTHORIZATION_NUMBER_TAG:
                                    AuthorizationNumber = reader.ReadElementContentAsString();
                                    break;
                                case SEQUENCE_NUMBER_TAG:
                                    SequenceNumber = reader.ReadElementContentAsString();
                                    break;
                                case AVS_RESPONSE_TAG:
                                    AVSResponse = reader.ReadElementContentAsString();
                                    break;
                                case CVV2_RESPONSE_TAG:
                                    CVV2Response = reader.ReadElementContentAsString();
                                    break;
                                case AVS_RETRIEVAL_REFERENCE_NUMBER_TAG:
                                    AVSRetrievalReferenceNumber = reader.ReadElementContentAsString();
                                    break;
                                case MERCHANT_NAME_TAG:
                                    MerchantName = reader.ReadElementContentAsString();
                                    break;
                                case MERCHANT_ADDRESS_TAG:
                                    MerchantAddress = reader.ReadElementContentAsString();
                                    break;
                                case MERCHANT_CITY_TAG:
                                    MerchantCity = reader.ReadElementContentAsString();
                                    break;
                                case MERCHANT_STATE_TAG:
                                    MerchantState = reader.ReadElementContentAsString();
                                    break;
                                case MERCHANT_COUNTRY_TAG:
                                    MerchantCountry = reader.ReadElementContentAsString();
                                    break;
                                case MERCHANT_ZIP_CODE_TAG:
                                    MerchantZipCode = reader.ReadElementContentAsString();
                                    break;
                                case MERCHANT_URL_TAG:
                                    MerchantURL = reader.ReadElementContentAsString();
                                    break;
                                case CUSTOMER_TRANSACTION_RECORD_TAG:
                                    CustomerTransactionRecord = reader.ReadElementContentAsString();
                                    break;
                                case CURRENT_BALANCE_TAG:
                                    CurrentBalance = reader.ReadElementContentAsDecimal();
                                    break;
                                case PREVIOUS_BALANCE_TAG:
                                    PreviousBalance = reader.ReadElementContentAsDecimal();
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
        }
    }
}
