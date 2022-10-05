import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { RoomRequestModel } from '../../models/RoomRequestModel';
import { RoomResponseModel } from '../../models/RoomResponseModel';
import { RoomService } from '../../services/room.service';

@Component({
  selector: 'app-create-room',
  templateUrl: './create-room.component.html',
  styleUrls: ['./create-room.component.css']
})
export class CreateRoomComponent implements OnInit {
 roomModels: RoomResponseModel[] = [];

 defaultRoom: RoomRequestModel={
  number:1,
roomType:1,
price:0,
available: true,
description:'Add some description of the room',
maximumGuests:1
 };

 roomToSubmit:RoomRequestModel={...this.defaultRoom};
 
  constructor(public roomService: RoomService,
    private router: Router) { }

  ngOnInit(): void {
  }

onSubmit(form:NgForm):void{
  if(form.valid){
    this.roomService.createRoom(this.roomToSubmit).subscribe(res=>{
      this.router.navigateByUrl('/rooms');
    });
   } else
    {
console.log("Invalid form.");
    }
  }
}


