$(document).ready(function () {

    var numero = $(".bloco")[0].baseURI.replace(/[^0-9]/g, '');
    numero = numero.replace('44398', '');
    
    el.click(function () {

        z = event.target;
        y = event.target;
        x = event.target.className;

        if (timer) clearTimeout(timer);
        timer = setTimeout(function () {
            condicao = 1;
        },
            300);
    });

    el.dblclick(function () {
        z = event.target;
        y = event.target;
        x = event.target.className;

        clearTimeout(timer);
        condicao = 2;

    });

    el.mouseover(function () {

        z = event.target;
        y = event.target;
        x = event.target.className;

        if (x !== "" && condicao === 4) {
            y = z;
            
            if (y.tagName === "DIV" && x.includes(substring)) {
                $(".Elemento").css("border", "none");

            }

            while (y !== null && x !== "content") {

                if (y.className === "Elemento grid-item ui-sortable-handle") {
                    $(".Elemento").css("border", "none");
                    var valor = y.id.replace("elemento", "").replace("Pagina" + numero, "");
                    $(".Elemento" + valor).css("display", "block");
                    $(".Elemento" + valor).css("border", "ridge");
                    $(".Elemento" + valor).css("border-width", "2px");
                    
                    $("#ElementoId").load("/Pagina/IdentificacaoElemento?elemento=" + valor);
                    break;
                }


                if (y.tagName === "DIV") {
                    var arr = x.split(" ");

                    for (var i = 0; i <= arr.length; i++) {
                        if (arr[i] === "ClassDiv") {
                            $(".ClassDiv").css("border", "none");
                            valor = y.id.replace("DIV", "").replace("Pagina" + numero, "");
                            $("#" + y.id).css("display", "block");
                            $("#" + y.id).css("border", "ridge");
                            $("#" + y.id).css("border-width", "10px");
                            $("#Bloco").load("/Pagina/IdentificacaoBloco?div=" + valor);
                            $("#QuantidadeElementos").load("/Pagina/QuantidadeBloco?div=" + valor);
                        }
                    }
                    
                    break;
                }

                y = y.parentElement;

            }

        }

    });

    el.mouseout(function () {

        z = event.target;
        y = event.target;
        x = event.target.className;


        if (y.className === "content" ||
            y.className === "bloco" ||
            y.className === "Conteudo") {
            condicao = 4;
            $(".remover").fadeOut("slow");
            $(".ClassDiv").css("border", "none");
            $(".grid-item").css("border", "none");
        }

    });

    setInterval(verifica, 1000);

    function EditModalBorda(idElemento) {
        
        $("#conteudomodal").load("/Elemento/Edit/" + idElemento);
        condicao = 0;
    }

    function verifica() {

        if (condicao !== 0) {

            if (condicao === 1) {


                if (y.tagName === "DIV" && x.includes(substring)) {
                    var id = $("#" + y.id).data("value");

                    condicao = 0;
                    $("#conteudomodal").load("/Elemento/EditDiv/" + id);
                }

                if (x === "Topo" || x === "Menu" || x === "bloco" || x === "bordaEsquerda" || x === "bordaDireita") {
                     id = $("#" + y.id).data("value");
                    $("#" + y.id).css("border-style", "solid");
                    $("#" + y.id).css("border-width", "5px");
                    $("#" + y.parentElement.id).css("border-style", "solid");
                    $("#" + y.parentElement.id).css("border-width", "5px");
                    condicao = 0;

                    $("#conteudomodal").load("/Ferramenta/EditBackground/" + id);
                }

                if (x === ""
                    || x !== ""
                    || x === "Elemento grid-item"
                    || x === "carousel-inner"
                    || x === "img-responsive"
                    || x === "carousel-item ativo"
                    || x === "img-responsive minhaimg") {
                    y = z;
                    while (y.className !== "content") {


                        if (y.className === "content") {
                            condicao = 0;
                            break;
                        }

                        if (y.className === "Elemento grid-item ui-sortable-handle") {

                            let id = $("#" + y.id).data("value");
                            EditModalBorda(id);
                            condicao = 0;
                            break;
                        }                        

                        y = y.parentElement;

                    }

                }

            }

            if (condicao === 2) {

                alert("condicao igual a 2");
                condicao = 0;

            }


        }


    }



});