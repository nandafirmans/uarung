#pragma checksum "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Category.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c0cd46192c8152e371d9117aa70f34f7eb35ac11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Category), @"mvc.1.0.view", @"/Views/Product/Category.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/Category.cshtml", typeof(AspNetCore.Views_Product_Category))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0cd46192c8152e371d9117aa70f34f7eb35ac11", @"/Views/Product/Category.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a454cc3725c524beb5749c7dfbd5fbc51bf3557c", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Category : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProductCategory>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Category.cshtml"
  
    ViewData[Constant.ViewDataKey.Title] = "Product Category";

#line default
#line hidden
            BeginContext(103, 459, true);
            WriteLiteral(@"
<div class=""d-flex mb-5"">
    <h3>Product Category</h3>
    <button class=""btn btn-outline-primary ml-auto"" data-toggle=""modal"" data-target=""#form-modal"">
        Add Category
    </button>
</div>

<table class=""table"">
    <thead class=""thead-light"">
    <tr>
        <th scope=""col"">#</th>
        <th scope=""col"">Id</th>
        <th scope=""col"">Product Category Name</th>
        <th scope=""col""></th>
    </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 24 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Category.cshtml"
     if (Model != null)
    {
        var i = 1;
        foreach (var category in Model)
        {

#line default
#line hidden
            BeginContext(666, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(705, 1, false);
#line 30 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Category.cshtml"
               Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(706, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(734, 11, false);
#line 31 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Category.cshtml"
               Write(category.Id);

#line default
#line hidden
            EndContext();
            BeginContext(745, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(773, 13, false);
#line 32 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Category.cshtml"
               Write(category.Name);

#line default
#line hidden
            EndContext();
            BeginContext(786, 49, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(835, 295, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5dc5c5a0e8794eb88f8e012a083fe647", async() => {
                BeginContext(904, 219, true);
                WriteLiteral("\r\n                        <button type=\"submit\" class=\"btn btn-danger btn-sm p-0 lh-0 rounded-circle\">\r\n                            <span data-feather=\"x\"></span>\r\n                        </button>\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 34 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Category.cshtml"
AddHtmlAttributeValue("", 849, Url.Action("DeleteCategory", "Product"), 849, 40, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 889, "/", 889, 1, true);
#line 34 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Category.cshtml"
AddHtmlAttributeValue("", 890, category.Id, 890, 12, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1130, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 41 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Category.cshtml"

            i++;
        }
    }

#line default
#line hidden
            BeginContext(1212, 149, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<div class=\"modal fade\" id=\"form-modal\">\r\n    <div class=\"modal-dialog\">\r\n        <div class=\"modal-content\">\r\n            ");
            EndContext();
            BeginContext(1361, 903, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c297c8c626944f18beb649c7d0ce1e5d", async() => {
                BeginContext(1431, 826, true);
                WriteLiteral(@"
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">Add Product Category</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <label>Category Name</label>
                    <input class=""form-control"" type=""text"" name=""name"" required/>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                    <button type=""submit"" class=""btn btn-primary"">Submit</button>
                </div>
            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 51 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Category.cshtml"
AddHtmlAttributeValue("", 1375, Url.Action("InsertCategory", "Product"), 1375, 40, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2264, 36, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProductCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
