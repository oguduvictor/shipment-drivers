import './custom.css';
import './App.scss';
import { Route, BrowserRouter as Router, Routes } from "react-router-dom";
import Home from "./pages/home/home";
import Layout from "./components/layout/layout";
import DriversList from './pages/drivers-list/drivers-list';
import Shipments from './pages/shipments/shipment';
import DriverDetail from './pages/driver-details/driver-detail';

const App = () => {
    return (
        <Router>
            <Layout>
                <Routes>
                    <Route path='/' element={<Home />} />
                    <Route path='/drivers' element={<DriversList />} />
                    <Route path='/driver/:id' element={<DriverDetail />} />
                    <Route path='/driver' element={<DriverDetail />} />
                    <Route path='/shipments' element={<Shipments />} />
                </Routes>
            </Layout>
        </Router>
    );
}

export default App