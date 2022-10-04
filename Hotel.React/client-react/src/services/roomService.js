const baseUrl='https://localhost:5001/api';

export const fetchRooms = async ()=>{
    const res = await fetch('https://localhost:5001/api/Room');
    const data = await res.json();
   // console.log(data);
    return data;
}

export const roomById =async (id)=>{
    const res = await fetch(`https://localhost:5001/api/Room/${id}`);
    const data = await res.json();
    return data;
}

export const addRoom = async(number, maximumGuests, price, description)=>{
    
        let response = await fetch(`${baseUrl}/Room`, {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
                //'X-Authorization': token,
            },
            body: JSON.stringify({number, maximumGuests, price, available:true, description})
        });
     
        let result = await response.json();
     
        return result;
    };
