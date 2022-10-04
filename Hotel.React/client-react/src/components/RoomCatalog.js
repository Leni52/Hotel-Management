import * as bookService from '../services/roomService';
import { useState, useEffect } from 'react';
import Room from '../components/Room';

const RoomCatalog = () => {
    const [rooms, setRooms] = useState([]);

    useEffect(() => {
        bookService.fetchRooms()
            .then(x => {
                setRooms(x);
            })
    })

    return (
        <div  className="our_room">
         <div className="container">
            <div className="row">
               <div className="col-md-12">
                  <div className="titlepage">
                     <h2>Our Room</h2>
                     <p>Lorem Ipsum available, but the majority have suffered </p>
                  </div>
               </div>
            </div>
            <div className="row">
              
              {rooms.map(x=><Room key={x.id} id={x.id}></Room>)}         
                         
                          
                 </div>
               </div>
            </div>
      
    )

}


export default RoomCatalog;