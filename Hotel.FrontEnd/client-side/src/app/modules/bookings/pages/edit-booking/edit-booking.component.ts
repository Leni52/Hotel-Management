import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationService } from 'src/app/shared/services/confirmation.service';
import { BookingResponseModel } from '../../models/BookingResponseModel';
import { BookingService } from '../../services/booking.service';

@Component({
  selector: 'app-edit-booking',
  templateUrl: './edit-booking.component.html',
  styleUrls: ['./edit-booking.component.css']
})
export class EditBookingComponent implements OnInit {

  id!:string;
booking!: BookingResponseModel;
bookingModels: BookingResponseModel[]=[];
editForm!:FormGroup;
result!:string;

   

  constructor(public bookingService:BookingService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private confirmationService: ConfirmationService) {
      this.editForm = this.formBuilder.group({
        id:[''],
        checkIn:['', Validators.required],
        checkOut:[''],
        numberOfGuests:[''],
        otherRequests: ['', Validators.required]       
      });
     }

     ngOnInit(): void {
      this.id = this.route.snapshot.params['id'];
  //this.roomId = this.route.snapshot.params['roomId'];
      this.bookingService.getAllBookingsForRoom(this.id).subscribe((data: BookingResponseModel[]) => {
        this.bookingModels = data;
      });
  
      this.bookingService
        .getBookingById(this.id)
        .subscribe((data: BookingResponseModel) => {
          this.booking = data;
          this.editForm.patchValue(data);
        });
    }
  
    onSubmit(formData: { value: BookingResponseModel }) {
      this.confirmationService
        .confirmDialog({
          title: 'Please confirm action',
          message: 'Are you sure you want to update the booking?',
          confirmText: 'Yes',
          cancelText: 'No',
        })
        .subscribe((result) => {
          if (result === true) {
            this.bookingService
              .updateBooking(this.id, this.editForm.value)
              .subscribe((res: any) => {
                this.router.navigateByUrl('/rooms');
              });
          }
        });
    }
}
