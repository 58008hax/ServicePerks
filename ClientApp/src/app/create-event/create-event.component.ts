import { Component, OnInit } from '@angular/core';
import { ElementRef, NgZone, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { } from 'googlemaps';
import { MapsAPILoader } from '@agm/core';

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
    public location:string;
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

    constructor(private mapsAPILoader: MapsAPILoader, private ngZone: NgZone) {}

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
        //do some basic user input checking
        this.eventTitle = this.eventTitleElementRef.nativeElement.value;
        console.log("Event Title: " + this.eventTitle);
        this.startTime = this.startTimeElementRef.nativeElement.value;
        console.log("Start Time: " + this.startTime);
        this.endTime = this.endTimeElementRef.nativeElement.value;
        console.log("End Time: " + this.endTime);
        this.date = this.dateElementRef.nativeElement.value;
        console.log("Date: " + this.date);
        console.log("Location: " + this.location);
        console.log("Lat: " + this.latitude + " Long: " + this.longitude);
        this.description = this.descriptionElementRef.nativeElement.value;
        console.log("Description: " + this.description);
    }
}