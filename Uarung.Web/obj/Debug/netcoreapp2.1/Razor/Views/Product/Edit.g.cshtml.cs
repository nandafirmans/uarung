#pragma checksum "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0d583889bbb3a53e95b883191d3ac81d292af59"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Edit), @"mvc.1.0.view", @"/Views/Product/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/Edit.cshtml", typeof(AspNetCore.Views_Product_Edit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0d583889bbb3a53e95b883191d3ac81d292af59", @"/Views/Product/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a454cc3725c524beb5749c7dfbd5fbc51bf3557c", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductEditViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(29, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
  
    ViewData[Constant.ViewDataKey.Title] = "Add Product";

    var apiHost = ViewData[Constant.ConfigKey.ApiHost];

#line default
#line hidden
            BeginContext(156, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("ScriptHeader", async() => {
                BeginContext(182, 409, true);
                WriteLiteral(@"
    <style>
        .list-product-image-item {
            background-size: cover;
            background-position: center;
            width: 80px;
            height: 80px;
            position: relative;
        }
        .list-product-image-item .btn {
            line-height: 0;
            position: absolute;
            right: -8px;
            top: -8px;
        }
    </style>    
");
                EndContext();
            }
            );
            BeginContext(594, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("ScriptFooter", async() => {
                BeginContext(620, 704, true);
                WriteLiteral(@" 
    <script type=""text/javascript"">
        $(""[name='categoryId']"").val($(""[data-selected='true']"").attr(""value""));

        $(""[data-updatedImg-remove]"").click(function () {
            const targetField = $(""[name='updatedImages']"");
            const imgPath = $(this).attr(""data-updatedImg-remove"");
            const imagesVal = targetField.val();

            if (imagesVal === undefined || imagesVal === null) return;

            const arrImages = imagesVal.split(""||"")
                .filter(function (img) { return img !== """" && img !== imgPath });

            targetField.val(arrImages.join(""||""));

            $(this).parent(""li"").remove();
        });
    </script>
");
                EndContext();
            }
            );
            BeginContext(1327, 133, true);
            WriteLiteral("\r\n<div class=\"d-flex mb-5\">\r\n    <h3 class=\"mr-auto\">Add Product</h3>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-6\">\r\n        ");
            EndContext();
            BeginContext(1460, 2514, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ed7ca62d808e4c33b0310089ad96f58b", async() => {
                BeginContext(1541, 44, true);
                WriteLiteral("\r\n            <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1585, "\"", 1610, 1);
#line 57 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
WriteAttributeValue("", 1593, Model.Product.Id, 1593, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1611, 180, true);
                WriteLiteral("/>\r\n            <div class=\"form-group\">\r\n                <label>Category</label>\r\n                <select class=\"form-control\" name=\"categoryId\" required=\"\">\r\n                    ");
                EndContext();
                BeginContext(1791, 26, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f21f916e13b4358912ad0c00204d957", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1817, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 62 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
                     if (Model.Categories.Any())
                    {
                        foreach (var category in Model.Categories)
                        {
                            var selected = category.Name.Equals(Model.Product.CategoryName);


#line default
#line hidden
                BeginContext(2083, 28, true);
                WriteLiteral("                            ");
                EndContext();
                BeginContext(2111, 158, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d887397335ec43bf9978233082deda7d", async() => {
                    BeginContext(2182, 34, true);
                    WriteLiteral("\r\n                                ");
                    EndContext();
                    BeginContext(2217, 13, false);
#line 69 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
                           Write(category.Name);

#line default
#line hidden
                    EndContext();
                    BeginContext(2230, 30, true);
                    WriteLiteral("\r\n                            ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 68 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
                               WriteLiteral(category.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#line 68 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
                                                                    Write(selected ? "true" : "");

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("data-selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2269, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 71 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
                        }
                    }

#line default
#line hidden
                BeginContext(2321, 189, true);
                WriteLiteral("                </select>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label>Name</label>\r\n                <input type=\"text\" name=\"name\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2510, "\"", 2537, 1);
#line 77 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
WriteAttributeValue("", 2518, Model.Product.Name, 2518, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2538, 179, true);
                WriteLiteral(" required/>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label>Price</label>\r\n                <input type=\"number\" name=\"price\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2717, "\"", 2745, 1);
#line 81 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
WriteAttributeValue("", 2725, Model.Product.Price, 2725, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2746, 167, true);
                WriteLiteral(" required/>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label>Images</label>\r\n                <input type=\"hidden\" name=\"updatedImages\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2913, "\"", 2961, 1);
#line 85 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
WriteAttributeValue("", 2921, string.Join("||", Model.Product.Images), 2921, 40, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2962, 69, true);
                WriteLiteral(" />\r\n                <ul class=\"list-inline\">\r\n                    \r\n");
                EndContext();
#line 88 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
                     foreach (var img in Model.Product.Images)
                    {

#line default
#line hidden
                BeginContext(3118, 103, true);
                WriteLiteral("                        <li class=\"list-inline-item list-product-image-item rounded border border-dark\"");
                EndContext();
                BeginWriteAttribute("style", "\r\n                            style=\"", 3221, "\"", 3304, 4);
                WriteAttributeValue("", 3258, "background-image:", 3258, 17, true);
                WriteAttributeValue(" ", 3275, "url(\'", 3276, 6, true);
#line 91 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
WriteAttributeValue("", 3281, $"{apiHost}/{img}", 3281, 21, false);

#line default
#line hidden
                WriteAttributeValue("", 3302, "\')", 3302, 2, true);
                EndWriteAttribute();
                BeginContext(3305, 126, true);
                WriteLiteral(">\r\n                            <button class=\"btn btn-danger btn-sm rounded-circle p-0\" type=\"button\" data-updatedImg-remove=\"");
                EndContext();
                BeginContext(3432, 3, false);
#line 92 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
                                                                                                                      Write(img);

#line default
#line hidden
                EndContext();
                BeginContext(3435, 138, true);
                WriteLiteral("\">\r\n                                <span data-feather=\"x\"></span>\r\n                            </button>\r\n                        </li>\r\n");
                EndContext();
#line 96 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
                    }

#line default
#line hidden
                BeginContext(3596, 371, true);
                WriteLiteral(@"                </ul>
                <input type=""file"" class=""form-control pt-1 pl-1"" name=""images"" accept=""image/png, image/jpeg, image/jpg"" multiple/>
            </div>
            <div class=""d-flex"">
                <button class=""btn btn-primary ml-auto mt-1"" type=""submit"">
                    Submit
                </button>
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
#line 56 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\Product\Edit.cshtml"
AddHtmlAttributeValue("", 1474, Url.Action("Update"), 1474, 21, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3974, 20, true);
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductEditViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
