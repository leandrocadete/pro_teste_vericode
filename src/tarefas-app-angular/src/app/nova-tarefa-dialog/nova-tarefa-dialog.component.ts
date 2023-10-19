import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { TarefaService } from '../tarefa.service';
import { ITarefa } from '../model/interface/itarefa';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormControl, FormGroup, RequiredValidator, Validators } from '@angular/forms';
@Component({
  selector: 'app-nova-tarefa-dialog',
  templateUrl: './nova-tarefa-dialog.component.html',
  styleUrls: ['./nova-tarefa-dialog.component.scss']
})
export class NovaTarefaDialogComponent implements OnInit {
  public refDialog!: MatDialogRef<NovaTarefaDialogComponent>;
  public formTarefa = new FormGroup({
    descricao: new FormControl('', Validators.required)
  });


  constructor(private tarefaService: TarefaService, private snack: MatSnackBar) { }

  ngOnInit(): void {
    
  }

  public Add() {
    if(!this.formTarefa.valid) {
      this.snack.open("Preencha os campos obrigatórios!", "Ok");
      return;
    }

    let desc = this.formTarefa.get('descricao')?.value;

    let itarefa: ITarefa = {
      id: 0, 
      descricao: desc?.toString(), 
      dataCriacao: (new Date).toISOString(), 
      status: 1
    }

    this.tarefaService.add(itarefa).subscribe(
      {
      next: (resp) => {
        this.snack.open("Nova tarefa solicitada com sucesso!", "Ok", { duration: 5000 });
        console.info(resp);
      },
      error: (err) => {
        console.error(err); 
        this.snack.open("Não foi possível realizar a solicitação de tarefa, tente mais tarde!", "Ok");
        this.refDialog.close();
      },
      complete: () => this.refDialog.close()
    });
  }

}
