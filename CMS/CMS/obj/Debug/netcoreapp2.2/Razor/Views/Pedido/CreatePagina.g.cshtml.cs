#pragma checksum "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "473fcb1a4ee6c1d09edc891a0d0c634f4bd2478a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pedido_CreatePagina), @"mvc.1.0.view", @"/Views/Pedido/CreatePagina.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Pedido/CreatePagina.cshtml", typeof(AspNetCore.Views_Pedido_CreatePagina))]
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
#line 1 "D:\cms-clean\CMS\CMS\Views\_ViewImports.cshtml"
using CMS;

#line default
#line hidden
#line 2 "D:\cms-clean\CMS\CMS\Views\_ViewImports.cshtml"
using CMS.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"473fcb1a4ee6c1d09edc891a0d0c634f4bd2478a", @"/Views/Pedido/CreatePagina.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0389c18537be78d994187c367b0e0aa311ab30d", @"/Views/_ViewImports.cshtml")]
    public class Views_Pedido_CreatePagina : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<business.business.Pagina>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
  
    ViewBag.Title = "Create";

#line default
#line hidden
            BeginContext(73, 22, true);
            WriteLiteral("\r\n<h2>Criar</h2>\r\n\r\n\r\n");
            EndContext();
#line 10 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(130, 23, false);
#line 12 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(157, 68, true);
            WriteLiteral("<div class=\"form-horizontal\">\r\n    <h4>Pagina</h4>\r\n    <hr />\r\n    ");
            EndContext();
            BeginContext(226, 64, false);
#line 17 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(290, 46, true);
            WriteLiteral("\r\n\r\n\r\n\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(337, 95, false);
#line 22 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
   Write(Html.LabelFor(model => model.Titulo, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(432, 47, true);
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
            EndContext();
            BeginContext(480, 95, false);
#line 24 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
       Write(Html.EditorFor(model => model.Titulo, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(575, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(590, 84, false);
#line 25 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
       Write(Html.ValidationMessageFor(model => model.Titulo, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(674, 70, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(745, 97, false);
#line 30 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
   Write(Html.LabelFor(model => model.Facebook, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(842, 47, true);
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
            EndContext();
            BeginContext(890, 97, false);
#line 32 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
       Write(Html.EditorFor(model => model.Facebook, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(987, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1002, 86, false);
#line 33 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
       Write(Html.ValidationMessageFor(model => model.Facebook, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1088, 70, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(1159, 95, false);
#line 38 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
   Write(Html.LabelFor(model => model.Twiter, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1254, 47, true);
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
            EndContext();
            BeginContext(1302, 95, false);
#line 40 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
       Write(Html.EditorFor(model => model.Twiter, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1397, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1412, 84, false);
#line 41 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
       Write(Html.ValidationMessageFor(model => model.Twiter, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1496, 70, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(1567, 98, false);
#line 46 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
   Write(Html.LabelFor(model => model.Instagram, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1665, 47, true);
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
            EndContext();
            BeginContext(1713, 98, false);
#line 48 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
       Write(Html.EditorFor(model => model.Instagram, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1811, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1826, 87, false);
#line 49 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
       Write(Html.ValidationMessageFor(model => model.Instagram, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1913, 70, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(1984, 97, false);
#line 54 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
   Write(Html.LabelFor(model => model.PedidoId, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(2081, 47, true);
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
            EndContext();
            BeginContext(2129, 84, false);
#line 56 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
       Write(Html.DropDownList("PedidoId", null, htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(2213, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(2228, 86, false);
#line 57 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
       Write(Html.ValidationMessageFor(model => model.PedidoId, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(2314, 222, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-offset-2 col-md-10\">\r\n            <input type=\"submit\" value=\"Criar\" class=\"btn btn-default\" />\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
#line 67 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
}

#line default
#line hidden
            BeginContext(2539, 13, true);
            WriteLiteral("\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2553, 47, false);
#line 70 "D:\cms-clean\CMS\CMS\Views\Pedido\CreatePagina.cshtml"
Write(Html.ActionLink("Voltar para a lista", "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(2600, 14, true);
            WriteLiteral("\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<business.business.Pagina> Html { get; private set; }
    }
}
#pragma warning restore 1591