import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { BookingResponseModel } from '../../models/BookingResponseModel';
import { BookingRequestModel } from '../../models/BookingRequestModel';
import { BookingService } from '../../services/booking.service';

@Component({
  selector: 'app-create-booking',
  templateUrl: './create-booking.component.html',
  styleUrls: ['./create-booking.component.css']
})







export class CreateBookingComponent implements OnInit {

  createForm: FormGroup;

  roomId!: string;

  constructor(

    public bookingService: BookingService,

    private route: ActivatedRoute,

    private router: Router,

    private formBuilder: FormBuilder

  ) {

    this.createForm = this.formBuilder.group({

      roomId: [this.route.snapshot.params['roomId']],
       checkIn: new Date(),
       checkOut: new Date(),
       numberOfGuests: 1,
       otherRequests: ['']
     
    });

  }

 
 ngOnInit(): void {
this.roomId = this.route.snapshot.params['roomId'];
console.log(this.roomId); }

 onSubmit(formData: { value: BookingRequestModel }): void {
 this.bookingService.createBooking(formData.value).subscribe((res) => {
 this.router.navigateByUrl('/rooms/' + this.roomId + '/bookings');
 });
 }
}




  

