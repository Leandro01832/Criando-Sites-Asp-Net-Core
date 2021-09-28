$(".GaleriaBackground").click(function () {

    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');

    $("#conteudomodal").load("/Ferramenta/ListaBackground/" + numero);
});

$("#GaleriaBloco").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');

    $("#FormTexto, #estrutura, #Permissao, #Galeria, #GaleriaBlocos").fadeOut("slow");
    $("#GaleriaBlocos").fadeIn("slow");
    $("#GaleriaBlocos").load("/Elemento/ListaBlocos/" + numero);


});

function ElementoGaleria(Elemento) {

    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44311', '');

    $("#FormTexto, #estrutura, #Permissao, #Galeria, #GaleriaBlocos").fadeOut("slow");
    $("#Galeria").fadeIn("slow");
    $("#Galeria").load("/Elemento/Lista/" + Elemento.id + numero + "/0");
}

$(".imagemBackPagina").click(function () {
    var id = $("#corpo").data("value");
    $("#conteudomodal").load("/Ferramenta/EditBackground/" + id);
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
    $("#conteudomodal").load("/Ferramenta/CreateBackground/BackgroundImagem");
});

$("#BlocoCriarBackgroundGradiente").click(function () {
    $("#conteudomodal").load("/Ferramenta/CreateBackground/BackgroundGradiente");
});

$("#BlocoCriarBackgroundCor").click(function () {
    $("#conteudomodal").load("/Ferramenta/CreateBackground/BackgroundCor");
});

$(".CoresBack").click(function () {
    $("#conteudomodal").load("/Ferramenta/CreateCor/");
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

    $("#conteudomodal").load("/Elemento/CreateDiv/DivComum");
});

$("#BlocoCriarBlocoFixo").click(function () {

    $("#conteudomodal").load("/Elemento/CreateDiv/DivFixo");
});

$("#BlocoCriarTexto").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Texto");
});

$("#BlocoCriarTextoDependente").click(function () {

    $("#conteudomodal").load("/Elemento/Create/TextoDependente");
});

$("#BlocoCriarVideo").click(function () {

    $("#conteudoVideo").load("/Elemento/Create/Video");
});

$("#BlocoCriarLink").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Link");
});

$("#BlocoCriarLinkMenu").click(function () {

    $("#conteudomodal").load("/Elemento/Create/LinkMenu");
});

$("#BlocoCriarTable").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Table");
});

$("#BlocoCriarImagem").click(function () {

    $("#conteudoImagem").load("/Elemento/Create/Imagem");
});

$("#BlocoCriarCarouselImg").click(function () {

    $("#conteudomodal").load("/Elemento/Create/CarouselImg");
});

$("#BlocoCriarCarouselPagina").click(function () {

    $("#conteudomodal").load("/Elemento/Create/CarouselPagina");
});

$("#BlocoCriarDropdown").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Dropdown");
});

$("#BlocoCriarProdutoAcessorio").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Acessorio");
});

$("#BlocoCriarProdutoCalcado").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Calcado");
});

$("#BlocoCriarProdutoAlimenticio").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Alimenticio");
});

$("#BlocoCriarProdutoRoupa").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Roupa");
});

$("#BlocoCriarProdutoShow").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Show");
});

$("#BlocoCriarFormulario").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Formulario");
});

$("#BlocoCriarCampo").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Campo");
});

$("#CriaElemento").click(function () {
    $("#conteudomodal").load("/Elemento/RenderizarElemento");
});