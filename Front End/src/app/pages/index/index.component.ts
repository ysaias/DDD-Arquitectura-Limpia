import { Component, OnInit } from '@angular/core';
import { ProductoService } from '../../services/producto.service';
import { ordenVenta, producto, productos } from '../../models/producto';
import { error } from 'protractor';
import { ModalService } from '../../_modal/modal.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  listProducto: producto[];
  nombre;
  precio;
  cantidad;
  identificador  = 0;

  /* Talonario */
  listOrdenProducto : ordenVenta[];
  obj: ordenVenta;
  constructor(private sProducto: ProductoService,
              private modalService: ModalService) { }

  ngOnInit() {
    this.listar();
    this.listarOrdenVenta();
  }
  listar() {
    this.sProducto.getSelectAll().subscribe(resp=> {
      console.log("respuesta",resp);
      this.listProducto = resp.productosDTO;
    }, error => {
      console.log(error);
    });
  }
  insert() {
    if(this.identificador != 0) {
      this.update(this.identificador);
      return;
    }
    this.sProducto.insert(this.nombre,this.precio +"", this.cantidad+"").subscribe(resp=>{
      console.log("si");
      this.listar();
    }, error=> {
      alert("error al insertar");
    });
  }
  delete(id) {
    let valor = confirm("estas seguro que deseas eliminar el item?" + id);
    if(!valor) {
      return;
    }
    this.sProducto.delete(id).subscribe(resp=> {
      alert("se elimino con exito");
      this.listar();
    });
  }
  get(id) {
    this.identificador = id;
    this.sProducto.get(id).subscribe(resp=> {
      this.nombre = resp.nombre;
      this.precio = resp.precio;
      this.cantidad = resp.cantidad;
    }, error => {
      console.log(error);
    });
  }
  update(id) {
    this.sProducto.update(this.nombre,this.precio +"", this.cantidad+"", id).subscribe(resp=>{
      this.listar();
      this.identificador = 0;
      this.nombre = "";
      this.precio = "";
      this.cantidad = "";
    }, error=> {
      alert("error al update");
    });
  }
  /* orden de venta */
  listarOrdenVenta() {
    this.sProducto.getListOrdenVenta().subscribe(resp=> {
      this.listOrdenProducto = resp.orders;
    }, error => {

    });
  }
  anulado(id) {
    let valor = confirm("estas seguro que deseas anular el item?" + id);
    if(!valor) {
      return;
    }
    this.sProducto.anulado(id).subscribe(resp=> {
      console.log(resp);
      this.listar();
      this.listarOrdenVenta();
    }, error => {
      console.log(error);
    });
  }
  listoDespacho(id) {
    let valor = confirm("estas seguro que deseas preparar para el despacho el item?" + id);
    if(!valor) {
      return;
    }
    this.sProducto.listoDespacho(id).subscribe(resp=> {
      console.log(resp);
      this.listar();
      this.listarOrdenVenta();
    }, error => {
      console.log(error);
    });
  }
  despachado(id) {
    let valor = confirm("estas seguro que deseas despachar el item?" + id);
    if(!valor) {
      return;
    }
    this.sProducto.despachado(id).subscribe(resp=> {
      console.log(resp);
      this.listar();
      this.listarOrdenVenta();
    }, error => {
      console.log(error);
    });
  }
  openModal(id: string, idOrdenVenta) {
    this.sProducto.getOrdenVenta(idOrdenVenta).subscribe(resp=> {
      this.obj = resp;
      console.log(resp);
    }, error => {

    });
    this.modalService.open(id);
  }

  closeModal(id: string) {
    this.modalService.close(id);
  }
}
