import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListBabyEventComponent } from './list-baby-event.component';

describe('ListBabyEventComponent', () => {
  let component: ListBabyEventComponent;
  let fixture: ComponentFixture<ListBabyEventComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListBabyEventComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListBabyEventComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
