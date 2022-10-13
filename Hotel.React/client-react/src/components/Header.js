import { Link } from 'react-router-dom';
import About from '../components/About';
import { useKeycloak } from "@react-keycloak/web";

const Header = () => {

   const [keycloak, initialized] = useKeycloak();

   return (
      <header>
         <div className="header">
            <div className="container">
               <div className="row">
                  <div className="col-xl-3 col-lg-3 col-md-3 col-sm-3 col logo_section">
                     <div className="full">
                        <div className="center-desk">
                           <div className="logo">
                              <Link to="/"><img src="images/logo.png" alt="#" /></Link>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div className="col-xl-9 col-lg-9 col-md-9 col-sm-9">
                     <nav className="navigation navbar navbar-expand-md navbar-dark ">
                        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExample04" aria-controls="navbarsExample04" aria-expanded="false" aria-label="Toggle navigation">
                           <span className="navbar-toggler-icon"></span>
                        </button>
                        <div className="collapse navbar-collapse" id="navbarsExample04">
                           <ul className="navbar-nav mr-auto">
                              <li className="nav-item ">
                                 <Link className="nav-link" to="/">Home</Link>
                              </li>
                              <li className="nav-item">
                                 <Link className="nav-link" to="/addroom">Add room</Link>
                              </li>
                              <li className="nav-item">
                                 <Link className="nav-link" to="/about">About</Link>
                              </li>
                              <li className="nav-item">
                                 <Link className="nav-link" to="">My bookings</Link>
                              </li>
                              <li className="nav-item">
                                 <Link className="nav-link" to="/contact">Contact Us</Link>
                              </li>
                              <li>

                                 {initialized ?
                                    keycloak.authenticated && <pre >{JSON.stringify(keycloak, undefined, 2)}</pre>
                                    : <h2>keycloak initializing ....!!!!</h2>
                                 }


                              </li>
                           </ul>
                        </div>
                     </nav>
                  </div>
               </div>
            </div>
         </div>
      </header>
   )
}
export default Header;