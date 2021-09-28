class ContaBancaria {
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
            Agencia: $("#Agencia").val(),
            CodigoBanco: $("#CodigoBanco").val(),
            Conta: $("#Conta").val(),
            DVAgencia: $("#DVAgencia").val(),
            DVConta: $("#DVConta").val(),
            TipoConta: $("#TipoConta").val()
        };
    }

    postDiv(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/InfoVenda/CadastrarContaBancaria',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {

            alert("cadastro efetuado com sucesso!!!");
            
        });
    }

    editDiv(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/InfoVenda/EditarContaBacaria',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {

            alert("Dados atualizados com sucesso!!!");

        });
    }
}

var ScriptContaBancaria = new ContaBancaria();


