export interface RespuestaTopProducto {
    productosDTO: producto[]
}
export interface producto {
    id: string;
    producto_Id: string;
    nombre: string;
    precio: string;
    cantidad: string;
}
export class productos {
    id: string;
    producto_Id: string;
    cantidad: string;
}
export interface ordenVentaHeaders {
    orders: ordenVenta[];
}
export interface ordenVenta {
    id: string;
    codigoFactura: string;
    estado: string;
    productoItems:producto[];
}