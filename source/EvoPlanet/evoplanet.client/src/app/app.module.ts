import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { PlanetSystemComponent } from './components/planet-system/planet-system.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SimulatorComponent } from './components/simulator/simulator.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';


@NgModule({
  declarations: [
    AppComponent,
    PlanetSystemComponent,
    SimulatorComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, NgbModule, RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
