#pragma checksum "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dff38ce5e5df604332d8e0acd0d75ec91533a3a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Requisicao_Resumo), @"mvc.1.0.view", @"/Views/Requisicao/Resumo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Requisicao/Resumo.cshtml", typeof(AspNetCore.Views_Requisicao_Resumo))]
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
#line 1 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\_ViewImports.cshtml"
using CMS;

#line default
#line hidden
#line 2 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\_ViewImports.cshtml"
using CMS.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dff38ce5e5df604332d8e0acd0d75ec91533a3a4", @"/Views/Requisicao/Resumo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0389c18537be78d994187c367b0e0aa311ab30d", @"/Views/_ViewImports.cshtml")]
    public class Views_Requisicao_Resumo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<business.ecommerce.Requisicao>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "buscaprodutos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(40, 121, true);
            WriteLiteral("<h3>Resumo do Pedido</h3>\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <div class=\"pull-right\">\r\n            ");
            EndContext();
            BeginContext(161, 108, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dff38ce5e5df604332d8e0acd0d75ec91533a3a44110", async() => {
                BeginContext(215, 50, true);
                WriteLiteral("\r\n                Voltar ao Catálogo\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
            BeginContext(269, 209, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<br />\r\n<div class=\"panel panel-default\">\r\n    <div class=\"panel-body\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <h3>Nº do Pedido: ");
            EndContext();
            BeginContext(480, 18, false);
#line 18 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml"
                              Write(Model.IdRequisicao);

#line default
#line hidden
            EndContext();
            BeginContext(499, 180, true);
            WriteLiteral("</h3>\r\n            </div>\r\n        </div>\r\n        <hr />\r\n        <div class=\"row\">\r\n            <div class=\"col-md-3\">\r\n                <h3>Seus Dados</h3>\r\n                <div>");
            EndContext();
            BeginContext(680, 19, false);
#line 25 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml"
                Write(Model.Cadastro.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(699, 29, true);
            WriteLiteral("</div>\r\n                <div>");
            EndContext();
            BeginContext(729, 23, false);
#line 26 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml"
                Write(Model.Cadastro.Telefone);

#line default
#line hidden
            EndContext();
            BeginContext(752, 80, true);
            WriteLiteral("</div>\r\n            </div>\r\n            <div class=\"col-md-3\">\r\n                ");
            EndContext();
            BeginContext(833, 20, false);
#line 29 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml"
           Write(Model.Cadastro.Email);

#line default
#line hidden
            EndContext();
            BeginContext(853, 125, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-md-6\">\r\n                <h3>Endereço de Entrega</h3>\r\n                <div>");
            EndContext();
            BeginContext(979, 23, false);
#line 33 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml"
                Write(Model.Cadastro.Endereco);

#line default
#line hidden
            EndContext();
            BeginContext(1002, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1004, 26, false);
#line 33 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml"
                                         Write(Model.Cadastro.Complemento);

#line default
#line hidden
            EndContext();
            BeginContext(1030, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(1034, 21, false);
#line 33 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml"
                                                                       Write(Model.Cadastro.Bairro);

#line default
#line hidden
            EndContext();
            BeginContext(1055, 8, true);
            WriteLiteral(" - CEP: ");
            EndContext();
            BeginContext(1064, 18, false);
#line 33 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml"
                                                                                                     Write(Model.Cadastro.CEP);

#line default
#line hidden
            EndContext();
            BeginContext(1082, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(1086, 24, false);
#line 33 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml"
                                                                                                                           Write(Model.Cadastro.Municipio);

#line default
#line hidden
            EndContext();
            BeginContext(1110, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(1114, 17, false);
#line 33 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml"
                                                                                                                                                       Write(Model.Cadastro.UF);

#line default
#line hidden
            EndContext();
            BeginContext(1131, 293, true);
            WriteLiteral(@" - Brasil</div>
            </div>
        </div>
        <hr />
        <div class=""row"">
            <div class=""col-md-10"">
                <h3>Item</h3>
            </div>
            <div class=""col-md-2"">
                <h3>Quantidade</h3>
            </div>
        </div>
");
            EndContext();
#line 45 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml"
         foreach (var item in Model.ItemRequisicao)
        {



#line default
#line hidden
            BeginContext(1492, 97, true);
            WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col-md-10\">\r\n                    <div>");
            EndContext();
            BeginContext(1590, 7, false);
#line 51 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml"
                    Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1597, 116, true);
            WriteLiteral("</div>\r\n                </div>\r\n                <div class=\"col-md-2\">\r\n                    <div class=\"pull-right\">");
            EndContext();
            BeginContext(1714, 15, false);
#line 54 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml"
                                       Write(item.Quantidade);

#line default
#line hidden
            EndContext();
            BeginContext(1729, 52, true);
            WriteLiteral("</div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 57 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Requisicao\Resumo.cshtml"
        }

#line default
#line hidden
            BeginContext(1792, 114, true);
            WriteLiteral("    </div>\r\n</div>\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <div class=\"pull-right\">\r\n            ");
            EndContext();
            BeginContext(1906, 108, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dff38ce5e5df604332d8e0acd0d75ec91533a3a412092", async() => {
                BeginContext(1960, 50, true);
                WriteLiteral("\r\n                Voltar ao Catálogo\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
            BeginContext(2014, 36, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<business.ecommerce.Requisicao> Html { get; private set; }
    }
}
#pragma warning restore 1591
