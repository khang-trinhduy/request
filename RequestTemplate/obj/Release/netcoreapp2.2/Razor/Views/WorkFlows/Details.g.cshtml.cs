#pragma checksum "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8acc17c9498bbef9a500878c3ada81542d5d676b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WorkFlows_Details), @"mvc.1.0.view", @"/Views/WorkFlows/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/WorkFlows/Details.cshtml", typeof(AspNetCore.Views_WorkFlows_Details))]
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
#line 1 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\_ViewImports.cshtml"
using RequestTemplate;

#line default
#line hidden
#line 2 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\_ViewImports.cshtml"
using RequestTemplate.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8acc17c9498bbef9a500878c3ada81542d5d676b", @"/Views/WorkFlows/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fda2e95e24e3ea526a4b43c49a0fd099761cada", @"/Views/_ViewImports.cshtml")]
    public class Views_WorkFlows_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RequestTemplate.Models.WorkFlow>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(85, 131, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>WorkFlow</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(217, 43, false);
#line 14 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Request));

#line default
#line hidden
            EndContext();
            BeginContext(260, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(324, 42, false);
#line 17 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Request.Id));

#line default
#line hidden
            EndContext();
            BeginContext(366, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(429, 41, false);
#line 20 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Start));

#line default
#line hidden
            EndContext();
            BeginContext(470, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(534, 37, false);
#line 23 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Start));

#line default
#line hidden
            EndContext();
            BeginContext(571, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(634, 39, false);
#line 26 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.End));

#line default
#line hidden
            EndContext();
            BeginContext(673, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(737, 35, false);
#line 29 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.End));

#line default
#line hidden
            EndContext();
            BeginContext(772, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(835, 48, false);
#line 32 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CurrentStage));

#line default
#line hidden
            EndContext();
            BeginContext(883, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(947, 44, false);
#line 35 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.CurrentStage));

#line default
#line hidden
            EndContext();
            BeginContext(991, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1054, 42, false);
#line 38 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Stage1));

#line default
#line hidden
            EndContext();
            BeginContext(1096, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1160, 38, false);
#line 41 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Stage1));

#line default
#line hidden
            EndContext();
            BeginContext(1198, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1261, 41, false);
#line 44 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name1));

#line default
#line hidden
            EndContext();
            BeginContext(1302, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1366, 37, false);
#line 47 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name1));

#line default
#line hidden
            EndContext();
            BeginContext(1403, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1466, 41, false);
#line 50 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Task1));

#line default
#line hidden
            EndContext();
            BeginContext(1507, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1571, 37, false);
#line 53 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Task1));

#line default
#line hidden
            EndContext();
            BeginContext(1608, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1671, 45, false);
#line 56 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Assignee1));

#line default
#line hidden
            EndContext();
            BeginContext(1716, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1780, 41, false);
#line 59 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Assignee1));

#line default
#line hidden
            EndContext();
            BeginContext(1821, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1884, 42, false);
#line 62 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Owner1));

#line default
#line hidden
            EndContext();
            BeginContext(1926, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1990, 38, false);
#line 65 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Owner1));

#line default
#line hidden
            EndContext();
            BeginContext(2028, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2091, 41, false);
#line 68 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.File1));

#line default
#line hidden
            EndContext();
            BeginContext(2132, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2196, 37, false);
#line 71 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.File1));

#line default
#line hidden
            EndContext();
            BeginContext(2233, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2296, 42, false);
#line 74 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Stage2));

#line default
#line hidden
            EndContext();
            BeginContext(2338, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2402, 38, false);
#line 77 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Stage2));

#line default
#line hidden
            EndContext();
            BeginContext(2440, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2503, 41, false);
#line 80 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name2));

#line default
#line hidden
            EndContext();
            BeginContext(2544, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2608, 37, false);
#line 83 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name2));

#line default
#line hidden
            EndContext();
            BeginContext(2645, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2708, 41, false);
#line 86 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Task2));

#line default
#line hidden
            EndContext();
            BeginContext(2749, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2813, 37, false);
#line 89 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Task2));

#line default
#line hidden
            EndContext();
            BeginContext(2850, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2913, 45, false);
#line 92 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Assignee2));

#line default
#line hidden
            EndContext();
            BeginContext(2958, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3022, 41, false);
#line 95 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Assignee2));

#line default
#line hidden
            EndContext();
            BeginContext(3063, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3126, 42, false);
#line 98 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Owner2));

#line default
#line hidden
            EndContext();
            BeginContext(3168, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3232, 38, false);
#line 101 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Owner2));

#line default
#line hidden
            EndContext();
            BeginContext(3270, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3333, 41, false);
#line 104 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.File2));

#line default
#line hidden
            EndContext();
            BeginContext(3374, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3438, 37, false);
#line 107 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.File2));

#line default
#line hidden
            EndContext();
            BeginContext(3475, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3538, 42, false);
#line 110 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Stage3));

#line default
#line hidden
            EndContext();
            BeginContext(3580, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3644, 38, false);
#line 113 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Stage3));

#line default
#line hidden
            EndContext();
            BeginContext(3682, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3745, 41, false);
#line 116 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name3));

#line default
#line hidden
            EndContext();
            BeginContext(3786, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3850, 37, false);
#line 119 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name3));

#line default
#line hidden
            EndContext();
            BeginContext(3887, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3950, 41, false);
#line 122 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Task3));

#line default
#line hidden
            EndContext();
            BeginContext(3991, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(4055, 37, false);
#line 125 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Task3));

#line default
#line hidden
            EndContext();
            BeginContext(4092, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(4155, 45, false);
#line 128 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Assignee3));

#line default
#line hidden
            EndContext();
            BeginContext(4200, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(4264, 41, false);
#line 131 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Assignee3));

#line default
#line hidden
            EndContext();
            BeginContext(4305, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(4368, 42, false);
#line 134 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Owner3));

#line default
#line hidden
            EndContext();
            BeginContext(4410, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(4474, 38, false);
#line 137 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Owner3));

#line default
#line hidden
            EndContext();
            BeginContext(4512, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(4575, 41, false);
#line 140 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.File3));

#line default
#line hidden
            EndContext();
            BeginContext(4616, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(4680, 37, false);
#line 143 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.File3));

#line default
#line hidden
            EndContext();
            BeginContext(4717, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(4780, 42, false);
#line 146 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Stage4));

#line default
#line hidden
            EndContext();
            BeginContext(4822, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(4886, 38, false);
#line 149 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Stage4));

#line default
#line hidden
            EndContext();
            BeginContext(4924, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(4987, 41, false);
#line 152 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name4));

#line default
#line hidden
            EndContext();
            BeginContext(5028, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(5092, 37, false);
#line 155 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name4));

#line default
#line hidden
            EndContext();
            BeginContext(5129, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(5192, 41, false);
#line 158 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Task4));

#line default
#line hidden
            EndContext();
            BeginContext(5233, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(5297, 37, false);
#line 161 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Task4));

#line default
#line hidden
            EndContext();
            BeginContext(5334, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(5397, 45, false);
#line 164 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Assignee4));

#line default
#line hidden
            EndContext();
            BeginContext(5442, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(5506, 41, false);
#line 167 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Assignee4));

#line default
#line hidden
            EndContext();
            BeginContext(5547, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(5610, 42, false);
#line 170 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Owner4));

#line default
#line hidden
            EndContext();
            BeginContext(5652, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(5716, 38, false);
#line 173 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Owner4));

#line default
#line hidden
            EndContext();
            BeginContext(5754, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(5817, 41, false);
#line 176 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.File4));

#line default
#line hidden
            EndContext();
            BeginContext(5858, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(5922, 37, false);
#line 179 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.File4));

#line default
#line hidden
            EndContext();
            BeginContext(5959, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(6022, 42, false);
#line 182 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Stage5));

#line default
#line hidden
            EndContext();
            BeginContext(6064, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(6128, 38, false);
#line 185 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Stage5));

#line default
#line hidden
            EndContext();
            BeginContext(6166, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(6229, 41, false);
#line 188 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name5));

#line default
#line hidden
            EndContext();
            BeginContext(6270, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(6334, 37, false);
#line 191 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name5));

#line default
#line hidden
            EndContext();
            BeginContext(6371, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(6434, 41, false);
#line 194 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Task5));

#line default
#line hidden
            EndContext();
            BeginContext(6475, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(6539, 37, false);
#line 197 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Task5));

#line default
#line hidden
            EndContext();
            BeginContext(6576, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(6639, 45, false);
#line 200 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Assignee5));

#line default
#line hidden
            EndContext();
            BeginContext(6684, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(6748, 41, false);
#line 203 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Assignee5));

#line default
#line hidden
            EndContext();
            BeginContext(6789, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(6852, 42, false);
#line 206 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Owner5));

#line default
#line hidden
            EndContext();
            BeginContext(6894, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(6958, 38, false);
#line 209 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.Owner5));

#line default
#line hidden
            EndContext();
            BeginContext(6996, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(7059, 41, false);
#line 212 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.File5));

#line default
#line hidden
            EndContext();
            BeginContext(7100, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(7164, 37, false);
#line 215 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
       Write(Html.DisplayFor(model => model.File5));

#line default
#line hidden
            EndContext();
            BeginContext(7201, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(7248, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8acc17c9498bbef9a500878c3ada81542d5d676b33789", async() => {
                BeginContext(7294, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 220 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\WorkFlows\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7302, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(7310, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8acc17c9498bbef9a500878c3ada81542d5d676b36123", async() => {
                BeginContext(7332, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7348, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RequestTemplate.Models.WorkFlow> Html { get; private set; }
    }
}
#pragma warning restore 1591
