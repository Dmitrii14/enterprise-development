import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../api/api';

const BuyerCreate = () => {
  const [lastName, setLastName] = useState('');
  const [firstName, setFirstName] = useState('');
  const [middleName, setMiddleName] = useState('');
  const [passportSeries, setPassportSeries] = useState('');
  const [passportNumber, setPassportNumber] = useState('');
  const [address, setAddress] = useState('');
  const [message, setMessage] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.post('/Buyer', {
        LastName: lastName.trim(),
        FirstName: firstName.trim(),
        MiddleName: middleName.trim(),
        PassportSeries: passportSeries,
        PassportNumber: passportNumber,
        Address: address
      });
      setMessage('Buyer created successfully!');
      setTimeout(() => {
        navigate('/');
      }, 1000);
    } catch (error) {
      console.error('Error creating Buyer:', error);
      setMessage(`Failed to create Buyer: ${error.response?.data || error.message}`);
    }
  };

  return (
    <div className="container mt-5">
      <h2>Create Buyer</h2>
      {message && (
        <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
          {message}
        </div>
      )}
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
        <button type="submit" className="btn btn-primary">Create</button>
      </form>
    </div>
  );
}

export default BuyerCreate;
