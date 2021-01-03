

class Elemento {

    Create() {

        if ($("#elemento").val() === "Link") {
            $("#elementosDependentes").val($("#textoLink_").val() + ", ");

            if ($("#imagemLink_").val() !== "")
            {
                $("#elementosDependentes").val($("#elementosDependentes").val() + ", " + $("#imagemLink_").val());
            }
        }       

        if ($("#elemento").val() === "Produto") {
            $("#elementosDependentes").val($("#table_").val() + ", " + $("#imagem_").val() + $("#elementosDependentes").val());
        }

        if ($("#elemento").val() === "Campo") {
            $("#elementosDependentes").val($("#formulario_").val() + ", ");
        }

        if ($("#elemento").val() === "Link" && $("#textoLink_").val() === "" ||
            $("#elemento").val() === "Link" && $("#UrlLink").is(':checked') === false && $("#paginaDestinoLink_").val() === "" ||
            $("#elemento").val() === "Produto" && $("#table_").val() === "" ||
            $("#elemento").val() === "Campo" && $("#formulario_").val() === "" ||
            $("#elemento").val() === "Produto" && $("#imagem_").val() === "") {
            alert("preencha o fommulário corretamente.");
        }
        else
        {
            let data = this.getData();
            this.postElemento(data);  
        }
    }

    Update() {

        if ($("#elemento").val() === "Link") {
            $("#elementosDependentes").val("");

            $("#elementosDependentes").val($("#textoLink_").val() + ", ");

            if ($("#imagemLink_").val() !== "") {
                $("#elementosDependentes").val($("#elementosDependentes").val() + ", " + $("#imagemLink_").val());
            }
        }

        

        let data = this.getData();
        this.editElemento(data);
    }

    getElementos() {

        return {
            Id: itemId,
            Quantidade: novaQuantidade
        };
    }

    getData() {

        var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
        numero = numero.replace('44398', '');

        return {
            IdElemento: $("#IdElemento").val(),
            Pagina_: numero,
            Renderizar: $("#Renderizar").is(':checked'),
            Nome: $("#Nome").val(),
            elemento: $("#elemento").val(),
            elementosDependentes: $("#elementosDependentes").val(),
            ArquivoImagem: $("#ArquivoImagem").val(),
            PastaImagemId: $("#PastaImagemId").val(),
            UrlLink:  $("#UrlLink").is(':checked'),
            Menu:  $("#Menu").is(':checked'),
            textoLink_: $("#textoLink_").val(),
            imagemLink_: $("#imagemLink_").val(),
            paginaDestinoLink_: $("#paginaDestinoLink_").val(),
            TextoLink: $("#TextoLink").val(),
            EstiloTable: $("#EstiloTable").val(),
            PalavrasTexto: $("#textarea").val(),
            ArquivoVideo: $("#ArquivoVideo").val(),
            Preco: $("#Preco").val(),
            estoque: $("#estoque").val(),
            Descricao: $("#Descricao").val(),
            Segmento: $("#Segmento").val(),
            Codigo: $("#Codigo").val(),
            Placeholder: $("#Placeholder").val(),
            TipoCampo: $("#TipoCampo").val(),
            Width: $("#Width").val()

         };
    }

    postElemento(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Elemento/Create',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {

            var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
            numero = numero.replace('44398', '');
            $(".content").load("/Pagina/getview", { id: numero });
            alert("Elemento criado com sucesso!!! " + response);
        });
    }

    editElemento(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Elemento/Edit',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {

            var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
            numero = numero.replace('44398', '');
            $(".content").load("/Pagina/getview", { id: numero });
        });
    }
}

var ScriptElemento = new Elemento();





