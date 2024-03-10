import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradeMasterComponent } from './grade-master.component';

describe('GradeMasterComponent', () => {
  let component: GradeMasterComponent;
  let fixture: ComponentFixture<GradeMasterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GradeMasterComponent]
    });
    fixture = TestBed.createComponent(GradeMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
