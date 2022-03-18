class DivComum {
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
        numero = numero.replace('44311', '');

        var data = $("form#formulario").serializeArray();

        var formdata = {};
        $(data).each(function (index, obj) {
            
            formdata[obj.name] = obj.value;
        });
        
        formdata["Pagina_"] = numero;
        return formdata;
    }

    postDiv(data) {

        data["Id"] = 0;
        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Div/_DivComum',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {

            $("#links-back").show();
            $("#form").css("display", "none");

            $("#numero-back").val(response.replace(/[^0-9]/g, ''));

            var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
            numero = numero.replace('44311', '');
            $(".content").load("/Pagina/getview", { id: numero });
            
            alert("Bloco criado com sucesso!!! " + response);
            
        });
    }

    editDiv(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Div/_DivComum',
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

var div = new DivComum();


