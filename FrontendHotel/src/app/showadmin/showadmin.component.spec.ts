import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowadminComponent } from './showadmin.component';

describe('ShowadminComponent', () => {
  let component: ShowadminComponent;
  let fixture: ComponentFixture<ShowadminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowadminComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowadminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
