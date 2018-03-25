import { Component, OnInit, Inject } from '@angular/core';
import { ElementRef, NgZone, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { } from 'googlemaps';
import { MapsAPILoader } from '@agm/core';
import { unescapeIdentifier } from '@angular/compiler';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
    selector: 'app-create-event',
    templateUrl: './create-event.component.html',
    styleUrls: ['./create-event.component.css']
})
export class CreateEventComponent implements OnInit {
    public eventTitle:string;
    public startTime:string;
    public endTime:string;
    public date:string;
    location:string;
    public description:string;

    public latitude: number;
    public longitude: number;
    public searchControl: FormControl;
    public zoom: number;

    @ViewChild("search") public searchElementRef: ElementRef;
    @ViewChild("eventTitle") public eventTitleElementRef: ElementRef;
    @ViewChild("startTime") public startTimeElementRef: ElementRef;
    @ViewChild("endTime") public endTimeElementRef: ElementRef;
    @ViewChild("date") public dateElementRef: ElementRef;
    @ViewChild("description") public descriptionElementRef: ElementRef;

    baseUrl: string;
    httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json; charset=utf-8'
        })
      };

    constructor(private mapsAPILoader: MapsAPILoader, private ngZone: NgZone, private http: HttpClient, @Inject('BASE_URL') baseURL: string, private router: Router) {
        this.baseUrl = baseURL;
    }

    ngOnInit() {
        //set google maps defaults
        this.zoom = 4;
        this.latitude = 39.8282;
        this.longitude = -98.5795;
    
        //create search FormControl
        this.searchControl = new FormControl();
    
        //set current position
        this.setCurrentPosition();
    
        //load Places Autocomplete
        this.mapsAPILoader.load().then(() => {
            let autocomplete = new google.maps.places.Autocomplete(this.searchElementRef.nativeElement, {
                types: ["address"]
            });
            autocomplete.addListener("place_changed", () => {
                this.ngZone.run(() => {
                    //get the place result
                    let place: google.maps.places.PlaceResult = autocomplete.getPlace();
    
                    //verify result
                    if (place.geometry === undefined || place.geometry === null) {
                        return;
                    }
    
                    //set latitude, longitude and zoom
                    this.latitude = place.geometry.location.lat();
                    this.longitude = place.geometry.location.lng();
                    this.location = this.searchElementRef.nativeElement.value;
                    this.zoom = 12;
                });
            });
        });
    }

    private setCurrentPosition() {
        if ("geolocation" in navigator) {
            navigator.geolocation.getCurrentPosition((position) => {
                this.latitude = position.coords.latitude;
                this.longitude = position.coords.longitude;
                this.zoom = 12;
            });
        }
    }

    submit() {
        this.eventTitle = this.eventTitleElementRef.nativeElement.value;
        this.startTime = this.startTimeElementRef.nativeElement.value;
        this.startTime = this.formatTime(this.startTime);
        this.endTime = this.endTimeElementRef.nativeElement.value;
        this.endTime = this.formatTime(this.endTime);
        this.date = this.dateElementRef.nativeElement.value;
        this.description = this.descriptionElementRef.nativeElement.value;
        if (this.location == undefined) {
            this.location = this.searchElementRef.nativeElement.value;
        }
        
        if (this.eventTitle == undefined || this.startTime == undefined || this.endTime == undefined || this.date == undefined || this.location == undefined || this.description == undefined) {
            alert("Please fill out all fields.");
            return;
        }

        let eventData = {
            "eventName": this.eventTitle,
            "startTime": this.startTime,
            "endTime": this.endTime,
            "eventDate": this.date,
            "eventLat": this.latitude,
            "eventLong": this.longitude,
            "eventLocation": this.location,
            "eventDescription": this.description,
            "registered": 0,
            "eventPoints": 300
        };

        console.log(eventData);
        this.http.post(this.baseUrl + 'api/events', eventData, this.httpOptions).subscribe(result => {
            console.log(result);
            this.router.navigate(['/']);
        }, error => {
            console.log("An error occured");
        });
    }

    formatTime(time) {
        var timeString = time;
        var H = +timeString.substr(0, 2);
        var h = H % 12 || 12;
        var ampm = (H < 12 || H === 24) ? "AM" : "PM";
        timeString = h + timeString.substr(2, 3) + ampm;
        return timeString;
    }


}