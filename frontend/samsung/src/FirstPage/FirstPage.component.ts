import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { BackendService } from 'BackendService';
import { Address } from 'Models/Address';
import { Person } from 'Models/Person';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-first-page',
  standalone: true, 
  imports: [CommonModule, FormsModule], 
  templateUrl: './FirstPage.component.html',
  styleUrls: ['./FirstPage.component.css'], 
})
export class FirstPageComponent implements OnInit {

  persons: Person[] = []; 
  adresses: Address[] = [];
  // newPersonName : string = "";
  constructor(private backendService: BackendService) { }

  async ngOnInit() {
    try {
      this.persons = await this.backendService.getAllPersons(); 

      if (!this.persons.length) {
        console.warn('No persons found.');
      }
    } catch (error) {
      console.error('Failed to load persons:', error); 
    }
  }

  // addPerson() {
  //   console.log("ok");
  // }

  getAdresses(pID: number) {
    const existingAddresses = this.adresses.filter(address => address.personId === pID);

    if (existingAddresses.length > 0) {
      this.adresses = this.adresses.filter(address => address.personId !== pID);
      console.log(`Removed addresses for person ID: ${pID}`);
    } else {
      this.backendService.getAddressesByPersonId(pID).then(addresses => {
        addresses?.forEach(data => {
          this.adresses.push(data);
        });
        console.log(this.adresses);
      }).catch(error => {
        console.error('Failed to fetch addresses:', error);
      });
    }
  }
}
