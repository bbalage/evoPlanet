import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

export const routes: Routes = [

  {
    path: 'home',
    component: HomeComponent
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes,
    {
      enableTracing: false,
    //  scrollPositionRestoration: 'enabled'
    })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
