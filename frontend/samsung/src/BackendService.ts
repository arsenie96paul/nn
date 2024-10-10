import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person, PersonInterface } from './Models/Person';
import { Address } from './Models/Address';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BackendService {
  private apiUrl = 'https://localhost:7106';

  constructor(private http: HttpClient) {}


  async getAllPersons(): Promise<Person[]> {
    try {
      const data = await this.http.get<Array<PersonInterface>>(`${this.apiUrl}/persons/all`).toPromise();
      console.log(data);
      return (data || []).map(pers => new Person(pers)); 
    } catch (error) {
      console.error('Error fetching persons:', error);
      throw error; 
    }
  }

  async addPerson(name: string) {
    try {
      return await this.http.post<Person>(`${this.apiUrl}/persons/add`, { name }).toPromise();
    } catch (error) {
      console.error('Error adding person:', error);
      throw error; 
    }
  }

  async getAddressesByPersonId(personId: number) {
    try {
      return await this.http.get<Address[]>(`${this.apiUrl}/address/person/${personId}`).toPromise();
    } catch (error) {
      console.error(`Error fetching addresses for person ID ${personId}:`, error);
      throw error; 
    }
  }

}
