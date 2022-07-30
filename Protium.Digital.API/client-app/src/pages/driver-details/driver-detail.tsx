import { ErrorMessage, Field, Form, Formik } from "formik";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import * as yup from 'yup';
import { ApiHelper } from "../../helpers/api-helper";
import { DateHelper } from "../../helpers/date-helper";
import { Driver } from "../../models/driver";

const DriverDetail = () => {
    const navigate = useNavigate();
    const { id } = useParams();
    const [driver, setDriver] = useState<Driver>();
    const [pageIsLoaded, setPageIsLoaded] = useState(false);

    const validationSchema = yup.object().shape({
        first_name: yup.string().required('First name is required'),
        last_name: yup.string().required('Last name is required'),
        vehicle_plate: yup.string().required('Vehicle plate number is required'),
        start_date: yup.date().required('Start date is required'),
        expiration_date: yup.date().required('Expiration date is required')
    });

    useEffect(() => {
        if (id) {
            fetchDriver(id);
        } else {
            setPageIsLoaded(true);
        }
    }, [id])

    const fetchDriver = async (id: string) => {
        try {
            const response = await ApiHelper.get(`${process.env.REACT_APP_API}/api/Driver/${id}`);

            const data = await response.json();

            setDriver(data);

            setPageIsLoaded(true);
        } catch (error) {
            console.error(`No driver with id ${id} found.`);

            alert(`No driver with id ${id} found.`);

            navigate('/drivers', { replace: true });
        }
    }

    const handleSubmit = async (values: {}) => {
        const driverDto = values as Driver;
        driverDto.start_date = DateHelper.parseToApiDate(driverDto.start_date);
        driverDto.expiration_date = DateHelper.parseToApiDate(driverDto.expiration_date);

        const response = id ? await editDriverAsync(driverDto) : await addDriverAsync(driverDto);

        if (!response.ok) {
            throw new Error(await response.text());
        }

        navigate('/drivers');
    }

    const addDriverAsync = async (driverDto: Driver) => {
        const response = await ApiHelper.post(`${process.env.REACT_APP_API}/api/Driver`, driverDto);

        return response;
    }

    const editDriverAsync = async (driverDto: Driver) => {
        const response = await ApiHelper.put(`${process.env.REACT_APP_API}/api/Driver/${id}`, driverDto);

        return response;
    }

    const renderFormik = () => (<Formik
        validationSchema={validationSchema}
        onSubmit={handleSubmit}
        initialValues={{
            first_name: driver?.first_name || '',
            last_name: driver?.last_name || '',
            vehicle_plate: driver?.vehicle_plate || '',
            start_date: driver ? DateHelper.parseToHtmlInputDate(driver.start_date) : '',
            expiration_date: driver ? DateHelper.parseToHtmlInputDate(driver.expiration_date) : '',
            active: driver?.active || false
        }}
    >
        {({
            handleSubmit, handleChange, handleBlur, values, touched, isValid, errors
        }) => (
            <Form noValidate onSubmit={handleSubmit}>
                <div className="form-floating mb-3">
                    <Field name="first_name" type="text" className={'form-control' + (errors.first_name && touched.first_name ? ' is-invalid' : '')} />
                    <label htmlFor="first_name">First Name</label>
                    <ErrorMessage name="first_name" />
                </div>

                <div className="form-floating mb-3">
                    <Field name="last_name" type="text" className={'form-control' + (errors.last_name && touched.last_name ? ' is-invalid' : '')} />
                    <label htmlFor="last_name">Last Name</label>
                    <ErrorMessage name="last_name" />
                </div>

                <div className="form-floating mb-3">
                    <Field name="vehicle_plate" type="text" className={'form-control' + (errors.vehicle_plate && touched.vehicle_plate ? ' is-invalid' : '')} />
                    <label htmlFor="vehicle_plate">Vehicle Plate</label>
                    <ErrorMessage name="vehicle_plate" />
                </div>

                <div className="form-floating mb-3">
                    <Field name="start_date" type="date" className={'form-control' + (errors.start_date && touched.start_date ? ' is-invalid' : '')} />
                    <label htmlFor="start_date">Start Date</label>
                    <ErrorMessage name="start_date" />
                </div>

                <div className="form-floating mb-3">
                    <Field name="expiration_date" type="date" className={'form-control' + (errors.expiration_date && touched.expiration_date ? ' is-invalid' : '')} />
                    <label htmlFor="expiration_date">Expiration Date</label>
                    <ErrorMessage name="expiration_date" />
                </div>

                <div className="form-check mb-3">
                    <Field name="active" type="checkbox" className='form-check-input' />
                    <label className="form-check-label" htmlFor="active">Active</label>
                </div>

                <div className="d-flex justify-content-between">
                    <button type="submit" className="btn btn-primary btn-lg">Submit</button>
                    <button type="button" className="btn btn-danger btn-lg" onClick={() => { navigate('/drivers') }}>Cancel</button>
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
                                <h3 className="mb-0">{id ? 'Edit ' : 'Create new '} driver</h3>
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


export default DriverDetail