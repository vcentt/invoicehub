/* eslint-disable @typescript-eslint/no-misused-promises */
/* eslint-disable @typescript-eslint/no-floating-promises */
/* eslint-disable @typescript-eslint/restrict-template-expressions */
/* eslint-disable @typescript-eslint/no-unsafe-assignment */
/* eslint-disable @typescript-eslint/no-unsafe-member-access */
/* eslint-disable @typescript-eslint/no-unsafe-argument */
import { useState, useEffect } from 'react';
import axios from 'axios';
import { FullInvoce, Invoce } from '../IInvoce';
import { FaPrint, FaEdit, FaTrash, FaInfoCircle } from 'react-icons/fa';
import { Alert } from 'react-bootstrap';

const InvoiceList = () => {
  const [invoices, setInvoices] = useState<Invoce[]>([]);
  const [selectedInvoice, setSelectedInvoice] = useState<FullInvoce>();
  const [modalOpen, setModalOpen] = useState(false);

  useEffect(() => {
    getInvoices();
  }, []);

  const getInvoices = async () => {
    try {
      const response = await axios.get('http://localhost:5194/Invoce');
      setInvoices(response.data);
    } catch (error) {
      console.error('Error al obtener las facturas:', error);
    }
  };

  const handleViewDetails = async (invoiceId:number) => {
    try {
      const response = await axios.get(`http://localhost:5194/Invoce/${invoiceId}`);
      setSelectedInvoice(response.data);
      setModalOpen(true);
    } catch (error) {
      console.error('Error al obtener los detalles de la factura:', error);
    }
  };

  const handleToDelete = (invoceId: number | undefined) => {
    try {
      axios.delete(`http://localhost:5194/Invoce/${invoceId}`);
      <Alert key={'success'} variant='success'>Invoce Deleted Sucesfully</Alert>
    } catch (e) {
      <Alert key={'sucess'} variant='danger'>Error</Alert>
    }
  }

  return (
    <div className="container mt-4">
      <h1 className="text-center">Invoice List</h1>

      <table className="table">
        <thead>
          <tr>
            <th>Full Customer Name</th>
            <th>FacturaId</th>
            <th>Fecha</th>
            <th>Estado</th>
            <th>Amount</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {invoices.map((invoice) => (
            <tr key={invoice.invoceId}>
              <td>{`${invoice.firstName} ${invoice.lastName}`}</td>
              <td>{invoice.invoceId}</td>
              <td>{invoice.date}</td>
              <td>{invoice.status}</td>
              <td>{invoice.total}</td>
              <td>
                <div className="btn-group" role="group">
                  <button
                    type="button"
                    className="btn btn-secondary"
                    onClick={() => handleViewDetails(invoice.invoceId)}
                  >
                    <FaInfoCircle/>
                  </button>
                  <button type="button" 
                  className="btn btn-secondary"
                  
                  >
                    <FaPrint/>
                  </button>
                  <button type="button" className="btn btn-secondary">
                    <FaEdit/>
                  </button>
                  <button type="button" 
                  className="btn btn-secondary"
                  onClick={() => handleToDelete(invoice.invoceId)}
                  >
                    <FaTrash/>
                  </button>
                </div>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {modalOpen && (
        <div className="modal" style={{ display: 'block' }}>
          <div className="modal-dialog">
            <div className="modal-content">
              <div className="modal-header">
                <h5 className="modal-title">Invoice Details</h5>
                <button type="button" className="btn-close" onClick={() => setModalOpen(false)}></button>
              </div>
              <div className="modal-body">
                <p>
                  <strong>Customer Name:</strong> {`${selectedInvoice?.invoce?.firstName} ${selectedInvoice?.invoce?.lastName}`}
                </p>
                <p>
                  <strong>Status:</strong> {selectedInvoice?.invoce?.status}
                </p>
                <p>
                  <strong>Date:</strong> {selectedInvoice?.invoce?.date}
                </p>
                <table className="table">
                  <thead>
                    <tr>
                      <th>Product Name</th>
                      <th>Quantity</th>
                      <th>Price</th>
                    </tr>
                  </thead>
                  <tbody>
                    {selectedInvoice?.products.map((product, index) => (
                      <tr key={index}>
                        <td>{product.invoceProducts.productName}</td>
                        <td>{product.invoceProducts.quantity}</td>
                        <td>{product.invoceProducts.price}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
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
    </div>
  );
};

export default InvoiceList;
