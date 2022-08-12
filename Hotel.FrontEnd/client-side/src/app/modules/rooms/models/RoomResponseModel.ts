import { RoomType } from "./enums/RoomType";

export interface RoomResponseModel{
    number: number;
    roomType: RoomType;
    price: number; 
    available: boolean;
    description: string;
    maximumGuests: number;
}