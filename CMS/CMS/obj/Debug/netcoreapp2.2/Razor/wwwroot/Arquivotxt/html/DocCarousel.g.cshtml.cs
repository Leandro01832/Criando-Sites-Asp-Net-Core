#pragma checksum "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\wwwroot\Arquivotxt\html\DocCarousel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b673b187b89f86caa2bee7c4b43dcbee11206fca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.wwwroot_Arquivotxt_html_DocCarousel), @"mvc.1.0.view", @"/wwwroot/Arquivotxt/html/DocCarousel.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/wwwroot/Arquivotxt/html/DocCarousel.cshtml", typeof(AspNetCore.wwwroot_Arquivotxt_html_DocCarousel))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b673b187b89f86caa2bee7c4b43dcbee11206fca", @"/wwwroot/Arquivotxt/html/DocCarousel.cshtml")]
    public class wwwroot_Arquivotxt_html_DocCarousel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 853, true);
            WriteLiteral(@"#if ($element.Elemento.tipo == 'Carousel')
<div id='carousel${element.Elemento.IdElemento}Pagina${model.Pagina.Id}' class='Elemento$element.Elemento.IdElemento grid-item' style='height:auto' data-value='$element.Elemento.IdElemento' data-id='$element.Elemento.IdElemento'>
    <div id='carouselsite$element.Elemento.IdElemento' class='carousel' data-ride='carousel'>

        <div class='carousel-inner' role='listbox'>

            #foreach($dependente in $element.Elemento.Despendentes)

            <div class='item'>
                <img class='img-responsive minhaimg' src='$dependente.ElementoDependente.Dependente.ArquivoImagem' alt='imagem' style='width:100%;' />
                <!-- <div class='carousel-caption'>
                </div>   -->
            </div>
            #end
        </div>
    </div>
</div>

#end



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