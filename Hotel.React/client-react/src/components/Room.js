import * as roomService from '../services/roomService';
import * as bookService from '../services/bookService';
import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

const Room = ({id}) => {
    const [room, setRoom] = useState([]);

    useEffect(() => {
   
        roomService.roomById(id)
      
            .then(x => {
                setRoom(x);
            })
    })

    return (
        <div className="col-md-4 col-sm-6">
                  <div id="serv_hover"  className="room">
                     <div className="room_img">
                        <figure><img src="images/room1.jpg" alt="#"/></figure>
                     </div>
                     <div className="bed_room">
                        <h3>Bed Room</h3>
                        <p>{room.description} </p>
                       <Link to={`/addbooking/${id}`}>Book this room</Link> 
                       <br/>    
                       <Link to={`/addreview/${id}`}>Add Review</Link>    
                       <br/>
                       <Link to={`/reviewCatalog`}>List all reviews</Link>             
                     </div>
                  </div>
               </div>
    )

}


export default Room;