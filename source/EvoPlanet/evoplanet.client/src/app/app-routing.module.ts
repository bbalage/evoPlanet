import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SimulatorComponent } from './components/simulator/simulator.component';
import { PlanetSystemComponent } from './components/planet-system/planet-system.component';
import { CelestialbodyComponent } from './components/celestialbody/celestialbody.component';

export const routes: Routes = [

  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'simulator',
    component: SimulatorComponent
  },
  {
    path: 'solarsystem',
    component: PlanetSystemComponent
  },
  {
    path: 'celestialbodies',
    component: CelestialbodyComponent
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
