#pragma checksum "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\wwwroot\Arquivotxt\html\DocTexto.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6940cb79adcf7e11d8985fa0f274a4f2f1987213"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.wwwroot_Arquivotxt_html_DocTexto), @"mvc.1.0.view", @"/wwwroot/Arquivotxt/html/DocTexto.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/wwwroot/Arquivotxt/html/DocTexto.cshtml", typeof(AspNetCore.wwwroot_Arquivotxt_html_DocTexto))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6940cb79adcf7e11d8985fa0f274a4f2f1987213", @"/wwwroot/Arquivotxt/html/DocTexto.cshtml")]
    public class wwwroot_Arquivotxt_html_DocTexto : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 319, true);
            WriteLiteral(@"#if ($element.Elemento.tipo == 'Texto')

<div id='texto${element.Elemento.IdElemento}Pagina${model.Pagina.Id}' class='Elemento$element.Elemento.IdElemento grid-item' data-value='$element.Elemento.IdElemento' data-id='$element.Elemento.IdElemento'>

    <p>$element.Elemento.PalavrasTexto</p>
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
