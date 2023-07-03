export class SimpleDTO {
    id: string = "";
    name: string = "";
    constructor(id: string, name: string) {
        this.id = id;
        this.name = name;
    }

    output(): string {
        return `Id: ${this.id}, Name: ${this.name}`;
    }
}