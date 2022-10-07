import * as reviewService from '../services/reviewService';
import { useState, useEffect } from 'react';
import Review from '../components/Review';

const ReviewCatalog = (roomId) => {
    const [reviews, setReviews] = useState([]);

    useEffect(() => {
        reviewService.reviewsForRoom(roomId)
            .then(x => {
                setReviews(x);
            })
    })

    return (
        <div  className="our_room">
         <div className="container">
            <div className="row">
               <div className="col-md-12">
                  <div className="titlepage">
                     <h2>Reviews:</h2>
                     <p>Lorem Ipsum available, but the majority have suffered </p>
                  </div>
               </div>
            </div>
            <div className="row">
              
              {reviews.map(x=><Review key={x.id} id={x.id}></Review>)}        
                         
                </div>
               </div>
            </div>
      
    )

}


export default ReviewCatalog;