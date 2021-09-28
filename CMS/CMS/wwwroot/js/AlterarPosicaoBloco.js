

function AlterarPosicaoBloco() {

    let token = $('[name=__RequestVerificationToken]').val();

    let headers = {};
    headers['RequestVerificationToken'] = token;

    let formData = new FormData();
    $('.linha').find('div').each(function (i) {
        formData.append('numeros', $('.linha').find('div')[i].id.replace('DIV', '').replace("Pagina" + numero, ""));
    });

    formData.append('id', numero);

    $.ajax(
        {
            url: '/Elemento/AlterarPosicaoBloco',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {

                if (data !== "") {
                    location.reload();
                }

                else { alert('Você não tem permissão'); }


            },
            headers: headers
        }
    );
}

function AlterarPosicaoElemento() {

    let token = $('[name=__RequestVerificationToken]').val();

    let headers = {};
    headers['RequestVerificationToken'] = token;

    let formData = new FormData();
    $('.Elemento').each(function (i) {
        formData.append('numeros', $('.Elemento')[i].id.replace("elemento", "").replace("Pagina" + numero, ""));
    });

    formData.append('id', numero);

    $.ajax(
        {
            url: '/Elemento/AlterarPosicaoElemento',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {

                if (data !== "") {
                    location.reload();
                }

                else { alert('Você não tem permissão'); }


            },
            headers: headers
        }
    );
}


