import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent {
    //For use once we have real data
    id:any;
    data:any;
    //Temporary static data:
    numOfPeople:number;
    date:string;
    time:string;
    points:number;
    description:string;
    location:string;
    lat:number;
    long:number;

    constructor(private route: ActivatedRoute, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.lat = 40.745310;
        this.long = -74.026239;
        this.route.params.subscribe(params => {
            this.id = params.data;
            console.log(this.id);
            this.http.get(baseUrl + 'api/events/' + this.id).subscribe(result => {
                if (result == null) {
                    console.log("No event data exists for id " + this.id);
                    return;
                }

                this.data = result;
                this.data.eventDate = new Date(this.data.eventDate).toLocaleDateString("en-US", { weekday: 'long', month: 'long', day: 'numeric' });
                if (this.data.eventLat != undefined && this.data.eventLong != undefined) {
                    this.lat = this.data.eventLat;
                    this.long = this.data.eventLong;
                }
            })
        });
    }
}