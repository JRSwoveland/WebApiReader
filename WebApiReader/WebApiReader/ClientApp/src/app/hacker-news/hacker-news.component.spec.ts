import { async, ComponentFixture, TestBed, inject } from '@angular/core/testing';
import { HackerNewsComponent } from './hacker-news.component';
import { HttpEvent, HttpEventType, HttpClientModule, HttpClient } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { } from 'jasmine';

describe('NewsComponent', () => {
  let component: HackerNewsComponent;
  let fixture: ComponentFixture<HackerNewsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [HackerNewsComponent],
      imports: [HttpClientTestingModule]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HackerNewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h1').textContent;
    expect(titleText).toEqual('Hacker News');
  }));

  it(`should issue a GET request to News controller`, async(inject([HttpClient, HttpTestingController],
    (http: HttpClient, backend: HttpTestingController) => {
      http.get('/api/News').subscribe();

      backend.expectOne({
        url: '/api/News',
        method: 'GET'
      });
    })));

});
