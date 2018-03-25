import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent {
    //For use once we have real data
    //id:any;
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

    constructor(private route: ActivatedRoute) {
        //delete once we have real data
        this.route.params.subscribe(params => {
            this.data = JSON.parse(params.data);
            console.log(this.data);
        });
        this.numOfPeople = 7;
        this.date = "Saturday, March 31";
        this.time = "1:30pm - 3:30pm";
        this.points = 200;
        this.description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sit amet porttitor nisi. Mauris a mollis ex. Donec porttitor, sapien non ullamcorper dictum, diam ligula ullamcorper orci, vitae maximus tellus nulla ut dui. Morbi facilisis pretium nulla, eget accumsan quam dictum quis. Mauris imperdiet vestibulum egestas. Nam tempus vestibulum luctus. Nam laoreet faucibus maximus. Etiam tincidunt aliquam nulla, id blandit massa venenatis quis. Proin congue lorem sed nisi elementum, a iaculis nibh volutpat. Maecenas ac aliquam metus. Nam eu velit at odio consequat accumsan id in metus. In at vehicula ipsum.";
        this.location = "Stevens Park, Hoboken, NJ 07030";
        this.lat = 40.744790;
        this.long = -74.025553;
        //For use once we have real data
        /*
        this.route.params.subscribe(params => {
            this.id = params.data;
            console.log(this.id);
        });
        */
    }
}