import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { TopMenuComponent } from './components/top-menu/top-menu.component';
import { SearchBoxComponent } from './components/search-box/search-box.component';
import { BrowserModule } from '@angular/platform-browser';



@NgModule({
  declarations: [
    TopMenuComponent,
    SearchBoxComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule
  ],
  exports: [
    TopMenuComponent,
    SearchBoxComponent
  ]
})
export class SharedModule { }
