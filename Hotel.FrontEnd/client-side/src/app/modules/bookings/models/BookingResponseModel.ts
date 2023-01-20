export interface BookingResponseModel {
  id:string;
  roomId: string;
  checkIn: Date;
  checkOut: Date;
  numberOfGuests: number;
  totalFee: number;
  otherRequests: string;
}
