import { useEffect, useState } from "react";
import { Link } from 'react-router-dom';

const Review=({id})=>{

    const [review, setReview]= useState([]);
    useEffect(()=>{
        reviewService.reviewById(id)
        .then(x=>{
            setReview(x);
        })
    })
return(
    <div className="col-md-4 col-sm-6">
    <div id="serv_hover"  className="review">
       
       <div className="review">
          <h3>Review</h3>
          <h4>{review.title}</h4>
          <p>{review.content} </p>
         <Link to={`/addreview/${id}`}> Add another review</Link>                      
       </div>
    </div>
 </div>


)


}

export default Review;