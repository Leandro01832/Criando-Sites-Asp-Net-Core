var numeroPagina = $(".Topo")[0].baseURI.replace(/[^0-9]/g, '');
numeroPagina = numeroPagina.replace('5001', '');

var chat = new signalR.HubConnectionBuilder().withUrl("/streamingHub").build();

$('#message').click(function () {
    if ($('#displayname').val() === '')
    {
        $('#displayname').val(prompt('Digite seu nome:', ''));
    }
    

});

$.ajax({
    type: 'POST',
    url: '/AjaxGet/Mensagens',
    dataType: 'json',
    data: {
        Pagina: numeroPagina
    },
    success: function (data) {

        if (data !== "") {
            $.each(data, function (i, data) {
                $('#discussion').append('<li><strong>' + data.nomeUsuario
                    + '</strong>: ' + data.mensagem + '</li>');
            });
        }
        else { alert('Erro: mensagem não enviada'); }
    },
    error: function (ex) {
        alert('Falha ao fazer leitura das mensagens.' + ex);
    }
});

chat.on("ReceiveMessage", (user, message) => {
    const recuperaMensagem = user + ": " + message;
    const li = document.createElement("li");
    li.textContent = recuperaMensagem;
    document.getElementById("discussion").appendChild(li);
});

chat.start().catch(err => console.error(err.toString()));

$("#sendmessage").click(function () {

    const user = $('#displayname').val();
    const message = $('#message').val();

    $.ajax({
        type: 'POST',
        url: '/AjaxCreate/EnviaMensagem',
        dataType: 'json',
        data: {
            Id: numeroPagina,
            NomeUsuario: $('#displayname').val(),
            Mensagem: $('#message').val()
        },
        success: function (data) {

            if (data !== "") {
                chat.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
                $('#message').val('').focus();
            }
            else { alert('Erro: mensagem não enviada'); }
        },
        error: function (ex) {
            alert('Falha ao enviar mensagem.' + ex);
        }
    });

    return false;

});





