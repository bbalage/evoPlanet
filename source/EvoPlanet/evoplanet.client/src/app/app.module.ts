import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { PlanetSystemComponent } from './components/planet-system/planet-system.component';
import { AppRoutingModule } from './app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './components/home/home.component';
import { CelestialbodyComponent } from './components/celestialbody/celestialbody.component';

@NgModule({
  declarations: [
    AppComponent,
    PlanetSystemComponent,
    HomeComponent,
    CelestialbodyComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, NgbModule, AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
