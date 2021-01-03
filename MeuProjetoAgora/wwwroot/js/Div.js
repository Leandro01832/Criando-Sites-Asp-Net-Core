class Div {
    Create() {
        let data = this.getData();
        this.postDiv(data);
    }

    Update() {
        let data = this.getData();
        this.editDiv(data);
    }

    getData() {

        var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
        numero = numero.replace('44398', '');

        return {
            IdDiv: $("#IdDiv").val(),
            Nome: $("#Nome").val(),
            Padding: $("#Padding").val(),
            EixoXBlocoFixado: $("#EixoXBlocoFixado").val(),
            EixoYBlocoFixado: $("#EixoYBlocoFixado").val(),
            Height: $("#Height").val(),
            Colunas: $("#Colunas").val(),
            Desenhado: $("#Desenhado").val(),
            Divisao: $("#Divisao").val(),
            BorderRadius: $("#BorderRadius").val(),
            Ordem: $("#Ordem").val(),
            background_: $("#background_").val(),
            PaginaId: $("#PaginaId").val(),
            Elementos: $("#Elementos").val(),
            Pagina_: numero,
            Fixado: $("#Fixado").is(':checked'),
            EscolherPosicao: $("#EscolherPosicao").is(':checked'),
            PosicaoFixacao: $("#PosicaoFixacao").val(),
            InicioFixacao: $("#InicioFixacao").val(),
        };
    }

    postDiv(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Elemento/CreateDiv',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {

            var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
            numero = numero.replace('44398', '');
            $(".content").load("/Pagina/getview", { id: numero });

            alert("Bloco criado com sucesso!!! " + response);
            
        });
    }

    editDiv(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Elemento/EditDiv',
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

var div = new Div();


