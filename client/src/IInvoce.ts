export interface FullInvoce {
    invoce: {
        invoceId: number,
        firstName: string,
        lastName: string,
        status: string,
        date: string,
        subTotal: number,
        itbis: number,
        discount: number,
        total: number
    },
    invoceProducts: [
        {
            invoceProductId: number,
            invoceId: number,
            productId: number,
            quantity: number,
            discount: number
        }
    ]
}

export interface Invoce {
    invoceId: number,
    firstName: string,
    lastName: string,
    status: string,
    date: string,
    subTotal: number,
    itbis: number,
    discount: number,
    total: number
}

export interface Product {
    productId: number,
    productName: string,
    description: string,
    price: number
}

export interface InvoceProduct {
    productId: number,
    productName: string,
    price: number,
    quantity: number,
    discount: number
}

export interface Customer {
    customerId: number,
    firstName: string,
    lastName: string,
    phoneNumber: string
}