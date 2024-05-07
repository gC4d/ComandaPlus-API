import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultMainFormLayoutComponent } from './default-main-form-layout.component';

describe('DefaultMainFormLayoutComponent', () => {
  let component: DefaultMainFormLayoutComponent;
  let fixture: ComponentFixture<DefaultMainFormLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DefaultMainFormLayoutComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DefaultMainFormLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
