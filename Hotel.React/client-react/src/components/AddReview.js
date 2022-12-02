import * as reviewService from '../services/reviewService';
import { useNavigate, useMatch } from "react-router-dom";

const AddReview = (props) => {
   const navigate = useNavigate();
   const match = useMatch("/addreview/:id");

   const onSubmitHandler = (e) => {


      e.preventDefault();
      let formData = new FormData(e.currentTarget);

      let { content, title } = Object.fromEntries(formData);

      const roomId = match.params.id;

      reviewService.addReview(roomId, content, title)
         .then(navigate("/"));

   }

   return (

    <div className="contact">
    <div className="container">
       <div className="row">
          <div className="col-md-6">
             <form id="request" className="main_form" onSubmit={onSubmitHandler}>
                <div className="row">

                  
                   <div className="col-md-12">
                   <label>Title</label>
                      <input className="contactus" placeholder="Title" type="text" name="title" />
                   </div>
                   <div className="col-md-12">
                   <label>Content</label>
                      <textarea className="textarea" placeholder="Content" type="text" name="content" defaultValue=""></textarea>
                   </div>
                   <div className="col-md-12">
                      <button className="send_btn">Add review</button>
                   </div>
                   
                </div>
             </form>
          </div>

       </div>
    </div>
 </div>

   )
}

export default AddReview;