#pragma checksum "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f310faee7b405fc42a96e93a25e16a74e68d87cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Employees_Detail), @"mvc.1.0.view", @"/Areas/Admin/Views/Employees/Detail.cshtml")]
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
#line 1 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\_ViewImports.cshtml"
using LeaveManagement.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\_ViewImports.cshtml"
using LeaveManagement.WebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
using LeaveManagement.WebApp.Models.ViewModels.LeaveAllocations;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f310faee7b405fc42a96e93a25e16a74e68d87cb", @"/Areas/Admin/Views/Employees/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5ec7645ecaa1045e81bb57e97fc2baa82a6cf93", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Employees_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewAllocationsVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateAllocation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning ml-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary mb-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-header bg-dark text-white\">\r\n        <h4>Details - ");
#nullable restore
#line 6 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
                 Write(Model.Employee.Firstname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 6 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
                                           Write(Model.Employee.Lastname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    </div>\r\n    <div class=\"card-body\">\r\n        <div>\r\n            <dl class=\"row\">\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 12 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
               Write(Html.DisplayNameFor(model => model.Employee.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 15 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
               Write(Html.DisplayFor(model => model.Employee.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 18 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
               Write(Html.DisplayNameFor(model => model.Employee.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 21 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
               Write(Html.DisplayFor(model => model.Employee.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 24 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
               Write(Html.DisplayNameFor(model => model.Employee.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 27 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
               Write(Html.DisplayFor(model => model.Employee.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 30 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
               Write(Html.DisplayNameFor(model => model.Employee.Firstname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 33 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
               Write(Html.DisplayFor(model => model.Employee.Firstname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 36 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
               Write(Html.DisplayNameFor(model => model.Employee.Lastname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 39 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
               Write(Html.DisplayFor(model => model.Employee.Lastname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 43 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
               Write(Html.DisplayNameFor(model => model.Employee.DateOfBirth));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 46 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
               Write(Html.DisplayFor(model => model.Employee.DateOfBirth));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </dd>
            </dl>
        </div>
    </div>
</div>

<div class=""card"">
    <div class=""card-header bg-dark text-white"">
        <h4>Leave Allocations</h4>
    </div>
    <div class=""card-body"">
        <ul class=""list-group list-group-flush"">
");
#nullable restore
#line 59 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
             if(Model.LeaveAllocations.Count() < 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"list-group-item\"><p>Employee don\'t have any leave allocations</p></li>\r\n");
#nullable restore
#line 62 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
             foreach (var item in Model.LeaveAllocations)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"list-group-item\">\r\n                    <h6>\r\n                        <b>");
#nullable restore
#line 67 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
                      Write(item.LeaveType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        <span class=\"badge badge-secondary\">number of days - ");
#nullable restore
#line 68 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
                                                                        Write(item.NumberOfDays);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f310faee7b405fc42a96e93a25e16a74e68d87cb12278", async() => {
                WriteLiteral("<i class=\"fas fa-edit\"></i> Edit");
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
#nullable restore
#line 69 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
                                                           WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </h6>\r\n                </li>\r\n");
#nullable restore
#line 72 "C:\Users\hovan\source\repos\LeaveManagement\LeaveManagement.WebApp\Areas\Admin\Views\Employees\Detail.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f310faee7b405fc42a96e93a25e16a74e68d87cb14936", async() => {
                WriteLiteral("<i class=\"fa fa-arrow-left\"></i> Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ViewAllocationsVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
