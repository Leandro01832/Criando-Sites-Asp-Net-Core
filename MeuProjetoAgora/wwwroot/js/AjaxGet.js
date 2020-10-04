var items = $(".imagem");
var numero = $(".Topo")[0].baseURI.replace(/[^0-9]/g, '');
numero = numero.replace('44398', '');
var imgs_ = [['']];

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
                response.idPastaImagem + '">' + response.nome + ' - Chave: ' + response.idPastaImagem +'</option>');
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
                + obj.idBackground + '">'
                + obj.nome + ' - Chave: ' + obj.idBackground +'</option>');

        });

    });

$.ajax({
    type: 'POST',
    url: '/AjaxGet/GetSelectedBackgrounds',
    dataType: 'json',
    data: { PaginaId: numero  }
})
    .done(function (response) {
        var obj = response;
        $(".backgroundSelected").empty();
        $.each(obj, function (i, obj) {

            if (parseInt($("#selecionado").val()) === obj.idBackground) {
                $(".backgroundSelected").append('<option value="'
                    + obj.idBackground + '" selected =' + "selected" + '>'
                    + obj.nome + ' - Chave: ' + obj.idBackground + '</option>');

            }
            else {
                $(".backgroundSelected").append('<option value="'
                    + obj.idBackground + '">'
                    + obj.nome + ' - Chave: ' + obj.idBackground + '</option>');
            }

            

        });

    });


$.ajax({
    type: 'POST',
    url: '/AjaxGet/GetBackgroundsGradiente',
    dataType: 'json',
    data: { PaginaId: numero }
})
    .done(function (response) {
        var obj = response;
        $(".backgroundGradiente").empty();
        $.each(obj, function (i, obj) {
            $(".backgroundGradiente").append('<option value="'
                + obj.idBackground + '">'
                + obj.nome + ' - Chave: ' + obj.idBackground +'</option>');

        });

    });


$.ajax({
    type: 'POST',
    url: '/AjaxGet/GetDivs',
    dataType: 'json',
    data: { PaginaId: numero },
    success: function (data) {

        $(".div").empty();
        $(".div").append('<option value="">[Selecione  um bloco..]</option>');

        $.each(data, function (i, data) {
            $(".div").append('<option value="'
                + data.idDiv + '">'
                + data.nome + ' - Chave: ' + data.idDiv + '</option>');
        });
    },
    error: function (ex) {
        alert('Falha ao buscar blocos.' + ex);
    }
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
                    + data.idCor + '">'
                    + data.corBackground + ' - Chave: '+ data.idCor +'</option>');
            });
        },
        error: function (ex) {
            alert('Falha ao buscar cores.' + ex);
        }
    });
    return false;
});


$(".pastas").change(function () {

    $.ajax({
        type: 'POST',
        url: '/AjaxGet/GetImagens',
        dataType: 'json',
        data: { Pasta: $(this).val() },
        success: function (data) {
            
            $(".imagem").empty();
            $(".imagem").append('<option value="">Escolher uma imagem</option>');

            $.each(data, function (i) { 

                if (i === data.length / 2) return false;

                $(".imagem").append('<option class="' + data[data.length / 2 + i] + '" value="'
                    + data[i] + '" > - Chave: ' + data[i]
                    + '</option>'); 

                
                
            });
        },
        error: function (ex) {
            alert('Falha ao buscar imagens.' + ex);
        }
    });
    return false;
});




$(".site").click(function () {    

    $.ajax({
        type: 'POST',
        url: '/AjaxGet/GetPaginas',
        dataType: 'json',
        data: { PedidoId: $(this).val() },
        success: function (data) {
            $(".pagina").empty();
            $(".pagina").append('<option value="">[Selecione  uma pagina..]</option>');
            $.each(data, function (i, data) {                
                
                $(".pagina").append('<option value="'
                    + data.idPagina + '">'
                    + data.titulo + ' - Chave: '+ data.idPagina +'</option>');
            });
        },
        error: function (ex) {
            alert('Falha ao buscar paginas.' + ex);
        }
    });
    return false;
});


$(".site").click(function () {

    $.ajax({
        type: 'POST',
        url: '/AjaxGet/GetPaginas',
        dataType: 'json',
        data: { PedidoId: $(this).val() },
        success: function (data) {
            $(".Getpagina").empty();
            $(".Getpagina").append('<option value="">[Selecione  uma pagina..]</option>');
            $.each(data, function (i, data) {

                $(".Getpagina").append('<option value="'
                    + data.idPagina + '">'
                    + data.titulo + ' - Chave: ' + data.idPagina + '</option>');
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
                    + data.idDiv + '">'
                    + data.nome + ' - Chave: ' + data.idDiv + '</option>');
            });
        },
        error: function (ex) {
            alert('Falha ao buscar blocos.' + ex);
        }
    });
    return false;
});

$(".div").change(function () {
    $.ajax({
        type: 'POST',
        url: '/AjaxGet/GetTexto',
        dataType: 'json',
        data: { DivId: $(this).val() },
        success: function (data) {
            $(".texto").empty();
            $(".texto").append('<option value="">[Selecione um texto..]</option>');

            $.each(data, function (i) {  

                if (i === data.length / 2) return false;
                
                $(".texto").append('<option value="'
                    + data[i] + '">'
                    + data[data.length / 2 + i] + ' - Chave: ' + data[i] + '</option>');
            });
        },
        error: function (ex) {
            alert('Falha ao buscar textos.' + ex);
        }
    });

    $(".imagem").empty();
    $(".imagem").append('<option value="">[Selecione uma imagem..]</option>');

});

$(".div").click(function () {

    $(".table").empty();
    $(".table").append('<option value="">[Selecione  uma tabela...]</option>');

    $.ajax({
        type: 'POST',
        url: '/AjaxGet/GetTable',
        dataType: 'json',
        data: { DivId: $(this).val() },
        success: function (data) {
            $.each(data, function (i) {
                if (i === data.length / 2) return false;

                $(".table").append('<option value="'
                    + data[i] + '">'
                    + data[data.length / 2 + i] + ' - Chave: ' + data[i] + '</option>');
            });
        },
        error: function (ex) {
            alert('Falha ao buscar tabelas.' + ex);
        }
    });
    return false;
});

$("#element").change(function () {

    $.ajax({
        type: 'POST',
        url: '/AjaxGet/GetElementos',
        dataType: 'json',
        data: { DivId: $("#div_51").val(), valor: $("#element").val(), pagina: numero },
        success: function (data) {


            if ($("#element").val() === "Texto") {
                $("#texto_").empty();
                $("#texto_").append('<option value="">Escolher um texto</option>');

                $.each(data, function (i) {
                    if (i === data.length / 2) return false;

                    $("#texto_").append('<option value="'
                        + data[i] + '">'
                        + data[data.length / 2 + i] + ' - Chave: ' + data[i] + '</option>');
                });
                document.getElementById('texto_').disabled = false;
            }
            else {
                document.getElementById('texto_').disabled = true;
                $("#texto_").empty();
            }

            if ($("#element").val() === "Carrossel") {
                $("#carousel_").empty();
                $("#carousel_").append('<option value="">Escolher um carrossel</option>');
                $.each(data, function (i) { 
                    if (i === data.length / 2) return false;

                    $("#carousel_").append('<option value="'
                        + data[i] + '">'
                        + data[data.length + i] + ' - Chave: ' + data[i] + '</option>');
                });
                document.getElementById('carousel_').disabled = false;
            }
            else {
                document.getElementById('carousel_').disabled = true;
                $("#carousel_").empty();

            }

            if ($("#element").val() === "Video") {
                $("#video_").empty();
                $("#video_").append('<option value="">Escolher un video</option>');

                $.each(data, function (i) {
                    if (i === data.length / 2) return false;

                    $("#video_").append('<option value="'
                        + data[i] + '">'
                        + data[data.length / 2 + i] + ' - Chave: ' + data[i] + '</option>');
                });
                document.getElementById('video_').disabled = false;
            }
            else {
                document.getElementById('video_').disabled = true;
                $("#video_").empty();
            }

            if ($("#element").val() === "Imagem") {

                // busca-se imagens atraves do select pastas
                // busca-se imagens atraves do select pastas
                // busca-se imagens atraves do select pastas
                // busca-se imagens atraves do select pastas              
                
                document.getElementById('imagem_71').disabled = false;
            }
            else {
                document.getElementById('imagem_71').disabled = true;
                $("#imagem_71").empty();
            }

            if ($("#element").val() === "Link") {
                $("#link_").empty();
                $("#link_").append('<option value="">Escolher um Link</option>');

                $.each(data, function (i) {
                    if (i === data.length / 2) return false;

                    $("#link_").append('<option value="'
                        + data[i] + '">'
                        + ' - Chave: ' + data[i] +'</option>');
                });
                document.getElementById('link_').disabled = false;
            }
            else {
                document.getElementById('link_').disabled = true;
                $("#link_").empty();
            }

            if ($("#element").val() === "Form") {
                $("#form_").empty();
                $("#form_").append('<option value="">Escolher um formulario</option>');

                $.each(data, function (i, data) {
                    if (i === data.length / 2) return false;

                    $("#form_").append('<option value="'
                        + data[i] + '">'
                        + ' - Chave: ' + data[i]+'</option>');
                });
                document.getElementById('form_').disabled = false;
            }
            else {
                document.getElementById('form_').disabled = true;
                $("#form_").empty();
            }

            if ($("#element").val() === "Table") {
                $("#table_").empty();
                $("#table_").append('<option value="">Escolher uma tabela</option>');

                $.each(data, function (i) {
                    if (i === data.length / 2) return false;

                    $("#table_").append('<option value="'
                        + data[i] + '">'
                        + data[data.length / 2 + i] + ' - Chave: ' + data[i] + '</option>');
                });
                document.getElementById('table_').disabled = false;
            }
            else {
                document.getElementById('table_').disabled = true;
                $("#table_").empty();
            }

        },
        error: function (ex) {
            alert('Falha ao buscar elementos.' + ex);
        }
    });

});

