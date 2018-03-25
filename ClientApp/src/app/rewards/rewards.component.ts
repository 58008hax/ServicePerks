import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-rewards',
  templateUrl: './rewards.component.html',
  styleUrls: ["./rewards.component.css"]
})
export class RewardsComponent {
    public my_cards:any;
    public avail_cards:any;
    public points = 2000;

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

        this.avail_cards = [
            {
                business: "Pierce Dining Hall",
                points: 1000,
                description: "One free meal swipe",
                value: 10
            },
            {
                business: "QDoba",
                points: 400,
                description: "Free side with purchase of a meal",
                value: 4
            },
            {
                business: "Stevens School Store",
                points: 500,
                description: "20% off an order of $10 or more",
                value: 5
            },
            {
                business: "Mamouns",
                points: 500,
                description: "Free medium hummus with purchase of a meal",
                value: 5
            }
        ]
    }
}