

class ElementoDependenteTable {

    Create() {
        let data = this.getData();
        this.postBack(data);
    }

    Update() {
        let data = this.getData();
        this.editBack(data);
    }

    getElementos() {

        return {
            Id: itemId,
            Quantidade: novaQuantidade
        };
    }

    getData() {

        var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
        numero = numero.replace('44311', '');

        return {
            Id: $("#Id").val(),
            Pagina_: numero,
            Nome: $("#Nome").val(),
            tipo: $("#TipoCampo").val(),
            Ordem: $("#Ordem").val(),
            TableId: $("#TableId").val(),
            Placeholder: $("#Placeholder").val(),
            TipoCampo: $("#TipoCampo").val(),
            ElementosDependentes: $("#ElementosDependentes").val(),
            EstiloTabela: $("#EstiloTabela").val()

         };
    }

    postElemento(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Elemento/_Table',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {

            var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
            numero = numero.replace('44311', '');
            $(".content").load("/Pagina/getview", { id: numero });
            alert("Elemento criado com sucesso!!! " + response);
        });
    }

    editElemento(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Elemento/_Table',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {

            var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
            numero = numero.replace('44311', '');
            $(".content").load("/Pagina/getview", { id: numero });
        });
    }
}

var ScriptElemento = new ElementoDependenteTable();





