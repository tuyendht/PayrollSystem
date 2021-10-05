import React, { Component } from "react";
import { Button } from "reactstrap";
import SignIn from '../../auth/Signin';
 function NvarbarAdmin(props){
    
        return (
            <>
            <nav className="navbar navbar-expand-sm bg-light navbar-light">
                 <div className="justify-content-end navbar-collapse collapse">
                    <div className="nav mr-auto navbar-nav">
                        <form role="Search" className="navbar-form navbar-left navbar-search-form ml-3 ml-lg-0">
                            <div className="input=group">
                                <i className="nc-icon nc-zoom-split">
                                    <input placeholder="Search..." type="text" className="form-control"></input>
                                </i>
                            </div>
                        </form>
                    </div>
                    {props.dataFromParent !== null && (
                        <button className="btn-primary">
                            Logout
                        </button>
                    )}
                    {props.dataFromParent === null && (
                        <SignIn />
                    )}
                    
                    
                 </div>
            </nav>
            </>
        );
    };

export default NvarbarAdmin