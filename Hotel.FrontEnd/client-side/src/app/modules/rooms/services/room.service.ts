import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BackendService } from 'src/app/shared/services/backend.service';
import { RoomRequestModel } from '../models/RoomRequestModel';
import { RoomResponseModel } from '../models/RoomResponseModel';

@Injectable({
  providedIn: 'root'
})
export class RoomService {
 
 private backendApiUrl;
  constructor(private backendService:BackendService) {
    this.backendApiUrl = 'https://localhost:5001/api/';
   }

  getAllRooms():Observable<RoomResponseModel[]>{
    return this.backendService.GETRequest(this.backendApiUrl + 'Room');
  }

  getRoom(id:string): Observable<RoomResponseModel>{
    return this.backendService.GETRequest(this.backendApiUrl + 'Room/' + id);

  }

  deleteRoom(id:string):Observable<void>{
    return this.backendService.DELETERequest(this.backendApiUrl + 'Room/' + id);
  }

  createRoom(roomModel: RoomRequestModel) : Observable<RoomRequestModel>{
    console.log("room model:" , roomModel)
    return this.backendService.POSTRequest(this.backendApiUrl + 'Room', roomModel);
  }

  updateRoom(id:string, roomModel:RoomRequestModel):Observable<RoomRequestModel>{
    return this.backendService.PUTRequest(this.backendApiUrl + 'Room/' + id, roomModel);
  }

}
