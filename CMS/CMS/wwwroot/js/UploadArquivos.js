function uploadFilesVideo(inputId) {

    var input = document.getElementById(inputId);
    var Arquivos = input.files;
    var formData = new FormData();
    $("#arquivoVideo").css("display", "block");

    let token = $('[name=__RequestVerificationToken]').val();

    let headers = {};
    headers['RequestVerificationToken'] = token;

    for (var i = 0; i !== Arquivos.length; i++)
    {
        formData.append("files", Arquivos[i]);
        formData.append("Nome", $("#NomeVideo").val());
        formData.append("Id", $(".bloco")[0].baseURI.replace(/[^0-9]/g, '').replace('44311', ''));
    }

    $.ajax({
        url: "/Upload/SalvarVideo",
        data: formData,
        processData: !1,
        contentType: !1,
        type: "POST",
        headers: headers,
        success: function (data) {
            stopUpdatingProgressIndicator();
            $("#arquivoVideo").css("display", "none");
            alert("Arquivos enviados com sucesso!" + data);
        }
    });
}

function uploadFilesImagem(inputId) {

    var input = document.getElementById(inputId);
    var Arquivos = input.files;
    var formData = new FormData();
    $("#arquivoImagem").css("display", "block");

    let token = $('[name=__RequestVerificationToken]').val();

    let headers = {};
    headers['RequestVerificationToken'] = token;

    for (var i = 0; i !== Arquivos.length; i++) {
        formData.append("files", Arquivos[i]);
        formData.append("Id", $(".bloco")[0].baseURI.replace(/[^0-9]/g, '').replace('44311', ''));
        formData.append("pasta", $("#PastaImagemId").val());
    }

    $.ajax({
        url: "/Upload/ImageUpload",
        data: formData,
        processData: !1,
        contentType: !1,
        type: "POST",
        headers: headers,
        success: function (data) {
            stopUpdatingProgressIndicator();
            $("#arquivoImagem").css("display", "none"); alert("Arquivos enviados com sucesso!");
        }
    });
}

function uploadFilesMusica(inputId) {

    var input = document.getElementById(inputId);
    var Arquivos = input.files;
    var formData = new FormData();
    $("#arquivoMusica").css("display", "block");

    let token = $('[name=__RequestVerificationToken]').val();

    let headers = {};
    headers['RequestVerificationToken'] = token;

    for (var i = 0; i !== Arquivos.length; i++) {
        formData.append("files", Arquivos[i]);
        formData.append("Id", $(".bloco")[0].baseURI.replace(/[^0-9]/g, '').replace('44311', ''));
    }

    $.ajax({
        url: "/Upload/SalvarMusica",
        data: formData,
        processData: !1,
        contentType: !1,
        type: "POST",
        headers: headers,
        success: function (data) {
            stopUpdatingProgressIndicator();
            $("#arquivoMusica").css("display", "none"); alert("Arquivos enviados com sucesso!");
        }
    });
}

var intervalId;

function stopUpdatingProgressIndicator() { clearInterval(intervalId); }