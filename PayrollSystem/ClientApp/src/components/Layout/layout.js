import React, { Component } from 'react';
import Sidebar from '../Sidebar/sidebar';
import NvarbarAdmin from '../Nvarbar/NvarbarAdmin.js';
export default class Layout extends Component{
    render() {
        return (
            <>
            <div className="wrapper">
                <Sidebar />
                <div className="main-panel">
                    <NvarbarAdmin />
                    <div id="content">
                    
                    </div>
                </div>
            </div>
            </>
        );
    }
}