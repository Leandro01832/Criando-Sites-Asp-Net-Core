function uploadFiles(inputId) {
    var input = document.getElementById(inputId); var Arquivos = input.files; var formData = new FormData(); $("#imagensGaleria").css("display", "block"); for (var i = 0; i !== Arquivos.length; i++) { formData.append("files", Arquivos[i]); formData.append("Id", $(".Topo")[0].baseURI.replace(/[^0-9]/g, '').replace('5001', '')) }
    $.ajax({ url: "/AjaxCreate/SalvarMusica", data: formData, processData: !1, contentType: !1, type: "POST", success: function (data) { stopUpdatingProgressIndicator(); $("#imagensGaleria").css("display", "none"); alert("Arquivos enviados com sucesso!") } })
}
var intervalId; function stopUpdatingProgressIndicator() { clearInterval(intervalId) }