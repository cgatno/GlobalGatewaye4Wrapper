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
        private const string AVS_RESPONSE_TAG = "AVS";
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
        public readonly AVSResponseCode AVSResponse;
        public readonly CVV2ResponseCode CVV2Response;
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
                                    AVSResponse = new AVSResponseCode(reader.ReadElementContentAsString());
                                    break;
                                case CVV2_RESPONSE_TAG:
                                    CVV2Response = new CVV2ResponseCode(reader.ReadElementContentAsString());
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
                        catch
                        {
                            // Do nothing on errors for now - just continue the loop
                        }
                    }
                }
            }
        }
    }

    public sealed class AVSResponseCode
    {
        public readonly string value;

        public AVSResponseCode(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            switch (value)
            {
                case "X":
                    return "Exact match, 9 digit ZIP";
                case "Y":
                    return "Exact match, 5 digit ZIP";
                case "A":
                    return "Address match only";
                case "W":
                    return "9 digit ZIP match only";
                case "Z":
                    return "5 digit ZIP match only";
                case "N":
                    return "No address or ZIP match";
                case "U":
                    return "Address unavailable";
                case "G":
                    return "Non-North American issuer, does not participate";
                case "R":
                    return "Issuer system not available";
                case "E":
                    return "Not a mail/phone order";
                case "S":
                    return "Service not supported";
                case "Q":
                    return "Bill to address did not pass edit checks";
                case "D":
                    return "International street address and postal code match";
                case "B":
                    return "International street address match, postal code not verified due to incompatible format";
                case "C":
                    return "International street address and postal code not verified due to incompatible format";
                case "P":
                    return "International postal code match, street address not verified due to incompatible format";
                case "1":
                    return "Cardholder name matches";
                case "2":
                    return "Cardholder name, billing address, and postal code match";
                case "3":
                    return "Cardholder name and billing postal code match";
                case "4":
                    return "Cardholder name and billing address match";
                case "5":
                    return "Cardholder name incorrect, billing address and postal code match";
                case "6":
                    return "Cardholder name incorrect, billing postal code matches";
                case "7":
                    return "Cardholder name incorrect, billing address matches";
                case "8":
                    return "Cardholder name, billing address, and postal code are all incorrect";
                default:
                    return "Unknown response code";
            }
        }
    }

    public sealed class CVV2ResponseCode
    {
        public readonly string value;
        
        public CVV2ResponseCode(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            switch (value)
            {
                case "M":
                    return "CVV2/CVC2/CVD Match";
                case "N":
                    return "CVV2/CVC2/CVD No match";
                case "P":
                    return "Not processed";
                case "S":
                    return "Merchant has indicated that CVV2/CVC2/CVD is not present on card";
                case "U":
                    return "Issuer is not certified and/or has not provided Visa encryption keys";
                default:
                    return "Unknown response code";
            }
        }
    }
}
