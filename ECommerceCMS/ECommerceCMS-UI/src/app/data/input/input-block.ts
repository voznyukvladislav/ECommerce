import { InputDTO } from "./input-dto";
import { InputGroupDTO } from "./input-group-dto";

export class InputBlockDTO {
    title: string = '';
    inputDTOs: InputDTO[] = [];
    inputGroupDTOs: InputGroupDTO[] = [];

    static isEmpty(inputBlockDTO: InputBlockDTO): boolean {
        if(inputBlockDTO.title && inputBlockDTO.inputDTOs.length != 0) {
            return true;
        } else return false;
    }
}