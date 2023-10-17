import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TarefasListComponent } from './tarefas-list/tarefas-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'tarefas', pathMatch: 'full' },
  { path: 'tarefas', component: TarefasListComponent },  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
