export interface AddressInterface {
    addressId: number;
    street: string;
    city: string;
    state: string;
    zipCode: string;
    personId: number; 
  }
  
export class Address implements AddressInterface {
  addressId: number;
  street: string;
  city: string;
  state: string;
  zipCode: string;
  personId: number; 

  constructor(adrInterface: AddressInterface) {
    this.personId = adrInterface.personId;
    this.addressId = adrInterface.addressId;
    this.street = adrInterface.street;
    this.city = adrInterface.city;
    this.state = adrInterface.state;
    this.zipCode = adrInterface.zipCode;
  }
}
