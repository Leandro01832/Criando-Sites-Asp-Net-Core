#pragma checksum "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\wwwroot\Arquivotxt\html\DocFormulario.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16bdfc82514dba630833c72b1a21b441d8b8cbec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.wwwroot_Arquivotxt_html_DocFormulario), @"mvc.1.0.view", @"/wwwroot/Arquivotxt/html/DocFormulario.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/wwwroot/Arquivotxt/html/DocFormulario.cshtml", typeof(AspNetCore.wwwroot_Arquivotxt_html_DocFormulario))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16bdfc82514dba630833c72b1a21b441d8b8cbec", @"/wwwroot/Arquivotxt/html/DocFormulario.cshtml")]
    public class wwwroot_Arquivotxt_html_DocFormulario : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1934, true);
            WriteLiteral(@"#if($element.Elemento.tipo == 'Formulario')

<div id='Form${element.Elemento.IdElemento}Pagina${model.Pagina.Id}' class='Elemento$element.Elemento.IdElemento grid-item' data-value='$element.Elemento.IdElemento' data-id='$element.Elemento.IdElemento'>

    <form>
        #foreach($el in $element.Elemento.Despendentes)
        
        <label>$el.ElementoDependente.Dependente.Nome</label>
        <input class='CampoFormulario$element.Elemento.IdElemento' id='Campo$el.ElementoDependente.Dependente.IdElemento' name='Campo$el.ElementoDependente.Dependente.IdElemento' type='$el.ElementoDependente.Dependente.TipoCampo' placeholder='$el.ElementoDependente.Dependente.Placeholder' />
         <br />
        
        #end
        <a href='#' id='SalvarDadosFormulario'>Salvar</a>
    </form>

</div>

<script type='text/javascript'>

    $(document).ready(function () {

        $('#SalvarDadosFormulario').click(function () {

            var Arquivos = $('.CampoFormulario');
            var formDat");
            WriteLiteral(@"a = new FormData();

            let token = $('[name=__RequestVerificationToken]').val();  
            let headers = {};
            headers['RequestVerificationToken'] = token;

            for (var i = 0; i !== Arquivos.length; i++) {
                formData.append('valores', document.getElementsByClassName('CampoFormulario$element.Elemento.IdElemento')[i].value);
                formData.append('Formulario', $element.Elemento.IdElemento); 
            }

            jQuery.ajax({
                url: '/Formulario/SalvarDados',
                data: formData,
                processData: !1,
                contentType: !1,
                type: 'POST',
                headers: headers,
                success: function (data) {
                    alert('dados salvos com sucesso!' + data);
                }
            });


        });

    });

</script>

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
