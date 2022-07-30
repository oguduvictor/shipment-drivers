export interface Driver {
    id: string;
    first_name: string;
    last_name: string;
    vehicle_plate: string;
    start_date: string | Date;
    expiration_date: string | Date;
    created_by: string;
    updated_by: string;
    active: boolean;
}
