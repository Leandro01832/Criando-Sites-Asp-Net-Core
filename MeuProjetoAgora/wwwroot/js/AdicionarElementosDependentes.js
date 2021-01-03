

$(".AdicionarElementosDependentes").click(function () {
    
    $("#elementosDependentes").val($("#elementosDependentes").val() + $("#elementoEscolhido").val() + ", ");

});