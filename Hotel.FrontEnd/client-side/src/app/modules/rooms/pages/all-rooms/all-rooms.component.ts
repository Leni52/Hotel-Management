import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'src/app/shared/services/confirmation.service';
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

  constructor(public roomService: RoomService,
    private confirmationService: ConfirmationService) {}

  ngOnInit(): void {
    this.roomService.getAllRooms().subscribe((data: RoomResponseModel[]) => {
      this.allRooms = data;
      console.log(data[0].description);

    });
  }

  openDialog(id: string) {
    this.confirmationService
      .confirmDialog({
        title: 'Please confirm action',
        message: 'Are you sure you want to delete the room?',
        confirmText: 'Yes',
        cancelText: 'No',
      })
      .subscribe((result: boolean) => {
        if (result === true) {
          this.roomService.deleteRoom(id).subscribe((res) => {
            this.allRooms = this.allRooms.filter((item) => item.id!== id);
          });
        }
      });
  }
}
