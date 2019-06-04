"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var hacker_news_component_1 = require("./hacker-news.component");
var http_1 = require("@angular/common/http");
var testing_2 = require("@angular/common/http/testing");
describe('NewsComponent', function () {
    var component;
    var fixture;
    beforeEach(testing_1.async(function () {
        testing_1.TestBed.configureTestingModule({
            declarations: [hacker_news_component_1.HackerNewsComponent],
            imports: [testing_2.HttpClientTestingModule]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = testing_1.TestBed.createComponent(hacker_news_component_1.HackerNewsComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should display a title', testing_1.async(function () {
        var titleText = fixture.nativeElement.querySelector('h1').textContent;
        expect(titleText).toEqual('Hacker News');
    }));
    it("should issue a GET request to News controller", testing_1.async(testing_1.inject([http_1.HttpClient, testing_2.HttpTestingController], function (http, backend) {
        http.get('/api/News').subscribe();
        backend.expectOne({
            url: '/api/News',
            method: 'GET'
        });
    })));
});
//# sourceMappingURL=hacker-news.component.spec.js.map