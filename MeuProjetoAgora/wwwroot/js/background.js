class background {

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
        numero = numero.replace('44398', '');

        return {
            IdBackground: $("#IdBackground").val(),
            Nome: $("#Nome").val(),
            backgroundImage: $("#backgroundImage").is(':checked'),
            backgroundTransparente: $("#backgroundTransparente").is(':checked'),
            Gradiente: $("#Gradiente").is(':checked'),
            Cor: $("#Cor").val(),
            Background_Repeat: $("#Background_Repeat").val(),
            Background_Position: $("#Background_Position").val(),
            PaginaId: numero,
            imagem_: $("#imagem_").val()

        };
    }

    postBack(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Ferramenta/CreateBackground',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {

            var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
            numero = numero.replace('44398', '');
            $(".content").load("/Pagina/getview", { id: numero });
            alert("background criado com sucesso!!! " + response);
        });
    }

    editBack(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Ferramenta/EditBackground',
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

var ScriptBackground = new background();





