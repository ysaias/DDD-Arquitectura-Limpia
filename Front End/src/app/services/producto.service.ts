import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  url = "https://localhost:44375/api/productoinventario";
  urlOrdenVenta = "https://localhost:44375/api/ordenventa";

  constructor(private http: HttpClient) { }
  getSelectAll() {
    // const headers = this.getHeaders();
    return this.http.get<any>(this.url);
  }
  getHeaders() {
    const header = new HttpHeaders({'Content-Type': 'application/json'});
    return header;
  }
  insert(Nombre, Precio, Cantidad) {
      const obj = {
        Nombre, Precio, Cantidad
      };
      const params = JSON.stringify(obj);
      const headers = this.getHeaders();
      return this.http.post<any>(this.url + "/", params,{headers});
  }
  get(id) {
    return this.http.get<any>(this.url+ "/" + id);
  }
  delete(id) {
    return this.http.delete(this.url + "/" + id );
  }
  update(Nombre, Precio, Cantidad, id) {
    const obj = {
      Nombre, Precio, Cantidad, id
    };
    const params = JSON.stringify(obj);
    const headers = this.getHeaders();
    return this.http.put<any>(this.url + "/", params,{headers});
  }
  getListOrdenVenta() {
    return this.http.get<any>(this.urlOrdenVenta);
  }
  anulado(id) {
    const obj = {
      id
    };
    const params = JSON.stringify(obj);

    const headers = this.getHeaders();
    return this.http.post<any>(this.urlOrdenVenta + "/anullado/" + id, params, {headers});
  }
  listoDespacho(id) {
    const obj = {
      id
    };
    const params = JSON.stringify(obj);

    const headers = this.getHeaders();
    return this.http.post<any>(this.urlOrdenVenta + "/listoparadespacho/" + id, params,{headers});
  }
  despachado(id) {
    const obj = {
      id
    };
    const params = JSON.stringify(obj);

    const headers = this.getHeaders();
    return this.http.post<any>(this.urlOrdenVenta + "/despachado/" + id, params,{headers});
  }
  getOrdenVenta(id) {
    return this.http.get<any>(this.urlOrdenVenta+ "/" + id);
  }
}
