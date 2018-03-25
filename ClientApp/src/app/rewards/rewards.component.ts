import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-rewards',
  templateUrl: './rewards.component.html',
  styleUrls: ["./rewards.component.css"]
})
export class RewardsComponent {
    public my_cards:any;
    public avail_cards:any;
    public user_points = 700;
    public user_profile;
    baseURL: string;
    httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json; charset=utf-8'
        })
    };

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseURL = baseUrl;
        this.avail_cards = [
            {
                "id":"vendor3",
                "name":"Pokebowl",
                "offer":"20% off order of $10 or more",
                "offerCode":"20perc10",
                "redeemPoints":500,
                "expiration":"2018-04-01T00:00:00",
                "value":5
            }
        ]
        this.http.get(baseUrl + 'api/users/mattaquiles@gmail.com').subscribe(result => {
            console.log("user: " + result);
            this.user_profile = result;
        });

        this.http.get(baseUrl + 'api/vendors').subscribe(result => {
            this.avail_cards = result;
        });

        /*
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
        */
    }

    purchaseCoupon(coupon) {
        this.user_profile.pointsAvailable -= coupon.redeemPoints;
        let data = {
            offerCode: coupon.id,
            email: 'mattaquiles@gmail.com',
            used: false
        };
        this.http.post(this.baseURL + 'api/redeemed', data, this.httpOptions).subscribe(result => {
            console.log(result);
            alert("Coupon successfully purchased!");
        });
    }
}