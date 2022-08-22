export interface BookingRequestModel {
    roomId: string;    
    checkIn: Date;
    checkOut: Date;
    numberOfGuests: number;    
    otherRequests: string;
  }
  