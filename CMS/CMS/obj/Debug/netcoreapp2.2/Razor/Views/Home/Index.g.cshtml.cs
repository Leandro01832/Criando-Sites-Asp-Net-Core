#pragma checksum "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37e455077348ba666d0fbacdf148788eea9198c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37e455077348ba666d0fbacdf148788eea9198c4", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0389c18537be78d994187c367b0e0aa311ab30d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<business.business.Pagina>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(130, 509, true);
            WriteLiteral(@"
<style>
    #esquerda {
        left: 1%;
    }

    #direita {
        right: 1%;
    }
</style>

<script src=""/lib/jquery/dist/jquery.js""></script>
<br />
<br />
<br />

<input type=""number"" id=""NumeroPaginaAcesso"" style=""width:90%;"" placeholder=""Digite o numero da pagina. Ex: 1, 2, 3, 4, 5, ..."" />
<a id=""acessoPaginaComInput"" href=""/Pagina/"" style=""width:10%;"" class=""glyphicon glyphicon-search"">
    Acessar
</a>



<div id=""my-carousel"" class=""carousel"" data-ride=""carousel"">
");
            EndContext();
#line 31 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Home\Index.cshtml"
      
        const int TAMANHO_PAGINA = 1;
        var paginas = (int)Math.Ceiling((double)Model.Count() / TAMANHO_PAGINA);

    

#line default
#line hidden
            BeginContext(777, 86, true);
            WriteLiteral("\r\n    <!-- Wrapper for slides -->\r\n    <div class=\"carousel-inner\" role=\"listbox\">\r\n\r\n");
            EndContext();
#line 40 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Home\Index.cshtml"
         for (int pagina = 0; pagina < paginas; pagina++)
        {

            var PagesDaPagina = Model.Skip(pagina * TAMANHO_PAGINA).Take(TAMANHO_PAGINA).ToList();

            

#line default
#line hidden
#line 45 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Home\Index.cshtml"
             foreach (var item in PagesDaPagina)
            {


#line default
#line hidden
            BeginContext(1104, 103, true);
            WriteLiteral("                <div class=\"item\">\r\n                    <div class=\"row\">\r\n                        <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1207, "\"", 1228, 2);
            WriteAttributeValue("", 1212, "pagina", 1212, 6, true);
#line 50 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Home\Index.cshtml"
WriteAttributeValue("", 1218, item.Id, 1218, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1229, 75, true);
            WriteLiteral(" class=\"Pag col-md-12 col-sm-12 col-lg-12\">\r\n\r\n                            ");
            EndContext();
            BeginContext(1305, 19, false);
#line 52 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Home\Index.cshtml"
                       Write(Html.Raw(item.Html));

#line default
#line hidden
            EndContext();
            BeginContext(1324, 88, true);
            WriteLiteral("\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 57 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#line 57 "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\Views\Home\Index.cshtml"
             
        }

#line default
#line hidden
            BeginContext(1438, 445, true);
            WriteLiteral(@"    </div>
</div>

<a class=""left carousel-control"" href=""#my-carousel"" role=""button"" id=""esquerda"" data-slide=""prev"">
    <span class=""glyphicon glyphicon-chevron-left""></span>
    <span class=""sr-only"">Previous</span>
</a>
<a class=""right carousel-control"" href=""#my-carousel"" role=""button"" id=""direita"" data-slide=""next"">
    <span class=""glyphicon glyphicon-chevron-right""></span>
    <span class=""sr-only"">Next</span>
</a>



");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1906, 244, true);
                WriteLiteral("\r\n\r\n\r\n    <script type=\"text/javascript\">\r\n\r\n        $(document).ready(function () {\r\n\r\n            jQuery(function () {\r\n\r\n                $(\'.item:first-child\').addClass(\'active\').show();\r\n            });\r\n\r\n        });\r\n\r\n    </script>\r\n\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(2153, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<business.business.Pagina>> Html { get; private set; }
    }
}
#pragma warning restore 1591