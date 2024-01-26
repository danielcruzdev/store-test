import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pedido } from '../models/pedido.model';

const baseUrl = 'https://localhost:7189/api/Pedido';

@Injectable({
  providedIn: 'root',
})
export class PedidoService {
  constructor(private http: HttpClient) {}

  getAll(): Observable<Pedido[]> {
    return this.http.get<Pedido[]>(baseUrl);
  }

  getById(id: any): Observable<Pedido> {
    return this.http.get<Pedido>(`${baseUrl}/${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post(baseUrl, data);
  }

  update(data: any): Observable<any> {
    return this.http.put(`${baseUrl}`, data);
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`${baseUrl}/?id=${id}`);
  }
}
