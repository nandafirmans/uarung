#pragma checksum "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5b541c85f5fa8113b585a7b3cd2576fe276f056"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transaction_Print), @"mvc.1.0.view", @"/Views/Transaction/Print.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Transaction/Print.cshtml", typeof(AspNetCore.Views_Transaction_Print))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\_ViewImports.cshtml"
using Uarung.Web;

#line default
#line hidden
#line 2 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\_ViewImports.cshtml"
using Uarung.Web.Models;

#line default
#line hidden
#line 3 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\_ViewImports.cshtml"
using Uarung.Model;

#line default
#line hidden
#line 1 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5b541c85f5fa8113b585a7b3cd2576fe276f056", @"/Views/Transaction/Print.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a454cc3725c524beb5749c7dfbd5fbc51bf3557c", @"/Views/_ViewImports.cshtml")]
    public class Views_Transaction_Print : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Transaction>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin:auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(95, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
  
    var brandAddress = Config.GetValue<string>(Constant.ConfigKey.BrandAddress);
    var brandName = Config.GetValue<string>(Constant.ConfigKey.BrandName);

#line default
#line hidden
            BeginContext(262, 59, true);
            WriteLiteral("\r\n<html moznomarginboxes=\"\" mozdisallowselectionprint=\"\">\r\n");
            EndContext();
            BeginContext(321, 411, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9de6cd445d56424c9b802e5f99361abe", async() => {
                BeginContext(327, 250, true);
                WriteLiteral("\r\n    <title></title>\r\n    <style>\r\n        h3 { text-align: center; }\r\n\r\n        table {\r\n            font-size: 12px;\r\n            text-align: center;\r\n        }\r\n\r\n        hr { border-top: dotted 1px; }\r\n\r\n        body { width: 72mm; }\r\n\r\n        ");
                EndContext();
                BeginContext(578, 28, true);
                WriteLiteral("@media print {\r\n            ");
                EndContext();
                BeginContext(607, 118, true);
                WriteLiteral("@page {\r\n                margin: 3.5mm;\r\n            }\r\n\r\n            body { margin: 0mm; }\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(732, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(736, 2663, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41f8cea01e0241b99f674fd9370af870", async() => {
                BeginContext(762, 192, true);
                WriteLiteral("\r\n<font face=\"verdana\" size=\"2\">\r\n    <div id=\"receiptDetails\" style=\"page-break-after: always !important\">\r\n        <div style=\"font-weight: bold; text-align: center; word-wrap: break-word;\">");
                EndContext();
                BeginContext(955, 9, false);
#line 38 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
                                                                              Write(brandName);

#line default
#line hidden
                EndContext();
                BeginContext(964, 72, true);
                WriteLiteral("</div>\r\n        <div style=\"text-align: center; word-wrap: break-word;\">");
                EndContext();
                BeginContext(1037, 12, false);
#line 39 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
                                                           Write(brandAddress);

#line default
#line hidden
                EndContext();
                BeginContext(1049, 109, true);
                WriteLiteral("</div>\r\n        <div style=\"text-align: center; word-wrap: break-word; font-size: 12px; margin-top:10px\">Id: ");
                EndContext();
                BeginContext(1159, 8, false);
#line 40 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
                                                                                                Write(Model.Id);

#line default
#line hidden
                EndContext();
                BeginContext(1167, 48, true);
                WriteLiteral("</div>\r\n        <div style=\"text-align: center\">");
                EndContext();
                BeginContext(1216, 61, false);
#line 41 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
                                   Write(Model.CreatedDate.ToString("ddd, dd MMMM yyyy 'at' HH:mm tt"));

#line default
#line hidden
                EndContext();
                BeginContext(1277, 298, true);
                WriteLiteral(@"</div>
        <hr>
        <table style=""width: 100%"">
            <thead>
            <tr>
                <th align=""left"">Product</th>
                <th align=""center"">Qty</th>
                <th align=""right"">Price</th>
            </tr>
            </thead>
            <tbody>
");
                EndContext();
#line 52 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
             foreach (var sp in Model.SelectedProducts)
            {

#line default
#line hidden
                BeginContext(1647, 59, true);
                WriteLiteral("                <tr>\r\n                    <td align=\"left\">");
                EndContext();
                BeginContext(1707, 15, false);
#line 55 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
                                Write(sp.Product.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1722, 46, true);
                WriteLiteral("</td>\r\n                    <td align=\"center\">");
                EndContext();
                BeginContext(1769, 11, false);
#line 56 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
                                  Write(sp.Quantity);

#line default
#line hidden
                EndContext();
                BeginContext(1780, 45, true);
                WriteLiteral("</td>\r\n                    <td align=\"right\">");
                EndContext();
                BeginContext(1826, 28, false);
#line 57 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
                                 Write(sp.TotalPrice.ToString("N0"));

#line default
#line hidden
                EndContext();
                BeginContext(1854, 30, true);
                WriteLiteral("</td>\r\n                </tr>\r\n");
                EndContext();
#line 59 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
            }

#line default
#line hidden
                BeginContext(1899, 213, true);
                WriteLiteral("            </tbody>\r\n        </table>\r\n        <hr>\r\n        <table style=\"width: 100%\">\r\n            <tbody>\r\n            <tr>\r\n                <td align=\"left\">Discount</td>\r\n                <td align=\"right\">-");
                EndContext();
                BeginContext(2114, 35, false);
#line 67 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
                               Write(Model.Discount.Value.ToString("N0"));

#line default
#line hidden
                EndContext();
                BeginContext(2150, 126, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td align=\"left\">Subtotal</td>\r\n                <td align=\"right\">");
                EndContext();
                BeginContext(2278, 56, false);
#line 71 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
                              Write((Model.TotalPrice - Model.Discount.Value).ToString("N0"));

#line default
#line hidden
                EndContext();
                BeginContext(2335, 173, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td align=\"left\" style=\"font-weight: 600\">Total</td>\r\n                <td align=\"right\" style=\"font-weight: 600\">");
                EndContext();
                BeginContext(2509, 31, false);
#line 75 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
                                                      Write(Model.TotalPrice.ToString("N0"));

#line default
#line hidden
                EndContext();
                BeginContext(2540, 193, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td><br/></td>\r\n            </tr>\r\n            <tr>\r\n                <td align=\"left\">Status</td>\r\n                <td align=\"right\">");
                EndContext();
                BeginContext(2734, 19, false);
#line 82 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
                             Write(Model.PaymentStatus);

#line default
#line hidden
                EndContext();
                BeginContext(2753, 130, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td align=\"left\">Payment Type</td>\r\n                <td align=\"right\">");
                EndContext();
                BeginContext(2885, 90, false);
#line 86 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Transaction\Print.cshtml"
                              Write((Model.PaymentType == Constant.PaymentType.Card ? "Debit/Credit Card" : Model.PaymentType));

#line default
#line hidden
                EndContext();
                BeginContext(2976, 416, true);
                WriteLiteral(@"</td>
            </tr>
            </tbody>
        </table>
        <hr>
        <div style=""margin-bottom: 15px; margin-top: 15px; text-align: center; word-wrap: break-word;"">
            Thank You.
        </div>
        <br>
    </div>
</font>

<script>
    (function(){
        window.print();
        setTimeout(function() {
            window.close();
        },500);
    })();
</script>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3399, 11, true);
            WriteLiteral("\r\n\r\n</html>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IConfiguration Config { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Transaction> Html { get; private set; }
    }
}
#pragma warning restore 1591
