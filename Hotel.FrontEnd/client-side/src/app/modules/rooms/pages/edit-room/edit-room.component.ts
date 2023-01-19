import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationService } from 'src/app/shared/services/confirmation.service';
import { RoomResponseModel } from '../../models/RoomResponseModel';
import { RoomService } from '../../services/room.service';

@Component({
  selector: 'app-edit-room',
  templateUrl: './edit-room.component.html',
  styleUrls: ['./edit-room.component.css']
})
export class EditRoomComponent implements OnInit {
id!:string;
room!: RoomResponseModel;
roomModels: RoomResponseModel[]=[];
editForm:FormGroup;
result!:string;
  

  constructor(public roomService:RoomService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private confirmationService: ConfirmationService) {
      this.editForm = this.formBuilder.group({
        id:[''],
        number:['', Validators.required],
        roomType:[''],
        price:[''],
        available:[''],        
        description: ['', Validators.required],
        maximumGuests: ['', Validators.required]
      });
     }

     ngOnInit(): void {
      this.id = this.route.snapshot.params['id'];
  
      this.roomService.getAllRooms().subscribe((data: RoomResponseModel[]) => {
        this.roomModels = data;
      });
  
      this.roomService
        .getRoom(this.id)
        .subscribe((data: RoomResponseModel) => {
          this.room = data;
          this.editForm.patchValue(data);
        });
    }
  
    onSubmit(formData: { value: RoomResponseModel }) {
      this.confirmationService
        .confirmDialog({
          title: 'Please confirm action',
          message: 'Are you sure you want to update the room?',
          confirmText: 'Yes',
          cancelText: 'No',
        })
        .subscribe((result) => {
          if (result === true) {
            console.log(this.editForm.value);
            this.roomService
            
              .updateRoom(this.id, this.editForm.value)
              .subscribe((res) => {
                this.router.navigateByUrl('/rooms');
                
              });
          }
        });
    }
  }
  