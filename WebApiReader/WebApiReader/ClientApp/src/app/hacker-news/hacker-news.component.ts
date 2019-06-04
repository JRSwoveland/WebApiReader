import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-hacker-news',
  templateUrl: '../shared/news.component.html'
})
export class HackerNewsComponent {
  public articles: Article[];
  public source: Source;
  public httpClient: HttpClient;
  
  constructor(http: HttpClient) {
    this.source = {
      title: "Hacker News",
      description: "List of the most recent articles posted to HackerNews.",
      sourceEnum: 1
    };

    this.httpClient = http;
    this.LoadTable('');
  }

  public LoadTable(searchText: string) {

    this.articles = null;

    let params = this.source.sourceEnum.toString();
    if (searchText.length > 0)
      params = params + '/' + searchText;

    this.httpClient.get<Article[]>('api/News/' + params).subscribe(result => {
      this.articles = result;
    }, error => console.error(error));
  }

  onSubmit(event: any) {
    this.LoadTable(event.target.search.value);
  }
}

interface Article {
  title: string;
  url: string;
}

interface Source {
  title: string;
  description: string;
  sourceEnum: number
}

export interface SearchQuery {
  searchText: string;
}
