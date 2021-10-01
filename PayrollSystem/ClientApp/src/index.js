/*import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import { BrowserRouter } from "react-router-dom";
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
ReactDOM.render(
    <BrowserRouter basename={baseUrl}>
        <App />
    </BrowserRouter>,
    rootElement);
registerServiceWorker();
*/
import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import { BrowserRouter } from "react-router-dom";
import firebase from "firebase/compat/app";

const firebaseConfig = {
    apiKey: "AIzaSyC373L24Sdhih-2oDikayTgVT5heMNoQ0U",
    authDomain: "payroll-9642e.firebaseapp.com",
    projectId: "payroll-9642e",
    storageBucket: "payroll-9642e.appspot.com",
    messagingSenderId: "635041237967",
    appId: "1:635041237967:web:743052b216c15d747b60ba",
    measurementId: "G-DV8QKF9YVS"
};

if (!firebase.apps[0]) {
    firebase.initializeApp(firebaseConfig);
}


ReactDOM.render(
    <BrowserRouter>
        <App />
    </BrowserRouter>,

    document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
registerServiceWorker();