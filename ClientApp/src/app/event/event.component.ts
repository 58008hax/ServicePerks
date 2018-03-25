import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent {
    data:any;

    constructor(private route: ActivatedRoute) {
        this.route.params.subscribe(params => {
            this.data = JSON.parse(params.data);
            console.log(this.data);
        });
    }
}