#pragma checksum "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Competition\Info.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abfdcbbfdac1bf534852d321d43fc8e72c8c4c50"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Competition_Info), @"mvc.1.0.view", @"/Views/Competition/Info.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abfdcbbfdac1bf534852d321d43fc8e72c8c4c50", @"/Views/Competition/Info.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b509cf98237c0499af91096a8eca47adff1b0f2", @"/Views/_ViewImports.cshtml")]
    public class Views_Competition_Info : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Stage>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("AddStage"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Competition\Info.cshtml"
  
    ViewBag.Title = "Соревнование";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h3 class=\"display-3\">");
#nullable restore
#line 7 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Competition\Info.cshtml"
                     Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    <h4 class=\"display-3\">");
#nullable restore
#line 8 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Competition\Info.cshtml"
                     Write(ViewBag.Competition.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n</div>\r\n\r\n\r\n<h5>Формат: ");
#nullable restore
#line 12 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Competition\Info.cshtml"
       Write(ViewBag.Competition.Format);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n<h5>Призовой фонд: ");
#nullable restore
#line 13 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Competition\Info.cshtml"
              Write(ViewBag.Competition.PrizePool);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n<h5>Количество этапов: ");
#nullable restore
#line 14 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Competition\Info.cshtml"
                  Write(ViewBag.Competition.StagesNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n<h5>Начало: ");
#nullable restore
#line 15 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Competition\Info.cshtml"
       Write(ViewBag.Competition.BeginTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n<h5>Окончание: ");
#nullable restore
#line 16 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Competition\Info.cshtml"
          Write(ViewBag.Competition.EndTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n<h5>Требования к участнику: ");
#nullable restore
#line 17 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Competition\Info.cshtml"
                       Write(ViewBag.Competition.Requirements);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n\r\n<h4>Объявленные этапы: </h4>\r\n");
#nullable restore
#line 21 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Competition\Info.cshtml"
 foreach (Stage stage in ViewBag.Stages)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Этап в ");
#nullable restore
#line 23 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Competition\Info.cshtml"
         Write(stage.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 24 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Competition\Info.cshtml"
}

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "abfdcbbfdac1bf534852d321d43fc8e72c8c4c507316", async() => {
                WriteLiteral("\r\n    <input type=\"hidden\" name=\"competitionID\"");
                BeginWriteAttribute("value", " value=\"", 741, "\"", 771, 1);
#nullable restore
#line 25 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Competition\Info.cshtml"
WriteAttributeValue("", 749, ViewBag.CompetitionID, 749, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <input type=\"submit\" value=\"Добавить этап\">\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
