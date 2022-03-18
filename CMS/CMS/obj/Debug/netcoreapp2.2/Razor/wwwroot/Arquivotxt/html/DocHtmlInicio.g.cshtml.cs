#pragma checksum "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\wwwroot\Arquivotxt\html\DocHtmlInicio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02e9e566c385b3ff168f50b4693f87c239cea3c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.wwwroot_Arquivotxt_html_DocHtmlInicio), @"mvc.1.0.view", @"/wwwroot/Arquivotxt/html/DocHtmlInicio.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/wwwroot/Arquivotxt/html/DocHtmlInicio.cshtml", typeof(AspNetCore.wwwroot_Arquivotxt_html_DocHtmlInicio))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02e9e566c385b3ff168f50b4693f87c239cea3c1", @"/wwwroot/Arquivotxt/html/DocHtmlInicio.cshtml")]
    public class wwwroot_Arquivotxt_html_DocHtmlInicio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 3573, true);
            WriteLiteral(@"
<meta charset='UTF-8'>

<div id='conteudo$model.Pagina.Id' class='Conteudo'>

    <div id='corpo' data-value='$model.background.IdBackground' class='Corpo'>

    </div>

    #if($model.Pagina.Topo)
    <div id='topo$model.background_topo.IdBackground' class='Topo' data-value='$model.background_topo.IdBackground'>
        <h1>$model.titulo</h1>
    </div>
    #end

    #if($model.Pagina.Menu)
    <div id='menu$model.background_menu.IdBackground' class='Menu' data-value='$model.background_menu.IdBackground'>
        <p>menu</p>
        <br />
        #if ($model.facebook != 'vazio' && $model.facebook != '')
        <a href='$model.facebook' target='_blank'>
            <img class='img-responsive' src='/imagem/facebook.png' alt='imagem' style='width:50px;' />
        </a>
        #end

        #if ($model.twiter != 'vazio' && $model.twiter != '')
        <a href='$model.twiter' target='_blank'>
            <img class='img-responsive' src='/imagem/twitter.png' alt='imagem' style='width");
            WriteLiteral(@":50px;' />
        </a>
        #end

        #if ($model.instagram != 'vazio' && $model.instagram != '')
        <a href='$model.instagram' target='_blank'>
            <img class='img-responsive' src='/imagem/instagram.png' alt='imagem' style='width:50px;' />
        </a>
        #end





        #if($model.Pedidos)

        <a href='/Requisicao/IndexPedido' target='_blank'>
            Pedidos
        </a>

        #end


    </div>
    #end

    <div id='blocos$model.background_bloco.IdBackground' class='bloco' data-value='$model.background_bloco.IdBackground'>

        #foreach($nunber in $model.Rows)



        #set ($condicao = 0)
        #set ($espacamento = 0)
        <div class='row linha' id='line$nunber'>


            #foreach($bloco in $divs)

            #if ($bloco.Div.Divisao == 'col-md-12' && $bloco.Div.Desenhado == 0 || $bloco.Div.Divisao == 'col-sm-12' && $bloco.Div.Desenhado == 0)
            #set($espacamento = $espacamento + 12)
            #end");
            WriteLiteral(@"

            #if ($bloco.Div.Divisao == 'col-md-6' && $bloco.Div.Desenhado == 0 || $bloco.Div.Divisao == 'col-sm-6' && $bloco.Div.Desenhado == 0)
            #set($espacamento = $espacamento + 6)
            #end

            #if ($bloco.Div.Divisao == 'col-md-4' && $bloco.Div.Desenhado == 0 || $bloco.Div.Divisao == 'col-sm-4' && $bloco.Div.Desenhado == 0)
            #set($espacamento = $espacamento + 4)
            #end

            #if ($bloco.Div.Divisao == 'col-md-3' && $bloco.Div.Desenhado == 0 || $bloco.Div.Divisao == 'col-sm-3' && $bloco.Div.Desenhado == 0)
            #set($espacamento = $espacamento + 3)
            #end

            #if ($bloco.Div.Divisao == 'col-md-2' && $bloco.Div.Desenhado == 0 || $bloco.Div.Divisao == 'col-sm-2' && $bloco.Div.Desenhado == 0)
            #set($espacamento = $espacamento + 2)
            #end

            #if ($espacamento > 12)
            #set($condicao = 1)

            #end

            #if ($condicao == 0 && $bloco.Div.Desenhado == 0");
            WriteLiteral(@")

            <div id='DIV${bloco.Div.IdDiv}Pagina${model.Pagina.Id}' class='ClassDiv $bloco.Div.Divisao grid-container' data-value='$bloco.Div.IdDiv'>



                #foreach($element in $bloco.Div.Elemento)

                #if($element.Elemento.tipo != 'Link' && $element.Elemento.tipo != 'Dropdown')                   

                <div id='elemento${element.Elemento.IdElemento}Pagina${model.Pagina.Id}' class='Elemento grid-item' data-value='$element.Elemento.IdElemento'>

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