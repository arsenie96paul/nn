export interface PersonInterface {
  personId: number;
  name: string;
}

export class Person implements PersonInterface {
  personId: number;
  name: string;

  constructor(pInterface: PersonInterface) {
    this.personId = pInterface.personId;
    this.name = pInterface.name;
  }
}
