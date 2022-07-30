import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import ConfirmAlert from "../../components/confirm-alert/confirm-alert";
import { ApiHelper } from "../../helpers/api-helper";
import { DateHelper } from "../../helpers/date-helper";
import { Shipment } from "../../models/shipment";

const ShipmentsList = () => {
    const [shipments, setShipments] = useState<Shipment[]>([]);
    const [loading, setLoading] = useState(true);

    const navigate = useNavigate();

    const fetchShipments = async () => {
        const response = await ApiHelper.get(`${process.env.REACT_APP_API}/api/Shipment`);

        const data = await response.json();

        setShipments(data);
        setLoading(false);
    };

    const handleAdd = () => {
        navigate('/shipment');
    }

    const handleEdit = (id: string) => {
        navigate(`/shipment/${id}`);
    };

    const handleDelete = (id: string) => {
        const shipment = shipments.find(x => x.id === id);

        if (!shipment) {
            alert('Invalid shipment');
        }

        ConfirmAlert({
            title: 'Delete Shipment',
            message: `Are you sure you want to delete shipment heading to '${shipment?.destination}'?`,
            onAccepted: () => deleteShipment(shipment)
        })
    };

    const deleteShipment = async (shipment?: Shipment) => {
        try {
            const response = await ApiHelper.delete(`${process.env.REACT_APP_API}/api/Shipment/${shipment?.id}`);

            if (!response.ok) {
                throw new Error(await response.text());
            }

            const newShipments = shipments.filter(x => x.id !== shipment?.id);

            setShipments(newShipments);
        } catch (error) {
            console.error(error);
            alert('Error occured removing shipment');
        }
    }

    const renderShipmentsTable = (shipments: Shipment[]) => (
        <table className="table align-items-center table-flush">
            <thead className="table-dark">
                <tr>
                    <th>Origin</th>
                    <th>Destination</th>
                    <th>Driver</th>
                    <th>Status</th>
                    <th>Date of Shipment</th>
                    <th></th>
                </tr>
            </thead>
            <tbody className="list">
                {shipments.map(shipment =>
                    <tr key={shipment.id}>
                        <td>{shipment.origin}</td>
                        <td>{shipment.destination}</td>
                        <td>{shipment.driver}</td>
                        <td>{shipment.status}</td>
                        <td>{DateHelper.parseDateToDisplayString(shipment.shipment_date)}</td>
                        <td>
                            <div className="dropdown">
                                <button className="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                                    Options
                                </button>
                                <ul className="dropdown-menu">
                                    <li><button className="dropdown-item" onClick={() => handleEdit(shipment.id)}>Edit</button></li>
                                    <li><button className="dropdown-item" onClick={() => handleDelete(shipment.id)}>Delete</button></li>
                                </ul>
                            </div>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>
    );

    useEffect(() => {
        fetchShipments();
    }, [])

    return (
        <>
            <div className="container-fluid mt--6">
                <div className="row">
                    <div className="col">
                        <div className="card">
                            <div className="card-header border-0 mb-1 px-2 d-flex justify-content-between">
                                <h3 className="mb-0">Shipments</h3>
                                <button className="btn btn-sm btn-outline-dark" onClick={() => handleAdd()}>Add new shipment</button>
                            </div>
                            {
                                loading
                                    ? <p><em>Loading...</em></p>
                                    : renderShipmentsTable(shipments)
                            }
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}

export default ShipmentsList;