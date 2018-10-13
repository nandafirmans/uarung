#pragma checksum "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ed9d4e54a326bdd9af861cedee9dee652888d06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Edit), @"mvc.1.0.view", @"/Views/User/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Edit.cshtml", typeof(AspNetCore.Views_User_Edit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ed9d4e54a326bdd9af861cedee9dee652888d06", @"/Views/User/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a454cc3725c524beb5749c7dfbd5fbc51bf3557c", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(13, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
  
    ViewData[Constant.ViewDataKey.Title] = "Edit User";

    var roles = new[]
    {
        string.Empty,
        Constant.UserRole.Admin,
        Constant.UserRole.Cashier,
    };

    var genders = new Dictionary<string, char>()
    {
        {string.Empty, char.MaxValue},
        {Constant.UserGender.MaleKey, Constant.UserGender.MaleValue},
        {Constant.UserGender.FemaleKey, Constant.UserGender.FemaleValue},
    };

#line default
#line hidden
            BeginContext(465, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("ScriptFooter", async() => {
                BeginContext(491, 220, true);
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        $(\"[name=\'Role\']\").val($(\"[data-role-selected=\'true\']\").attr(\"value\"));\r\n        $(\"[name=\'Gender\']\").val($(\"[data-gender-selected=\'true\']\").attr(\"value\"));\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(714, 166, true);
            WriteLiteral("\r\n<div class=\"row mb-5\">\r\n    <div class=\"col-6 offset-3\">\r\n        <div class=\"d-flex mb-3\">\r\n            <h3 class=\"mr-auto\">Add User</h3>\r\n        </div>\r\n        ");
            EndContext();
            BeginContext(880, 3016, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df6a51d6c1ad4e7891f9516a1391a553", async() => {
                BeginContext(943, 44, true);
                WriteLiteral("\r\n            <input name=\"Id\" type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 987, "\"", 1004, 1);
#line 35 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
WriteAttributeValue("", 995, Model.Id, 995, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1005, 151, true);
                WriteLiteral("/>\r\n            <div class=\"form-group\">\r\n                <label>Full Name</label>\r\n                <input type=\"text\" name=\"Name\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1156, "\"", 1175, 1);
#line 38 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
WriteAttributeValue("", 1164, Model.Name, 1164, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1176, 269, true);
                WriteLiteral(@" required/>
            </div>
            <div class=""row"">
                <div class=""col"">
                    <div class=""form-group"">
                        <label>Phone</label>
                        <input type=""number"" name=""Phone"" class=""form-control""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1445, "\"", 1465, 1);
#line 44 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
WriteAttributeValue("", 1453, Model.Phone, 1453, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1466, 269, true);
                WriteLiteral(@" required/>
                    </div>
                </div>
                <div class=""col"">
                    <div class=""form-group"">
                        <label>Email</label>
                        <input type=""email"" name=""Email"" class=""form-control""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1735, "\"", 1755, 1);
#line 50 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
WriteAttributeValue("", 1743, Model.Email, 1743, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1756, 321, true);
                WriteLiteral(@" required/>
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col"">
                    <div class=""form-group"">
                        <label>Role</label>
                        <select class=""form-control"" name=""Role"" required="""">
");
                EndContext();
#line 59 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
                             foreach (var role in roles)
                            {
                                var selected = role.Equals(Model.Role);


#line default
#line hidden
                BeginContext(2241, 32, true);
                WriteLiteral("                                ");
                EndContext();
                BeginContext(2273, 155, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "76135a53b10342b59bf53a40ae534b38", async() => {
                    BeginContext(2342, 38, true);
                    WriteLiteral("\r\n                                    ");
                    EndContext();
                    BeginContext(2381, 4, false);
#line 64 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
                               Write(role);

#line default
#line hidden
                    EndContext();
                    BeginContext(2385, 34, true);
                    WriteLiteral("\r\n                                ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 63 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
                                   WriteLiteral(role);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#line 63 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
                                                                      Write(selected ? "true" : "");

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("data-role-selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2428, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 66 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
                            }

#line default
#line hidden
                BeginContext(2461, 296, true);
                WriteLiteral(@"                        </select>
                    </div>
                </div>
                <div class=""col"">
                    <div class=""form-group"">
                        <label>Gender</label>
                        <select class=""form-control"" name=""Gender"" required="""">
");
                EndContext();
#line 74 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
                             foreach (var g in genders)
                            {
                                var selected = g.Value.Equals(Model.Gender);


#line default
#line hidden
                BeginContext(2925, 32, true);
                WriteLiteral("                                ");
                EndContext();
                BeginContext(2957, 161, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "acf3aba32096456695b9836aa9d55740", async() => {
                    BeginContext(3031, 38, true);
                    WriteLiteral("\r\n                                    ");
                    EndContext();
                    BeginContext(3070, 5, false);
#line 79 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
                               Write(g.Key);

#line default
#line hidden
                    EndContext();
                    BeginContext(3075, 34, true);
                    WriteLiteral("\r\n                                ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 78 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
                                   WriteLiteral(g.Value);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#line 78 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
                                                                           Write(selected ? "true" : "");

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("data-gender-selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3118, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 81 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
                            }

#line default
#line hidden
                BeginContext(3151, 276, true);
                WriteLiteral(@"                        </select>
                    </div>
                </div>
            </div>
            <hr/>
            <div class=""form-group"">
                <label>Username</label>
                <input type=""text"" name=""Username"" class=""form-control""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3427, "\"", 3450, 1);
#line 89 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
WriteAttributeValue("", 3435, Model.Username, 3435, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3451, 187, true);
                WriteLiteral(" required/>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label>Password</label>\r\n                <input type=\"password\" name=\"Password\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3638, "\"", 3661, 1);
#line 93 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
WriteAttributeValue("", 3646, Model.Password, 3646, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3662, 227, true);
                WriteLiteral(" required/>\r\n            </div>\r\n            <div class=\"d-flex\">\r\n                <button class=\"btn btn-primary ml-auto mt-1\" type=\"submit\">\r\n                    Submit\r\n                </button>\r\n            </div>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 34 "D:\Nanda\SKRIPSI\aplikasi\Uarung\Uarung.Web\Views\User\Edit.cshtml"
AddHtmlAttributeValue("", 894, Url.Action("Submit"), 894, 21, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3896, 20, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591