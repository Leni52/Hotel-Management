import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllBookingsComponent } from '../../pages/all-bookings/all-bookings.component';
import { CreateBookingComponent } from '../../pages/create-booking/create-booking.component';
import { EditBookingComponent } from '../../pages/edit-booking/edit-booking.component';

const routes: Routes = [
  {path: 'rooms/:roomId/bookings', component: AllBookingsComponent},
  {path: 'rooms/:roomId/bookings/create', component: CreateBookingComponent},
  {path: 'rooms/:roomId/bookings/:id/edit', component: EditBookingComponent}
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookingRoutingModule { }
