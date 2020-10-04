let token = $('[name=__RequestVerificationToken]').val();
let headers = {};
headers['RequestVerificationToken'] = token;

$(".btn-Cor").click(function () {

    $.ajax({
        type: 'POST',
        url: '/AjaxCreate/SalvarCor',
        dataType: 'json',
        data:
        {
            BackgroundGradienteId: $("#BackgroundGradienteId").val(),
            Color: $("#CorBackground").val(),
            Position: $("#Position").val(),
            Transparencia: $("#Transparencia").val()
        },
        headers: headers,
        success: function (data) {

            if (data !== "") {
                $("#Hidden1").val(true);
                $(".content").load("/Pagina/getview", { id: numero });

                alert("Cor criada com sucesso!!! " + data);

            }
            else { alert('Erro: Preencha o formulario corretamente'); }


        },
        error: function (ex) {
            alert('Falha na alteração.' + ex);
        }
    });
    return false;
});

$(".btn-back").click(function () {

    $.ajax({
        type: 'POST',
        url: '/AjaxCreate/CriarBackground',
        dataType: 'json',
        data:
        {
            Nome: $("#Nome").val(),
            backgroundImage: $("#backgroundImage").is(':checked'),
            backgroundTransparente: $("#backgroundTransparente").is(':checked'),
            Gradiente: $("#Gradiente").is(':checked'),
            cores: $("#cores").val(),
            Background_Repeat: $("#Background_Repeat").val(),
            Background_Position: $("#Background_Position").val(),
            imagem_: $("#imagem_10").val(),
            pagina: numero,
            Grau: $("#Grau").val()
        },
        headers: headers,
        success: function (data) {

            if (data !== "") {
                $("#Hidden1").val(true);
                $(".content").load("/Pagina/getview", { id: numero });

                alert("plano de fundo criado com sucesso!!! " + data);

            }
            else { alert('Erro: Preencha o formulario corretamente'); }


        },
        error: function (ex) {
            alert('Falha na alteração.' + ex);
        }
    });
    return false;
});

$(".btn-Carousel").click(function () {
    $.ajax({
        type: 'POST',
        url: '/AjaxCreate/SalvarCarousel',
        dataType: 'json',
        data: {
            Div: $("#div_2").val(),
            Nome: $("#Nome").val(),
            CheckCarousel: $("#checkCarousel").val()
        },
        headers: headers,
        success: function (data) {

            if (data !== "") {
                $("#Hidden1").val(true);
                $(".content").load("/Pagina/getview",
                    { id: numero });

                alert("Carrossel criado com sucesso!!! " + data);

            }
            else { alert('Erro: Preencha o formulario corretamente'); }
        },
        error: function (ex) {
            alert('Falha ao alterar elemento.' + ex);
        }
    });
    return false;
}); 

$(".btn-div").click(function () {
    $.ajax({
        type: 'POST',
        url: '/AjaxCreate/CriarDiv',
        dataType: 'json',
        data: { Nome: $("#Nome").val(), background_: $("#background_10").val(), pagina_: numero },
        headers: headers,
        success: function (data) {
            if (data !== "") {

                $("#Hidden1").val(true);
                $(".content").load("/Pagina/getview",
                    { id: numero });

                alert("Bloco criado com sucesso!!! " + data);

            }
            else { alert('Erro: Preencha o formulario corretamente'); }
        },

        error: function (ex) {
            alert('Falha na alteração: ' + ex);
        }
    });
    return false;
});

$(".btn-Elemento").click(function () {

    var valor = null;
    if ($("#element").val() === "Texto") valor = $("#texto_").val();
    if ($("#element").val() === "Video") valor = $("#video_").val();
    if ($("#element").val() === "Imagem") valor = $("#imagem_70").val();
    if ($("#element").val() === "Link") valor = $("#link_").val();
    if ($("#element").val() === "Form") valor = $("#form_").val();
    if ($("#element").val() === "Table") valor = $("#table_").val();
    if ($("#element").val() === "Carrossel") valor = $("#carousel_").val();

    $.ajax({
        type: 'POST',
        url: '/AjaxCreate/RenderizarElemento',
        dataType: 'json',
        data: {
            Id: valor,
            Div: $("#div_50").val()
        },
        headers: headers,
        success: function (data) {

            if (data !== "") {
                $("#Hidden1").val(true);
                $(".content").load("/Pagina/getview",
                    { id: numero });

                alert("Elemento renderizado com sucesso!!!" + data);

            }
            else { alert('Erro: Preencha o formulario corretamente'); }
        },
        error: function (ex) {
            alert('Falha ao alterar elemento.' + ex);
        }
    });
    return false;
});

$(".btn-Link").click(function () {
    $.ajax({
        type: 'POST',
        url: '/AjaxCreate/SalvarLink',
        dataType: 'json',
        data: {
            Div: $("#div_").val(),
            Imagem: $("#imagem_").val(),
            Pagina: $("#pagina_499").val(),
            Texto: $("#texto_").val(),
            Url: $("#Url").is(':checked'),
            CheckLink: $("#checkLink").val(),
            TextoLink: $("#TextoLink").val()
        },
        headers: headers,
        success: function (data) {

            if (data !== "") {
                $("#Hidden1").val(true);
                $(".content").load("/Pagina/getview",
                    { id: numero });

                alert("Link criado com sucesso!!! " + data);

            }
            else { alert('Erro: Preencha o formulario corretamente'); }
        },
        error: function (ex) {
            alert('Falha ao alterar elemento.' + ex);
        }
    });
    return false;
});

$("#CriarPasta").click(function () {
    $.ajax({
        type: 'POST',
        url: '/AjaxCreate/CriarPasta',
        dataType: 'json',
        data: {
            Nome: $("#Nome").val(),
            Pagina: $(".Topo")[0]
                .baseURI.replace(/[^0-9]/g, '')
                .replace('5001', '')
        },
        headers: headers,
        success: function (data) {
            if (data !== "") {
                alert("Pasta criada com sucesso!!! " + data);
                $("#Hidden1").val(true);
                $(".content").load("/Pagina/getview",
                    { id: numero });

            }
            else { alert('Erro: Preencha o formulario corretamente'); }
        },
        error: function (ex) {
            alert('Falha ao criar pasta.' + ex);
        }
    });
    return false;
});

$("#SalvarProd").click(function () {
    $.ajax({
        type: 'POST',
        url: '/AjaxCreate/CriarProduto',
        dataType: 'json',
        data: {
            Descricao: $("#Descricao").val(),
            estoque: $("#estoque").val(),
            Nome: $("#Nome").val(),
            Preco: $("#Preco").val(),
            Table: $("#table_").val(),
            Imagem: $("#imagemProduto").val()
        },
        headers: headers,
        success: function (data) {

            if (data !== "") {
                $("#Hidden1").val(true);
                $(".content").load("/Pagina/getview",
                    { id: numero });

                alert("Produto criado com sucesso!!! " + data);

            }
            else { alert('Erro: Preencha o formulario corretamente'); }
        },
        error: function (ex) {
            alert('Falha na alteração.' + ex);
        }
    });
    return false;
});

$(".btn-Table").click(function () {
    $.ajax({
        type: 'POST',
        url: '/AjaxCreate/SalvarTable',
        dataType: 'json',
        data: {
            Div: $("#div_").val(),
            Nome: $("#Nome").val(),
            Estilo: $("#Estilo").val(),
            CheckTable: $("#checkTable").val()
        },
        headers: headers,
        success: function (data) {

            if (data !== "") {
                $("#Hidden1").val(true);
                $(".content").load("/Pagina/getview",
                    { id: numero });

                alert("Tabela criada com sucesso!!! " + data);

            }
            else { alert('Erro: Preencha o formulario corretamente'); }
        },
        error: function (ex) {
            alert('Falha ao alterar elemento.' + ex);
        }
    });
    return false;
});

$(".btn-Texto").click(function () {
    $.ajax({
        type: 'POST',
        url: '/AjaxCreate/SalvarTexto',
        dataType: 'json',

        data: {
            Div: $("#div_").val(),
            Nome: $("#Nome").val(),
            Palavras: $("#textareaCriar").val(),
            CheckTexto: $("#CheckTexto").val()
        },
        headers: headers,
        success: function (data) {
            if (data !== "") {
                $("#Hidden1").val(true);

                Criar = undefined;
                $(".content").load("/Pagina/getview",
                    { id: numero });

                alert("Texto criado com sucesso!!! " + data);

            }
            else { alert('Erro: Preencha o formulario corretamente'); }
        },
        error: function (ex) {
            alert('Falha ao alterar elemento.' + ex);
        }
    });
    return false;
});

$(".btnAdicionarImagemProduto").click(function () {
    $.ajax({
        type: 'POST',
        url: '/AjaxCreate/AdicionarImagemProduto',
        dataType: 'json',
        data:
        {
            Id: $("#Id").val(),
            Imagem: $("#Imagem").val()
        },
        headers: headers,
        success: function (data) {
        if (data === "") {
            $("#Hidden1").val(true);
            $(".content").load("/Pagina/getview",
                { id: "@Model.div.PaginaId" });

            alert("Imagem para produto criado com sucesso!!!");

        }
        else { alert('Formulario não foi preenchido corretamente'); }


    },
    error: function (ex) {
        alert('Falha ao salvar dados.' + ex);
    }
                });
return false;
});

$(".btnAdicionarImagemCarousel").click(function () {
    $.ajax({
        type: 'POST',
        url: '/AjaxCreate/AdicionarImagemCarousel',
        dataType: 'json',
        data: { Id: $("#Id").val(), Imagem: $("#Imagem").val() },
        headers: headers,
        success: function (data) {
            if (data === "") {
                $("#Hidden1").val(true);
                $(".content").load("/Pagina/getview",
                    { id: numero });

                alert("Imagem para carrossel criada com sucesso!!!");

            }
            else { alert('Formulario não foi preenchido corretamente'); }


        },
        error: function (ex) {
            alert('Falha ao buscar cidades.' + ex);
        }
    });
    return false;
});





$("#InfomarConta").click(function () {

    $.ajax({
        type: 'POST',
        url: '/InfoVenda/CadastrarContaBancaria',
        dataType: 'json',
        data:
        {
            Agencia: $("#Agencia").val(),
            CodigoBanco: $("#CodigoBanco").val(),
            Conta: $("#Conta").val(),
            DVAgencia: $("#DVAgencia").val(),
            DVConta: $("#DVConta").val(),
            TipoConta: $("#TipoConta").val()
        },
        headers: headers,
        success: function (data) {

            if (data !== "") {

                alert(data);

            }
            else { alert('Erro: Preencha o formulario corretamente'); }


        },
        error: function (ex) {
            alert('Falha na alteração.' + ex);
        }
    });
    return false;
});