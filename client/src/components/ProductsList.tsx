/* eslint-disable @typescript-eslint/no-misused-promises */
/* eslint-disable @typescript-eslint/no-floating-promises */
/* eslint-disable @typescript-eslint/restrict-template-expressions */
/* eslint-disable @typescript-eslint/no-unsafe-assignment */
/* eslint-disable @typescript-eslint/no-unsafe-member-access */
/* eslint-disable @typescript-eslint/no-unsafe-argument */
import { useState, useEffect } from 'react';
import axios from 'axios';
import { Product } from '../IInvoce';
import { FaEdit, FaTrash } from 'react-icons/fa';

const ProductsList = () => {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    getProducts();
  }, []);

  const getProducts = async () => {
    try {
      const response = await axios.get('http://localhost:5194/Product');
      setProducts(response.data);
    } catch (error) {
      console.error('Error al obtener las facturas:', error);
    }
  };


  return (
    <div className="container mt-4">
      <h1 className="text-center">Products List</h1>

      <table className="table">
        <thead>
          <tr>
            <th>ProductId</th>
            <th>Product Name</th>
            <th>Price</th>
          </tr>
        </thead>
        <tbody>
          {products.map((product) => (
            <tr key={product.productId}>
              <td>{`${product.productName}`}</td>
              <td>{product.price}</td>
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

export default ProductsList;
