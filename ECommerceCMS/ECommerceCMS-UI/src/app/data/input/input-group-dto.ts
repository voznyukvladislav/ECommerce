import { InputDTO } from "./input-dto";

export class InputGroupDTO {
    commonValue: string = '';
    commonName: string = '';
    inputDTOs: InputDTO[] = [];
}