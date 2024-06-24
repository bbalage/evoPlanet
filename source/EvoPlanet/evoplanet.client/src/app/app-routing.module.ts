import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SimulatorComponent } from './components/simulator/simulator.component';

export const routes: Routes = [

  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'simulator',
    component: SimulatorComponent
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes,
    {
      enableTracing: false,
    })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
