#pragma checksum "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e8b20177bd0fe4abe979a2862fcb4cc6160e2a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Stage_Info), @"mvc.1.0.view", @"/Views/Stage/Info.cshtml")]
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
#line 1 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\_ViewImports.cshtml"
using DriftCompetitionWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\_ViewImports.cshtml"
using DriftCompetitionWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e8b20177bd0fe4abe979a2862fcb4cc6160e2a8", @"/Views/Stage/Info.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b509cf98237c0499af91096a8eca47adff1b0f2", @"/Views/_ViewImports.cshtml")]
    public class Views_Stage_Info : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Stage>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
  
    ViewBag.Title = "Этап";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h3 class=\"display-3\">");
#nullable restore
#line 7 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                     Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n</div>\r\n\r\n\r\n<h5>Соревнование: ");
#nullable restore
#line 11 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
             Write(ViewBag.Stage.Competition.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n<h5>Место проведения: ");
#nullable restore
#line 12 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                 Write(ViewBag.Stage.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n<h5>Старт регистрации: ");
#nullable restore
#line 13 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                  Write(ViewBag.Stage.RegistrationStartTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n<h5>Окончание регистрации: ");
#nullable restore
#line 14 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                      Write(ViewBag.Stage.RegistrationEndTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Stage>> Html { get; private set; }
    }
}
#pragma warning restore 1591