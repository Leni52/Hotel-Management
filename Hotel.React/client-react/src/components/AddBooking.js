import * as bookService from '../services/bookService';
import { useNavigate } from "react-router-dom";

const AddBooking=()=>{
    const navigate = useNavigate();
const onSubmitHandler=(e)=>{


    e.preventDefault();
    let formData =new FormData(e.currentTarget);
   
let { RoomId, checkIn, checkOut, numberOfGuests,OtherRequests } = Object.fromEntries(formData);

roomService.addRoom(RoomId, checkIn, checkOut, numberOfGuests,OtherRequests)
 .then(navigate("/"));

   console.log(RoomId, checkIn, checkOut, numberOfGuests,OtherRequests);
}


    return(

        <div className="contact">
        <div className="container">
           <div className="row">
              <div className="col-md-6">
                 <form id="request" className="main_form" onSubmit={onSubmitHandler}>
                    <div className="row">
                       <div className="col-md-12 ">
                          <input className="contactus" placeholder="Room Id" type="number" name="RoomId"/> 
                       </div>
                       <div className="col-md-12">
                          <input className="contactus" placeholder="Check In" type="date" name="checkIn"/> 
                       </div>
                       <div className="col-md-12">
                          <input className="contactus" placeholder="Check Out" type="number" name="checkOut"/>                          
                       </div>
                       <div className="col-md-12">
                          <textarea className="textarea" placeholder="Number of Guests" type="number" name="NumberOfGuests" defaultValue={"Add a description"}></textarea>
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

export default Addroom;