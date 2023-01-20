import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BackendService } from 'src/app/shared/services/backend.service';
import { ReviewRequestModel } from '../models/ReviewRequestModel';
import { ReviewResponseModel } from '../models/ReviewResponseModel';


@Injectable({
  providedIn: 'root'
})
export class ReviewService { 

  constructor(private backendService:BackendService) {   
   }

  getAllReviewFromRoom(roomId: string):Observable<ReviewResponseModel[]>{
    return this.backendService.GETRequest('Review/Room/' + roomId);
  }

  getReviewById(id:string): Observable<ReviewResponseModel>{
    return this.backendService.GETRequest( 'Review/' + id);

  }

  deleteReview(id:string):Observable<void>{
    return this.backendService.DELETERequest('Review/' + id);
  }

  createReview(reviewModel: ReviewRequestModel) : Observable<ReviewRequestModel>{
    console.log("review model:" , reviewModel)
    return this.backendService.POSTRequest('Review', reviewModel);
  }

  updateReview(id:string, reviewModel:ReviewRequestModel):Observable<ReviewRequestModel>{
    return this.backendService.PUTRequest('Review/' + id, reviewModel);
  }

}
