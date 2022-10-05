import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllRoomsComponent } from '../../pages/all-rooms/all-rooms.component';
import { CreateRoomComponent } from '../../pages/create-room/create-room.component';
import { EditRoomComponent } from '../../pages/edit-room/edit-room.component';

const routes: Routes = [
  {path: 'rooms', component:AllRoomsComponent},
  {path: 'rooms/create', component: CreateRoomComponent},
  {path: 'rooms/:id/edit', component:EditRoomComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoomsRoutingModule { }
