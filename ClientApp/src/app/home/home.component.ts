import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  cards:any;
  items:any;
  searchInput:string;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get(baseUrl + 'api/events').subscribe(result => {
      console.log(result);
      if (result == null) {
        console.log("No events exists");
        return;
      }
      this.cards = result;
      for (let card of this.cards) {
        card.eventDate = new Date(card.eventDate).toLocaleDateString("en-US", { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' });
        console.log(card.eventDate);
      }
      this.items = this.cards;
    });
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
