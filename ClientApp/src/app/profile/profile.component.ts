import { Component } from '@angular/core';

@Component({
    selector: 'app-profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
    public user_name = "Thomas Falsone";
    public my_cards:any;
    public used_cards:any;
    public money_saved = 0;
    public upcoming_items:any;
    public past_items:any;
    public user_points = 700;
    public user_total_points = 0;
    public num_events = 0;

    constructor() {
        this.my_cards = [
            {
                business: "Benny Tudinos",
                points: 500,
                description: "Get a free slice of pizza",
                value: 5
            },
            {
                business: "Tally-Ho",
                points: 3000,
                description: "Free two hour happy hour at Tally-Ho",
                value: 30
            },
            {
                business: "Pokebowl",
                points: 500,
                description: "20% off an order of $10 or more",
                value: 5
            },
            {
                business: "Pita Pit",
                points: 700,
                description: "Free regular pita sandwich",
                value: 7
            }
        ]

        this.used_cards = [
            {
                business: "Giovanni's",
                points: 500,
                description: "Get a free slice of pizza",
                value: 5
            },
            {
                business: "Mr L's",
                points: 500,
                description: "$5 off your next haircut",
                value: 5
            }
        ]

        this.used_cards.forEach(card => {
            this.money_saved += card.value;
        });

        this.upcoming_items = [
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

        this.past_items = [
            {
                name: "Hoboken Fun Run",
                date: "Saturday, February 20",
                time: "8:00am - 1:00pm",
                location: "Pier A, Hoboken, NJ 07030",
                points: 500
            },
            {
                name: "Career Fair",
                date: "Wednesday, March 15",
                time: "11:00am - 3:00pm",
                location: "1 Castle Point Ter, Hoboken, NJ 07030",
                points: 400
            }
        ]
        this.past_items.forEach(card => {
            this.user_total_points += card.points;
            this.num_events ++;
        })
        this.user_total_points += this.user_points;
    }
}