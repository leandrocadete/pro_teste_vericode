import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { TarefaService } from '../tarefa.service';
import { ITarefa } from '../model/interface/itarefa';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormControl, FormGroup } from '@angular/forms';
@Component({
  selector: 'app-nova-tarefa-dialog',
  templateUrl: './nova-tarefa-dialog.component.html',
  styleUrls: ['./nova-tarefa-dialog.component.scss']
})
export class NovaTarefaDialogComponent implements OnInit {
  public refDialog!: MatDialogRef<NovaTarefaDialogComponent>;
  public formTarefa = new FormGroup({
    descricao: new FormControl('')
  });


  constructor(private tarefaService: TarefaService, private snack: MatSnackBar) { }

  ngOnInit(): void {
    this.tarefaService.testWeahter().subscribe({
      next: (r) => console.table(r),
      error: (err) => console.error(err),
      complete: () => console.info('Done!')
    });
  }

  public Add() {
    let desc = this.formTarefa.get('descricao')?.value;

    let itarefa: ITarefa = {
      id: 0, 
      descricao: desc?.toString(), 
      data: (new Date).toISOString(), 
      status: 1
    }

    this.tarefaService.add(itarefa).subscribe(
      {
      next: (resp) => {
        this.snack.open("Nova tarefa solicitada com sucesso!", "Ok", { duration: 5000 });
        console.info(resp);
      },
      error: (err) => {
        console.error(err)
      },
      complete: this.refDialog.close
    });
  }

}
