class Carrinho {
    
    
    

    getData(elemento) {
        var caminho = "";
        var controler = $(elemento).id;
        if (controler === "carousel")
        {
            caminho = "";
            return {
                Div: $("#div_2").val(),
                Nome: $("#Nome").val(),
                CheckCarousel: $("#checkCarousel").val() 
            }, caminho;
        }

        if (controler === "table") {
            caminho = "";
            return {
                Div: $("#div_").val(),
                Nome: $("#Nome").val(),
                Estilo: $("#Estilo").val(),
                CheckTable: $("#checkTable").val()
            }, caminho;
        }

        if (controler === "table") {
            caminho = "";
            return {
                Div: $("#div_").val(),
                Nome: $("#Nome").val(),
                Estilo: $("#Estilo").val(),
                CheckTable: $("#checkTable").val()
            }, caminho;
        }

        return {
            Id: itemId,
            Quantidade: novaQuantidade
        };
    }

    postQuantidade(data, endereco) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: endereco,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {
            let itemPedido = response.itemPedido;
            let linhaDoItem = $('[item-id=' + itemPedido.id + ']')
            linhaDoItem.find('input').val(itemPedido.quantidade);
            linhaDoItem.find('[subtotal]').html((itemPedido.subtotal).duasCasas());
            let carrinhoViewModel = response.carrinhoViewModel;
            $('[numero-itens]').html('Total: ' + carrinhoViewModel.itens.length + ' itens');
            $('[total]').html((carrinhoViewModel.total).duasCasas());

            if (itemPedido.quantidade == 0) {
                linhaDoItem.remove();
            }
        });
    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.', ',');
}



