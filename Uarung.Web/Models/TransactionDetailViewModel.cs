using Uarung.Model;

namespace Uarung.Web.Models
{
    public class TransactionDetailViewModel
    {
        public TransactionDetailViewModel()
        {
            Transaction = new Transaction();
            User = new User();
        }

        public Transaction Transaction { get; set; }
        public User User { get; set; }
    }
}