import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import api from '../api/api';

const BuyerUpdate = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [lastName, setLastName] = useState('');
  const [firstName, setFirstName] = useState('');
  const [middleName, setMiddleName] = useState('');
  const [passportSeries, setPassportSeries] = useState('');
  const [passportNumber, setPassportNumber] = useState('');
  const [address, setAddress] = useState('');
  const [message, setMessage] = useState('');
  const [error, setError] = useState(null);
  const [isLoading, setIsLoading] = useState(true); 

  useEffect(() => {
    const fetchBuyer = async () => {
      try {
        const response = await api.get(`/Buyer/${id}`);
        setLastName(response.data.LastName);
        setFirstName(response.data.FirstName);
        setMiddleName(response.data.MiddleName);
        setPassportSeries(response.data.PassportSeries);
        setPassportNumber(response.data.PassportNumber);
        setAddress(response.data.Address);
      } catch (error) {
        console.error('Error fetching buyer:', error);
        setError('Buyer not found');
      } finally {
        setIsLoading(false); 
      }
    };

    fetchBuyer();
  }, [id]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.put(`/Buyer/${id}`, { 
        LastName: lastName.trim(),
        FirstName: firstName.trim(),
        MiddleName: middleName.trim(),
        PassportSeries: passportSeries,
        PassportNumber: passportNumber,
        Address: address
      });
      setMessage('Buyer updated successfully!');
      setTimeout(() => {
        navigate('/');
      }, 1000);
    } catch (error) {
      console.error('Error updating buyer:', error);
      setMessage('Failed to update buyer.');
    }
  };

  if (isLoading) {
    return <div>Loading...</div>; 
  }

  return (
    <div className="container mt-5">
      <h2>Edit Buyer</h2>
      {message && (
        <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
          {message}
        </div>
      )}
      {error && (
        <div className="alert alert-danger" role="alert">
          {error}
        </div>
      )}
      {!error && (
        <form onSubmit={handleSubmit}>
          <div className="mb-3">
            <label htmlFor="lastName" className="form-label">Last Name:</label>
            <input
              type="text"
              className="form-control"
              id="lastName"
              value={lastName}
              onChange={(e) => setLastName(e.target.value)}
              required
            />
          </div>
          <div className="mb-3">
            <label htmlFor="firstName" className="form-label">First Name:</label>
            <input
              type="text"
              className="form-control"
              id="firstName"
              value={firstName}
              onChange={(e) => setFirstName(e.target.value)}
              required
            />
          </div>
          <div className="mb-3">
            <label htmlFor="middleName" className="form-label">Middle Name:</label>
            <input
              type="text"
              className="form-control"
              id="middleName"
              value={middleName}
              onChange={(e) => setMiddleName(e.target.value)}
            />
          </div>
          <div className="mb-3">
            <label htmlFor="passportSeries" className="form-label">Passport Series:</label>
            <input
              type="text"
              className="form-control"
              id="passportSeries"
              value={passportSeries}
              onChange={(e) => setPassportSeries(e.target.value)}
              required
            />
          </div>
          <div className="mb-3">
            <label htmlFor="passportNumber" className="form-label">Passport Number:</label>
            <input
              type="text"
              className="form-control"
              id="passportNumber"
              value={passportNumber}
              onChange={(e) => setPassportNumber(e.target.value)}
              required
            />
          </div>
          <div className="mb-3">
            <label htmlFor="address" className="form-label">Address:</label>
            <input
              type="text"
              className="form-control"
              id="address"
              value={address}
              onChange={(e) => setAddress(e.target.value)}
              required
            />
          </div>
          <button type="submit" className="btn btn-primary">Update Buyer</button>
        </form>
      )}
    </div>
  );
};

export default BuyerUpdate;
