import { ItemPedido } from "./itemPedido.model";

export class Pedido {
  id?: number;
  nomeCliente?: string;
  emailCliente?: string;
  pago?: boolean;
  valorTotal?: number;
  itensPedido?: ItemPedido[];
}