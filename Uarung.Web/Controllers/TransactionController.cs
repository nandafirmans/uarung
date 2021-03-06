﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Uarung.Model;
using Uarung.Web.Models;
using Uarung.Web.Utility;

namespace Uarung.Web.Controllers
{
    [Authorize]
    public class TransactionController : BaseController
    {
        public TransactionController(IConfiguration configuration) : base(configuration)
        {
        }

        public IActionResult Index()
        {
            var model = new List<Transaction>();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlTransaction);
                var response = Requestor().Get<CollectionResponse<Transaction>>(url);

                CheckResponse(response);

                model = response.Collections;
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(model);
        }

        public IActionResult Detail(string id)
        {
            var model = new TransactionDetailViewModel();

            try
            {
                model.Transaction = FetchTransaction(id).Collections.FirstOrDefault();

                var urlGetUser = $"{CreateServiceUrl(Constant.ConfigKey.ApiUrlUser)}{model.Transaction?.CreatedById}";
                var responseGetUser = Requestor().Get<CollectionResponse<User>>(urlGetUser);

                CheckResponse(responseGetUser);

                model.User = responseGetUser.Collections.FirstOrDefault();
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(model);
        }

        public IActionResult Report(string searchDate)
        {
            var model = new ReportViewModel();

            try
            {
                var searchDateSplited = searchDate?.Split(" - ") ?? new []
                {
                    DateTime.Today.ToString("d"),
                    DateTime.Today.ToString("d")
                };
                
                DateTime.TryParseExact(searchDateSplited[0], "d", null, DateTimeStyles.None, out var start);
                DateTime.TryParseExact(searchDateSplited[1], "d", null, DateTimeStyles.None, out var end);

                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlTransactionReport);
                var request = new TransactionReportRequest()
                {
                    StartDate = start, 
                    EndDate = end
                };

                var response = Requestor().Get<CollectionResponse<Transaction>>(url, request);

                CheckResponse(response);

                model.Transactions = response.Collections;
                model.StartDate = start;
                model.EndDate = end;

                if (response.Collections.Any())
                {
                    var paymentStatus = new[]
                    {
                        Constant.PaymentStatus.Hold,
                        Constant.PaymentStatus.Paid,
                        Constant.PaymentStatus.Canceled
                    };

                    var paymentTypes = new[]
                    {
                        Constant.PaymentType.Card,
                        Constant.PaymentType.Cash,
                        Constant.PaymentType.Other,
                    };

                    model.PaymentStatusTable =
                        GenerateReportTable<ReportItemPayment>(response.Collections, paymentStatus, "PaymentStatus");
                    model.PaymentTypeTable =
                        GenerateReportTable<ReportItemBase>(response.Collections, paymentTypes, "PaymentType");
                }
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Export(string reportModelJson)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<ReportViewModel>(reportModelJson);
                var fileName = $"{model.StartDate:ddMMyy}-{model.EndDate:ddMMyy}";
                var sb = new StringBuilder();

                sb.AppendLine($"Transaction Reports from {model.StartDate:dd MMM yyyy} to {model.EndDate:dd MMM yyyy},");

                sb.AppendLine("");
                sb.AppendLine("No, Payment Status, Transaction Count, Total Price");
                var psNum = 1;
                foreach (var item in model.PaymentStatusTable)
                {
                    sb.AppendLine(string.Join(",", new[]
                    {
                        psNum.ToString(),
                        item.Value.Name,
                        item.Value.Count.ToString(),
                        $"\"{item.Value.Total:N0}\""
                    }));

                    psNum++;
                }

                sb.AppendLine("");
                sb.AppendLine("No, Payment Type, Transaction Count");
                var ptNum = 1;
                foreach (var item in model.PaymentTypeTable)
                {
                    sb.AppendLine(string.Join(",", new[]
                    {
                        ptNum.ToString(),
                        item.Value.Name,
                        item.Value.Count.ToString(),
                    }));

                    ptNum++;
                }
                
                sb.AppendLine("");
                sb.AppendLine("No, Id, Notes, Payment Status, Payment Type, Created Date, Total Price,");
                var tNum = 1;
                foreach (var t in model.Transactions.AsEnumerable())
                {
                    sb.AppendLine(string.Join(",", new[]
                    {
                        tNum.ToString(),
                        t.Id,
                        string.IsNullOrEmpty(t.Notes) ? "-" : t.Notes,
                        t.PaymentStatus,
                        t.PaymentType,
                        t.CreatedDate.ToString("g"),
                        $"\"{(t.TotalPrice - t.Discount.Value):N0}\""
                    }));

                    tNum++;
                }
                
                return File(Encoding.Default.GetBytes(sb.ToString()), "text/csv", $"{fileName}.csv");
            }
            catch (Exception e)
            {
                return RedirectToAction("Report", new {err = e.Message});
            }
        }

        public IActionResult SalesRegister()
        {
            var model = new SalesRegisterViewModel();
            
            try
            {
                var requestor = Requestor();

                var urlCategories = CreateServiceUrl(Constant.ConfigKey.ApiUrlProductCategory);
                var urlProduct = CreateServiceUrl(Constant.ConfigKey.ApiUrlProduct);
                var urlDiscount = CreateServiceUrl(Constant.ConfigKey.ApiUrlDiscount);

                var responseCategory = requestor.Get<CollectionResponse<ProductCategory>>(urlCategories);
                var responseProduct = requestor.Get<CollectionResponse<Product>>(urlProduct);
                var responseDiscount = requestor.Get<CollectionResponse<Discount>>(urlDiscount);

                CheckResponse(new BaseResponse[] {responseCategory, responseProduct, responseDiscount});

                model.Categories = new List<ProductCategory> {new ProductCategory {Id = "0", Name = "All"}}
                    .Concat(responseCategory.Collections)
                    .ToList();

                model.Discounts = responseDiscount.Collections;
                model.Products = responseProduct.Collections;
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(model);
        }

        [RemoveDefaultLayout]
        public IActionResult Print(string id)
        {
            try
            {
                var model = FetchTransaction(id).Collections.FirstOrDefault();

                return View(model);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpPost]
        public IActionResult Submit([FromBody] Transaction request, string id = "")
        {
            var response = new CollectionResponse<Transaction>();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlTransaction);

                response = id.Equals("update") 
                    ? Requestor().Put<CollectionResponse<Transaction>>(url, request) 
                    : Requestor().Post<CollectionResponse<Transaction>>(url, request);
            }
            catch (Exception e)
            {
                response.Status.SetError(e.Message);
            }

            return Json(response);
        }

        [HttpGet]
        public IActionResult GetHoldOnly() 
        {
            var response = new CollectionResponse<Transaction>();

            try
            {
                response = FetchTransaction(null, true);
            }
            catch (Exception e)
            {
                response.Status.SetError(e.Message);
            }

            return Json(response);
        }

        [HttpGet]
        public IActionResult Delete(string id) 
        {
            try
            {
                var url = $"{CreateServiceUrl(Constant.ConfigKey.ApiUrlTransaction)}{id}";
                var response = Requestor().Delete<BaseResponse>(url);

                CheckResponse(response);

                return RedirectToAction("Index", new { ok = "delete success" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { err = e.Message });
            }
        }
        
        [HttpGet]
        public IActionResult Cancel(string id)
        {
            try
            {
                var url = $"{CreateServiceUrl(Constant.ConfigKey.ApiUrlTransactionCancel)}{id}";
                var response = Requestor().Get<BaseResponse>(url);

                CheckResponse(response);

                return RedirectToAction("Detail", new { id, ok = "transaction canceled" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Detail", new { id, err = e.Message });
            }
        }

        private CollectionResponse<Transaction> FetchTransaction(string id = null, bool isHold = false)
        {
            var url = CreateServiceUrl((isHold 
                ? Constant.ConfigKey.ApiUrlTransactionGetHold 
                : Constant.ConfigKey.ApiUrlTransaction));

            if (!string.IsNullOrEmpty(id))
                url = $"{url}{id}";

            var response = Requestor().Get<CollectionResponse<Transaction>>(url);

            CheckResponse(response);

            return response;
        }

        private static Dictionary<string, T> GenerateReportTable<T>(
            IReadOnlyCollection<Transaction> transactions, 
            IEnumerable<string> keys, 
            string keyProp
        ) where T : ReportItemBase, new()
        {
            var result = new Dictionary<string, T>();

            foreach (var key in keys)
            {
                var trans = transactions
                    .Where(t => t.GetType().GetProperty(keyProp).GetValue(t).ToString() == key)
                    .ToList();

                var item = new T()
                {
                    Name = key,
                    Count = trans.Count()
                };

                if (item is ReportItemPayment)
                    (item as ReportItemPayment).Total = trans.Sum(t => t.TotalPrice - t.Discount.Value);

                result.Add(key, item);
            }

            return result;
        }
    }
}