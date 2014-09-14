using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GlobalGatewaye4RESTWrapper
{
    public class Transaction
    {
        private const string TRANSACTION_TYPE_TAG = "Transaction_Type";
        public TransactionType TransactionType { get; set; }

        private const string CHARGE_AMOUNT_TAG = "DollarAmount";
        public decimal ChargeAmount { get; set; }

        private const string CARD_NUMBER_TAG = "Card_Number";
        public string CardNumber { get; set; }

        private const string TRANSACTION_TAG_TAG = "Transaction_Tag";
        public string TransactionTag { get; set; }

        private const string SWIPE_DATA_1_TAG = "Track1";
        public string SwipeData1 { get; set; }

        private const string SWIPE_DATA_2_TAG = "Track2";
        public string SwipeData2 { get; set; }

        private const string AUTHORIZATION_NUMBER_TAG = "Authorization_Num";
        public string AuthorizationNumber { get; set; }

        private const string CARD_EXPIRATION_DATE_TAG = "Expiry_Date";
        public string CardExpirationDate
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(CardExpirationMonth) && !string.IsNullOrWhiteSpace(CardExpirationYear))
                {
                    return CardExpirationMonth + CardExpirationYear;
                }
                else
                {
                    return null;
                }
            }
        }

        public string CardExpirationMonth { get; set; }
        public string CardExpirationYear { get; set; }

        private const string CARDHOLDER_NAME_TAG = "CardHoldersName";
        public string CardholderName { get; set; }

        private const string CARD_SECURITY_CODE_TAG = "CVDCode";
        public string CardSecurityCode { get; set; }

        private const string CARD_SECURITY_CODE_INDICATOR_TAG = "CVD_Presence_Ind";
        public CardSecurityCodeIndicator CardSecurityCodeIndicator { get; set; }

        private const string REFERENCE_NUMBER_TAG = "Reference_No";
        private string mReferenceNumber;
        public string ReferenceNumber
        {
            get
            {
                if (string.IsNullOrWhiteSpace(mReferenceNumber))
                {
                    Random r = new Random();
                    // if the user hasn't specified a unique order ID, we will generate one for them
                    // note that this must be the ID of a previous order for void and credit transactions
                    mReferenceNumber = "R" + DateTime.Now.ToString("MMddyyHHmmssFFF") + r.Next(1000, 9999).ToString();
                }
                return mReferenceNumber;
            }
            set
            {
                mReferenceNumber = value;
            }
        }

        private const string ZIP_CODE_TAG = "ZipCode";
        public string ZipCode { get; set; }

        private const string TAX_1_AMOUNT = "Tax1Amount";
        public decimal Tax1Amount { get; set; }

        private const string TAX_1_NUMBER = "Tax1Number";
        public string Tax1Number { get; set; }

        private const string TAX_2_AMOUNT = "Tax2Amount";
        public decimal Tax2Amount { get; set; }

        private const string TAX_2_NUMBER = "Tax2Number";
        public string Tax2Number { get; set; }

        private const string CUSTOMER_REFERENCE_TAG = "Customer_Ref";
        public string CustomerReference
        {
            get
            {
                return ReferenceNumber;
            }
        }

        private const string REFERENCE_3_TAG = "Reference_3";
        public string Reference3 { get; set; }

        private const string CLIENT_IP_ADDRESS_TAG = "Client_IP";
        public IPAddress ClientIPAddress { get; set; }

        private const string EMAIL_ADDRESS_TAG = "Client_Email";
        public string EmailAddress { get; set; }

        private const string PROCESSOR_USERNAME_TAG = "user_name";
        public string ProcessorUsername { get; set; }

        private const string CURRENCY_TAG = "Currency";
        public string Currency { get; set; }

        private const string PARTIAL_REDEMPTION_TAG = "PartialRedemption";
        public bool PartialRedemption { get; set; }

        private const string CAVV_TAG = "CAVV";
        public string CAVV { get; set; }

        private const string XID_TAG = "XID";
        public string XID { get; set; }

        private const string PAYMENT_TYPE_TAG = "Ecommerce_Flag";
        public PaymentType[] PaymentType { get; set; }

        private const string TRANSARMOR_TOKEN_TAG = "TransarmorTag";
        public string TransarmorToken { get; set; }

        private const string CARD_TYPE_TAG = "CardType";
        public CreditCardType CardType { get; set; }

        private const string EAN_TAG = "EAN";
        public string EAN { get; set; }

        private const string VIRTUAL_CARD_TAG = "VirtualCard";
        public bool VirtualCard { get; set; }

        private const string CARD_COST_TAG = "CardCost";
        public string CardCost { get; set; }

        private const string FRAUD_SUSPECTED_TAG = "FraudSuspected";
        public string FraudSuspected { get; set; }

        private const string CHECK_NUMBER_TAG = "CheckNumber";
        public string CheckNumber { get; set; }

        private const string CHECK_TYPE_TAG = "CheckType";
        public CheckType CheckType { get; set; }

        private const string BANK_ACCOUNT_NUMBER_TAG = "BankAccountNumber";
        public string BankAccountNumber { get; set; }

        private const string BANK_ROUTING_NUMBER_TAG = "BankRoutingNumber";
        public string BankRoutingNumber { get; set; }

        private const string CUSTOMER_NAME_TAG = "CustomerName";
        public string CustomerName { get; set; }

        private const string CUSTOMER_ID_TYPE_TAG = "CustomerIDType";
        public CustomerIDType CustomerIDType { get; set; }

        private const string CUSTOMER_ID_NUMBER_TAG = "CustomerID";
        public string CustomerIDNumber { get; set; }

        private const string PARTNER_ID_TAG = "TPPID";
        public string PartnerID { get; set; }

        private const string SPLIT_TENDER_ID_TAG = "SplitTenderID";
        public string SplitTenderID { get; set; }

        public CustomerAddress Address { get; set; }

        public void WriteTransactionXMLBlob(XmlWriter writer)
        {
            if (TransactionType != null) writer.WriteElementString(TRANSACTION_TYPE_TAG, TransactionType.ToString());
            writer.WriteElementString(CHARGE_AMOUNT_TAG, ChargeAmount.ToString());
            if (!string.IsNullOrWhiteSpace(CardNumber)) writer.WriteElementString(CARD_NUMBER_TAG, CardNumber);
            if (!string.IsNullOrWhiteSpace(TransactionTag)) writer.WriteElementString(TRANSACTION_TAG_TAG, TransactionTag);
            if (!string.IsNullOrWhiteSpace(SwipeData1)) writer.WriteElementString(SWIPE_DATA_1_TAG, SwipeData1);
            if (!string.IsNullOrWhiteSpace(SwipeData2)) writer.WriteElementString(SWIPE_DATA_2_TAG, SwipeData2);
            if (!string.IsNullOrWhiteSpace(AuthorizationNumber)) writer.WriteElementString(AUTHORIZATION_NUMBER_TAG, AuthorizationNumber);
            if (!string.IsNullOrWhiteSpace(CardExpirationDate)) writer.WriteElementString(CARD_EXPIRATION_DATE_TAG, CardExpirationDate);
            if (!string.IsNullOrWhiteSpace(CardholderName)) writer.WriteElementString(CARDHOLDER_NAME_TAG, CardholderName);
            if (!string.IsNullOrWhiteSpace(CardSecurityCode)) writer.WriteElementString(CARD_SECURITY_CODE_TAG, CardSecurityCode);
            if (CardSecurityCodeIndicator != null) writer.WriteElementString(CARD_SECURITY_CODE_INDICATOR_TAG, CardSecurityCodeIndicator.ToString());
            writer.WriteElementString(REFERENCE_NUMBER_TAG, ReferenceNumber);
            if (!string.IsNullOrWhiteSpace(ZipCode)) writer.WriteElementString(ZIP_CODE_TAG, ZipCode);
            writer.WriteElementString(TAX_1_AMOUNT, Tax1Amount.ToString());
            writer.WriteElementString(TAX_1_NUMBER, Tax1Number.ToString());
            writer.WriteElementString(TAX_2_AMOUNT, Tax2Amount.ToString());
            writer.WriteElementString(TAX_2_NUMBER, Tax2Number.ToString());
            writer.WriteElementString(CUSTOMER_REFERENCE_TAG, CustomerReference);
            if (!string.IsNullOrWhiteSpace(Reference3)) writer.WriteElementString(REFERENCE_3_TAG, Reference3);
            if (ClientIPAddress != null) writer.WriteElementString(CLIENT_IP_ADDRESS_TAG, ClientIPAddress.ToString());
            if (!string.IsNullOrWhiteSpace(EmailAddress)) writer.WriteElementString(EMAIL_ADDRESS_TAG, EmailAddress);
            if (!string.IsNullOrWhiteSpace(ProcessorUsername)) writer.WriteElementString(PROCESSOR_USERNAME_TAG, ProcessorUsername);
            if (!string.IsNullOrWhiteSpace(Currency)) writer.WriteElementString(CURRENCY_TAG, Currency);
            writer.WriteElementString(PARTIAL_REDEMPTION_TAG, PartialRedemption.ToString());
            if (!string.IsNullOrWhiteSpace(CAVV)) writer.WriteElementString(CAVV_TAG, CAVV);
            if (!string.IsNullOrWhiteSpace(XID)) writer.WriteElementString(XID_TAG, XID);
            if (PaymentType != null)
            {
                string paymentTypeString = string.Empty;
                foreach (PaymentType pt in PaymentType)
                {
                    paymentTypeString += pt.ToString();
                }
                writer.WriteElementString(PAYMENT_TYPE_TAG, paymentTypeString);
            }
            if (!string.IsNullOrWhiteSpace(TransarmorToken)) writer.WriteElementString(TRANSARMOR_TOKEN_TAG, TransarmorToken);
            if (CardType != null) writer.WriteElementString(CARD_TYPE_TAG, CardType.ToString());
            if (!string.IsNullOrWhiteSpace(EAN)) writer.WriteElementString(EAN_TAG, EAN);
            writer.WriteElementString(VIRTUAL_CARD_TAG, VirtualCard.ToString());
            if (!string.IsNullOrWhiteSpace(CardCost)) writer.WriteElementString(CARD_COST_TAG, CardCost);
            if (!string.IsNullOrWhiteSpace(FraudSuspected)) writer.WriteElementString(FRAUD_SUSPECTED_TAG, FraudSuspected);
            if (!string.IsNullOrWhiteSpace(CheckNumber)) writer.WriteElementString(CHECK_NUMBER_TAG, CheckNumber);
            if (CheckType != null) writer.WriteElementString(CHECK_TYPE_TAG, CheckType.ToString());
            if (!string.IsNullOrWhiteSpace(BankAccountNumber)) writer.WriteElementString(BANK_ACCOUNT_NUMBER_TAG, BankAccountNumber);
            if (!string.IsNullOrWhiteSpace(BankRoutingNumber)) writer.WriteElementString(BANK_ROUTING_NUMBER_TAG, BankRoutingNumber);
            if (!string.IsNullOrWhiteSpace(CustomerName)) writer.WriteElementString(CUSTOMER_NAME_TAG, CustomerName);
            if (CustomerIDType != null) writer.WriteElementString(CUSTOMER_ID_TYPE_TAG, CustomerIDType.ToString());
            if (!string.IsNullOrWhiteSpace(CustomerIDNumber)) writer.WriteElementString(CUSTOMER_ID_NUMBER_TAG, CustomerIDNumber);
            if (!string.IsNullOrWhiteSpace(PartnerID)) writer.WriteElementString(PARTNER_ID_TAG, PartnerID);
            if (!string.IsNullOrWhiteSpace(SplitTenderID)) writer.WriteElementString(SPLIT_TENDER_ID_TAG, SplitTenderID);
            if (Address != null) Address.WriteAddressXMLBlob(writer);
        }
    }

    public class CustomerAddress
    {
        private const string ADDRESS_TAG = "Address";

        private const string ADDRESS_1_TAG = "Address1";
        public string Address1 { get; set; }

        private const string ADDRESS_2_TAG = "Address2";
        public string Address2 { get; set; }

        private const string CITY_TAG = "City";
        public string City { get; set; }

        private const string STATE_TAG = "State";
        public string State { get; set; }

        private const string COUNTRY_TAG = "CountryCode";
        public string Country { get; set; }

        private const string PHONE_NUMBER_TAG = "PhoneNumber";
        public string PhoneNumber { get; set; }

        private const string PHONE_TYPE_TAG = "PhoneType";
        public PhoneType PhoneType { get; set; }

        public void WriteAddressXMLBlob(XmlWriter writer)
        {
            writer.WriteStartElement(ADDRESS_TAG);
            if (!string.IsNullOrWhiteSpace(Address1)) writer.WriteElementString(ADDRESS_1_TAG, Address1);
            if (!string.IsNullOrWhiteSpace(Address2)) writer.WriteElementString(ADDRESS_2_TAG, Address2);
            if (!string.IsNullOrWhiteSpace(City)) writer.WriteElementString(CITY_TAG, City);
            if (!string.IsNullOrWhiteSpace(State)) writer.WriteElementString(STATE_TAG, State);
            if (!string.IsNullOrWhiteSpace(Country)) writer.WriteElementString(COUNTRY_TAG, Country);
            if (!string.IsNullOrWhiteSpace(PhoneNumber)) writer.WriteElementString(PHONE_NUMBER_TAG, PhoneNumber);
            if (PhoneType != null) writer.WriteElementString(PHONE_TYPE_TAG, PhoneType.ToString());
            writer.WriteEndElement();
        }
    }

    public sealed class PhoneType
    {
        private readonly string value;

        public static readonly PhoneType Home = new PhoneType("H");
        public static readonly PhoneType Work = new PhoneType("W");
        public static readonly PhoneType Day = new PhoneType("D");
        public static readonly PhoneType Night = new PhoneType("N");

        private PhoneType(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }

    public sealed class TransactionType
    {
        private readonly string value;

        // Normal transaction types
        public static readonly TransactionType Purchase = new TransactionType("00");
        public static readonly TransactionType PreAuthorization = new TransactionType("01");
        public static readonly TransactionType PreAuthorizationCompletion = new TransactionType("02");
        public static readonly TransactionType ForcedPost = new TransactionType("03");
        public static readonly TransactionType Refund = new TransactionType("04");
        public static readonly TransactionType PreAuthorizationOnly = new TransactionType("05");
        public static readonly TransactionType PayPalOrder = new TransactionType("07");
        public static readonly TransactionType Void = new TransactionType("13");
        public static readonly TransactionType TaggedPreAuthorizationCompletion = new TransactionType("32");
        public static readonly TransactionType TaggedVoid = new TransactionType("33");
        public static readonly TransactionType TaggedRefund = new TransactionType("34");

        // ValueLink transaction types
        public static readonly TransactionType CashOut = new TransactionType("83");
        public static readonly TransactionType Activation = new TransactionType("85");
        public static readonly TransactionType BalanceInquiry = new TransactionType("86");
        public static readonly TransactionType Reload = new TransactionType("88");
        public static readonly TransactionType Deactivation = new TransactionType("89");

        private TransactionType(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }

    public sealed class CardSecurityCodeIndicator
    {
        private readonly string value;

        // Normal transaction types
        public static readonly CardSecurityCodeIndicator NotSupported = new CardSecurityCodeIndicator("0");
        public static readonly CardSecurityCodeIndicator Provided = new CardSecurityCodeIndicator("1");
        public static readonly CardSecurityCodeIndicator Illegible = new CardSecurityCodeIndicator("2");
        public static readonly CardSecurityCodeIndicator NotAvailable = new CardSecurityCodeIndicator("9");


        private CardSecurityCodeIndicator(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }

    public sealed class PaymentType
    {
        private readonly string value;

        // Mail-order/Telephone-order (MOTO) payment types
        public static readonly PaymentType MOTOSingle = new PaymentType("1");
        public static readonly PaymentType MOTORecurring = new PaymentType("2");
        public static readonly PaymentType MOTOInstallment = new PaymentType("3");
        public static readonly PaymentType MOTODeferred = new PaymentType("4");

        // E-commerce (ECI) payment types
        public static readonly PaymentType ECISecure = new PaymentType("5");
        public static readonly PaymentType ECINonAuthenticated = new PaymentType("6");
        public static readonly PaymentType ECIChannelEncrypted = new PaymentType("7");
        public static readonly PaymentType ECINonSecureChannel = new PaymentType("8");
        
        // Retail payment type
        public static readonly PaymentType Retail = new PaymentType("R");

        private PaymentType(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }

    public sealed class CreditCardType
    {
        private readonly string value;

        public static readonly CreditCardType AmericanExpress = new CreditCardType("American Express");
        public static readonly CreditCardType Visa = new CreditCardType("Visa");
        public static readonly CreditCardType Mastercard = new CreditCardType("Mastercard");
        public static readonly CreditCardType Discover = new CreditCardType("Discover");
        public static readonly CreditCardType DinersClub = new CreditCardType("Diners Club");
        public static readonly CreditCardType JCB = new CreditCardType("JCB");
        public static readonly CreditCardType GiftCard = new CreditCardType("Gift");
        public static readonly CreditCardType PayPal = new CreditCardType("PayPal");

        private CreditCardType(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }

    public sealed class CheckType
    {
        private readonly string value;

        public static readonly CheckType Personal = new CheckType("P");
        public static readonly CheckType Corporate = new CheckType("C");

        private CheckType(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }

    public sealed class CustomerIDType
    {
        private readonly string value;

        public static readonly CustomerIDType DriversLicense = new CustomerIDType("0");
        public static readonly CustomerIDType SocialSecurityNumber = new CustomerIDType("1");
        public static readonly CustomerIDType TaxID = new CustomerIDType("2");
        public static readonly CustomerIDType MilitaryID = new CustomerIDType("3");

        private CustomerIDType(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
