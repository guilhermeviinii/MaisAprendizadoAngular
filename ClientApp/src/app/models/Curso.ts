import { Timestamp } from "rxjs";

export interface Curso {
    id: number;
    alunoid: number;
    nome: string;
    preco: number;
    cargaHoraria: number;
}