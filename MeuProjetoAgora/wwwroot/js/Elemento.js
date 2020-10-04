

class Elemento {

    Create() {
        let data = this.getData();
        this.postElemento(data);
    }

    Update() {
        let data = this.getData();
        this.postElemento(data);
    }

    getElementos() {

        return {
            Id: itemId,
            Quantidade: novaQuantidade
        };
    }

    getData() {
        return {
            Nome: $("#Nome").val(),
            elemento: $("#elemento").val(),
            div: $("#div").val(),
            div_: $("#div_").val(),
            ArquivoImagem: $("#ArquivoImagem").val(),
            PastaImagemId: $("#PastaImagemId").val(),
            UrlLink: $("#UrlLink").val(),
            textoLink_: $("#textoLink_").val(),
            imagemLink_: $("#imagemLink_").val(),
            paginaDestinoLink_: $("#paginaDestinoLink_").val(),
            TextoLink: $("#TextoLink").val(),
            EstiloTable: $("#EstiloTable").val(),
            PalavrasTexto: $("#PalavrasTexto").val(),
            ArquivoVideo: $("#ArquivoVideo").val()
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

            alert("Elemento criado com sucesso!!! " + response);
        });
    }
}

var ScriptElemento = new Elemento();





