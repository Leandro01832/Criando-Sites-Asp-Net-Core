$(".GaleriaBackground").click(function () {

    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');

    $("#conteudomodal").load("/Ferramenta/ListaBackground/" + numero);
});


$("#GaleriaBlocoFixo").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');

    $("#FormTexto, #estrutura, #Permissao, #Galeria, #GaleriaBlocos").fadeOut("slow");
    $("#GaleriaBlocos").fadeIn("slow");
    $("#GaleriaBlocos").load("/Div/ListaFixo/");


});


$("#GaleriaBloco").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');

    $("#FormTexto, #estrutura, #Permissao, #Galeria, #GaleriaBlocos").fadeOut("slow");
    $("#GaleriaBlocos").fadeIn("slow");
    $("#GaleriaBlocos").load("/Div/Lista/");


});

function ElementoGaleria(Elemento) {

    $("#FormTexto, #estrutura, #Permissao, #Galeria, #GaleriaBlocos").fadeOut("slow");
    $("#Galeria").fadeIn("slow");
    $("#Galeria").load("/Elemento/Lista/" + Elemento.id + "-" + numero);
}

$(".imagemBackPagina").click(function () {
    var id = $("#corpo")[0].data("value");
    $("#conteudomodal").load("/Elemento/EditDiv/" + id);
});

$("#CreatePath").click(function () {
    $("#conteudomodal").load("/Ferramenta/CreatePasta");
});

$("#EditarCores").click(function () {  
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');

    $("#conteudomodal").load("/Ferramenta/ListaCores/" + numero);
});

$("#BlocoCriarBackgroundImagem").click(function () {
    $("#conteudomodal").load("/Background/Create/BackgroundImagem");
});

$("#BlocoCriarBackgroundGradiente").click(function () {
    $("#conteudomodal").load("/Background/Create/BackgroundGradiente");
});

$("#BlocoCriarBackgroundCor").click(function () {
    $("#conteudomodal").load("/Background/Create/BackgroundCor");
});

$(".CoresBack").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Background/CreateCor/" + numero);
});


$(".Salvar").click(function () {
    var valor = $(this).data("value").replace(/[^0-9]/g, '');
    $("#conteudomodal").load("/Pagina/Salvar/" + valor);
});


$("#EditToolsLink").click(function () {
    var id = $(this).data("value");
    $("#conteudomodal").load("/Elemento/Edit/" + id);
});

$("#EditToolsForm").click(function () {

    var id = $(this).data("value");

    $("#conteudomodal").load("/Elemento/Edit/" + id);
});

$("#EditToolsTable").click(function () {

    var id = $(this).data("value");
   

    $("#conteudomodal").load("/Elemento/Edit/" + id);
});



$("#EditToolsImagem").click(function () {

    var id = $(this).data("value");

    $("#conteudomodal").load("/Elemento/Edit/" + id);
});

$("#EditToolsVideo").click(function () {

    var id = $(this).data("value");

    $("#conteudomodal").load("/Elemento/Edit/" + id);
});

$("#EscolherMusica").click(function () {
    $("#conteudoMusica").load("/Elemento/Create/musica");
});

$("#btnConfig").click(function () {
    $("#FormTexto, #estrutura, #Permissao").fadeOut("slow");
    $("#estrutura").fadeIn("slow");
});

$("#btnPermissao").click(function () {
    $("#FormTexto, #estrutura, #Permissao").fadeOut("slow");
    $("#Permissao").fadeIn("slow");
    $("#Permissao").load("/Admin/EditPermissao?id=" + numero);

});

$("#modo").click(function () {
    if ($("#modo").is(':checked')) {
        $(".content").css("width", "380px");
        $(".content").css("margin", "auto");
    }
    else {
        $(".content").css("width", "66%");
    }

});

$(".Configuracao").click(function () {

    $("#conteudomodal").load("/Pagina/EditarPagina/" + numero);
    });



$("#Atualizar").click(function () {
    $(".content").load("/Pagina/GetView/" + numero);
});

$("#SalvarBlocos").click(function () {

    if (condicaoBloco) {
        condicaoBloco = false;
        AlterarPosicaoBloco();

    }
});

$("#SalvarElementos").click(function () {

    if (condicaoElemento) {
        condicaoElemento = false;
        AlterarPosicaoElemento();

    }
});

$("#AlterarPosicao").click(function () {
    location.reload();
});

$("#Ocultar").click(function () {

    $("#Chat").css("display", "none");
    $(".content").removeClass('col-md-8').addClass('col-md-12');

});

$(".Ferramenta").click(function () {    
    
    $(".content").removeClass('col-md-12').addClass('col-md-8');
    $("#Chat").css("display", "block");
    $("#FormTexto").load("/Pagina/EmBranco/");
    $("#FormTexto, #estrutura, #Permissao, #Galeria, #GaleriaBlocos").fadeOut("slow");
    $("#estrutura").fadeIn("slow");
    
});

$("#BlocoCriarBlocoComum").click(function () {

    $("#conteudomodal").load("/Div/Create/DivComum");
});

$("#BlocoCriarBlocoFixo").click(function () {

    $("#conteudomodal").load("/Div/Create/DivFixo");
});

$("#BlocoCriarTexto").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');

    $("#conteudomodal").load("/Elemento/Create/Texto/" + numero);
});

$("#BlocoCriarTextoDependente").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Elemento/Create/TextoDependente/" + numero);
});

$("#BlocoCriarVideo").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudoVideo").load("/Elemento/Create/Video/" + numero);
});

$("#BlocoCriarLink").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Elemento/Create/LinkBody/" + numero);
});

$("#BlocoCriarLinkMenu").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Elemento/Create/LinkMenu/" + numero);
});

$("#BlocoCriarTable").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Elemento/Create/Table/" + numero);
});

$("#BlocoCriarImagem").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudoImagem").load("/Elemento/Create/Imagem/" + numero);
});

$("#BlocoCriarCarouselImg").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Elemento/Create/CarouselImg/" + numero);
});

$("#BlocoCriarCarouselPagina").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Elemento/Create/CarouselPagina/" + numero);
});

$("#BlocoCriarDropdown").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Elemento/Create/Dropdown/" + numero);
});

$("#BlocoCriarProdutoAcessorio").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Elemento/Create/Acessorio/" + numero);
});

$("#BlocoCriarProdutoCalcado").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Elemento/Create/Calcado/" + numero);
});

$("#BlocoCriarProdutoAlimenticio").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Elemento/Create/Alimenticio/" + numero);
});

$("#BlocoCriarProdutoRoupa").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Elemento/Create/Roupa/" + numero);
});

$("#BlocoCriarProdutoShow").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Elemento/Create/Show/" + numero);
});

$("#BlocoCriarFormulario").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Elemento/Create/Formulario/" + numero);
});

$("#BlocoCriarCampo").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');
    $("#conteudomodal").load("/Elemento/Create/Campo/" + numero);
});

$("#CriaElemento").click(function () {
    $("#conteudomodal").load("/Elemento/RenderizarElemento");
});