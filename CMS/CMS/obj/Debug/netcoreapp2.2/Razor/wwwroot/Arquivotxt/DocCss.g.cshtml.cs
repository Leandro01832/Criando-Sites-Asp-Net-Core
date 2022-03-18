#pragma checksum "C:\Users\leand\Documents\cms-aspnetcore\copia\CMS\wwwroot\Arquivotxt\DocCss.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e32593e376d330e6ef2b8ef62fe8a772fbf8d58e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.wwwroot_Arquivotxt_DocCss), @"mvc.1.0.view", @"/wwwroot/Arquivotxt/DocCss.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/wwwroot/Arquivotxt/DocCss.cshtml", typeof(AspNetCore.wwwroot_Arquivotxt_DocCss))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e32593e376d330e6ef2b8ef62fe8a772fbf8d58e", @"/wwwroot/Arquivotxt/DocCss.cshtml")]
    public class wwwroot_Arquivotxt_DocCss : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 17497, true);
            WriteLiteral(@"#set($site = '')

#if($model.Div1.Div.Background.Tipo == ""BackgroundImagem"")

<style>    

    .content {
        background-image: url($site$model.Div1.Div.Background.Imagem.ArquivoImagem);
    }
</style>

#elseif($model.Div1.Div.BackGround.Tipo == ""BackgroundGradiente"")

<style>
    .content {

         #set($um = 1)
         #foreach($Cores in $model.Div1.Div.Background.BackgroundGradiente.Cores)
         #if($um == 1)
        #set($back = $Cores.HexToColor($Cores.CorBackground))
        background: rgb($back); 
        #end
        #set($um = $um + 1)        
         #end


         #set($quantidade = $model.Div1.Div.Background.Cores.Count())
        background: -moz-linear-gradient(${model.Div1.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div1.Div.Background.Cores)
         #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

            #if($velocityCount ");
            WriteLiteral(@"== $quantidade)
             );
        #else
            ,
            #end

        #end  

        background: -webkit-linear-gradient(${model.Div1.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div1.Div.Background.Cores)
        #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

        #if($velocityCount == $quantidade)
             );
        #else
            ,
            #end

        #end  

        background: linear-gradient(${model.Div1.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div1.Div.Background.BackgroundGradiente.Cores)
        #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

            #if($velocityCount == $quantidade)
             );
        #else
             ,
            #end

        #end  

        filter: progid:");
            WriteLiteral(@"DXImageTransform.Microsoft.gradient(startColorstr='#09e718',endColorstr='#1c8ea5',GradientType=1);
    }

    #pagina$model.Pagina.Id {

         #set($um = 1)
         #foreach($Cores in $model.Div1.Div.Background.Cores)
         #if($um == 1)
        #set($back = $Cores.HexToColor($Cores.CorBackground))
        background: rgb($back); 
        #end
        #set($um = $um + 1)        
         #end


         #set($quantidade = $model.Div1.Div.Background.Cores.Count())
        background: -moz-linear-gradient(${model.Div1.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div1.Div.Background.Cores)
         #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

            #if($velocityCount == $quantidade)
             );
        #else
            ,
            #end

        #end  

        background: -webkit-linear-gradient(${model.Div1.Div.Background.Grau}deg,
       ");
            WriteLiteral(@" #foreach($Cor in $model.Div1.Div.Background.Cores)
        #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

        #if($velocityCount == $quantidade)
             );
        #else
            ,
            #end

        #end  

        background: linear-gradient(${model.Div1.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div1.Div.Background.Cores)
        #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

            #if($velocityCount == $quantidade)
             );
        #else
             ,
            #end

        #end  

        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#09e718',endColorstr='#1c8ea5',GradientType=1);
    }

</style>

#else

<style>
    .content {
        background-color: $model.Div1.Div.Background.Cor;");
            WriteLiteral(@"
    }

    #pagina$model.Pagina.Id {
        background-color: $model.Div1.Div.Background.Cor;
    }
</style>

#end

#if($model.Div2.Div.Background.Tipo == ""BackgroundImagem"")
<style>
    #topo$model.Div2.Div.Id {
        background-image: url($site$model.Div2.Div.Background.Imagem.ArquivoImagem);
        background-repeat: $model.Div2.Div.Background.Background_Repeat;
    }
</style>

#elseif($model.Div2.Div.Background.Tipo == ""BackgroundGradiente"")

<style>
    #topo$model.Div2.Div.Background.Id {

         #set($um = 1)
         #foreach($Cores in $model.Div2.Div.Background.Cores)
         #if($um == 1)
        #set($back = $Cores.HexToColor($Cores.CorBackground))
        background: rgb($back); 
        #end
        #set($um = $um + 1)        
         #end


         #set($quantidade = $model.Div2.Div.Background.Cores.Count())
        background: -moz-linear-gradient(${model.Div2.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div2.Div.Background.Cores)
      ");
            WriteLiteral(@"   #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

            #if($velocityCount == $quantidade)
             );
        #else
            ,
            #end

        #end  

        background: -webkit-linear-gradient(${model.Div2.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div2.Div.Background.Cores)
        #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

        #if($velocityCount == $quantidade)
             );
        #else
            ,
            #end

        #end  

        background: linear-gradient(${model.Div2.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div2.Div.Background.Cores)
        #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${");
            WriteLiteral(@"Cor.Position}%

            #if($velocityCount == $quantidade)
             );
        #else
             ,
            #end

        #end  

        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#09e718',endColorstr='#1c8ea5',GradientType=1);
    }
</style>

#else

<style>
    #topo$model.Div2.Div.Background.Id {
        background-color: $model.Div2.Div.Background.Cor;
    }
</style>

#end

#if($model.Div3.Div.Background.Tipo == ""BackgroundImagem"")

<style>
    #menu$model.Div3.Div.Background.Id {
        background-image: url($site$model.Div3.Div.Background.Imagem.ArquivoImagem);
        background-repeat: $model.Div3.Div.Background.Background_Repeat;
    }
</style>

#elseif($model.Div3.Div.Background.Tipo == ""BackgroundGradiente"")

<style>
    #menu$model.Div3.Div.Background.Id {

         #set($um = 1)
         #foreach($Cores in $model.Div3.Div.Background.Cores)
         #if($um == 1)
        #set($back = $Cores.HexToColor($Cores.CorBackground");
            WriteLiteral(@"))
        background: rgb($back); 
        #end
        #set($um = $um + 1)        
         #end


         #set($quantidade = $model.Div3.Div.Background.Cores.Count())
        background: -moz-linear-gradient(${model.Div3.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div3.Div.background.Cores)
         #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

            #if($velocityCount == $quantidade)
             );
        #else
            ,
            #end

        #end  

        background: -webkit-linear-gradient(${model.Div3.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div3.Div.Background.Cores)
        #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

        #if($velocityCount == $quantidade)
             );
        #else
            ,");
            WriteLiteral(@"
            #end

        #end  

        background: linear-gradient(${model.Div3.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div3.Div.Background.Cores)
        #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

            #if($velocityCount == $quantidade)
             );
        #else
             ,
            #end

        #end  

        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#09e718',endColorstr='#1c8ea5',GradientType=1);
    }
</style>

#else

<style>
    #menu$model.Div3.Div.Background.Id {
        background-color: $model.Div3.Div.Background.Cor;
    }
</style>

#end

#if($model.Div5.Div.Background.Tipo == ""BackgroundImagem"")

<style>
    #bordaEsquerda$model.Div5.Div.Id {
        background-image: url($site$model.Div5.Div.Background.Imagem.ArquivoImagem);
        background-repeat: $model.Div5.Div.Background.Backgrou");
            WriteLiteral(@"nd_Repeat;
    }
</style>

#elseif($model.Div5.Div.Background.Tipo == ""BackgroundGradiente"")

<style>
    #bordaEsquerda$model.Div5.Div.Background.Id {

         #set($um = 1)
         #foreach($Cores in $model.Div5.Div.Background.Cores)
         #if($um == 1)
        #set($back = $Cores.HexToColor($Cores.CorBackground))
        background: rgb($back); 
        #end
        #set($um = $um + 1)        
         #end


         #set($quantidade = $model.Div5.Div.Background.Cores.Count())
        background: -moz-linear-gradient(${model.Div5.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div5.Div.Background.Cores)
         #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

            #if($velocityCount == $quantidade)
             );
        #else
            ,
            #end

        #end  

        background: -webkit-linear-gradient(${model.Div5.Div.Backgroun");
            WriteLiteral(@"d.Grau}deg,
        #foreach($Cor in $model.Div5.Div.Background.Cores)
        #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

        #if($velocityCount == $quantidade)
             );
        #else
            ,
            #end

        #end  

        background: linear-gradient(${model.Div5.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div5.Div.Background.Cores)
        #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

            #if($velocityCount == $quantidade)
             );
        #else
             ,
            #end

        #end  

        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#09e718',endColorstr='#1c8ea5',GradientType=1);
    }
</style>

#else

<style>
    #bordaEsquerda$model.Div5.Div.Background.Id {
    ");
            WriteLiteral(@"    background-color: $model.Div5.Div.Background.Cor;
    }
</style>

#end

#if($model.Div6.Div.Background.Tipo == ""BackgroundImagem"")

<style>
    #bordaDireita$model.Div6.Div.Background.Id {
        background-image: url($site$model.Div6.Div.Background.Imagem.ArquivoImagem);
        background-repeat: $model.Div6.Div.Background.Background_Repeat;
    }
</style>

#elseif($model.Div6.Div.Background.Tipo == ""BackgroundGradiente"")

<style>
    #bordaEsquerda$model.Div6.Div.Background.Id {

         #set($um = 1)
         #foreach($Cores in $model.Div6.Div.Background.Cores)
         #if($um == 1)
        #set($back = $Cores.HexToColor($Cores.CorBackground))
        background: rgb($back); 
        #end
        #set($um = $um + 1)        
         #end


         #set($quantidade = $model.Div6.Div.Background.Cores.Count())
        background: -moz-linear-gradient(${model.Div6.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div6.Div.Background.Cores)
         #set($Transpa");
            WriteLiteral(@"rencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

            #if($velocityCount == $quantidade)
             );
        #else
            ,
            #end

        #end  

        background: -webkit-linear-gradient(${model.Div6.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div6.Div.Background.Cores)
        #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

        #if($velocityCount == $quantidade)
             );
        #else
            ,
            #end

        #end  

        background: linear-gradient(${model.Div6.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div6.Div.Background.Cores)
        #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%
");
            WriteLiteral(@"
            #if($velocityCount == $quantidade)
             );
        #else
             ,
            #end

        #end  

        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#09e718',endColorstr='#1c8ea5',GradientType=1);
    }
</style>

#else

<style>
    #bordaDireita$model.Div6.Div.Background.Id {
        background-color: $model.Div6.Div.Background.Cor;
    }
</style>

#end

#if($model.Div4.Div.Background.Tipo == ""BackgroundImagem"")

<style>
    #blocos$model.Div4.Div.Id {
        background-image: url($site$model.Div4.Div.Background.Imagem.ArquivoImagem);
        background-repeat: $model.Div4.Div.Background.Background_Repeat;
    }
</style>

#elseif($model.Div4.Div.Background.Tipo == ""BackgroundGradiente"")

<style>
    #blocos$model.Div4.Div.Id {

         #set($um = 1)
         #foreach($Cores in $model.Div4.Div.Background.Cores)
         #if($um == 1)
        #set($back = $Cores.HexToColor($Cores.CorBackground))
        background: rg");
            WriteLiteral(@"b($back); 
        #end
        #set($um = $um + 1)        
         #end


         #set($quantidade = $model.Div4.Div.Background.Cores.Count())
        background: -moz-linear-gradient(${model.Div4.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div4.Div.Background.Cores)
         #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

            #if($velocityCount == $quantidade)
             );
        #else
            ,
            #end

        #end  

        background: -webkit-linear-gradient(${model.Div4.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div4.Div.Background.Cores)
        #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

        #if($velocityCount == $quantidade)
             );
        #else
            ,
            #end

     ");
            WriteLiteral(@"   #end  

        background: linear-gradient(${model.Div4.Div.Background.Grau}deg,
        #foreach($Cor in $model.Div4.Div.Background.Cores)
        #set($Transparencia = $Cor.Transparencia / 10)
        rgba($Cor.HexToColor($Cor.CorBackground),$Transparencia.toString().replace(',','.')) ${Cor.Position}%

            #if($velocityCount == $quantidade)
             );
        #else
             ,
            #end

        #end  

        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#09e718',endColorstr='#1c8ea5',GradientType=1);
    }
</style>

#else

<style>
    #blocos$model.Div4.Div.Id {
        background-color: $model.Div4.Div.Background.Cor;
    }
</style>

#end

<meta charset='UTF-8'>

 <div id='corpo' data-value='$model.Div1.Div.Id' class='Corpo'>

    </div>

   #if($model.Pagina.Topo)
    <div id='topo$model.Div2.Div.Id' class='Topo' data-value='$model.Div2.Div.Id' style='z-index:10;'>
        <h1>$model.titulo</h1>
    </div>
    #end
");
            WriteLiteral(@"
    #if($model.Pagina.Menu)
    <div id='menu$model.Div3.Div.Id' class='Menu' data-value='$model.Div3.Div.Id' style='z-index:10;'>
        <p>menu</p>
        <br />
        #if ($model.facebook != 'vazio' && $model.facebook != '')
        <a href='$model.facebook' target='_blank'>
            <img class='img-responsive' src='/imagem/facebook.png' alt='imagem' style='width:50px;' />
        </a>
        #end

        #if ($model.twiter != 'vazio' && $model.twiter != '')
        <a href='$model.twiter' target='_blank'>
            <img class='img-responsive' src='/imagem/twitter.png' alt='imagem' style='width:50px;' />
        </a>
        #end

        #if ($model.instagram != 'vazio' && $model.instagram != '')
        <a href='$model.instagram' target='_blank'>
            <img class='img-responsive' src='/imagem/instagram.png' alt='imagem' style='width:50px;' />
        </a>
        #end





        #if($model.Pedidos)

        <a href='/Requisicao/IndexPedido' target='_blank'>");
            WriteLiteral("\r\n            Pedidos\r\n        </a>\r\n\r\n        #end\r\n\r\n\r\n    </div>\r\n    #end\r\n\r\n\r\n\r\n    ");
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
