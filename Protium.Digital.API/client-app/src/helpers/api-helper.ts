export const ApiHelper = {
    get: (url: string): Promise<Response> => {
        return fetch(url, {
            method: 'GET',
            headers: {
                'content-type': 'application/json',
            }
        });
    },
    post<T>(url: string, data: T): Promise<Response> {
        return fetch(url, {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'content-type': 'application/json',
            }
        });
    },
    put<T>(url: string, data: T): Promise<Response> {
        return fetch(url, {
            method: 'PUT',
            body: JSON.stringify(data),
            headers: {
                'content-type': 'application/json',
            }
        });
    },
    delete: (url: string): Promise<Response> => {
        return fetch(url, {
            method: 'DELETE',
            headers: {
                'content-type': 'application/json',
            }
        });
    }
}