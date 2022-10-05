export interface BookingResponseModel {
  id:string;
  roomNumber: number;
  checkIn: Date;
  checkOut: Date;
  numberOfGuests: number;
  totalFee: number;
  otherRequests: string;
}
