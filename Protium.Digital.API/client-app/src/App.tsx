import './custom.css';
import './App.scss';
import { Route, BrowserRouter as Router, Routes } from "react-router-dom";
import Home from "./pages/home/home";
import Layout from "./components/layout/layout";
import DriversList from './pages/drivers-list/drivers-list';
import ShipmentsList from './pages/shipments-list/shipments-list';
import DriverDetail from './pages/driver-details/driver-detail';
import ShipmentDetails from './pages/shipment-details/shipment-details';

const App = () => {
    return (
        <Router>
            <Layout>
                <Routes>
                    <Route path='/' element={<Home />} />
                    <Route path='/drivers' element={<DriversList />} />
                    <Route path='/driver/:id' element={<DriverDetail />} />
                    <Route path='/driver' element={<DriverDetail />} />
                    <Route path='/shipments' element={<ShipmentsList />} />
                    <Route path='/shipment/:id' element={<ShipmentDetails />} />
                    <Route path='/shipment' element={<ShipmentDetails />} />
                </Routes>
            </Layout>
        </Router>
    );
}

export default App