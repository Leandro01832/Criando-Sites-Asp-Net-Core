class InfoEntrega {
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
            PesoCaixa: $("#PesoCaixa").val(),
            AlturaCaixa: $("#AlturaCaixa").val(),
            ComprimentoCaixa: $("#ComprimentoCaixa").val(),
            LarguraCaixa: $("#LarguraCaixa").val()            
        };
    }

    postDiv(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/InfoVenda/CadastrarInfoEntrega',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {

            alert("cadastro efetuado com sucesso!!! informe tambem dados de conta bancária.");
            $("#conteudomodal").load("/InfoVenda/CadastrarContaBancaria/");
            
        });
    }

    editDiv(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/InfoVenda/EditarInfoEntrega',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {

            alert("Dados atualizados com sucesso!!! informe tambem dados de conta bancária.");
            $("#conteudomodal").load("/InfoVenda/CadastrarContaBancaria/");

        });
    }
}

var ScriptInfoEntrega = new InfoEntrega();


