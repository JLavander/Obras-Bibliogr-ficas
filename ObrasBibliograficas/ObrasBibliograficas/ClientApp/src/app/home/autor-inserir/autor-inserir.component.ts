import { Component, OnInit } from '@angular/core';
import { Autor } from '../../autor';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AutorService } from '../autor.service';
import { AutorListagemComponent } from '../autor-listagem/autor-listagem.component';

@Component({
  selector: 'app-autor-inserir',
  templateUrl: './autor-inserir.component.html',
  styleUrls: ['./autor-inserir.component.css']
})
export class AutorInserirComponent implements OnInit {

  formulario: FormGroup;
  btnQtdAtivo: boolean = false;
  public quantidadeAtual = 0;
  public quantidadeTotal = 0;
  public quantidadeAInserir = 0;
  public msg = '';
    

  constructor(private service: AutorService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.btnQtdAtivo = true;
    this.configurarFormulario();
  }

  // Método para validar o formulario, se foi digitado alguma coisa
  configurarFormulario() {
    this.formulario = this.formBuilder.group({
      NomeCompleto: [null, Validators.required]
    });
  }

  // Inclusão dos Autores
  incluir() {
      this.atualizarMensagem(1);

    // Chama o servico
    this.service.incluir(this.formulario.value).subscribe(
      res => {
        this.service.listar();
        this.atualizarContador();
        this.bloqueiaCampo();
        this.formulario.reset();
        this.atualizarMensagem(0);
      })
  }

  // Exibir mensagem
  atualizarMensagem(op) {
    if (op == 1)
      this.msg = "Atualizando lista de autores...";
    else
      this.msg = "";
  }


  atualizarContador() {
    this.quantidadeAtual = this.quantidadeAtual + 1;
  }


  // Seta a quantidade de campos a serem cadastrados
  onClickQtd(): void {
    this.quantidadeTotal = this.quantidadeAInserir;
    this.bloqueiaCampo();
  }

  // bloqueia campo após todas as entradas serem realizadas
  bloqueiaCampo() {
    if (this.quantidadeAInserir == 0 || this.quantidadeAtual >= this.quantidadeTotal)
      this.btnQtdAtivo = true;
    else {
      this.btnQtdAtivo = false;
    }
  }



}
