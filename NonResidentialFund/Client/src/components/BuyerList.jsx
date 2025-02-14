import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import api from '../api/api';

const BuyerList = () => {
  const [buyers, setBuyers] = useState([]);
  const [message, setMessage] = useState('');
  const [expandedBuyerId, setExpandedBuyerId] = useState(null); 

  const deleteBuyer = async (id) => {
    const confirmDelete = window.confirm("Are you sure you want to delete this buyer?");
    if (!confirmDelete) return; 

    try {
      await api.delete(`/Buyer/${id}`);
      setBuyers(buyers.filter((buyer) => buyer.buyerId !== id));
      setMessage('Buyer deleted successfully!');
      setTimeout(() => setMessage(''), 3000);
    } catch (error) {
      console.error('Error deleting buyer:', error);
      setMessage('Failed to delete buyer.');
      setTimeout(() => setMessage(''), 3000);
    }
  };

  const toggleExpand = (id) => {
    setExpandedBuyerId(expandedBuyerId === id ? null : id); 
  };

  useEffect(() => {
    const fetchBuyers = async () => {
      try {
        const response = await api.get('/Buyer');
        setBuyers(response.data);
      } catch (error) {
        console.error('Error fetching buyers:', error);
        setMessage('Failed to fetch buyers.');
        setTimeout(() => setMessage(''), 3000);
      }
    };
    fetchBuyers();
  }, []);

  return (
    <div className="container mt-5">
      <h2>Buyer List</h2>
      {message && (
        <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
          {message}
        </div>
      )}
      <Link to="/buyer/create" className="btn btn-success mb-3">Create New Buyer</Link>
      <ul className="list-group">
        {buyers.length > 0 ? (
          buyers.map((buyer) => (
            <li key={buyer.buyerId} className="list-group-item">
              <div className="d-flex justify-content-between align-items-center">
                <span>{buyer.LastName} {buyer.FirstName}</span>
              </div>
              <button 
                className="btn btn-info btn-sm mt-2" 
                onClick={() => toggleExpand(buyer.buyerId)}
              >
                Информация
              </button>
              {expandedBuyerId === buyer.buyerId && (
                <div className="mt-2">
                  <p><strong>Middle Name:</strong> {buyer.middleName}</p>
                  <p><strong>Passport Series:</strong> {buyer.passportSeries}</p>
                  <p><strong>Passport Number:</strong> {buyer.passportNumber}</p>
                  <p><strong>Address:</strong> {buyer.address}</p>
                  <div className="mt-2">
                    <Link to={`/buyer/update/${buyer.buyerId}`} className="btn btn-warning btn-sm me-2">Update</Link>
                    <button onClick={() => deleteBuyer(buyer.buyerId)} className="btn btn-danger btn-sm">Delete</button>
                  </div>
                </div>
              )}
            </li>
          ))
        ) : (
          <li className="list-group-item">No buyers found.</li>
        )}
      </ul>
    </div>
  );
}

export default BuyerList;
