import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IndexComponent } from './pages/index/index.component';
import { ErrorComponent } from './pages/error/error.component';
import { ModalModule } from './_modal/modal.module';
import { PipesModule } from './pipes/pipes.module';
@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    ErrorComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    ModalModule,
    PipesModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
