#pragma checksum "C:\Users\trinh\source\WTF\API\Request\RequestTemplate\Views\Requests\add-generic.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "decf12592ab54cbcab3a2557bacccb8c4f8f3c72"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Requests_add_generic), @"mvc.1.0.view", @"/Views/Requests/add-generic.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Requests/add-generic.cshtml", typeof(AspNetCore.Views_Requests_add_generic))]
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
#line 1 "C:\Users\trinh\source\WTF\API\Request\RequestTemplate\Views\_ViewImports.cshtml"
using RequestTemplate;

#line default
#line hidden
#line 2 "C:\Users\trinh\source\WTF\API\Request\RequestTemplate\Views\_ViewImports.cshtml"
using RequestTemplate.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"decf12592ab54cbcab3a2557bacccb8c4f8f3c72", @"/Views/Requests/add-generic.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fda2e95e24e3ea526a4b43c49a0fd099761cada", @"/Views/_ViewImports.cshtml")]
    public class Views_Requests_add_generic : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 308, true);
            WriteLiteral(@"<div class=""generic-contents"">
    <input type=""text"" class=""form-control"" placeholder=""Tên đầu việc"">
    <input type=""text"" class=""form-control"" placeholder=""Mô tả nội dung công việc"">
    <span>Thời gian thực hiện công việc: </span> <input type=""number"" class=""form-control""> <span>(giờ)</span>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
