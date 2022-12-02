import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { AllRoomsComponent } from './modules/rooms/pages/all-rooms/all-rooms.component';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatCardModule} from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatProgressSpinner, MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { CreateRoomComponent } from './modules/rooms/pages/create-room/create-room.component';
import { EditRoomComponent } from './modules/rooms/pages/edit-room/edit-room.component';
import { FormsModule } from '@angular/forms';
import { ConfirmationComponent } from './shared/pages/confirmation/confirmation.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AllBookingsComponent } from './modules/bookings/pages/all-bookings/all-bookings.component';
import { CreateBookingComponent } from './modules/bookings/pages/create-booking/create-booking.component';
import { EditBookingComponent } from './modules/bookings/pages/edit-booking/edit-booking.component'; 

@NgModule({
  declarations: [
    AppComponent,
    AllRoomsComponent,
    CreateRoomComponent,
    EditRoomComponent,
    ConfirmationComponent,
    AllBookingsComponent,
    CreateBookingComponent,
    EditBookingComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    MatCardModule,
    MatDialogModule,
    MatButtonModule,
    MatToolbarModule,
    BrowserAnimationsModule,
   MatProgressSpinnerModule,
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: 'rooms', component:AllRoomsComponent, pathMatch:'full'},
      {path: 'rooms/create', component: CreateRoomComponent, pathMatch:'full'},
      {path: 'rooms/:id/edit', component:EditRoomComponent, pathMatch:'full'},
      {path: 'rooms/:roomId/bookings', component: AllBookingsComponent, pathMatch:'full'},
      {path: 'rooms/:roomId/bookings/create', component: CreateBookingComponent},
      {path: 'rooms/:roomId/bookings/:id/edit', component: EditBookingComponent}
    ]),
    BrowserAnimationsModule
  ],
  exports:[RouterModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
