$(".GaleriaBackground").click(function () {

    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44398', '');

    $("#conteudomodal").load("/Ferramenta/ListaBackground/" + numero);
});

$("#selectCriar").change(function () {

    switch ($(this).val()) {
        case "Link":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarLink").fadeIn("slow");
            
            break;
        case "Dropdown":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarDropdown").fadeIn("slow");

            break;
        case "Background":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarBackground").fadeIn("slow");

            break;
        case "Carousel":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarCarousel").fadeIn("slow");
            
            break;
        case "CarouselPagina":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarCarouselPagina").fadeIn("slow");

            break;
        case "Imagem":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarImagem").fadeIn("slow");
            
            break;
        case "Pasta":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarPasta").fadeIn("slow");

            break;
        case "Video":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarVideo").fadeIn("slow");
            
            break;
        case "Musica":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarMusica").fadeIn("slow");
            
            break;
        case "Formulario":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarFormulario").fadeIn("slow");
            
            break;
        case "Bloco":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarBloco").fadeIn("slow");
            
            break;
        case "Texto":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarTexto").fadeIn("slow");
            
            break;
        case "Table":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarTable").fadeIn("slow");
            
            break;
        case "Produto":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarProduto").fadeIn("slow");
            
            break;
        case "Campo":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarCampo").fadeIn("slow");
            
            break;
        case "Cor":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarCor").fadeIn("slow");
            
            break; 
        case "Pagina":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarPagina").fadeIn("slow");
            
            break;
        case "Site":

            $(".BlocoCriar").fadeOut("slow");
            $("#BlocoCriarSite").fadeIn("slow");
            
            break;
    }


});

$("#GaleriaBloco").click(function () {
    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44398', '');

    $("#FormTexto, #estrutura, #Permissao, #Galeria, #GaleriaBlocos").fadeOut("slow");
    $("#GaleriaBlocos").fadeIn("slow");
    $("#GaleriaBlocos").load("/Elemento/ListaBlocos/" + numero);


});

function ElementoGaleria(Elemento) {

    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44398', '');

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
    numero = numero.replace('44398', '');

    $("#conteudomodal").load("/Ferramenta/ListaCores/" + numero);
});

$(".CriarPlano").click(function () {
    $("#conteudomodal").load("/Ferramenta/CreateBackground/");
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









$("#CriaBloco").click(function () {

    $("#conteudomodal").load("/Elemento/CreateDiv");
});

$("#CriaTexto").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Texto");
});

$("#CriaVideo").click(function () {

    $("#conteudoVideo").load("/Elemento/Create/Video");
});

$("#CriaLink").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Link");
});

$("#CriaTable").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Table");
});

$("#CriaImagem").click(function () {

    $("#conteudoImagem").load("/Elemento/Create/Imagem");
});

$("#CriaCarousel").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Carousel");
});

$("#CriaCarouselPagina").click(function () {

    $("#conteudomodal").load("/Elemento/Create/CarouselPagina");
});

$("#CriaDropdown").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Dropdown");
});

$("#CriaProduto").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Produto");
});

$("#CriaFormulario").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Formulario");
});

$("#CriaCampo").click(function () {

    $("#conteudomodal").load("/Elemento/Create/Campo");
});

$("#CriaElemento").click(function () {
    $("#conteudomodal").load("/Elemento/RenderizarElemento");
});