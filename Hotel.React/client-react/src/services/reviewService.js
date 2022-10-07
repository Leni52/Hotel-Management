const baseUrl='https://localhost:5001/api';

export const fetchReviews = async ()=>{
    const res = await fetch('https://localhost:5001/api/Review');
    const data = await res.json();
   // console.log(data);
    return data;
}

export const reviewById =async (id)=>{
    const res = await fetch(`https://localhost:5001/api/Review/${id}`);
    const data = await res.json();
    return data;
}

export const reviewsForRoom = async(id)=>{
    const res = await fetch(`https://localhost:5001/api/Review/Room/${id}`);
    const data = await res.json();
    return data;
}

export const addReview = async(roomId, content, title)=>{
    
        let response = await fetch(`${baseUrl}/Review`, {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
                //'X-Authorization': token,
            },
            body: JSON.stringify({roomId, content, title})
        });
     
        let result = await response.json();
     
        return result;
    };
