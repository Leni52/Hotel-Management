import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { AllRoomsComponent } from './modules/rooms/pages/all-rooms/all-rooms.component';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatCardModule} from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatProgressSpinner, MatProgressSpinnerModule} from '@angular/material/progress-spinner';


@NgModule({
  declarations: [
    AppComponent,
    AllRoomsComponent
  ],
  imports: [
    MatCardModule,
    MatDialogModule,
    MatButtonModule,
    MatToolbarModule,
    BrowserAnimationsModule,
   MatProgressSpinnerModule,
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: 'rooms', component:AllRoomsComponent, pathMatch:'full'}
    ]),
    BrowserAnimationsModule
  ],
  exports:[RouterModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
