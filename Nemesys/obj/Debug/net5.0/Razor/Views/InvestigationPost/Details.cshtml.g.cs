#pragma checksum "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf5a5650f95ff6e6244e0362f535f95b048c5b0a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_InvestigationPost_Details), @"mvc.1.0.view", @"/Views/InvestigationPost/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf5a5650f95ff6e6244e0362f535f95b048c5b0a", @"/Views/InvestigationPost/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_InvestigationPost_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Nemesys.ViewModels.InvestigationViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "InvestigationPost", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"


<h1>Investigation Details</h1>
<div class=""card"" style=""width: 90%;padding:20px; margin:20px;"">

    <div class=""card"" style=""width: 90%;padding:20px; margin:20px;"">
        <div class=""card-body"">
            <p class=""card-text"">Date of Action : ");
#nullable restore
#line 10 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
                                             Write(Model.DateOfAction);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">Description : ");
#nullable restore
#line 11 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
                                      Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">Investigator details  : ");
#nullable restore
#line 12 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
                                                Write(Model.InvestigatorDetails);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n    <div class=\"card\" style=\"width: 90%;padding:20px; margin:20px;\">\r\n        <h2>Report</h2>\r\n        <div class=\"card-body\">\r\n            <h3 class=\"card-title\">");
#nullable restore
#line 21 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
                              Write(Model.Report.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <p class=\"card-text\">Date of the hazard ");
#nullable restore
#line 22 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
                                               Write(Model.Report.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">Description : ");
#nullable restore
#line 23 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
                                      Write(Model.Report.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">Location : ");
#nullable restore
#line 24 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
                                   Write(Model.Report.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">Type of hazard  : ");
#nullable restore
#line 25 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
                                          Write(Model.Report.TypeOfHazard.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">Status : ");
#nullable restore
#line 26 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
                                 Write(Model.Report.Status.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">Upvotes : ");
#nullable restore
#line 27 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
                                  Write(Model.Report.Upvotes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">By ");
#nullable restore
#line 28 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
                           Write(Model.Report.ReporterInformations);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">Create date: ");
#nullable restore
#line 29 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
                                     Write(Model.Report.CreatedDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n            <p class=\"small\"></p>\r\n        </div>\r\n        <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 1416, "\"", 1444, 1);
#nullable restore
#line 32 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
WriteAttributeValue("", 1422, Model.Report.ImageUrl, 1422, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1445, "\"", 1480, 3);
            WriteAttributeValue("", 1451, "Image", 1451, 5, true);
            WriteAttributeValue(" ", 1456, "for", 1457, 4, true);
#nullable restore
#line 32 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
WriteAttributeValue(" ", 1460, Model.Report.Title, 1461, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </div>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf5a5650f95ff6e6244e0362f535f95b048c5b0a10066", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf5a5650f95ff6e6244e0362f535f95b048c5b0a10333", async() => {
                    WriteLiteral("Back to investigations");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cf5a5650f95ff6e6244e0362f535f95b048c5b0a11878", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 37 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\InvestigationPost\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Nemesys.ViewModels.InvestigationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
