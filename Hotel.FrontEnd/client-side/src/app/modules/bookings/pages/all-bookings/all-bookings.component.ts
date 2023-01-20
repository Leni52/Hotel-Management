import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationService } from 'src/app/shared/services/confirmation.service';
import { BookingResponseModel } from '../../models/BookingResponseModel';
import { BookingService } from '../../services/booking.service';

@Component({
  selector: 'app-all-bookings',
  templateUrl: './all-bookings.component.html',
  styleUrls: ['./all-bookings.component.css']
})
export class AllBookingsComponent implements OnInit {
allBookingsFromRoom: BookingResponseModel[] =[];
  roomId!: string; 
  constructor(
    public bookingService: BookingService,
    private route: ActivatedRoute,
    private router: Router,
    private confirmationService: ConfirmationService
  ) { }

  ngOnInit(): void {
this.roomId = this.route.snapshot.params['roomId'];

this.bookingService
.getAllBookingsForRoom(this.roomId)
.subscribe((data: BookingResponseModel[])=>{
  this.allBookingsFromRoom= data;
  console.log(data);
  console.log("roomId", this.roomId);
});
   
  }

  openDialog(id: string) {
    this.confirmationService
      .confirmDialog({
        title: 'Please confirm action',
        message: 'Are you sure you want to delete the booking?',
        confirmText: 'Yes',
        cancelText: 'No',
      })
      .subscribe((result: boolean) => {     
        if (result === true) {
          this.bookingService.deleteBooking(id).subscribe((res) => {
            this.allBookingsFromRoom = this.allBookingsFromRoom.filter(
              (item) => item.id !== id            
            );            
          });
        }
      });
    }
}
