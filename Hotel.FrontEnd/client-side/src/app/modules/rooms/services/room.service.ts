import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BackendService } from 'src/app/shared/services/backend.service';
import { RoomRequestModel } from '../models/RoomRequestModel';
import { RoomResponseModel } from '../models/RoomResponseModel';

@Injectable({
  providedIn: 'root'
})
export class RoomService {
 

  constructor(private backendService:BackendService) { }

  getAllRooms():Observable<RoomResponseModel[]>{
    return this.backendService.GETRequest('Room');
  }

  getRoom(id:string): Observable<RoomResponseModel>{
    return this.backendService.GETRequest('Room/'+id);

  }

  deleteRoom(id:string):Observable<void>{
    return this.backendService.DELETERequest('Room/'+id);
  }

  createRoom(roomModel: RoomRequestModel) : Observable<RoomRequestModel>{
    return this.backendService.POSTRequest('Room', roomModel);
  }

  updateRoom(id:string, roomModel:RoomRequestModel):Observable<RoomRequestModel>{
    return this.backendService.PUTRequest('Room/'+id, roomModel);
  }

}
