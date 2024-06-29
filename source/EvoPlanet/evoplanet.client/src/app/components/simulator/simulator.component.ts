import { HttpClientModule } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SolarSystemService } from '../../services/solar-system/solar-system.service';
import { IdHandler, SolarSystem } from '../../types';

@Component({
  selector: 'app-simulator',
  standalone: true,
  imports: [HttpClientModule],
  templateUrl: './simulator.component.html',
  styleUrls: ['./simulator.component.css'],
  providers: [SolarSystemService]
})
export class SimulatorComponent implements OnInit {
  activatedRoute = inject(ActivatedRoute);
  handler: IdHandler = { id:'' }
  router = inject(Router);
  ngOnInit(): void {
    const solarId: string = this.activatedRoute.snapshot.params['id'];
    this.handler.id = solarId
    this.solarService.getSolarSystemById(this.handler).subscribe(
      {
        next: (item) => {
          this.planetSystem = item;
        }
      }
    );
  }
  planetSystem: SolarSystem = { id: ''  };
  solarService: SolarSystemService = inject(SolarSystemService);


}
