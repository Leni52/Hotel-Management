import * as bookService from '../services/bookService';
import { useNavigate, useMatch } from "react-router-dom";

const AddBooking = (props) => {
   const navigate = useNavigate();
   const match = useMatch("/addbooking/:id");

   const onSubmitHandler = (e) => {


      e.preventDefault();
      let formData = new FormData(e.currentTarget);

      let { checkIn, checkOut, numberOfGuests, otherRequests } = Object.fromEntries(formData);

      const roomId = match.params.id;

      bookService.addBooking(roomId, checkIn, checkOut, numberOfGuests, otherRequests)
         .then(navigate("/"));


     // console.log(id);
      //  console.log(RoomId, checkIn, checkOut, numberOfGuests,OtherRequests);
   }


   return (

      <div className="contact">
         <div className="container">
            <div className="row">
               <div className="col-md-6">
                  <form id="request" className="main_form" onSubmit={onSubmitHandler}>
                     <div className="row">

                        <div className="col-md-12">
                           <label>Check in date:</label>
                           <input className="contactus" placeholder="Check In" type="date" name="checkIn" />
                        </div>
                        <div className="col-md-12">
                        <label>Check out date:</label>
                           <input className="contactus" placeholder="Check Out" type="date" name="checkOut" />
                        </div>
                        <div className="col-md-12">
                        <label>Number of guests</label>
                           <input className="contactus" placeholder="Number of Guests" type="number" name="numberOfGuests" />
                        </div>
                        <div className="col-md-12">
                        <label>Other Requests:</label>
                           <textarea className="textarea" placeholder="Other Requests" type="text" name="otherRequests" defaultValue={""}></textarea>
                        </div>
                        <div className="col-md-12">
                           <button className="send_btn">Book</button>
                        </div>
                        
                     </div>
                  </form>
               </div>

            </div>
         </div>
      </div>

   )
}

export default AddBooking;