import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public tabla = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any[]>(baseUrl + 'Factura').subscribe(result => {
      this.tabla = result;
    }, error => console.error(error));
  }
}
