import axios from 'axios';

const API_BASE_URL = 'http://localhost:5044/api';

export const api = axios.create({
    baseURL: API_BASE_URL,
    headers: {
        'Content-Type': 'application/json',
    },
});

export interface Customer {
    id: number;
    name: string;
    phoneNumber: string;
    address: string;
    isActive?: boolean;
    totalDebt?: number;
    totalPaid?: number;
    balance?: number;
}

export interface Vehicle {
    id: number;
    plate: string;
    brand: string;
    model: string;
    customerId: number;
    isActive?: boolean;
}

export interface VehicleDto {
    id: number;
    marka: string;
    plaka: string;
    model: string;
    müsteri_Adı: string;
    musteri_Id: number;
    isActive?: boolean;
}

export interface Service {
    id: number;
    vehicleId: number | null;
    date: string;
    name: string;
    description: string;
    price: number;
}

export interface PerformedServiceDto {
    id: number;
    serviceName: string;
    description: string;
    price: number;
    date: string;
    plate: string;
    customerName: string;
}

export const customerApi = {
    getAll: () => api.get<Customer[]>('/customers'),
    getById: (id: number) => api.get<Customer>(`/customers/${id}`),
    add: (customer: Omit<Customer, 'id'>) => api.post<Customer>('/customers', customer),
    update: (customer: Customer) => api.put('/customers', customer),
    delete: (id: number) => api.delete(`/customers/${id}`),
};

export const vehicleApi = {
    getAll: () => api.get<Vehicle[]>('/vehicles'),
    getDto: () => api.get<VehicleDto[]>('/vehicles/dto'),
    add: (vehicle: Omit<Vehicle, 'id' | 'customer' | 'services'>) => api.post<Vehicle>('/vehicles', vehicle),
    update: (vehicle: Vehicle) => api.put('/vehicles', vehicle),
    delete: (id: number) => api.delete(`/vehicles/${id}`),
};

export interface Invoice {
    id: number;
    customerId: number;
    vehicleId: number;
    totalAmount: number;
    date: string;
}

export interface InvoiceDetail {
    id: number;
    invoiceId: number;
    serviceId: number;
    price: number;
    amount: number;
}

export interface InvoiceListDto {
    id: number;
    customerName: string;
    plate: string;
    date: string;
    totalAmount: number;
}

export interface InvoiceDetailDto {
    id: number;
    hizmet_Adi: string;
    birim_Fiyat: number;
    adet: number;
    tutar: number;
}

export const serviceApi = {
    getAll: () => api.get<Service[]>('/services'),
    getPerformed: () => api.get<PerformedServiceDto[]>('/services/performed'),
    getPerformedByCustomer: (customerId: number) => api.get<PerformedServiceDto[]>(`/services/performed/customer/${customerId}`),
    add: (service: Omit<Service, 'id' | 'vehicle'>) => api.post<Service>('/services', service),
    update: (service: Service) => api.put('/services', service),
    delete: (id: number) => api.delete(`/services/${id}`),
};

export const invoiceApi = {
    getAll: () => api.get<InvoiceListDto[]>('/invoices'),
    getById: (id: number) => api.get<Invoice>(`/invoices/${id}`),
    getDetails: (id: number) => api.get<InvoiceDetailDto[]>(`/invoices/${id}/details`),
    add: (invoice: Omit<Invoice, 'id'>) => api.post<Invoice>('/invoices', invoice),
    update: (invoice: Invoice) => api.put<Invoice>('/invoices', invoice),
    deleteDetails: (id: number) => api.delete(`/invoices/${id}/details`),
    addDetail: (detail: Omit<InvoiceDetail, 'id'>) => api.post<InvoiceDetail>('/invoices/detail', detail),
    getByCustomer: (customerId: number) => api.get<InvoiceListDto[]>(`/invoices/customer/${customerId}`),
};

export interface Payment {
    id: number;
    customerId: number;
    amount: number;
    date: string;
    description: string;
}

export const paymentApi = {
    getByCustomer: (customerId: number) => api.get<Payment[]>(`/payments/customer/${customerId}`),
    add: (payment: Omit<Payment, 'id'>) => api.post<Payment>('/payments', payment),
    delete: (id: number) => api.delete(`/payments/${id}`),
};

export const authApi = {
    login: (credentials: { username: string; password: string }) => api.post('/auth/login', credentials),
};




