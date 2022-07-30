import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import ConfirmAlert from "../../components/confirm-alert/confirm-alert";
import { ApiHelper } from "../../helpers/api-helper";
import { Driver } from "../../models/driver";

const DriversList = () => {
    const [drivers, setDrivers] = useState<Driver[]>([]);
    const [loading, setLoading] = useState(true);

    const navigate = useNavigate();

    const fetchDrivers = async () => {
        const response = await ApiHelper.get(`${process.env.REACT_APP_API}/api/Driver`);

        const data = await response.json();

        setDrivers(data);
        setLoading(false);
    };

    const handleAdd = () => {
        navigate('/driver');
    }

    const handleEdit = (id: string) => {
        navigate(`/driver/${id}`);
    };

    const handleDelete = (id: string) => {
        const driver = drivers.find(x => x.id === id);

        if (!driver) {
            alert('Invalid driver');
        }

        ConfirmAlert({
            title: 'Delete Driver',
            message: `Are you sure you want to delete '${driver?.first_name} ${driver?.last_name}' with vehicle plate number '${driver?.vehicle_plate}'?`,
            onAccepted: () => deleteDriver(driver)
        })
    };

    const deleteDriver = async (driver?: Driver) => {
        try {
            const response = await ApiHelper.delete(`${process.env.REACT_APP_API}/api/Driver/${driver?.id}`);

            if (!response.ok) {
                throw new Error(await response.text());
            }

            const newDrivers = drivers.filter(x => x.id !== driver?.id);

            setDrivers(newDrivers);
        } catch (error) {
            console.error(error);
            alert('Error occured removing driver');
        }
    }

    const renderDriversTable = (drivers: Driver[]) => (
        <table className="table align-items-center table-flush">
            <thead className="table-dark">
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Vehicle Plate</th>
                    <th>Active</th>
                    <th></th>
                </tr>
            </thead>
            <tbody className="list">
                {drivers.map(driver =>
                    <tr key={driver.id}>
                        <td>{driver.first_name}</td>
                        <td>{driver.last_name}</td>
                        <td>{driver.vehicle_plate}</td>
                        <td>{driver.active ? "Yes" : "No"}</td>
                        <td>
                            <div className="dropdown">
                                <button className="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                                    Options
                                </button>
                                <ul className="dropdown-menu">
                                    <li><button className="dropdown-item" onClick={() => handleEdit(driver.id)}>Edit</button></li>
                                    <li><button className="dropdown-item" onClick={() => handleDelete(driver.id)}>Delete</button></li>
                                </ul>
                            </div>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>
    );

    useEffect(() => {
        fetchDrivers();
    }, [])

    return (
        <>
            <div className="container-fluid mt--6">
                <div className="row">
                    <div className="col">
                        <div className="card">
                            <div className="card-header border-0 mb-1 px-2 d-flex justify-content-between">
                                <h3 className="mb-0">Drivers</h3>
                                <button className="btn btn-sm btn-outline-dark" onClick={() => handleAdd()}>Add new driver</button>
                            </div>
                            {
                                loading
                                    ? <p><em>Loading...</em></p>
                                    : renderDriversTable(drivers)
                            }
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}

export default DriversList;