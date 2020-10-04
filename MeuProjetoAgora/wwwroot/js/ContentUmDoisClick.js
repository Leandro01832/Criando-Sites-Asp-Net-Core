$(document).ready(function () {

    

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

                if (y.className === "Elemento grid-item" && !$("#BotaoSalvar").length) {
                    $(".Elemento").css("border", "none");
                    var valor = y.id.replace("elemento", "");
                    $("#" + y.id).css("display", "block");
                    $("#" + y.id).css("border", "ridge");
                    $("#" + y.id).css("border-width", "2px");
                    $("#ElementoId").load("/Pagina/IdentificacaoElemento?elemento=" + valor);
                    break;
                }


                if (y.tagName === "DIV" && !$("#BotaoSalvar").length) {
                    var arr = x.split(" ");

                    for (var i = 0; i <= arr.length; i++) {
                        if (arr[i] === "ClassDiv") {
                            $(".ClassDiv").css("border", "none");
                             valor = y.id.replace("DIV", "");
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
        }

    });

    $(".remover").click(function () {

        var valor = this.id.replace("remover", "");

        $("#conteudomodal").load("/Elemento/Apagar/" + valor);
        condicao = 0;
    });

    setInterval(verifica, 1000);

    function EditModalBorda(idElemento) {
        debugger;
        $("#conteudomodal").load("/EditTools/EditModalElemento/" + idElemento);
        condicao = 0;
    }

    function CreateModal(string) {
        $("#conteudomodal").load("/CreateTools/CreateModal" + string + "?id=" + numero);
        x = "";
        condicao = 0;
    }

    function verifica() {

        if (condicao !== 0) {

            if (condicao === 1) {


                if (y.tagName === "DIV" && x.includes(substring)) {
                    var id = $("#" + y.id).data("value");

                    condicao = 0;
                    $("#conteudomodal").load("/EditTools/EditModalDiv/" + id);
                }

                if (x === "Topo" || x === "Menu" || x === "bloco" || x === "bordaEsquerda" || x === "bordaDireita") {
                     id = $("#" + y.id).data("value");
                    $("#" + y.id).css("border-style", "solid");
                    $("#" + y.id).css("border-width", "5px");
                    $("#" + y.parentElement.id).css("border-style", "solid");
                    $("#" + y.parentElement.id).css("border-width", "5px");
                    condicao = 0;

                    $("#conteudomodal").load("/EditTools/EditModalBackground/" + id);
                }


                if (x === "video grid-item"
                    //  || x == "Textos grid-item"
                    || x === "Link grid-item"
                    || x === "Form grid-item"
                    || x === "Table grid-item") {

                    y = z;
                     id = $("#" + y.id).attr("data-id");
                    EditModalBorda(id);
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

                        if (y.className === "Textos grid-item") {

                            let id = $("#" + y.id).attr("data-id");

                            $("#FormTexto, #estrutura, #Permissao").fadeOut("slow");
                            $("#FormTexto").fadeIn("slow");
                            
                            Criar = undefined;                            
                            $("#FormTexto").load("/EditTools/EditModalTexto/" + id);
                            condicao = 0;
                            break;
                        }

                        if (y.className === "Table grid-item") {
                            let id = $("#" + y.id).attr("data-id");
                            EditModalBorda(id);
                            condicao = 0;
                            break;
                        }

                        if (y.className === "Elemento grid-item") {
                            
                            let id = $("#" + y.id).data("value");
                            EditModalBorda(id);
                            condicao = 0;
                            break;
                        }

                        if (y.className === "Imagem grid-item") {
                            let id = $("#" + y.id).attr("data-id");
                            EditModalBorda(id);
                            condicao = 0;
                            break;
                        }


                        if (y.className === "linhaProduto") {
                            let id = $("#" + y.id).data("value");
                            $("#conteudomodal").load("/EditTools/EditModalProduto/" + id);
                            condicao = 0;
                            break;
                        }

                        y = y.parentElement;

                    }

                }

            }

            if (condicao === 2) {



                if (y.tagName === "DIV" && x.includes(substring)) {
                    CreateModal("Div");

                }

                if (x === "Topo" || x === "Menu" || x === "bordaEsquerda" || x === "bordaDireita" || y.className === "content") {
                    CreateModal("Background");
                }

                if (x === "bloco") {

                    CreateModal("Div");
                }

                if (x === "video grid-item"
                    || x === "Textos grid-item"
                    || x === "img-responsive"
                    || x === "Link grid-item"
                    || x === "Form grid-item"
                    || x === "Table grid-item") {

                    CreateModal("Elemento");
                    x = "";
                }

                if (x === "" && y !== null ||
                    x === "carousel-inner" && y !== null ||
                    x === "carousel-item ativo" && y !== null ||
                    x === "img-responsive minhaimg") {
                    y = z;
                    while (y !== null && y.className !== "content") {
                        y = y.parentElement;
                        if (y.className === "content") {
                            condicao = 0;
                            break;
                        }

                        if (y.className === "Textos grid-item") {

                            CreateModal("Elemento");
                            x = "Textos";
                            break;
                        }

                        if (y.className === "Table grid-item") {

                            CreateModal("Elemento");
                            x = "Textos";
                            break;
                        }

                        if (y.className === "Carrosel grid-item") {

                            CreateModal("Elemento");
                            x = "Carrosel";
                            break;
                        }

                    }

                }

            }


        }


    }



});