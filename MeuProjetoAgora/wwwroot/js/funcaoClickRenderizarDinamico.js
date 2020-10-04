$(".imagemBackPagina").click(function () {
    var id = $("#corpo").data("value");
    $("#conteudomodal").load("/EditTools/EditModalBackground/" + id);
});

$("#CreatePath").click(function () {
    $("#conteudomodal").load("/CreateTools/CreateModalPasta");
}); 

$("#Ferramenta").click(function () {

    $("#Chat").css("display", "block");
    $(".content").removeClass('col-md-12').addClass('col-md-8');

    $("#FormTexto").load("/Pagina/EmBranco/");
    $("#FormTexto, #estrutura, #Permissao").fadeOut("slow");
    $("#estrutura").fadeIn("slow");    
});

$("#EditarCores").click(function () {    
    $("#conteudomodal").load("/EditTools/EditModalCor/");
});

$(".CriarPlano").click(function () {
    $("#conteudomodal").load("/CreateTools/CreateModalBackground/");
});

$(".CoresBack").click(function () {
    $("#conteudomodal").load("/CreateTools/CreateModalCor/");
});


$(".Salvar").click(function () {
    var valor = $(this).data("value").replace(/[^0-9]/g, '');
    $("#conteudomodal").load("/Pagina/Salvar/" + valor);
});


$("#EditToolsLink").click(function () {
    var id = $(this).data("value");
    $("#conteudomodal").load("/EditTools/EditModalLink/" + id);
});

$("#EditToolsForm").click(function () {

    var id = $(this).data("value");

    $("#conteudomodal").load("/EditTools/EditModalForm/" + id);
});

$("#EditToolsTable").click(function () {

    var id = $(this).data("value");
   

    $("#conteudomodal").load("/EditTools/EditModalTable/" + id);
});



$("#EditToolsImagem").click(function () {

    var id = $(this).data("value");

    $("#conteudomodal").load("/EditTools/EditModalImagem/" + id);
});

$("#EditToolsVideo").click(function () {

    var id = $(this).data("value");

    $("#conteudomodal").load("/EditTools/EditModalVideo/" + id);
});

$("#EscolherMusica").click(function () {
    $("#conteudoMusica").load("/CreateTools/CreateModalMusica");
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

    $("#conteudomodal").load("/EditTools/EditModalPagina/" + numero);
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



////////////////////////////////////////////////////////////////////////////////////////






$("#CriaBloco").click(function () {

    $("#conteudomodal").load("/Elemento/CreateDiv");
});

$("#CriaTexto").click(function () {

    $("#conteudomodal").load("/Elemento/Create/texto");
});

$("#CriaVideo").click(function () {

    $("#conteudoVideo").load("/Elemento/Create/video");
});

$("#CriaLink").click(function () {

    $("#conteudomodal").load("/Elemento/Create/link");
});

$("#CriaTable").click(function () {

    $("#conteudomodal").load("/Elemento/Create/table");
});

$("#CriaImagem").click(function () {

    $("#conteudoImagem").load("/Elemento/Create/imagem");
});

$("#CriaCarousel").click(function () {

    $("#conteudomodal").load("/Elemento/Create/carousel");
});

$("#CriaElemento").click(function () {
    $("#conteudomodal").load("/CreateTools/CreateModalElemento");
});