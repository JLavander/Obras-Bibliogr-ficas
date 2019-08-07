import { Component, OnInit } from '@angular/core';
import { AutorService } from '../autor.service';

@Component({
  selector: 'app-autor-listagem',
  templateUrl: './autor-listagem.component.html',
  styleUrls: ['./autor-listagem.component.css']
})
export class AutorListagemComponent implements OnInit {

  //autores: Array<any>;

  constructor(private autorService: AutorService ) { }

  ngOnInit() {
    this.autorService.listar();
  }

  listar() {
    //this.autorService.listar().subscribe(dados => this.autores = dados);
  }


}
