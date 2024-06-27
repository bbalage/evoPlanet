import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CelestialbodyComponent } from './celestialbody.component';

describe('CelestialbodyComponent', () => {
  let component: CelestialbodyComponent;
  let fixture: ComponentFixture<CelestialbodyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CelestialbodyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CelestialbodyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
