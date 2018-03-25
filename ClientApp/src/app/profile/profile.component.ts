import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
    selector: 'app-profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
    public user_profile:any;
    public my_cards:any; // coupons
    public upcoming_items:any; // events
    public num_events = 0;

    private registered_cards:any;
    private all_events:any;
    private redeemed_cards:any;
    private all_vendors;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        var eventCodes = [];
        var cardCodes = [];
        this.upcoming_items = [];
        this.my_cards = [];

        http.get(baseUrl + 'api/users/mattaquiles@gmail.com').subscribe(result => {
            console.log("user: " + result);
            this.user_profile = result;
        });

        http.get(baseUrl + 'api/registered').subscribe(result => {
            this.registered_cards = result;
            for (let card of this.registered_cards) {
                eventCodes.push(card.eventCode);
            }
            console.table(eventCodes);

            http.get(baseUrl + 'api/events').subscribe(result => {
                console.table(result);
                this.all_events = result;
                for (let event of this.all_events) {
                    if(eventCodes.includes(event.id)) {
                        console.log(event);
                        event.eventDate = new Date(event.eventDate).toLocaleDateString("en-US", { weekday: 'long', month: 'long', day: 'numeric' });
                        this.upcoming_items.push(event);
                    }
                }
                console.log(this.upcoming_items);
            });
        });

        http.get(baseUrl + 'api/redeemed').subscribe(result => {
            this.redeemed_cards = result;
            for (let card of this.redeemed_cards) {
                cardCodes.push(card.offerCode);
            }

            http.get(baseUrl + 'api/vendors').subscribe(result => {
                this.all_vendors = result;
                for (let vendor of this.all_vendors) {
                    if(cardCodes.includes(vendor.id)) {
                        this.my_cards.push(vendor);
                    }
                }
            });
        });
    }
}