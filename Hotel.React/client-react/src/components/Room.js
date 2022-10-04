import * as bookService from '../services/roomService';
import { useState, useEffect } from 'react';


const Room = ({id}) => {
    const [room, setRoom] = useState([]);

    useEffect(() => {
   
        bookService.roomById(id)
      
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
                     </div>
                  </div>
               </div>
    )

}


export default Room;