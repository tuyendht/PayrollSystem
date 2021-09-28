import React, { Component } from "react";
export default class Sidebar extends Component{
    
    render() {
        return (

        <><nav id="sidebar">
                <div className="sidebar-header">
                    <h3>Payroll System</h3>
                </div>

                <ul className="list-unstyled components">
                    <li className="active">
                        <a data-toggle="collapse" aria-expanded="false" className="dropdown-toggle">
                            <i className="fas fa-home"></i>
                            Home
                        </a>
                        <ul className="collapse list-unstyled" id="homeSubmenu">
                            <li>
                                <a>Home 1</a>
                            </li>
                            <li>
                                <a>Home 2</a>
                            </li>
                            <li>
                                <a>Home 3</a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a>
                            <i className="fas fa-briefcase"></i>
                            About
                        </a>
                        <a data-toggle="collapse" aria-expanded="false" className="dropdown-toggle">
                            <i className="fas fa-copy"></i>
                            Pages
                        </a>
                        <ul className="collapse list-unstyled" id="pageSubmenu">
                            <li>
                                <a>Page 1</a>
                            </li>
                            <li>
                                <a>Page 2</a>
                            </li>
                            <li>
                                <a>Page 3</a>
                            </li>
                        </ul>
                    </li>
                </ul>

            </nav>
            <div id="content">
                    <nav class="navbar navbar-expand-lg navbar-light bg-light">
                        <div class="container-fluid">
                            <button type="button" id="sidebarCollapse" class="btn btn-info">
                                <i class="fas fa-align-left"></i>
                                <span>Toggle Sidebar</span>
                            </button>
                        </div>
                    </nav>
                </div></>
        );
    }
}