#pragma checksum "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\Requests\email-template.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92cff4619f0f83a049a183c8c0cc7e93a14f1f62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Requests_email_template), @"mvc.1.0.view", @"/Views/Requests/email-template.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Requests/email-template.cshtml", typeof(AspNetCore.Views_Requests_email_template))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92cff4619f0f83a049a183c8c0cc7e93a14f1f62", @"/Views/Requests/email-template.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fda2e95e24e3ea526a4b43c49a0fd099761cada", @"/Views/_ViewImports.cshtml")]
    public class Views_Requests_email_template : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1846, true);
            WriteLiteral(@"<div class=""email-container"">


    <div class=""email-header"">
        <label class=""control-label"" id=""to"">To: </label>  <input class=""form-control"" id=""to"" type=""text"" placeholder="""" />
        <a class=""cbb"">Cbb/Bb</a>
        <div id=""additional""><label class=""control-label"" class=""to"">Cbb: </label>  <input class=""form-control"" id=""Cbb"" type=""text"" placeholder="""" /></div>
        <label class=""control-label"" class=""to"">Bb: </label>  <input class=""form-control"" id=""Bb"" type=""text"" placeholder="""" />
        <label class=""control-label"" id=""subject"">Subject: </label><input class=""form-control"" id=""subject"" type=""text"" placeholder="""" />
    </div>

    <div class=""email-body"">
        <label class=""control-label"" id=""email-content""></label><textarea class=""form-control"" rows=""5"" id=""contents""></textarea>
    </div>

    <div class=""email-attachment"">
        <label>Attachment</label>
    </div>
    <!-- <input class=""btn btn-default"" type=""button"" value=""Gửi""/></i> -->
    <div class=""email");
            WriteLiteral(@"-action"">
        <i class=""fas fa-paperclip "" title=""Đính kèm""></i>
        <i class=""far fa-image "" title=""Ảnh""></i>
        <i class=""far fa-laugh "" title=""Emoji""></i>
        <i class=""fas fa-link "" title=""Link""></i>
        <div class=""send""><i class=""fab fa-telegram-plane "" title=""Gửi""></i></div>
    </div>
</div>

<style>
    .email-container{
        box-shadow: 2px 2px 2px 10px rgba(#333, 0.2);
        display: grid;
        background: white;
    }
    .fas, .fab, .far{
        <!-- color: #3dacef; -->
        <!-- border-bottom: 1px solid black; -->
        margin-right: 10px;

    }
    .fab{
        margin-right: 5px;
    }
    .send{
        text-align: right;
        width: 50%;
        float:right;
        color:#3dacef;
    }
</style>

<script>
    
</script>
");
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
