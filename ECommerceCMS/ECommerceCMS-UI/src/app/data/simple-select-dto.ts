export class SimpleSelectDTO {
    id: string = "";
    name: string = "";
    isSelected: boolean = false;

    constructor(id: string, name: string) {
        this.id = id;
        this.name = name;
    }

    changeState(): void {
        this.isSelected = !this.isSelected;
    }

    output(): string {
        return `Id: ${this.id}, Name: ${this.name}`;
    }
}