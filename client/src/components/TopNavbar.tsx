/* eslint-disable @typescript-eslint/no-unsafe-assignment */
import React from 'react';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser, faFileInvoice, faBoxOpen, faAngleDown, faTachometerAlt } from '@fortawesome/free-solid-svg-icons';

const TopNavbar: React.FC = () => {
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container">

                <button
                    className="navbar-toggler"
                    type="button"
                    data-bs-toggle="collapse"
                    data-bs-target="#navbarNav"
                    aria-controls="navbarNav"
                    aria-expanded="false"
                    aria-label="Toggle navigation"
                >
                    <span className="navbar-toggler-icon"></span>
                </button>

                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav ml-auto">
                        <li className="nav-item">
                            <Link to="/" className="nav-link">
                                <FontAwesomeIcon icon={faTachometerAlt} /> Dashboard
                            </Link>
                        </li>
                        <li className="nav-item dropdown">
                            <a
                                className="nav-link dropdown-toggle"
                                href="#"
                                id="productsDropdown"
                                role="button"
                                data-bs-toggle="dropdown"
                                aria-expanded="false"
                            >
                                <FontAwesomeIcon icon={faUser} /> Customers <FontAwesomeIcon icon={faAngleDown} />
                            </a>
                            <ul className="dropdown-menu" aria-labelledby="productsDropdown">
                                <li>
                                    <Link to="/new-customer" className="dropdown-item">
                                        New Customer
                                    </Link>
                                </li>
                                <li>
                                    <Link to="/manage-customers" className="dropdown-item">
                                        Manage Customers
                                    </Link>
                                </li>
                            </ul>
                        </li>
                        <li className="nav-item dropdown">
                            <a
                                className="nav-link dropdown-toggle"
                                href="#"
                                id="productsDropdown"
                                role="button"
                                data-bs-toggle="dropdown"
                                aria-expanded="false"
                            >
                                <FontAwesomeIcon icon={faFileInvoice} /> Invoices <FontAwesomeIcon icon={faAngleDown} />
                            </a>
                            <ul className="dropdown-menu" aria-labelledby="productsDropdown">
                                <li>
                                    <Link to="/new-invoice" className="dropdown-item">
                                        New Invoice
                                    </Link>
                                </li>
                                <li>
                                    <Link to="/manage-invoices" className="dropdown-item">
                                        Manage Invoices
                                    </Link>
                                </li>
                            </ul>
                        </li>
                        <li className="nav-item dropdown">
                            <a
                                className="nav-link dropdown-toggle"
                                href="#"
                                id="productsDropdown"
                                role="button"
                                data-bs-toggle="dropdown"
                                aria-expanded="false"
                            >
                                <FontAwesomeIcon icon={faBoxOpen} /> Products <FontAwesomeIcon icon={faAngleDown} />
                            </a>
                            <ul className="dropdown-menu" aria-labelledby="productsDropdown">
                                <li>
                                    <Link to="/new-products" className="dropdown-item">
                                        New Product
                                    </Link>
                                </li>
                                <li>
                                    <Link to="/manage-products" className="dropdown-item">
                                        Manage Products
                                    </Link>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
};

export default TopNavbar;