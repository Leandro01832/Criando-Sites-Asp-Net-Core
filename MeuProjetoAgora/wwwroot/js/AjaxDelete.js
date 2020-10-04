
    let token = $('[name=__RequestVerificationToken]').val();
        let headers = {};
    headers['RequestVerificationToken'] = token;

        jQuery("#ApagarComId").click(function () {
        $.ajax({
            type: 'POST',
            url: '/AjaxDelete/ApagarElemento',
            dataType: 'json',
            data: { id: $("#IdApagar").val() },
            headers: headers,
            success: function (data) {
                if (data !== "") {
                    var numero = $(".Topo")[0].baseURI.replace(/[^0-9]/g, '');
                    numero = numero.replace('5001', '');
                    $("#Hidden1").val(true);
                    $(".content").load("/Pagina/getview", { id: numero });
                    alert("Elemento apagado com sucesso");
                }
                else { alert('Erro: Preencha o formulario corretamente'); }
            },
            error: function (ex) {
                alert('Falha ao alterar elemento.' + ex);
            }
        });
    return false;
});
   