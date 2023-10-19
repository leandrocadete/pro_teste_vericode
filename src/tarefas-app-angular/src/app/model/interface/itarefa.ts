export interface ITarefa {
    id: number;
    descricao?: string;
    dataCriacao: string;
    status: number;    
}

export enum EStatusTarefa {
    Pendente = 1,
    EmExecucao = 2,
    Finalizada = 3,
    Cancelada = 4
}