import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PlanetSystemComponent } from './planet-system.component';


describe('PlanetSystemComponent', () => {
  let component: PlanetSystemComponent;
  let fixture: ComponentFixture<PlanetSystemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlanetSystemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlanetSystemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
