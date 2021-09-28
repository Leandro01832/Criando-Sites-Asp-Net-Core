class InfoVenda {
    Create() {
        let data = this.getData();
        this.postDiv(data);
    }

    Update() {
        let data = this.getData();
        this.editDiv(data);
    }

    getData() {

        return {
            Cpf: $("#Cpf").val(),
            Estado: $("#Estado").val(),
            Cidade: $("#Cidade").val(),
            Bairro: $("#Bairro").val(),
            Rua: $("#Rua").val(),
            Numero: $("#Numero").val(),
            Cep: $("#Cep").val()
        };
    }

    postDiv(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/InfoVenda/CadastrarCpf',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {

            alert("cadastro efetuado com sucesso!!! informe tambem dados de entrega.");
            $("#conteudomodal").load("/InfoVenda/CadastrarInfoEntrega/");
            
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

            alert("Dados atualizados com sucesso!!! informe tambem dados de entrega.");
            $("#conteudomodal").load("/InfoVenda/CadastrarInfoEntrega/");

        });
    }
}

var ScriptInfoVenda = new InfoVenda();


