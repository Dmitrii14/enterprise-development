import './App.css';
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import BuyerCreate from './components/BuyerCreate';
import BuyerList from './components/BuyerList';
import BuyerUpdate from './components/BuyerUpdate';
import BuyerDelete from './components/BuyerDelete';

function App() {
  return (
    <Router>
      <div>
        <h1 className="text-center">Buyers Client</h1>
        <Routes>
          <Route path="/" element={<BuyerList />} />
          <Route path="/buyer/create" element={<BuyerCreate />} />
          <Route path="/buyer/update/:id" element={<BuyerUpdate />} />
          <Route path="/buyer/delete/:id" element={<BuyerDelete />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
