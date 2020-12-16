import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filtroBuscador'
})
export class FiltroBuscadorPipe implements PipeTransform {

  transform(arreglo: any[], texto: string, columna: string): any[] {
    if ( texto === '') { return arreglo; }
    return arreglo.filter(item => {
      return item[columna].toLowerCase().includes(texto.toLowerCase());
    });
  }

}
