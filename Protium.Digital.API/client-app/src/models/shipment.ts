export interface Shipment {
    id:             string;
    origin:         string;
    destination:    string;
    status:         number;
    shipment_date:  string;
    driver_id:      string;
    planned_date:   string;
    effective_date: string;
    comments:       string;
    created_at:     string;
    created_by:     string;
    updated_at:     string;
    updated_by:     string;
}
