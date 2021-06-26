import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  baseUrl: string = "https://localhost:44362/";
  registro: any;
  res: any;
  constructor(private http: HttpClient) {
  }


  onSubmit() {
    var numeDoc = ((document.getElementById('numeDoc') as HTMLInputElement).value);
    var codiEstado = ((document.getElementById('codiEstado') as HTMLInputElement).value);
    var valorFac = ((document.getElementById('valorFac') as HTMLInputElement).value);
    var fechaFac = ((document.getElementById('fechaFac') as HTMLInputElement).value);
    this.registro = {
      numeDoc: numeDoc,
      codiEstado: codiEstado,
      valorFac: valorFac,
      fechaFac: fechaFac
    }
    console.log(this.registro);
    this.http.post<any[]>(this.baseUrl + 'Factura', this.registro).subscribe(result => {
      this.res = result;
      console.log(result);
    }, error => console.error(error));

  }

}
