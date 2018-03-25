import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  cards:any;
  items:any;
  searchInput:string;

  constructor(private router: Router) {
    //Load most recent events
    this.cards = [
      {
        id: 1,
        name: "Park Cleanup", 
        date: "Saturday, March 31",
        time: "3:00pm - 5:00pm",
        location: "Stevens Park, Hoboken, NJ 07030",
        points: 200
      },
      {
        id: 2,
        name: "Homeless Shelter", 
        date: "Sunday, April 1",
        time: "1:00pm - 2:00pm",
        location: "The Hoboken Shelter, Hoboken, NJ 07030",
        points: 100
      },
      {
        id: 3,
        name: "Boys and Girls Club", 
        date: "Tuesday, April 3",
        time: "6:00pm - 8:00pm",
        location: "Boy's & Girls Club-Hudson County, Hoboken, NJ 07030",
        points: 200
      }
    ];
    this.items = this.cards;
  }

  goToEvent(card:any) {
    console.log("Event Clicked:");
    console.log(card);
    //delete once we have real data to query
    let cardString = JSON.stringify(card);
    //once we have real data, send card.id instead of cardString
    this.router.navigate(['/event', {data: cardString}]);
  }

  filterItems() {
    //console.log(this.searchInput);
    this.items = this.cards;
    this.items = this.items.filter((card) => {
      //Initially filter based on name
      var result = card.name.toLowerCase().indexOf(this.searchInput.toLowerCase()) > -1;
      //But if no results are returned, then filter based on location
      if (result == false) {
        result = card.location.toLowerCase().indexOf(this.searchInput.toLowerCase()) > -1;
      }
      return result;
    });
  }

}
