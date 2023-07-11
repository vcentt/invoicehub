/* eslint-disable @typescript-eslint/no-misused-promises */
/* eslint-disable @typescript-eslint/no-floating-promises */
/* eslint-disable @typescript-eslint/restrict-template-expressions */
/* eslint-disable @typescript-eslint/no-unsafe-assignment */
/* eslint-disable @typescript-eslint/no-unsafe-member-access */
/* eslint-disable @typescript-eslint/no-unsafe-argument */
import { useState, useEffect } from 'react';
import axios from 'axios';
import { Customer } from '../IInvoce';
import { FaEdit, FaTrash } from 'react-icons/fa';

const CustomersList = () => {
  const [customers, setCustomers] = useState<Customer[]>([]);

  useEffect(() => {
    getProducts();
  }, []);

  const getProducts = async () => {
    try {
      const response = await axios.get('http://localhost:5194/Customer');
      setCustomers(response.data);
    } catch (error) {
      console.error('Error al obtener las facturas:', error);
    }
  };


  return (
    <div className="container mt-4">
      <h1 className="text-center">Customers List</h1>

      <table className="table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Full Name</th>
            <th>Phone</th>
          </tr>
        </thead>
        <tbody>
          {customers.map((customer) => (
            <tr key={customer.customerId}>
              <td>{`${customer.firstName} ${customer.lastName}`}</td>
              <td>{customer.phoneNumber}</td>
              <td>
                <div className="btn-group" role="group">
                  <button type="button" className="btn btn-secondary">
                    <FaEdit/>
                  </button>
                  <button type="button" className="btn btn-secondary">
                    <FaTrash/>
                  </button>
                </div>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default CustomersList;
