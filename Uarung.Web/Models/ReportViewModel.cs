using System.Collections.Generic;
using Uarung.Model;

namespace Uarung.Web.Models
{
    public class ReportViewModel : TransactionReportRequest
    {
        public ReportViewModel()
        {
            Transactions = new List<Transaction>();
        }

        public List<Transaction> Transactions { get; set; }
    }
}