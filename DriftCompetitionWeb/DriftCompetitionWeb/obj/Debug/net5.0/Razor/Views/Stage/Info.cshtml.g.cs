#pragma checksum "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f17e87a19d979aafb2bb50b7b31d66ca9911902d"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f17e87a19d979aafb2bb50b7b31d66ca9911902d", @"/Views/Stage/Info.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b509cf98237c0499af91096a8eca47adff1b0f2", @"/Views/_ViewImports.cshtml")]
    public class Views_Stage_Info : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Stage>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Stage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveParticipantFromStage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("SelectCarNumber"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("EventStage"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
  
    ViewBag.Title = "Этап";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f17e87a19d979aafb2bb50b7b31d66ca9911902d5527", async() => {
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <title>Поля</title>
    <style type=""text/css"">
        .stage {
            width: 500px; /* Ширина контента */
            height: 400px;
            float: left;
            margin: 7px;
            border: 2px solid silver; /* Параметры границы */
            padding: 10px;
            border-radius: 15px;
            overflow-y: auto;
            background: #9CEE90;
        }
        .participants {
            width: 500px; /* Ширина контента */
            height: 400px;
            float: right;
            margin: 7px;
            border: 2px solid silver; /* Параметры границы */
            padding: 10px;
            border-radius: 15px;
            overflow-y: auto;
            background: #E0FFFF;
        }
        .results {
            width: 500px; /* Ширина контента */
            height: 400px;
            margin-left: auto;
            margin-right: auto;
            border: 2px sol");
                WriteLiteral(@"id silver; /* Параметры границы */
            padding: 10px;
            border-radius: 15px;
            overflow-y: auto;
            background: #FFEFD5;
        }
        .container {
            overflow: hidden;
            width: 100%;
        }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f17e87a19d979aafb2bb50b7b31d66ca9911902d7838", async() => {
                WriteLiteral("\r\n\r\n    <div class=\"text-center\">\r\n        <h3 class=\"display-3\">");
#nullable restore
#line 53 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                         Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n    </div>\r\n\r\n    <div class=\"container\">\r\n        <div class=stage>\r\n            <h5>Соревнование: </h5>\r\n            <h6>");
#nullable restore
#line 59 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
           Write(ViewBag.Stage.Competition.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n            <h5>Место проведения: </h5>\r\n            <h6>");
#nullable restore
#line 61 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
           Write(ViewBag.Stage.Address);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n            <h5>Организатор: </h5>\r\n            <h6>");
#nullable restore
#line 63 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
           Write(ViewBag.Organizer.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n            <h5>Старт регистрации: </h5>\r\n            <h6>");
#nullable restore
#line 65 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
           Write(ViewBag.Stage.RegistrationStartTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n            <h5>Окончание регистрации: </h5>\r\n            <h6>");
#nullable restore
#line 67 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
           Write(ViewBag.Stage.RegistrationEndTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n            <h5>Цена просмотра: </h5>\r\n            <h6>");
#nullable restore
#line 69 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
           Write(ViewBag.Stage.ViewPrice);

#line default
#line hidden
#nullable disable
                WriteLiteral("$</h6>\r\n            <h5>Цена участия: </h5>\r\n            <h6>");
#nullable restore
#line 71 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
           Write(ViewBag.Stage.ParticipationPrice);

#line default
#line hidden
#nullable disable
                WriteLiteral("$</h6>\r\n        </div>\r\n        <div class=\"participants\">\r\n            <h5>Участники: </h5>\r\n");
#nullable restore
#line 75 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
             for (int iParticipant = 1; iParticipant <= ViewBag.Participants.Count; ++iParticipant)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <h6>");
#nullable restore
#line 77 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
               Write(iParticipant);

#line default
#line hidden
#nullable disable
                WriteLiteral(".  ");
#nullable restore
#line 77 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                               Write(ViewBag.Participants[iParticipant - 1].UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral(", номер: ");
#nullable restore
#line 77 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                                                                                        Write(ViewBag.CarNumbers[iParticipant - 1]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n");
#nullable restore
#line 78 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                 if (ViewBag.CurrentUser == ViewBag.Organizer && !ViewBag.Stage.IsOver)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f17e87a19d979aafb2bb50b7b31d66ca9911902d12488", async() => {
                    WriteLiteral("Удалить пользователя из соревнования");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-UserId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 80 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                                                                                            WriteLiteral(ViewBag.Participants[iParticipant - 1].Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["UserId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-UserId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["UserId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute(",", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 80 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                                                                                                                                                            WriteLiteral(ViewBag.Stage.StageID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["StageID"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-StageID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["StageID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 81 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 81 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                 
}

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n    </div>\r\n\r\n");
#nullable restore
#line 86 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
     if (User.Identity.Name != null && !ViewBag.Stage.IsOver)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"text-center\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f17e87a19d979aafb2bb50b7b31d66ca9911902d17077", async() => {
                    WriteLiteral("\r\n                <input type=\"hidden\" name=\"stageID\"");
                    BeginWriteAttribute("value", " value=\"", 3135, "\"", 3165, 1);
#nullable restore
#line 90 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
WriteAttributeValue("", 3143, ViewBag.Stage.StageID, 3143, 22, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                <input type=\"submit\" value=\"Зарегистрироваться\">\r\n            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 94 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 96 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
     if (ViewBag.CurrentUser == ViewBag.Organizer && !ViewBag.Stage.IsOver)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"text-center\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f17e87a19d979aafb2bb50b7b31d66ca9911902d19809", async() => {
                    WriteLiteral("\r\n                <input type=\"hidden\" name=\"StageID\"");
                    BeginWriteAttribute("value", " value=\"", 3505, "\"", 3535, 1);
#nullable restore
#line 100 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
WriteAttributeValue("", 3513, ViewBag.Stage.StageID, 3513, 22, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                <input type=\"submit\" value=\"Провести этап\">\r\n            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 104 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 106 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
     if (ViewBag.Stage.IsOver)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"results\">\r\n            <h5>Результаты: </h5>\r\n");
#nullable restore
#line 110 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
             for (int iRound = ViewBag.RoundPairsNames.Count; iRound > 0; --iRound)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <h5>Раунд ");
#nullable restore
#line 112 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                     Write(iRound);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n");
#nullable restore
#line 113 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                foreach (Tuple<string, string> usersPair in ViewBag.RoundPairsNames[iRound - 1])
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <h6>");
#nullable restore
#line 115 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                       Write(usersPair.Item1);

#line default
#line hidden
#nullable disable
                WriteLiteral(" (победа) - ");
#nullable restore
#line 115 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                                                   Write(usersPair.Item2);

#line default
#line hidden
#nullable disable
                WriteLiteral(" (поражение)</h6>\r\n");
#nullable restore
#line 116 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n");
#nullable restore
#line 119 "D:\Labs\RPBD\DriftCompetition\DriftCompetitionWeb\DriftCompetitionWeb\Views\Stage\Info.cshtml"
     }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
