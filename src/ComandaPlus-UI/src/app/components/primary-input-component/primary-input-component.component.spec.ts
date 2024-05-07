import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrimaryInputComponentComponent } from './primary-input-component.component';

describe('PrimaryInputComponentComponent', () => {
  let component: PrimaryInputComponentComponent;
  let fixture: ComponentFixture<PrimaryInputComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrimaryInputComponentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PrimaryInputComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
