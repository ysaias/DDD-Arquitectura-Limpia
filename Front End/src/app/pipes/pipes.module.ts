import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FiltroBuscadorPipe } from './filtro-buscador.pipe';



@NgModule({
  declarations: [FiltroBuscadorPipe],
  exports: [FiltroBuscadorPipe]
})
export class PipesModule { }
