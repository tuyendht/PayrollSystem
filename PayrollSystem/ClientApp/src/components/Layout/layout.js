import React, { Component } from 'react';
import { Container } from 'reactstrap';
import Sidebar from '../Sidebar/sidebar';
import NvarbarAdmin from '../Nvarbar/NvarbarAdmin.js';
import { Switch, Route } from "react-router-dom";
// import routes from "routes.js";
export default class Layout extends Component{
    render(){
        return (
            <>
            <div className="wrapper">
                <Sidebar />
                <div className="main-panel">
                    <NvarbarAdmin />
                    <div id="content">
                        <Container>
                            {this.props.children}
                        </Container>
                    </div>
                </div>
            </div>
            </>
        );
        }
}