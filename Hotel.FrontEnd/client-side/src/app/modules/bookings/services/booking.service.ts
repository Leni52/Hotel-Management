import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BackendService } from 'src/app/shared/services/backend.service';
import { BookingRequestModel } from '../models/BookingRequestModel';
import { BookingResponseModel } from '../models/BookingResponseModel';

@Injectable({
  providedIn: 'root'
})
export class BookingService {  
  constructor(private backendService: BackendService) {    
  }


 getAllBookingsForRoom(roomId:string): Observable<BookingResponseModel[]>{
   console.log(roomId);
  return this.backendService.GETRequest('Booking/booking/'+roomId);
 }

 updateBooking(
  id:string,
  request: BookingRequestModel)
  :Observable<BookingRequestModel>{
    return this.backendService.PUTRequest('Booking/'+id, request);

  }
 
  createBooking(request: BookingRequestModel):Observable<BookingRequestModel>{
    console.log(request);
    return this.backendService.POSTRequest('Booking', request);
  }

  deleteBooking(id:string): Observable<void>{
    return this.backendService.DELETERequest('Booking/'+ id);
  }

  getBookingById(id:string):Observable<BookingResponseModel>{
    return this.backendService.GETRequest('Booking/' +id);
  }


}
