
import './App.css';
import Header from '../src/components/Header';
import Home from '../src/components/Home';
import Addroom from './components/Addroom';
import { Route, Routes} from 'react-router-dom';
import About from '../src/components/About';
import Footer from '../src/components/Footer';
import AddBooking from './components/AddBooking';
import Contact from './components/Contact';

function App() {


  return (
    <div className="App">
  <Header></Header>
   <Routes>
    <Route path='/' exact element={<Home></Home>}></Route>
    <Route path='/addroom'  element={<Addroom></Addroom>}></Route>
    <Route path='/about' element={<About></About>}></Route>
    <Route path='/addbooking/:id' element={<AddBooking></AddBooking>}></Route>
    <Route path='/contact' element={<Contact></Contact>}></Route>
    
   </Routes>
   

<Footer></Footer>
    </div>
  );
}

export default App;
