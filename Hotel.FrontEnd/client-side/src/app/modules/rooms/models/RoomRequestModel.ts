import { RoomType } from "./enums/RoomType";

export interface RoomRequestModel{
number:Number;
roomType:Number;
price:Number;
available: boolean;
description:string;
maximumGuests:Number;
}

