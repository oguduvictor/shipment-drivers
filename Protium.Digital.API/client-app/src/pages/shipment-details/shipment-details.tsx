import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { ErrorMessage, Field, Form, Formik } from "formik";
import * as yup from 'yup';
import { ApiHelper } from "../../helpers/api-helper";
import { DateHelper } from "../../helpers/date-helper";
import { Shipment } from "../../models/shipment";
import { NamedId } from "../../models/named-id";

const ShipmentDetails = () => {

    const navigate = useNavigate();
    const { id } = useParams();
    const [shipment, setShipment] = useState<Shipment>();
    const [drivers, setDrivers] = useState<NamedId[]>([]);
    const [pageIsLoaded, setPageIsLoaded] = useState(false);

    const validationSchema = yup.object().shape({
        origin: yup.string().required('Origin is required'),
        destination: yup.string().required('Destination is required'),
        shipment_date: yup.string().required('Shipment date is required'),
        planned_date: yup.date().required('Planned date is required'),
        effective_date: yup.date().required('Effective date is required'),
        driver_id: yup.string().required('Driver must be selected')

    });

    useEffect(() => {
        fetchDrivers();

        if (id) {
            fetchShipment(id);
        } else {
            setPageIsLoaded(true);
        }
    }, [id])

    const fetchDrivers = async () => {
        const response = await ApiHelper.get(`${process.env.REACT_APP_API}/api/Driver/summaries`);

        const data = await response.json();

        setDrivers(data);
    }

    const fetchShipment = async (id: string) => {
        try {
            const response = await ApiHelper.get(`${process.env.REACT_APP_API}/api/Shipment/${id}`);

            const data = await response.json();

            setShipment(data);

            setPageIsLoaded(true);
        } catch (error) {
            console.error(`No shipment with id ${id} found.`);

            alert(`No shipment with id ${id} found.`);

            navigate('/shipments', { replace: true });
        }
    }

    const handleSubmit = async (values: {}) => {
        const shipmentDto = values as Shipment;
        shipmentDto.planned_date = DateHelper.parseToApiDate(shipmentDto.planned_date);
        shipmentDto.effective_date = DateHelper.parseToApiDate(shipmentDto.effective_date);
        shipmentDto.shipment_date = DateHelper.parseToApiDate(shipmentDto.shipment_date);

        const response = id ? await editShipmentAsync(shipmentDto) : await addShipmentAsync(shipmentDto);

        if (!response.ok) {
            throw new Error(await response.text());
        }

        navigate('/shipments');
    }

    const addShipmentAsync = async (shipmentDto: Shipment) => {
        const response = await ApiHelper.post(`${process.env.REACT_APP_API}/api/Shipment`, shipmentDto);

        return response;
    }

    const editShipmentAsync = async (shipmentDto: Shipment) => {
        const response = await ApiHelper.put(`${process.env.REACT_APP_API}/api/Shipment/${id}`, shipmentDto);

        return response;
    }

    const renderFormik = () => (<Formik
        validationSchema={validationSchema}
        onSubmit={handleSubmit}
        initialValues={{
            origin: shipment?.origin || '',
            destination: shipment?.destination || '',
            status: shipment?.status || '',
            shipment_date: shipment ? DateHelper.parseToHtmlInputDate(shipment.shipment_date) : '',
            planned_date: shipment ? DateHelper.parseToHtmlInputDate(shipment.planned_date) : '',
            effective_date: shipment ? DateHelper.parseToHtmlInputDate(shipment.effective_date) : '',
            driver_id: shipment?.driver_id || '',
            comments: shipment?.comments || '',
            associated_barcode: shipment?.associated_barcode || ''
        }}
    >
        {({
            handleSubmit, handleChange, handleBlur, values, touched, isValid, errors
        }) => (
            <Form noValidate onSubmit={handleSubmit}>
                <div className="form-floating mb-3">
                    <Field name="origin" type="text" className={'form-control' + (errors.origin && touched.origin ? ' is-invalid' : '')} />
                    <label htmlFor="origin">Origin</label>
                    <ErrorMessage name="origin" />
                </div>

                <div className="form-floating mb-3">
                    <Field name="destination" type="text" className={'form-control' + (errors.destination && touched.destination ? ' is-invalid' : '')} />
                    <label htmlFor="destination">Destination</label>
                    <ErrorMessage name="destination" />
                </div>

                <div className="form-floating mb-3">
                    <Field name="associated_barcode" type="text" className={'form-control' + (errors.associated_barcode && touched.associated_barcode ? ' is-invalid' : '')} />
                    <label htmlFor="associated_barcode">Associated Barcode</label>
                    <ErrorMessage name="associated_barcode" />
                </div>

                <div className="form-floating mb-3">
                    <Field name="planned_date" type="date" className={'form-control' + (errors.planned_date && touched.planned_date ? ' is-invalid' : '')} />
                    <label htmlFor="planned_date">Planned Date</label>
                    <ErrorMessage name="planned_date" />
                </div>

                <div className="form-floating mb-3">
                    <Field name="effective_date" type="date" className={'form-control' + (errors.effective_date && touched.effective_date ? ' is-invalid' : '')} />
                    <label htmlFor="effective_date">Effective Date</label>
                    <ErrorMessage name="effective_date" />
                </div>

                <div className="form-floating mb-3">
                    <Field name="shipment_date" type="date" className={'form-control' + (errors.shipment_date && touched.shipment_date ? ' is-invalid' : '')} />
                    <label htmlFor="shipment_date">Expiration Date</label>
                    <ErrorMessage name="expiration_date" />
                </div>

                <div className="form-floating mb-3">
                    <Field as="textarea" name="comments" className={'form-control' + (errors.comments && touched.comments ? ' is-invalid' : '')} />
                    <label className="form-check-label" htmlFor="active">Comments</label>
                    <ErrorMessage name="comments" />
                </div>

                <div className="form-floating mb-3">
                    <Field as="select" name="status" className='form-control'>
                        <option value={1}>Init</option>
                        <option value={2}>Pickup</option>
                        <option value={3}>Delivered</option>
                        <option value={4}>Returned</option>
                    </Field>
                    <label htmlFor="status">Status</label>
                    <ErrorMessage name="status" />
                </div>

                <div className="form-floating mb-3">
                    <Field as="select" name="driver_id" className='form-control'>
                        <option></option>
                        {drivers.map(driver => (
                            <option key={driver.id} value={driver.id}>{driver.name}</option>
                        ))}
                    </Field>
                    <label htmlFor="driver_id">Driver</label>
                    <ErrorMessage name="driver_id" />
                </div>

                <div className="d-flex justify-content-between">
                    <button type="submit" className="btn btn-primary btn-lg">Submit</button>
                    <button type="button" className="btn btn-danger btn-lg" onClick={() => { navigate('/shipments') }}>Cancel</button>
                </div>
            </Form>
        )}
    </Formik>);

    return (
        <>
            <div className="container mt--7 pb-5 pt-2">
                <div className="row justify-content-center">
                    <div className="col-lg-5 col-md-7">
                        <div className="card text-bg-light border-0 mb-0">
                            <div className="card-header border-0 mb-1 px-2 d-flex justify-content-between">
                                <h3 className="mb-0">{id ? 'Edit ' : 'Create new '} shipment</h3>
                            </div>
                            <div className="card-body px-lg-5 py-lg-5">
                                {
                                    !pageIsLoaded ?
                                        (<div>Loading...</div>) :
                                        renderFormik()
                                }
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}

export default ShipmentDetails;