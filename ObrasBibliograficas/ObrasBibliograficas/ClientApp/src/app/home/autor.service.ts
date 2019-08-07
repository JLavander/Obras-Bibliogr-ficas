import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Autor } from '../autor';

@Injectable({
  providedIn: 'root'
})
export class AutorService {

  apiUrl = 'http://localhost:52921/api/SampleData/';
  forecasts: any;
  autores: Array<any>;

  constructor(private http: HttpClient) { }

  listar() {
    this.http.get(this.apiUrl + 'ListarAutores')
      .toPromise()
      .then(res => this.autores = res as Array<any>)
  }

  incluir(autor: any) {
    return this.http.post(this.apiUrl + 'IncluirAutor', autor);
  }


}
