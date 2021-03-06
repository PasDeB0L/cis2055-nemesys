#pragma checksum "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d417fe66a5cf3ec2da4ba6496279ba5a9a1cd441"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d417fe66a5cf3ec2da4ba6496279ba5a9a1cd441", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\33607\Documents\GitHub\NEMESYS\Nemesys\Views\Home\About.cshtml"
  
    ViewData["Title"] = "About ";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>1 PROJECT OUTLINE - JUNE SESSION</h1>

<h2>1.1 OVERVIEW</h2>

<p>
    Have you ever spotted something dangerous which can easily cause an accident and/or injury on
    campus? Have you ever noticed someone working without the necessary safety precautions (e.g.
    working without protective equipment)? Have you ever felt that some caution could save lives?<br />

    This is your chance to build NEMESYS – a Near Miss Exposure and Reporting System. Students and
    staff can use NEMESYS to report near misses on and around campus – where administration can
    then intervene.<br />

    Near-miss reports are intended for administrative bodies at UoM (e.g. student bodies, precincts
    office etc…) on which action can then be taken to improve the overall Health and Safety conditions
    on campus.<br />

    There are two types of users in NEMESYS, reporters and investigators. Reporters can create a nearmiss report while investigators are responsible to review these reports and eventually ");
            WriteLiteral(@"add an
    investigation entry to each individual report before closing the case. There can only be one
    investigation for each report. Reporters will be able to create reports, edit/delete their own reports
    and browse all near-miss entries (and associated investigation, if any) created by themselves and
    others. Reporters may also upvote other people’s reports. Apart from the above operations,
    investigators are also able to add and edit investigations for individual reports.<br />

    A report is made up of the following properties: date of report, location where hazard was spotted,
    date and time when hazard was spotted, type of hazard (e.g. unsafe act, condition, equipment or
    structure), description, status, details of person who created the report (including email and
    optionally phone), optional photo, and upvotes. Report status is initially set to open and this can only
    be modified by investigators. <br />

    An investigation is then created by the person who ");
            WriteLiteral(@"is handling the near-miss report. This has the
    following properties: description of investigation, date of action and investigator’s details (including
    email and optionally phone). The investigator can change the report’s status to closed, being
    investigated or no action required. Ideally, the owner of the report would receive an email once the
    report is handled (e.g. status changed, investigation added etc…), however this is optional.<br />

    A simple “hall-of-fame” page should also be created, where a “reporters ranking” chart shows the
    most active reporters (based on number of reports made) throughout the current year<br />
</p>

<h2>1.2 TASK</h2>
<p>
    Build this web app using ASP.Net Core MVC as well as SQL Server and Entity Framework. You are to
    build this application from the ground up as demonstrated in class. This applies for both client and
    server-side code.<br />
    <h2>1.2.1 Give it a twist</h2>  <br />
    Once you’ve built the app, you should the");
            WriteLiteral(@"n give it your own interpretation. You can add simple
    features, modify existing ones or create additional functionality to make it more useful.<br />
    Some examples of additional features include:<br />

    • Integration with Google or Bing maps for report location<br />
    • Email notifications when<br />
    o a new report has been submitted (received by investigators)<br />
    o when an investigation has been added (owner of report receives update)<br />
    <br />
</p>

<h2>1.3 TEAMS</h2>
<p>
    • You can work in teams of two, however you can also go solo. Those working in a team must
    state their individual contribution towards the project.<br />
    • You are to use a private GitHub repository named “cis2055-nemesys” (even if working
    alone). Please also include chrisporter-um along with your team members as collaborators. It
    doesn’t matter who creates the repository, as long as all team members are added as
    Collaborators.<br />
    • Please note that plagiari");
            WriteLiteral(@"sm will not be tolerated. It is understood that certain code is autogenerated by the tools/framework (scaffolding), however logic is not, and should not be
    copied from other people (including online sources).<br />
    • It is recommended you start working on this as soon as possible. Leaving only a few weeks
    for this will result in low-quality work (and grades).
</p>

<h2>1.4 SUBMISSION DETAILS</h2>
<p>
    • Due date: please refer to the unit’s VLE area.<br />
    • Submission: Documentation is to be submitted via the unit’s VLE area. Please use the Word
    template available from the Departmental site for your documentation
    (https://www.um.edu.mt/ict/cis/students/resources)<br />
    • Code: Although you will also provide a link to your GitHub repository, all code and database
    backups must also be submitted in the respective VLE area (compressed).
</p>


<h1>Other details</h1>
<p>
    1) Patterns, best-practices and technologies necessary to complete this assignment will");
            WriteLiteral(@" be
    discussed in depth in-class.<br />
    2) Git activity will highlight aspects such as time-management as well as team effectiveness
    over time (where applicable).<br />
    3) Regarding documentation for your assignment, these are some basic requirements:<br />
    a. No page min/max - however, you need to at least provide a brief description of the
    architecture adopted (i.e. how you adopted MVC (e.g. the various C's and M's used,
    view models and any custom routes), best practices adopted, database schema,
    external libraries used, security aspects (as part of the framework and any other you
    may have introduced), user management flows, patterns adopted (e.g. DI) and why,
    use of roles etc...<br />
    b. You may add a few code-snippets for salient aspects, and/or flow-charts and
    screenshots.<br />
    c. Challenges you faced and how these were overcome.<br />
    d. Each team (where applicable) is to provide a signed teamwork declaration, including
    a detaile");
            WriteLiteral(@"d description of contributions made by each team member towards the
    project’s deliverables.<br />
    e. And of course, a signed plagiarism declaration sheet.<br />
    f. The plagiarism declaration form and assignemnt template are available from:
    https://www.um.edu.mt/ict/cis/students/resources<br />
    4) You may be called in for a 15-minute clarification meeting (in group) at the end of the
    course.

</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
