#pragma checksum "C:\Users\r.wilson\OneDrive - Robin Digital\Documents\FEA\West London College\Net Core\v3.1\VisitorDetails\VisitorDetails\Pages\Visitors\Leave.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "553ebc8a7df15cfb07531c1de8fbd71b56e74b0d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(VisitorDetails.Pages.Visitors.Pages_Visitors_Leave), @"mvc.1.0.razor-page", @"/Pages/Visitors/Leave.cshtml")]
namespace VisitorDetails.Pages.Visitors
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
#line 1 "C:\Users\r.wilson\OneDrive - Robin Digital\Documents\FEA\West London College\Net Core\v3.1\VisitorDetails\VisitorDetails\Pages\_ViewImports.cshtml"
using VisitorDetails;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{site?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"553ebc8a7df15cfb07531c1de8fbd71b56e74b0d", @"/Pages/Visitors/Leave.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1cfe15af4205dedd75a5b6c3a723726639aa3fea", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Visitors_Leave : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\r.wilson\OneDrive - Robin Digital\Documents\FEA\West London College\Net Core\v3.1\VisitorDetails\VisitorDetails\Pages\Visitors\Leave.cshtml"
  
    ViewData["Title"] = "Leaving Site";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container Spacer\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md\">\r\n");
#nullable restore
#line 11 "C:\Users\r.wilson\OneDrive - Robin Digital\Documents\FEA\West London College\Net Core\v3.1\VisitorDetails\VisitorDetails\Pages\Visitors\Leave.cshtml"
             if (Model.UserIDNotNull == false)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""container Spacer"">
                    <div class=""row"">
                        <div class=""col-md"">
                            <div class=""alert alert-danger text-center"" role=""alert"">
                                <h4 class=""alert-heading""><i class=""fas fa-exclamation-circle""></i> No Record Found</h4>
                                <p>
                                    Sorry it was not possible to check you out as you do not appear to have checked in
                                </p>
                                <p>
                                    Alternatively you may have already checked out
                                </p>
                                <p class=""text-right text-muted"">
                                    Error: NCF
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <script>
                    scanError");
            WriteLiteral("();\r\n                </script>\r\n");
#nullable restore
#line 34 "C:\Users\r.wilson\OneDrive - Robin Digital\Documents\FEA\West London College\Net Core\v3.1\VisitorDetails\VisitorDetails\Pages\Visitors\Leave.cshtml"
            }
            else if (Model.UserIDValid == false)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""container Spacer"">
                    <div class=""row"">
                        <div class=""col-md"">
                            <div class=""alert alert-danger text-center"" role=""alert"">
                                <h4 class=""alert-heading""><i class=""fas fa-exclamation-circle""></i> No Record Found</h4>
                                <p>
                                    Sorry it was not possible to check you out as you do not appear to have checked in
                                </p>
                                <p>
                                    Alternatively you may have already checked out
                                </p>
                                <p class=""text-right text-muted"">
                                    Error: UNV
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <script>
                    scanError");
            WriteLiteral("();\r\n                </script>\r\n");
#nullable restore
#line 58 "C:\Users\r.wilson\OneDrive - Robin Digital\Documents\FEA\West London College\Net Core\v3.1\VisitorDetails\VisitorDetails\Pages\Visitors\Leave.cshtml"
            }
            else if (Model.Visitor.SiteCode == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""container Spacer"">
                    <div class=""row"">
                        <div class=""col-md"">
                            <div class=""alert alert-danger text-center"" role=""alert"">
                                <h4 class=""alert-heading""><i class=""fas fa-exclamation-circle""></i> Could Not Determine Site</h4>
                                <p>
                                    Sorry it was not possible to determine which site you are visiting
                                </p>
                                <p>
                                    Please re-scan the QR code in the exit to check out.
                                </p>
                                <p class=""text-right text-muted"">
                                    Error: NSP
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <script>
                    scanError(");
            WriteLiteral(");\r\n                </script>\r\n");
#nullable restore
#line 82 "C:\Users\r.wilson\OneDrive - Robin Digital\Documents\FEA\West London College\Net Core\v3.1\VisitorDetails\VisitorDetails\Pages\Visitors\Leave.cshtml"
            }
            else if (Model.SiteIsValid == false)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""container Spacer"">
                    <div class=""row"">
                        <div class=""col-md"">
                            <div class=""alert alert-danger text-center"" role=""alert"">
                                <h4 class=""alert-heading""><i class=""fas fa-exclamation-circle""></i> Could Not Determine Site</h4>
                                <p>
                                    Sorry it was not possible to determine which site you are visiting
                                </p>
                                <p>
                                    Please re-scan the QR code in the exit to check out.
                                </p>
                                <p class=""text-right text-muted"">
                                    Error: SNV
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <script>
                    scanError(");
            WriteLiteral(");\r\n                </script>\r\n");
#nullable restore
#line 106 "C:\Users\r.wilson\OneDrive - Robin Digital\Documents\FEA\West London College\Net Core\v3.1\VisitorDetails\VisitorDetails\Pages\Visitors\Leave.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""container Spacer"">
                    <div class=""row"">
                        <div class=""col-md"">
                            <div class=""alert alert-success text-center"" role=""alert"">
                                <h4 class=""alert-heading""><i class=""fas fa-info-circle""></i> Thanks, you have checked out</h4>
                                <p>
                                    You may now close this window.
                                </p>
                                <a class=""btn btn-success"" href=""https://www.wlc.ac.uk""><i class=""fas fa-external-link-alt""></i> Go to the WLC Website</a>
                            </div>
                        </div>
                    </div>
                </div>
                <script>
                    scanOK();
                </script>
");
#nullable restore
#line 125 "C:\Users\r.wilson\OneDrive - Robin Digital\Documents\FEA\West London College\Net Core\v3.1\VisitorDetails\VisitorDetails\Pages\Visitors\Leave.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 132 "C:\Users\r.wilson\OneDrive - Robin Digital\Documents\FEA\West London College\Net Core\v3.1\VisitorDetails\VisitorDetails\Pages\Visitors\Leave.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VisitorDetails.Pages.Visitors.LeaveModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<VisitorDetails.Pages.Visitors.LeaveModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<VisitorDetails.Pages.Visitors.LeaveModel>)PageContext?.ViewData;
        public VisitorDetails.Pages.Visitors.LeaveModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591