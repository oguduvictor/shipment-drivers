export interface Shipment {
    id: string;
    origin: string;
    destination: string;
    status: string;
    shipment_date: Date;
    driver: string;
    driver_id: string;
    planned_date: Date;
    effective_date: Date;
    comments: string;
    associated_barcode: string;
}
