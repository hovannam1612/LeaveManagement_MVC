#pragma checksum "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Views\Shared\_StatusMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "670cd3a73855a6af3b4bcde7bf7f989f949b02b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__StatusMessage), @"mvc.1.0.view", @"/Views/Shared/_StatusMessage.cshtml")]
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
#nullable restore
#line 1 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Views\_ViewImports.cshtml"
using LeaveManagement.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Views\_ViewImports.cshtml"
using LeaveManagement.WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"670cd3a73855a6af3b4bcde7bf7f989f949b02b1", @"/Views/Shared/_StatusMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5ec7645ecaa1045e81bb57e97fc2baa82a6cf93", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__StatusMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Views\Shared\_StatusMessage.cshtml"
  
    var message = TempData["StatusMessage"] as string;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Views\Shared\_StatusMessage.cshtml"
 if (!String.IsNullOrEmpty(message))
{
    var statusMessageClass = message.Contains("Error") ? "danger" : "success";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div");
            BeginWriteAttribute("class", " class=\"", 188, "\"", 245, 4);
            WriteAttributeValue("", 196, "alert", 196, 5, true);
            WriteAttributeValue(" ", 201, "alert-", 202, 7, true);
#nullable restore
#line 7 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Views\Shared\_StatusMessage.cshtml"
WriteAttributeValue("", 208, statusMessageClass, 208, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 227, "alert-dismissible", 228, 18, true);
            EndWriteAttribute();
            WriteLiteral(" role=\"alert\">\r\n    ");
#nullable restore
#line 8 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Views\Shared\_StatusMessage.cshtml"
Write(message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>\r\n</div>\r\n");
#nullable restore
#line 11 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Views\Shared\_StatusMessage.cshtml"
}

#line default
#line hidden
#nullable disable
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
