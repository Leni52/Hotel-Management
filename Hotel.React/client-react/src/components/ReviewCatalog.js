import * as reviewService from '../services/reviewService';
import { useState, useEffect } from 'react';
import Review from '../components/Review';
import { useNavigate, useMatch } from "react-router-dom";

const ReviewCatalog = (props) => {
    const [reviews, setReviews] = useState([]);
    const navigate = useNavigate();
   
    const match = useMatch("/reviewCatalog/:roomId");
    
    const z = props;
    const roomId = match.params.roomId;
   
    useEffect(() => {     
        reviewService.reviewsForRoom(roomId)
            .then(x => {
                setReviews(x);
                console.log("HERE",reviews);
            })
    },[])

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