import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JugadorBasicComponentComponent } from './jugador-basic-component.component';

describe('JugadorBasicComponentComponent', () => {
  let component: JugadorBasicComponentComponent;
  let fixture: ComponentFixture<JugadorBasicComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JugadorBasicComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JugadorBasicComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
