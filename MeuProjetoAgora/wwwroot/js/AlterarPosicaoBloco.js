

function AlterarPosicaoBloco() {

    let formData = new FormData();
    $('.linha').find('div').each(function (i) {
        formData.append('numeros', $('.linha').find('div')[i].id.replace('DIV', ''));
    });

    formData.append('id', numero);

    $.ajax(
        {
            url: '/AjaxEdit/AlterarPosicaoBloco',
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

    let formData = new FormData();
    $('.Elemento').each(function (i) {
        formData.append('numeros', $('.Elemento')[i].id.replace('elemento', ''));
    });

    formData.append('id', numero);

    $.ajax(
        {
            url: '/AjaxEdit/AlterarPosicaoElemento',
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


