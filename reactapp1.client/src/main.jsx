import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Alerts from './component/Alerts.jsx';
import App from './App.jsx';
//import './index.css';
import Login from './component/login.jsx';
import { UserContext } from './UserContext';



ReactDOM.createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <BrowserRouter>
            <UserContext.Provider value={true}>
            <Routes>
                
                    <Route index element={<App />} />
                    <Route path="login" element={<Login />} />
                    <Route path="Alerts" element={<Alerts />} />
                
                
                </Routes>
            </UserContext.Provider>
        </BrowserRouter>
    
  </React.StrictMode>
)
