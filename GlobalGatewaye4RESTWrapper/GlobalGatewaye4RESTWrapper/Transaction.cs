using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalGatewaye4RESTWrapper
{
    public class Transaction
    {
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
}
