using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Uarung.Model;
using Uarung.Web.Models;
using Uarung.Web.Utility;

namespace Uarung.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IConfiguration configuration)
            : base(configuration)
        {
        }

        public IActionResult Index()
        {
            var model = new DashboardViewModel();

            try
            {
                model.UserName = HttpContext.Session
                    .GetValue<User>(Constant.SessionKey.JsonUser)?.Name;

                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlTransactionReport);
                var request = new TransactionReportRequest
                {
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today,
                    PaymentStatus = Constant.PaymentStatus.Paid
                };
                var response = Requestor().Get<CollectionResponse<Transaction>>(url, request);

                CheckResponse(response);

                model.Transactions = response.Collections;
                model.TotalTransaction = response.Collections.Count;
                model.TotalSales = response.Collections.Sum(t => t.TotalPrice - t.Discount.Value);

                foreach (var transaction in response.Collections)
                foreach (var sp in transaction.SelectedProducts)
                    if (model.TopSellings.Any(p => p.Product.Id == sp.Product.Id))
                    {
                        var index = model.TopSellings.FindIndex(p => p.Product.Id == sp.Product.Id);

                        model.TopSellings[index].Quantity += sp.Quantity;
                    }
                    else
                    {
                        model.TopSellings.Add(new TopSelling
                        {
                            Product = sp.Product,
                            Quantity = sp.Quantity
                        });
                    }

                const int maxTopSelling = DashboardViewModel.MaxTopSellings;

                if (model.TopSellings.Count > maxTopSelling)
                {
                    model.TopSellings = model.TopSellings
                        .OrderByDescending(t => t.Quantity)
                        .ToList()
                        .GetRange(0, maxTopSelling);
                }

            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}