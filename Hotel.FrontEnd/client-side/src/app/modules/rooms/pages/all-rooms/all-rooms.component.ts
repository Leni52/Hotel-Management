import { Component, OnInit } from '@angular/core';
import { RoomResponseModel } from '../../models/RoomResponseModel';
import { RoomService } from '../../services/room.service';

@Component({
  selector: 'app-all-rooms',
  templateUrl: './all-rooms.component.html',
  styleUrls: ['./all-rooms.component.css'],
})
export class AllRoomsComponent implements OnInit {
  allRooms: RoomResponseModel[] = [];
  roomTypes: string[] = ['', 'Economic', 'Luxury'];

  constructor(public roomService: RoomService) {}

  ngOnInit(): void {
    this.roomService.getAllRooms().subscribe((data: RoomResponseModel[]) => {
      this.allRooms = data;
      console.log(data);

    });
  }
}
