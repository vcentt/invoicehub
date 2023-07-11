import { useEffect } from 'react'
import './App.css'
import CreateInvoice from './components/CreateInvoice'
import Navbar from './components/Navbar'

import TopNavbar from './components/TopNavbar'
import InvoiceList from './components/InvoiceList'
import { Route, Routes } from 'react-router-dom'
import ProductsList from './components/ProductsList'
import CustomersList from './components/CustomersList'

function App() {
  return (
    <div className=''>
      <Navbar/>
      <TopNavbar/>
      <Routes>
        {/* /* <Route path='/' element={} />
        <Route path='/new-customer' element={} /> */}
        <Route path='/manage-customers' element={<CustomersList/>} />
        <Route path='/new-invoice' element={<CreateInvoice/>} />
        <Route path='/manage-invoices' element={<InvoiceList/>} />
        {/* <Route path='/new-product' element={} /> */}
        <Route path='/manage-products' element={<ProductsList/>} /> */
      </Routes>
    </div>
  )
}

export default App
