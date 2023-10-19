import { ITarefa } from "../interface/itarefa";

export class Tarefa implements ITarefa {
    id!: number;
    descricao?: string | undefined;
    dataCriacao!: string;
    status!: number;

    dataCriacaoNumerica!: number;
}