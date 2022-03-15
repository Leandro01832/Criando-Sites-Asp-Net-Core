class backgroundImagem {

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

        var data = $("form#formulario").serializeArray();
        
        var formdata = {};
        $(data).each(function (index, obj) {
            formdata[obj.name] = obj.value;
        });

        formdata["PaginaId"] = numero;

        return formdata;
    }

    postBack(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Background/_BackgroundImagem',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {

            var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
            numero = numero.replace('44311', '');
            $(".content").load("/Pagina/getview", { id: numero });
            alert("background criado com sucesso!!! " + response);
        });
    }

    editBack(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Background/_BackgroundImagem',
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

var ScriptBackground = new backgroundImagem();





