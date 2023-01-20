import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllReviewsComponent } from '../../pages/all-reviews/all-reviews.component';
import { CreateReviewComponent } from '../../pages/create-review/create-review.component';
import { EditReviewComponent } from '../../pages/edit-review/edit-review.component';

const routes: Routes = [
  { path: 'rooms/:roomId/reviews', component: AllReviewsComponent },
  {
    path: 'rooms/:roomId/reviews/create',
    component: CreateReviewComponent,
  },
  {
    path: 'rooms/:roomId/reviews/:id/edit',
    component: EditReviewComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReviewRoutingModule { }
