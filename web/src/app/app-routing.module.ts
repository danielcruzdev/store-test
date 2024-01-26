import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PedidoListComponent } from './components/pedidos-list/pedidos-list.component';
import { PedidoDetailsComponent } from './components/pedido-details/pedido-details.component';
import { AddPedidoComponent } from './components/add-pedido/add-pedido.component';

const routes: Routes = [
  { path: '', redirectTo: 'pedidos', pathMatch: 'full' },
  { path: 'pedidos', component: PedidoListComponent },
  { path: 'pedidos/:id', component: PedidoDetailsComponent },
  { path: 'adicionar', component: AddPedidoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
