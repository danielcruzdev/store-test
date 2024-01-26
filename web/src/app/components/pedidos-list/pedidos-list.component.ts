import { Component, OnInit } from '@angular/core';
import { Pedido } from '../../models/pedido.model';
import { PedidoService } from '../../services/pedido.service';

@Component({
  selector: 'app-pedidos-list',
  templateUrl: './pedidos-list.component.html',
  styleUrls: ['./pedidos-list.component.css'],
})
export class PedidoListComponent implements OnInit {
  pedidos?: Pedido[];
  currentPedido: Pedido = {};
  currentIndex = -1;
  title = '';

  constructor(private pedidoService: PedidoService) {}

  ngOnInit(): void {
    this.retrievePedidos();
  }

  retrievePedidos(): void {
    this.pedidoService.getAll().subscribe({
      next: (data) => {
        this.pedidos = data;
        console.log(data);
      },
      error: (e) => console.error(e)
    });
  }

  refreshList(): void {
    this.retrievePedidos();
    this.currentPedido = {};
    this.currentIndex = -1;
  }

  setActivePedido(pedido: Pedido, index: number): void {
    this.currentPedido = pedido;
    this.currentIndex = index;
  }
}
