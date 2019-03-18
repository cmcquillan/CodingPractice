import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBabyEventComponent } from './add-baby-event.component';

describe('AddBabyEventComponent', () => {
  let component: AddBabyEventComponent;
  let fixture: ComponentFixture<AddBabyEventComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddBabyEventComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBabyEventComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
