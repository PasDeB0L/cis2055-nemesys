#pragma checksum "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b61e4d0236c1752f25a4ff869b92061dde701e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ReportPost_Investigation), @"mvc.1.0.view", @"/Views/ReportPost/Investigation.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b61e4d0236c1752f25a4ff869b92061dde701e1", @"/Views/ReportPost/Investigation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_ReportPost_Investigation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Nemesys.ViewModels.InvestigationViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ReportPost", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n<div class=\"card\" style=\"width: 90%;padding:20px; margin:20px;\">\r\n\r\n    <div class=\"card-body\">\r\n        <p class=\"card-text\">Date of Action : ");
#nullable restore
#line 8 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml"
                                         Write(Model.DateOfAction.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"small\">Description : ");
#nullable restore
#line 9 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml"
                                  Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"small\">Investigator details  : ");
#nullable restore
#line 10 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml"
                                            Write(Model.InvestigatorDetails);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n\r\n\r\n    <div class=\"card\" style=\"width: 90%;padding:20px; margin:20px;\">\r\n        <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 507, "\"", 535, 1);
#nullable restore
#line 15 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml"
WriteAttributeValue("", 513, Model.Report.ImageUrl, 513, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 536, "\"", 571, 3);
            WriteAttributeValue("", 542, "Image", 542, 5, true);
            WriteAttributeValue(" ", 547, "for", 548, 4, true);
#nullable restore
#line 15 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml"
WriteAttributeValue(" ", 551, Model.Report.Title, 552, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        <div class=\"card-body\">\r\n            <h3 class=\"card-title\">");
#nullable restore
#line 17 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml"
                              Write(Model.Report.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <p class=\"card-text\">Date of the hazard ");
#nullable restore
#line 18 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml"
                                               Write(Model.Report.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">Description : ");
#nullable restore
#line 19 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml"
                                      Write(Model.Report.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">Location : ");
#nullable restore
#line 20 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml"
                                   Write(Model.Report.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">Type of hazard  : ");
#nullable restore
#line 21 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml"
                                          Write(Model.Report.TypeOfHazard.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">Status : ");
#nullable restore
#line 22 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml"
                                 Write(Model.Report.Status.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">Upvotes : ");
#nullable restore
#line 23 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml"
                                  Write(Model.Report.Upvotes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">By ");
#nullable restore
#line 24 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml"
                           Write(Model.Report.ReporterInformations);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"small\">Create date: ");
#nullable restore
#line 25 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\ReportPost\Investigation.cshtml"
                                     Write(Model.Report.CreatedDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n            <p class=\"small\"></p>\r\n        </div>\r\n    </div>\r\n\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b61e4d0236c1752f25a4ff869b92061dde701e19152", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b61e4d0236c1752f25a4ff869b92061dde701e19418", async() => {
                    WriteLiteral("Back to reports");
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
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
