class Div {
    Create() {
        let data = this.getData();
        this.postDiv(data);
    }

    Update() {
        let data = this.getData();
        this.postDiv(data);
    }

    getData() {

        return {
            Nome: $("#Nome").val(),
            Padding: $("#Padding").val(),
            Height: $("#Height").val(),
            Colunas: $("#Colunas").val(),
            Desenhado: $("#Desenhado").val(),
            Divisao: $("#Divisao").val(),
            BorderRadius: $("#BorderRadius").val(),
            Ordem: $("#Ordem").val(),
            background_: $("#background_").val(),
            PaginaId: $("#PaginaId").val()
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

            alert("Bloco criado com sucesso!!! " + response);
            
        });
    }
}

var div = new Div();


