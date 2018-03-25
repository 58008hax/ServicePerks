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
    console.log(card.id);
    this.router.navigate(['/event', {data: card.id}]);
  }

  filterItems() {
    //console.log(this.searchInput);
    this.items = this.cards;
    this.items = this.items.filter((card) => {
      //Initially filter based on name
      var result = card.eventName.toLowerCase().indexOf(this.searchInput.toLowerCase()) > -1;
      //But if no results are returned, then filter based on location
      if (result == false) {
        result = card.eventLocation.toLowerCase().indexOf(this.searchInput.toLowerCase()) > -1;
      }
      return result;
    });
  }

  popularCompare(a, b) {
    if (a.registered < b.registered) {
      return 1;
    }
    if (a.registered > b.registered) {
      return -1;
    }
    return 0;
  }

  upcomingCompare(a, b) {
    if (a.eventDate < b.eventDate) {
      return -1;
    }
    if (a.eventDate > b.eventDate) {
      return 1;
    }
    return 0;
  }

  filterBy(option:string) {
    if (option == "popular") {
      this.items.sort(this.popularCompare);
    }
    if (option == "upcoming") {
      this.items.sort(this.upcomingCompare);
    }
  }

}
