import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ITarefa } from './model/interface/itarefa';

@Injectable({
  providedIn: 'root'
})
export class TarefaService {
  apiUrl: string;

  header_node = {
    Accept: 'application/json',
    rejectUnauthorized: 'false',
  }

  url_params = new HttpParams()
  .set('rejectUnauthorized', 'false')
  .set('requestCert', 'false')
  .set('insecure', 'true')

  constructor(public http: HttpClient) { 
    this.apiUrl = environment.default_api;

    
  }

  public add(tarefa :ITarefa) {
    return this.http.post(`${this.apiUrl}/Tarefa`, tarefa, { headers: this.header_node});
  }

  public Search(tarefa: ITarefa) {
    return this.http.get<ITarefa[]>(`${this.apiUrl}/Tarefa/${tarefa.descricao}`);
  }


}
