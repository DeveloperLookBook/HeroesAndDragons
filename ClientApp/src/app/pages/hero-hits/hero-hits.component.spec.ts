import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeroHitsComponent } from './hero-hits.component';

describe('HeroHitsComponent', () => {
  let component: HeroHitsComponent;
  let fixture: ComponentFixture<HeroHitsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeroHitsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeroHitsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
