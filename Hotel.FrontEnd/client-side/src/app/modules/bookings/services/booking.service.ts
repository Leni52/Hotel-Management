import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BackendService } from 'src/app/shared/services/backend.service';
import { BookingRequestModel } from '../models/BookingRequestModel';
import { BookingResponseModel } from '../models/BookingResponseModel';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private backendApiUrl;
  constructor(private backendService: BackendService) { 
    this.backendApiUrl = 'https://localhost:5001/api/';
  }


 getAllBookingsForRoom(roomId:string): Observable<BookingResponseModel[]>{
   console.log(roomId);
  return this.backendService.GETRequest( this.backendApiUrl + 'Booking/booking/'+roomId);
 }

 updateBooking(
  id:string,
  request: BookingRequestModel)
  :Observable<BookingRequestModel>{
    return this.backendService.PUTRequest(this.backendApiUrl + 'Booking/'+id, request);

  }
 
  createBooking(request: BookingRequestModel):Observable<BookingRequestModel>{
    console.log(request);
    return this.backendService.POSTRequest(this.backendApiUrl + 'Booking', request);
  }

  deleteBooking(bookingId:string, roomId:string): Observable<void>{
    return this.backendService.DELETERequest(this.backendApiUrl + 'Booking/'+ roomId + '/delete/' + bookingId);
  }

  getBookingById(id:string):Observable<BookingResponseModel>{
    return this.backendService.GETRequest(this.backendApiUrl + 'Booking/' +id);
  }


}
