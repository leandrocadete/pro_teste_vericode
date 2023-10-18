import { Component, OnInit, ViewChild } from '@angular/core'
import { MatTableDataSource } from '@angular/material/table'
import { ITarefa } from '../model/interface/itarefa'
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { NovaTarefaDialogComponent } from '../nova-tarefa-dialog/nova-tarefa-dialog.component';
import { TarefaService } from '../tarefa.service';
import { FormControl, FormGroup } from '@angular/forms';

const MY_FORMATS = {
  parse: {
    dateInput: 'DD/MM/YYYY', // this is how your date will be parsed from Input
  },
  display: {
    dateInput: 'DD/MM/YYYY', // this is how your date will get displayed on the Input
    monthYearLabel: 'MMMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY'
  }
};

@Component({
  selector: 'app-tarefas-list',
  templateUrl: './tarefas-list.component.html',
  styleUrls: ['./tarefas-list.component.scss'],
  providers: [
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS],
    },
    { provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
  ]
})
export class TarefasListComponent implements OnInit {
  private dialogRef!: MatDialogRef<NovaTarefaDialogComponent>;

  public formSearch: FormGroup = new FormGroup({
    descricao: new FormControl('')
  });

  public columns = ['descricao', 'dataCriacao', 'status'];
  public dataSource: MatTableDataSource<ITarefa>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;


  constructor(private dialog: MatDialog, private tarefaService: TarefaService) {
    this.dataSource = new MatTableDataSource()
  }

  ngOnInit(): void { }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  novaTarefa() {
    this.dialogRef = this.dialog.open(NovaTarefaDialogComponent);
    this.dialogRef.componentInstance.refDialog = this.dialogRef;
  }

  buscar() {
    let tarefaSearch: ITarefa = {
      dataCriacao: "", id: 0, status: 0, descricao: this.formSearch.get('descricao')?.value
    }
    this.tarefaService.Search(tarefaSearch).subscribe(
      {
        next: (resp) => {
          resp.map(t => {
            let index = t.dataCriacao.lastIndexOf(':');
            let dtSubString = t.dataCriacao.substring(0, index);
            //console.log(dtSubString)
            let dt = new Date(dtSubString).toLocaleString();
            
            t.dataCriacao = dt;
          });
          this.dataSource = new MatTableDataSource(resp)
          console.table(resp)
        },
        error: (err) => console.error(err),
        complete: () => console.info("implementar loading ")
      }
    );
  }
}
