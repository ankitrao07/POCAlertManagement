import React from 'react';
import { useState,useContext } from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import { UserContext } from '../UserContext';

function Login() {
    
    
    const [email, setEmail] = useState();
    const [password, setPassword] = useState();
    const [isAuth, setAuth] = useState();
    const [error, setError] = useState();
    const handleChangeEmail = (e) => {
        setEmail(e.target.value);
    }

    const handleChangePassword = (e) => {
        setPassword(e.target.value);
     }
    const handleSubmit = (event) => {
        event.preventDefault();
        var isAuthenticated = authenticate(email, password)
        setAuth(isAuthenticated)
        

    };
    return (
        <div className="d-flex align-items-center justify-centent-center vh-70">
        <div className="p-3 rounded bg-white w-100">
                <form onSubmit={handleSubmit} className="needs-validation">
                    <div className="form-group">
                        <label>{ isAuth==false?"Email or Password Incorrect !!!":"" }</label>
                    </div>
            <div className="form-group">
                <label>
                    <p>Email ID</p>
                    <input className="form-control" onChange={handleChangeEmail} type="Email" required />
                </label>
            </div>
           <div className="form-group">
            <label>
                <p>Password</p>
                    <input className="form-control" onChange={handleChangePassword} type="password" required />
                </label>
            </div>
            <div>
                <button type="submit" className="btn-primary rounded">SignIn</button>
                </div>
           
                </form>
            </div>
        </div>
    )
   async function authenticate(email,password) {
        //const response = await fetch('auth');
        //const data = await response.json();
        //console.log(data);
        let data = {
            "email": email,
            "password":password
        }

        const response = await fetch('https://localhost:7216/api/Auth', {
            method: 'POST',
            headers: {
                'content-type': "application/json",
                'Access-Control-Allow-Origin': "*"
            },
            body: JSON.stringify(data)
        })
            .then(r => r.json()).then(res => {

                if (res == true) {
                    
                    return true;
                }
                else {
                    console.log(res);
                    return false;
                }
            });

    }
   

    
}
export default Login;