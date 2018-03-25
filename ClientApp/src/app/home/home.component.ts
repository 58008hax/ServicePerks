import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public cards:any;

  constructor() {
    //Load most recent events
    this.cards = [
      {
        name: "Park Cleanup", 
        date: "Saturday, March 31",
        time: "3:00pm - 5:00pm",
        location: "Stevens Park, Hoboken, NJ 07030",
        points: 200
      },
      {
        name: "Homeless Shelter", 
        date: "Sunday, April 1",
        time: "1:00pm - 2:00pm",
        location: "The Hoboken Shelter, Hoboken, NJ 07030",
        points: 100
      },
      {
        name: "Boys and Girls Club", 
        date: "Tuesday, April 3",
        time: "6:00pm - 8:00pm",
        location: "Boy's & Girls Club-Hudson County, Hoboken, NJ 07030",
        points: 200
      }
    ]
  }

  goToEvent(card:any) {
    console.log("Event Clicked:");
    console.log(card);
  }


}
