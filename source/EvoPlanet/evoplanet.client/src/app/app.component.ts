import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Planet } from './types';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent  {
  sidebarExpanded: boolean = true;
  constructor(private http: HttpClient) {}



  title = 'evoplanet.client';
}
