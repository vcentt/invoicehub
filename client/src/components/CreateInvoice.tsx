/* eslint-disable @typescript-eslint/no-floating-promises */
/* eslint-disable @typescript-eslint/no-misused-promises */
/* eslint-disable @typescript-eslint/no-unsafe-member-access */
/* eslint-disable @typescript-eslint/no-unsafe-assignment */
/* eslint-disable @typescript-eslint/no-unsafe-argument */
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Customer, InvoceProduct, Product } from '../IInvoce';

const CreateInvoice = () => {
  const [invoice, setInvoice] = useState({
    invoceId: 0,
    customerId: 0,
    status: '',
    date: '',
    subTotal: 0,
    itbis: 0,
    discount: 0,
    total: 0,
  });
  const [invoiceSummary, setInvoiceSummary] = useState({
    invoceId: 0,
    customerId: 0,
    status: '',
    date: '',
    subTotal: 0,
    itbis: 0,
    discount: 0,
    total: 0,
  });
  const [invoiceProducts, setInvoiceProducts] = useState<InvoceProduct[]>([]);
  const [customers, setCustomers] = useState<Customer[]>([]);
  const [products, setProducts] = useState<Product[]>([]);
  const [selectedCustomer, setSelectedCustomer] = useState<Customer | null>(null);
  const [selectedProduct, setSelectedProduct] = useState<Product | null>(null);
  const [modalOpen, setModalOpen] = useState(false);

  useEffect(() => {
    getCustomers();
    getProducts();
  }, []);

  const getCustomers = async () => {
    try {
      const response = await axios.get('http://localhost:5194/Customer');
      setCustomers(response.data);
    } catch (error) {
      console.error('Error al obtener los clientes:', error);
    }
  };

  const getProducts = async () => {
    try {
      const response = await axios.get('http://localhost:5194/Product');
      setProducts(response.data);
    } catch (error) {
      console.error('Error al obtener los productos:', error);
    }
  };

  const handleCustomerSelect = (customer: Customer) => {
    setSelectedCustomer(customer);
    setInvoice({ ...invoice, customerId: customer.customerId });
    setModalOpen(false);
  };

  const handleProductSelect = (product: Product) => {
    setSelectedProduct(product);
  };

  const handleAddProduct = () => {
    if (selectedProduct) {
      const newProduct: InvoceProduct = {
        invoceProductId: 0,
        invoceId: 0,
        productId: selectedProduct.productId,
        quantity: 1,
        discount: 0,
      };

      setInvoiceProducts([...invoiceProducts, newProduct]);
      setSelectedProduct(null);
      updateInvoiceSummary();
    }
  };

  const handleQuantityChange = (index: number, quantity: number) => {
    const updatedProducts = [...invoiceProducts];
    updatedProducts[index].quantity = quantity;
    setInvoiceProducts(updatedProducts);
    updateInvoiceSummary();
  };

  const handleDiscountChange = (index: number, discount: number) => {
    const updatedProducts = [...invoiceProducts];
    updatedProducts[index].discount = discount;
    setInvoiceProducts(updatedProducts);
    updateInvoiceSummary();
  };

  const updateInvoiceSummary = () => {
    let subTotal = 0;
    let discount = 0;

    invoiceProducts.forEach((product) => {
      const productPrice = products.find((p) => p.productId === product.productId)?.price || 0;
      subTotal += productPrice * product.quantity;
      discount += (productPrice * product.quantity * product.discount) / 100;
    });

    const itbis = subTotal * 0.18;
    const total = subTotal + itbis - discount;

    setInvoiceSummary({ ...invoiceSummary, subTotal, itbis, discount, total });
  };

  const handleCreateInvoice = async () => {
    if (selectedCustomer) {
      const data = {
        invoce: { ...invoice, customerId: selectedCustomer.customerId },
        invoceProducts: invoiceProducts,
      };

      try {
        const response = await axios.post('http://localhost:5194/Invoce', data);
        console.log('Factura creada:', response.data);
        setInvoice({
          invoceId: 0,
          customerId: 0,
          status: '',
          date: '',
          subTotal: 0,
          itbis: 0,
          discount: 0,
          total: 0,
        });
        setInvoiceProducts([]);
        setSelectedCustomer(null);
        setInvoiceSummary({ ...invoiceSummary, subTotal: 0, itbis: 0, discount: 0, total: 0 });
      } catch (error) {
        console.log(data.invoce);
        console.log(data.invoceProducts);
        console.error('Error al crear la factura:', error);
      }

    }
  };

  return (
    <div className="container mt-4">
      <h1 className="text-center">Create Invoice</h1>

      <div className="row mb-3">
        <label className="col-sm-2 col-form-label">Customer:</label>
        <div className="col-sm-10">
          <input
            type="text"
            className="form-control"
            value={selectedCustomer ? `${selectedCustomer.firstName} ${selectedCustomer.lastName}` : ''}
            readOnly
          />
          <button className="btn btn-primary mt-2" onClick={() => setModalOpen(true)}>
            Choose Customer
          </button>
        </div>
      </div>

      {modalOpen && (
        <div className="modal" style={{ display: 'block' }}>
          <div className="modal-dialog">
            <div className="modal-content">
              <div className="modal-header">
                <h5 className="modal-title">Choose Customer</h5>
                <button type="button" className="btn-close" onClick={() => setModalOpen(false)}></button>
              </div>
              <div className="modal-body">
                <ul className="list-group">
                  {customers.map((customer) => (
                    <li
                      key={customer.customerId}
                      className={`list-group-item ${selectedCustomer?.customerId === customer.customerId ? 'active' : ''}`}
                      onClick={() => handleCustomerSelect(customer)}
                      style={{ cursor: 'pointer' }}
                    >
                      {customer.firstName} {customer.lastName}
                    </li>
                  ))}
                </ul>
              </div>
              <div className="modal-footer">
                <button type="button" className="btn btn-secondary" onClick={() => setModalOpen(false)}>
                  Close
                </button>
              </div>
            </div>
          </div>
        </div>
      )}

      <div className="row mb-3">
        <label className="col-sm-2 col-form-label">Date:</label>
        <div className="col-sm-10">
          <input
            type="date"
            className="form-control"
            value={invoice.date}
            onChange={(e) => setInvoice({ ...invoice, date: e.target.value })}
          />
        </div>
      </div>

      <div className="row mb-3">
        <label className="col-sm-2 col-form-label">Status:</label>
        <div className="col-sm-10">
          <select
            className="form-select"
            value={invoice.status}
            onChange={(e) => setInvoice({ ...invoice, status: e.target.value })}
          >
            <option value="">Select status</option>
            <option value="Paid">Paid</option>
            <option value="Pending">Pending</option>
          </select>
        </div>
      </div>

      <div className="row mb-3">
        <label className="col-sm-2 col-form-label">Products:</label>
        <div className="col-sm-10">
          <div className="d-flex align-items-center mb-2">
            <select
              className="form-select me-2"
              value={selectedProduct?.productId || ''}
              onChange={(e) =>
                setSelectedProduct(
                  products.find((product) => product.productId === parseInt(e.target.value)) || null
                )
              }
            >
              <option value="">Select product</option>
              {products.map((product) => (
                <option key={product.productId} value={product.productId}>
                  {product.productName}
                </option>
              ))}
            </select>
            <button className="btn btn-primary" onClick={handleAddProduct}>
              Add a product
            </button>
          </div>
          <table className="table">
            <thead>
              <tr>
                <th>Product Name</th>
                <th>Quantity</th>
                <th>Discount (%)</th>
              </tr>
            </thead>
            <tbody>
              {invoiceProducts.map((product, index) => (
                <tr key={product.productId}>
                  <td>{products.find((p) => p.productId === product.productId)?.productName || ''}</td>
                  <td>
                    <input
                      type="number"
                      className="form-control"
                      value={product.quantity}
                      onChange={(e) => handleQuantityChange(index, parseInt(e.target.value))}
                    />
                  </td>
                  <td>
                    <input
                      type="number"
                      className="form-control"
                      value={product.discount}
                      onChange={(e) => handleDiscountChange(index, parseInt(e.target.value))}
                    />
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>

      <div className="row mb-3">
        <label className="col-sm-2 col-form-label">Order Summary:</label>
        <div className="col-sm-10">
          <p>Subtotal: ${invoiceSummary.subTotal}</p>
          <p>Itbis: ${invoiceSummary.itbis.toFixed(2)}</p>
          <p>Descuentos: ${invoiceSummary.discount}</p>
          <p>Total: ${invoiceSummary.total.toFixed(2)}</p>
        </div>
      </div>

      <div className="row mb-3">
        <div className="col-sm-2"></div>
        <div className="col-sm-10">
          <button className="btn btn-primary" onClick={handleCreateInvoice}>
            Create Invoice
          </button>
        </div>
      </div>
    </div>
  );
};

export default CreateInvoice;
