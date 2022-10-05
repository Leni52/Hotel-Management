const baseUrl='https://localhost:5001/api';

export const fetchBookings = async ()=>{
    const res = await fetch('https://localhost:5001/api/Booking');
    const data = await res.json();
   // console.log(data);
    return data;
}

export const bookingById =async (id)=>{
    const res = await fetch(`https://localhost:5001/api/Booking/${id}`);
    const data = await res.json();
    return data;
}

export const addBooking = async(RoomId, checkIn, checkOut, numberOfGuests,OtherRequests)=>{
    
        let response = await fetch(`${baseUrl}/Booking`, {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
                //'X-Authorization': token,
            },
            body: JSON.stringify({RoomId, checkIn, checkOut, numberOfGuests,OtherRequests})
        });
     
        let result = await response.json();
     
        return result;
    };