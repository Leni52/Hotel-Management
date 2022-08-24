
import './App.css';
import Header from '../src/components/Header';

import Home from '../src/components/Home';
import Addroom from './components/Addroom';
import { Route, Routes} from 'react-router-dom';
import About from '../src/components/About';
import Footer from '../src/components/Footer';

function App() {


  return (
    <div className="App">
  <Header></Header>
   <Routes>
    <Route path='/' exact element={<Home></Home>}></Route>
    <Route path='/addroom'  element={<Addroom></Addroom>}></Route>
    <Route path='/about' element={<About></About>}></Route>

   </Routes>



    </div>
  );
}

export default App;
