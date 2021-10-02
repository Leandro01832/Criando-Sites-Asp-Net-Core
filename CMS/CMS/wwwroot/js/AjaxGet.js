var items = $(".imagem");
var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
numero = numero.replace('44311', '');
var imgs_ = [['']];

var selects = $("select");

var elementoSelect = "";

for (var i = 0; i < selects.length; i++) {

    var ele_selecionado = selects[i].className;

    if (ele_selecionado.includes("Texto") || ele_selecionado.includes("TextoDependente") ||
        ele_selecionado.includes("Imagem") || ele_selecionado.includes("ImagemDependente") ||
        ele_selecionado.includes("LinkBody") || ele_selecionado.includes("LinkMenu") ||
        ele_selecionado.includes("Video") || ele_selecionado.includes("Table") ||
        ele_selecionado.includes("Campo") || ele_selecionado.includes("Calcado") ||
        ele_selecionado.includes("Roupa") || ele_selecionado.includes("Alimenticio") ||
        ele_selecionado.includes("Show") || ele_selecionado.includes("Acessorio") ||
        ele_selecionado.includes("CarrosselPagina") || ele_selecionado.includes("CarrosselImg"))
        buscar();    
}

function buscar()
{
    $.ajax({
        type: 'POST',
        url: '/AjaxGet/Elementos',
        dataType: 'json',
        data: { Pagina: numero },
        success: function (data) {

            $("." + data.tipo).empty();

            if ($("#selecionado" + data.tipo).val() === "") {
                $("." + data.tipo).append('<option value="">Escolher ' + data.tipo + '...</option>');
            }


            $.each(data, function (i) {

                if (i === data.length / 2) return false;

                if ($("#selecionado" + data.tipo).val() !== "" &&
                    parseInt($("#selecionado" + data.tipo).val()) === data.id) {
                    $("." + data.tipo).append('<option value="'
                        + data.id + '" ' + '" selected =' + "selected" + '> ' + data.nome +
                        ' - Chave: '  + data.id
                        + '</option>');
                }
                else {
                    $("." + data.tipo).append('<option value="' + data.id + '" > ' + data.nome +
                        ' - Chave: ' + data.id
                        + '</option>');
                }
            });
        },
        error: function (ex) {
            alert('Falha ao buscar elementos.' + ex);
        }
    });
}

items.change(function () {
    var x = items[0];
    var y = x.selectedOptions[0].className;
    y = y.replace("~", "../..");

    var visu = document.getElementsByClassName("VisualizarImagem");

    for (var i = 0; i < visu.length; i++) {
        document.getElementsByClassName("VisualizarImagem")[i].innerHTML
            = "<br /> <img src='" + y
            + "' style='max-width: 100%;' /> <br />";
    }

});



$("#PaginaId").val(numero);

$(".pastas").empty();
$(".pastas").append('<option value="">Escolher pasta para as imagens</option>');


$.ajax({
    type: 'POST',
    url: '/AjaxGet/GetPastas',
    dataType: 'json',
    data: { Pagina: numero }
})
    .done(function (response) {

        $.each(response, function (i, response) {
            $(".pastas").append('<option  value="' +
                response.id + '">' + response.nome + ' - Chave: ' + response.id +'</option>');
        });

    });


$.ajax({
    type: 'POST',
    url: '/AjaxGet/GetBackgrounds',
    dataType: 'json',
    data: { PaginaId: numero }
})
    .done(function (response) {
        var obj = response;
        $(".background").empty();
        $.each(obj, function (i, obj) {            
            $(".background").append('<option value="'
                + obj.id + '">'
                + obj.nome + ' - Chave: ' + obj.id +'</option>');

        });

    });

$.ajax({
    type: 'POST',
    url: '/AjaxGet/GetBackgrounds',
    dataType: 'json',
    data: { PaginaId: numero  }
})
    .done(function (response) {
        var obj = response;
        $(".backgroundSelected").empty();
        $.each(obj, function (i, obj) {

            if (parseInt($("#selecionado").val()) === obj.id) {
                $(".backgroundSelected").append('<option value="'
                    + obj.id + '" selected =' + "selected" + '>'
                    + obj.nome + ' - Chave: ' + obj.id + '</option>');

            }
            else {
                $(".backgroundSelected").append('<option value="'
                    + obj.id + '">'
                    + obj.nome + ' - Chave: ' + obj.id + '</option>');
            }

            

        });

    });


$.ajax({
    type: 'POST',
    url: '/AjaxGet/GetBackgrounds',
    dataType: 'json',
    data: { PaginaId: numero }
})
    .done(function (response) {
        var obj = response;
        $(".backgroundGradiente").empty();

        
        $.each(obj, function (i, obj) {

            if (obj.tipo === "BackgroundGradiente")
            $(".backgroundGradiente").append('<option value="'
                + obj.id + '">'
                + obj.nome + ' - Chave: ' + obj.id +'</option>');

        });

    });

$(".backgroundGradiente").click(function () {

    $.ajax({
        type: 'POST',
        url: '/AjaxGet/GetCores',
        dataType: 'json',
        data: { Background: $(this).val() },
        success: function (data) {
            $(".CoresBackground").empty();
            $.each(data, function (i, data) {                
                $(".CoresBackground").append('<option value="'
                    + data.id + '">'
                    + data.corBackground + ' - Chave: '+ data.id +'</option>');
            });
        },
        error: function (ex) {
            alert('Falha ao buscar cores.' + ex);
        }
    });
    return false;
});


//$(".pastas").change(function () {

//    $.ajax({
//        type: 'POST',
//        url: '/AjaxGet/Elementos',
//        dataType: 'json',
//        data: { Pagina: numero, Tipo: "Imagem" },
//        success: function (data) {
            
//            $(".imagem").empty();

//            if ($("#selecionado").val() !== "") {
//                $(".imagem").append('<option value="">Escolher uma imagem</option>');
//            }
            

//            $.each(data, function (i) { 

//                if (i === data.length / 2) return false;

//                if ($("#selecionado").val() !== "" &&
//                    parseInt($("#selecionado").val()) === data[i]) {
//                    $(".imagem").append('<option class="' + data[data.length / 2 + i] + '" value="'
//                        + data[i] + '" ' + '" selected =' + "selected" + '> - Chave: ' + data[i]
//                        + '</option>');
//                }
//                else {
//                    $(".imagem").append('<option class="' + data[data.length / 2 + i] + '" value="'
//                    + data[i] + '" > - Chave: ' + data[i]
//                    + '</option>'); 
//                }
//            });
//        },
//        error: function (ex) {
//            alert('Falha ao buscar imagens.' + ex);
//        }
//    });
//    return false;
//});


$.ajax({
    type: 'POST',
    url: '/AjaxGet/GetPaginas',
    dataType: 'json',
    data: { Pagina: numero },
    success: function (data) {
        $(".pagina").empty();

        if ($("#selecionadoPagina").val() === "") {
            $(".pagina").append('<option value="">[Selecione  uma pagina..]</option>');
        }

        
        $.each(data, function (i, data) {

            if ($("#selecionadoPagina").val() !== "" &&
                parseInt($("#selecionadoPagina").val()) === data[i]) {
                $(".pagina").append('<option value="'
                    + data.id + '" ' + '" selected =' + "selected" + '>'
                    + data.titulo + ' - Chave: ' + data.id + '</option>');
            }
            else {
                $(".pagina").append('<option value="'
                    + data.id + '" ' +  ' >'
                    + data.titulo + ' - Chave: ' + data.id + '</option>');
            }

            
        });
    },
    error: function (ex) {
        alert('Falha ao buscar paginas.' + ex);
    }
});


$.ajax({
    type: 'POST',
    url: '/AjaxGet/GetSites',
    dataType: 'json',
    data: { Pagina: numero },
    success: function (data) {
        $(".site").empty();

        if ($("#selecionadoPedido").val() === "") {
            $(".site").append('<option value="">[Selecione  uma site..]</option>');
        }

        $.each(data, function (i, data) {

            if ($("#selecionadoPedido").val() !== "" &&
                parseInt($("#selecionadoPedido").val()) === data[i]) {
                $(".site").append('<option value="'
                    + data.id + '" ' + '" selected =' + "selected" + ' >'
                    + data.nome + ' - Chave: ' + data.id + '</option>');
            }
            else {
                $(".site").append('<option value="'
                    + data.id + '" ' + ' >'
                    + data.nome + ' - Chave: ' + data.id + '</option>');
            }

        });
    },
    error: function (ex) {
        alert('Falha ao buscar sites.' + ex);
    }
});





$(".site").change(function () {

    $.ajax({
        type: 'POST',
        url: '/AjaxGet/GetPaginasDoSite',
        dataType: 'json',
        data: { Pedido: $(this).val() },
        success: function (data) {
            $(".pagina").empty();
            $(".pagina").append('<option value="">[Selecione  uma pagina..]</option>');
            $.each(data, function (i, data) {

                $(".pagina").append('<option value="'
                    + data.id + '">'
                    + data.titulo + ' - Chave: ' + data.id + '</option>');
            });
        },
        error: function (ex) {
            alert('Falha ao buscar paginas.' + ex);
        }
    });
    return false;
});


$(".pagina").change(function () {   

    $.ajax({
        type: 'POST',
        url: '/AjaxGet/GetDivs',
        dataType: 'json',
        data: { PaginaId: $(this).val() },
        success: function (data) {
            $(".div").empty();
            $(".div").append('<option value="">[Selecione  um bloco..]</option>');
            $.each(data, function (i, data) {                
                
                $(".div").append('<option value="'
                    + data.id + '">'
                    + data.nome + ' - Chave: ' + data.id + '</option>');
            });
        },
        error: function (ex) {
            alert('Falha ao buscar blocos.' + ex);
        }
    });
    return false;
});


//$.ajax({
//    type: 'POST',
//    url: '/AjaxGet/Elementos',
//    dataType: 'json',
//    data: { Pagina: numero, Tipo: "Texto" },
//    success: function (data) {
//        $(".texto").empty();
//        $(".texto").append('<option value="">[Selecione um texto..]</option>');

//        $.each(data, function (i) {

//            if (i === data.length / 2) return false;

//            $(".texto").append('<option value="'
//                + data[i] + '">'
//                + data[data.length / 2 + i] + ' - Chave: ' + data[i] + '</option>');
//        });
//    },
//    error: function (ex) {
//        alert('Falha ao buscar textos.' + ex);
//    }
//});



//$(".divTexto").change(function () {
//    $.ajax({
//        type: 'POST',
//        url: '/AjaxGet/Elementos',
//        dataType: 'json',
//        data: { Pagina: numero, Tipo: "Texto" },
//        success: function (data) {
//            $(".texto").empty();
//            $(".texto").append('<option value="">[Selecione um texto..]</option>');

//            $.each(data, function (i) {  

//                if (i === data.length / 2) return false;
                
//                $(".texto").append('<option value="'
//                    + data[i] + '">'
//                    + data[data.length / 2 + i] + ' - Chave: ' + data[i] + '</option>');
//            });
//        },
//        error: function (ex) {
//            alert('Falha ao buscar textos.' + ex);
//        }
//    });

//    $(".imagem").empty();
//    $(".imagem").append('<option value="">[Selecione uma imagem..]</option>');

//});

//$(".divTable").click(function () {

//    $(".table").empty();
//    $(".table").append('<option value="">[Selecione  uma tabela...]</option>');

//    $.ajax({
//        type: 'POST',
//        url: '/AjaxGet/Elementos',
//        dataType: 'json',
//        data: { Pagina: numero, Tipo: "Table" },
//        success: function (data) {
//            $.each(data, function (i) {
//                if (i === data.length / 2) return false;

//                $(".table").append('<option value="'
//                    + data[i] + '">'
//                    + data[data.length / 2 + i] + ' - Chave: ' + data[i] + '</option>');
//            });
//        },
//        error: function (ex) {
//            alert('Falha ao buscar tabelas.' + ex);
//        }
//    });
//    return false;
//});

//$("#element").change(function () {

//    $.ajax({
//        type: 'POST',
//        url: '/AjaxGet/Elementos',
//        dataType: 'json',
//        data: { Pagina: numero, Tipo: $(this).val() },
//        success: function (data) {


//            if ($("#element").val() === "Texto") {
//                $("#texto_").empty();
//                $("#texto_").append('<option value="">Escolher um texto</option>');

//                $.each(data, function (i) {
//                    if (i === data.length / 2) return false;

//                    $("#texto_").append('<option value="'
//                        + data[i] + '">'
//                        + data[data.length / 2 + i] + ' - Chave: ' + data[i] + '</option>');
//                });
//                document.getElementById('texto_').disabled = false;
//            }
//            else {
//                document.getElementById('texto_').disabled = true;
//                $("#texto_").empty();
//            }

//            if ($("#element").val() === "Carrossel") {
//                $("#carousel_").empty();
//                $("#carousel_").append('<option value="">Escolher um carrossel</option>');
//                $.each(data, function (i) { 
//                    if (i === data.length / 2) return false;

//                    $("#carousel_").append('<option value="'
//                        + data[i] + '">'
//                        + data[data.length + i] + ' - Chave: ' + data[i] + '</option>');
//                });
//                document.getElementById('carousel_').disabled = false;
//            }
//            else {
//                document.getElementById('carousel_').disabled = true;
//                $("#carousel_").empty();

//            }

//            if ($("#element").val() === "Video") {
//                $("#video_").empty();
//                $("#video_").append('<option value="">Escolher un video</option>');

//                $.each(data, function (i) {
//                    if (i === data.length / 2) return false;

//                    $("#video_").append('<option value="'
//                        + data[i] + '">'
//                        + data[data.length / 2 + i] + ' - Chave: ' + data[i] + '</option>');
//                });
//                document.getElementById('video_').disabled = false;
//            }
//            else {
//                document.getElementById('video_').disabled = true;
//                $("#video_").empty();
//            }

//            if ($("#element").val() === "Imagem") {

//                // busca-se imagens atraves do select pastas
//                // busca-se imagens atraves do select pastas
//                // busca-se imagens atraves do select pastas
//                // busca-se imagens atraves do select pastas              
                
//                document.getElementById('imagem_71').disabled = false;
//            }
//            else {
//                document.getElementById('imagem_71').disabled = true;
//                $("#imagem_71").empty();
//            }

//            if ($("#element").val() === "Link") {
//                $("#link_").empty();
//                $("#link_").append('<option value="">Escolher um Link</option>');

//                $.each(data, function (i) {
//                    if (i === data.length / 2) return false;

//                    $("#link_").append('<option value="'
//                        + data[i] + '">'
//                        + ' - Chave: ' + data[i] +'</option>');
//                });
//                document.getElementById('link_').disabled = false;
//            }
//            else {
//                document.getElementById('link_').disabled = true;
//                $("#link_").empty();
//            }

//            if ($("#element").val() === "Form") {
//                $("#form_").empty();
//                $("#form_").append('<option value="">Escolher um formulario</option>');

//                $.each(data, function (i, data) {
//                    if (i === data.length / 2) return false;

//                    $("#form_").append('<option value="'
//                        + data[i] + '">'
//                        + ' - Chave: ' + data[i]+'</option>');
//                });
//                document.getElementById('form_').disabled = false;
//            }
//            else {
//                document.getElementById('form_').disabled = true;
//                $("#form_").empty();
//            }

//            if ($("#element").val() === "Table") {
//                $("#table_").empty();
//                $("#table_").append('<option value="">Escolher uma tabela</option>');

//                $.each(data, function (i) {
//                    if (i === data.length / 2) return false;

//                    $("#table_").append('<option value="'
//                        + data[i] + '">'
//                        + data[data.length / 2 + i] + ' - Chave: ' + data[i] + '</option>');
//                });
//                document.getElementById('table_').disabled = false;
//            }
//            else {
//                document.getElementById('table_').disabled = true;
//                $("#table_").empty();
//            }

//        },
//        error: function (ex) {
//            alert('Falha ao buscar elementos.' + ex);
//        }
//    });

//});

