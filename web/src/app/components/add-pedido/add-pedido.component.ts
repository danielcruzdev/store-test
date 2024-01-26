import { Component } from '@angular/core';
import { Pedido } from '../../models/pedido.model';
import { PedidoService } from '../../services/pedido.service';
import { ItemPedido } from '../../models/itemPedido.model';

@Component({
  selector: 'app-add-pedido',
  templateUrl: './add-pedido.component.html',
  styleUrls: ['./add-pedido.component.css'],
})
export class AddPedidoComponent {
  pedido: Pedido = {
    nomeCliente: '',
    emailCliente: '',
    pago: false,
  };

  itemPedido: ItemPedido = {};

  itensPedido: ItemPedido[] = [];

  submitted = false;

  constructor(private pedidoService: PedidoService) {}

  savePedido(): void {
    if (
      this.pedido.nomeCliente == null ||
      this.pedido.nomeCliente == undefined ||
      this.pedido.nomeCliente.length <= 0 ||
      this.pedido.emailCliente == null ||
      this.pedido.emailCliente == undefined ||
      this.pedido.emailCliente.length <= 0 ||
      this.itensPedido.length <= 0
    ) {
      window.alert(
        'Preencha todos os dados do pedido e inclua pelo menos um item!'
      );
    }

    const data = {
      nomeCliente: this.pedido.nomeCliente,
      emailCliente: this.pedido.emailCliente,
      itensPedido: this.itensPedido,
    };

    this.pedidoService.create(data).subscribe({
      next: (res) => {
        console.log(res);
        this.submitted = true;
        this.itensPedido = []
      },
      error: (e) => console.error(e),
    });
  }

  addItemPedido() {
    const data = {
      nomeProduto: this.itemPedido.nomeProduto,
      valorProduto: this.itemPedido.valorProduto,
      quantidade: this.itemPedido.quantidade,
    };

    this.itensPedido.push(data);
    this.itemPedido = {};
  }

  newPedido(): void {
    this.submitted = false;
    this.pedido = {
      nomeCliente: '',
      emailCliente: '',
      pago: false,
    };

    this.itensPedido = [];
  }

  excluirItemPedido(item: ItemPedido) {
    var index = this.itensPedido.indexOf(item);
    if (index > -1) {
      this.itensPedido.splice(index, 1);
    }
  }
}
