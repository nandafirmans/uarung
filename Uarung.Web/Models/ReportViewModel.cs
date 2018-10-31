using System.Collections.Generic;
using Uarung.Model;

namespace Uarung.Web.Models
{
    public class ReportViewModel : TransactionReportRequest
    {
        public ReportViewModel()
        {
            Transactions = new List<Transaction>();
            PaymentTypeTable = new Dictionary<string, ReportItemBase>();
            PaymentStatusTable = new Dictionary<string, ReportItemPayment>();
        }

        public List<Transaction> Transactions { get; set; }

        public Dictionary<string, ReportItemBase> PaymentTypeTable { get; set; }

        public Dictionary<string, ReportItemPayment> PaymentStatusTable { get; set; }
    }
}