using System.Collections.Generic;
using Uarung.Model;

namespace Uarung.Web.Models
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            Transactions = new List<Transaction>();
            TopSellings = new List<TopSelling>();
        }

        public const int MaxTopSellings = 5;

        public List<Transaction> Transactions { get; set; }

        public string UserName { get; set; }

        public decimal TotalSales { get; set; }

        public int TotalTransaction { get; set; }

        public List<TopSelling> TopSellings { get; set; }
    }
}