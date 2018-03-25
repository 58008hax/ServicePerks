import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AgmCoreModule } from '@agm/core';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RewardsComponent } from './rewards/rewards.component';
import { CreateEventComponent } from './create-event/create-event.component';
import { EventComponent } from './event/event.component';
import { ProfileComponent } from './profile/profile.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    RewardsComponent,
    CreateEventComponent,
    EventComponent,
    ProfileComponent
  ],
  imports: [
    AgmCoreModule.forRoot({
      apiKey: "AIzaSyDgvuE7VCQJxtG1LFYKQ4Q4S3Z1zmzYzPA",
      libraries: ["places"]
    }),
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'rewards', component: RewardsComponent },
      { path: 'create-event', component: CreateEventComponent },
      { path: 'event', component: EventComponent },
      { path: 'profile', component: ProfileComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
