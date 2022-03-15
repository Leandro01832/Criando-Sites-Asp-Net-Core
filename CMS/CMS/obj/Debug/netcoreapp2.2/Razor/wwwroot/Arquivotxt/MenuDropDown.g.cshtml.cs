#pragma checksum "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\wwwroot\Arquivotxt\MenuDropDown.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01348098d01e1927ec3151f5a2974606f365c6a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.wwwroot_Arquivotxt_MenuDropDown), @"mvc.1.0.view", @"/wwwroot/Arquivotxt/MenuDropDown.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/wwwroot/Arquivotxt/MenuDropDown.cshtml", typeof(AspNetCore.wwwroot_Arquivotxt_MenuDropDown))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01348098d01e1927ec3151f5a2974606f365c6a2", @"/wwwroot/Arquivotxt/MenuDropDown.cshtml")]
    public class wwwroot_Arquivotxt_MenuDropDown : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 6761, true);
            WriteLiteral(@"
#set($site = 'http://www.siteprofissional.somee.com')

<header>
    <div class='navbar navbar-inverse navbar-fixed-top'>
        <div class='container'>
            <div class='navbar-header'>
                <button type='button' class='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                    <span class='icon-bar'></span>
                    <span class='icon-bar'></span>
                    <span class='icon-bar'></span>
                </button>
                <a href='/site/$model.Pagina.Pedido.DominioTemporario/' class='navbar-brand'>$model.Pagina.Pedido.Nome</a>
                <input type='text' placeholder='Digite a Page' id='PaginaInput' style='width: 120px;' />
                <a id='acessoPaginaInput' href='/site/$model.Pagina.Pedido.DominioTemporario/'>
                    Acessar
                </a>
            </div>
            <div class='navbar-collapse collapse'>
                <ul class='nav navbar-nav'>

                    #foreac");
            WriteLiteral(@"h($bloco in $divs)

                    #foreach($element in $bloco.Div.Elemento)

                    #if($element.Elemento.tipo == 'Dropdown')

                    <li class='dropdown'>
                        <a href='#' class='dropdown-toggle' data-toggle='dropdown'>$element.Elemento.Nome</a>
                        <ul class='dropdown-menu'>
                            #foreach($depe in $element.Elemento.Despendentes)

                            #if($depe.ElementoDependente.Dependente.UrlLink == false)

                            <li>
                                <a href='/site/$depe.ElementoDependente.Dependente.Destino.Pedido.DominioTemporario/$depe.ElementoDependente.Dependente.Destino.Titulo.Replace(' ', '')'>

                                    #set($linkIndice = 0)
                                    #foreach($el in $depe.ElementoDependente.Dependente.Despendentes)

                                    #if($linkIndice == 0)
                                    $el.ElementoDe");
            WriteLiteral(@"pendente.Dependente.PalavrasTexto
                                    #end

                                    #set($linkIndice = $linkIndice + 1)

                                    #end
                                </a>
                            </li>

                            #else

                            <li>
                                <a href='$depe.ElementoDependente.Dependente.TextoLink'>

                                    #set($linkIndice = 0)
                                    #foreach($el in $depe.ElementoDependente.Dependente.Despendentes)

                                    #if($linkIndice == 0)
                                    $el.ElementoDependente.Dependente.PalavrasTexto
                                    #end

                                    #set($linkIndice = $linkIndice + 1)

                                    #end
                                </a>
                            </li>

                            #end

          ");
            WriteLiteral(@"                  #end
                        </ul>
                    </li>

                    #end

                    #end

                    #end

                    #foreach($bloco in $divs)

                    #foreach($element in $bloco.Div.Elemento)

                    #if($element.Elemento.tipo == 'Link' && $element.Elemento.Menu)

                    #if($element.Elemento.UrlLink == false)

                    <li>
                        <a href='/site/$element.Elemento.Destino.Pedido.DominioTemporario/$element.Elemento.Destino.Titulo.Replace(' ', '')'>

                            #set($linkIndice = 0)
                            #foreach($el in $element.Elemento.Despendentes)

                            #if($linkIndice == 0)
                            $el.ElementoDependente.Dependente.PalavrasTexto
                            #end

                            #set($linkIndice = $linkIndice + 1)

                            #end
                        </");
            WriteLiteral(@"a>
                    </li>

                    #else

                    <li>
                        <a href='$element.Elemento.TextoLink'>

                            #set($linkIndice = 0)
                            #foreach($el in $element.Elemento.Despendentes)

                            #if($linkIndice == 0)
                            $el.ElementoDependente.Dependente.PalavrasTexto
                            #end

                            #set($linkIndice = $linkIndice + 1)

                            #end
                        </a>
                    </li>

                    #end

                    #end

                    #end

                    #end

                    <li>

                    </li>
                    <li>

                    </li>

                </ul>
                #if($model.Pedidos)

                

                <ul class=""nav navbar-nav navbar-right"">
                    #if ($model.Login)

          ");
            WriteLiteral(@"          <li>
                        <a id=""manage"" class=""nav-link text-dark"" title=""Manage"" href=""/Identity/Account/Manage"">Oi, $model.Usuario !</a>
                       
                    </li>
                    <li>
                        <form id=""logoutForm"" class=""form-inline"" action=""/Identity/Account/Logout?returnUrl=%2FHome"" method=""post"">
                            <button id=""logout"" type=""submit"" class=""nav-link btn btn-link text-dark"">Sair</button>
                            <input name=""__RequestVerificationToken"" type=""hidden"" value=""CfDJ8LdrVGWay89Gnc42IyEnHHppMlkm4CH8DCfruhQDwTp6mrmZakOUvn6p0yp6HOIx10L6D9091IlcnLG8fpz2B1cnc6J_ILtUopVplmJXcAUn0Z3V8jvgkwO7fbFQ43OVIm5aGF_jTB5hL3TRXh-q-c5teZO57owGq821fyYmo1hXXAgeaMy2P8uqieV9BSx4YA"">
                        </form>
                    </li>

                    #else

                    <li>
                        <a class=""nav-link text-dark"" id=""register"" href=""/Identity/Account/Register"">Registrar</a>
              ");
            WriteLiteral(@"          
                    </li>

                    <li class=""nav-item"">
                        <a class=""nav-link text-dark"" id=""login"" href=""/Identity/Account/Login"">Entrar</a>
                        
                    </li>
                    #end

                </ul>

                #end
            </div>
        </div>
    </div>
</header>

#foreach($bloco in $divs)

#if($bloco.Div.Fixado)

<script type='text/javascript'>

    jQuery(function () {
        $('#DIV${bloco.Div.IdDIv}Pagina${model.Pagina.Id}').css('display', 'block');
    });

</script>

#end
#end");
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
