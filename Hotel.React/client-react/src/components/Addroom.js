import * as bookService from '../services/bookService';
import { useNavigate } from "react-router-dom";

const Addroom=()=>{
    const navigate = useNavigate();
const onSubmitHandler=(e)=>{


    e.preventDefault();
    let formData =new FormData(e.currentTarget);
   
let { number, maximumGuests, price, description } = Object.fromEntries(formData);

bookService.addRoom(number, maximumGuests, price, description)
 .then(navigate("/"));

   console.log(number, maximumGuests, price, description);
}


    return(

        <div className="contact">
        <div className="container">
           <div className="row">
              <div className="col-md-6">
                 <form id="request" className="main_form" onSubmit={onSubmitHandler}>
                    <div className="row">
                       <div className="col-md-12 ">
                          <input className="contactus" placeholder="Room Number" type="number" name="number"/> 
                       </div>
                       <div className="col-md-12">
                          <input className="contactus" placeholder="Maximum Guests" type="number" name="maximumGuests"/> 
                       </div>
                       <div className="col-md-12">
                          <input className="contactus" placeholder="Price" type="number" name="price"/>                          
                       </div>
                       <div className="col-md-12">
                          <textarea className="textarea" placeholder="Description" type="text" name="description" defaultValue={"Add a description"}></textarea>
                       </div>
                       <div className="col-md-12">
                          <button className="send_btn">Add</button>
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