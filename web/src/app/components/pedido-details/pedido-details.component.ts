import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Pedido, } from '../../models/pedido.model';
import { PedidoService } from '../../services/pedido.service';
import { ItemPedido } from '../../models/itemPedido.model';

@Component({
  selector: 'app-pedido-details',
  templateUrl: './pedido-details.component.html',
  styleUrls: ['./pedido-details.component.css'],
})
export class PedidoDetailsComponent implements OnInit {
  @Input() viewMode = false;

  @Input() currentPedido: Pedido = {
    nomeCliente: '',
    emailCliente: ''
  };

  message = '';

  constructor(
    private pedidoService: PedidoService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  itemPedido: ItemPedido = {};

  itensPedido?: ItemPedido[] = [];

  ngOnInit(): void {
    if (!this.viewMode) {
      this.message = '';
      this.getPedido(this.route.snapshot.params['id']);
    }
  }

  getPedido(id: string): void {
    this.pedidoService.getById(id).subscribe({
      next: (data) => {
        this.currentPedido = data;
        this.itensPedido = data.itensPedido
        this.itensPedido?.forEach(element => {
          element.valorProduto = element.valorUnitario
        });
        console.log(data);
      },
      error: (e) => console.error(e)
    });
  }

  updatePedido(): void {
    console.log(this.currentPedido)
    this.pedidoService
      .update(this.currentPedido)
      .subscribe({
        next: (res) => {
          console.log(res);
          window.alert("Pedido Atualizado com Sucesso!")
          this.router.navigate(['/pedidos']);
        },
        error: (e) => console.error(e)
      });
  }

  deletePedido(): void {
    this.pedidoService.delete(this.currentPedido.id).subscribe({
      next: (res) => {
        console.log(res);
        this.router.navigate(['/pedidos']);
      },
      error: (e) => console.error(e)
    });
  }

  addItemPedido() {
    const data = {
      nomeProduto: this.itemPedido.nomeProduto,
      valorProduto: this.itemPedido.valorProduto,
      quantidade: this.itemPedido.quantidade,
    };

    this.itensPedido?.push(data);
    this.itemPedido = {};
  }
}
