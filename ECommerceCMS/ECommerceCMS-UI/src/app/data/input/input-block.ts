import { InputDTO } from "./input-dto";
import { InputGroupDTO } from "./input-group-dto";

export class InputBlockDTO {
    title: string = '';
    inputDTOs: InputDTO[] = [];
    inputGroupDTOs: InputGroupDTO[] = [];
}