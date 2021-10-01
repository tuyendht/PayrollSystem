import React, { Component } from "react";


export default class NvarbarAdmin extends Component{
    render() {
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
                </div>
                <button>Login</button>
            </nav>
            </>
        );
    }
}