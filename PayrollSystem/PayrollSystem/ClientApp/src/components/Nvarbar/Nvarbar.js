//import React, { Component } from "react";
//import { Button } from "reactstrap";
//import SignIn from '../../auth/Signin';
// function Nvarbar(props){
    
//        return (
//            <>
//            <nav className="navbar navbar-expand-sm bg-light navbar-light">
//                 <div className="justify-content-end navbar-collapse collapse">
//                    <div className="nav mr-auto navbar-nav">
//                        <form role="Search" className="navbar-form navbar-left navbar-search-form ml-3 ml-lg-0">
//                            <div className="input=group">
//                                <i className="nc-icon nc-zoom-split">
//                                    <input placeholder="Search..." type="text" className="form-control"></input>
//                                </i>
//                            </div>
//                        </form>
//                    </div>
//                    {props.dataFromParent !== null && (
//                        <button className="btn-primary">
//                            Logout
//                        </button>
//                    )}
//                    {props.dataFromParent === null && (
//                        <SignIn />
//                    )}
                    
                    
//                 </div>
//            </nav>
//            </>
//        );
//    };

//export default Nvarbar
import React, { useState } from 'react';
import * as FaIcons from 'react-icons/fa';
import * as AiIcons from 'react-icons/ai';
import { Link, } from 'react-router-dom';
import { Sidebar } from '../Sidebar/Sidebar.js';
import { IconContext } from 'react-icons';
import SignIn from '../../auth/Signin';

function Nvarbar() {
    const [collapseOpen, setCollapseOpen] = React.useState(false);
    const [sidebar, setSidebar] = useState(false);

    const showSidebar = () => setSidebar(!sidebar);

    return (
        <>
            <IconContext.Provider value={{ color: '#fff' }}>
                <nav class="navbar navbar-expand-sm bg-secondary navbar-dark">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <Link to='#' className='menu-bars'>
                                <FaIcons.FaBars onClick={showSidebar} />
                            </Link>
                        </li>

                        <li class="nav-item text-center">

                        </li>
                    </ul>
                    <div class="alignCenter">
                        <form class="form-inline" action="/search">
                            <input class="form-control mr-sm-2" type="text" placeholder="Search" />
                            {/* <button class="btn btn-success" type="submit">Search</button> */}
                        </form>
                    </div>
                    <div class="d-flex">
                        <form class="form-inline" >
                            <SignIn />
                            <button class="btn btn-success" type="submit">Logout</button>
                        </form>
                    </div>
                  

                </nav>
                <nav className={sidebar ? 'nav-menu active' : 'nav-menu'}>
                    <ul className='nav-menu-items' onClick={showSidebar}>
                        <li className='navbar-toggle'>
                            <Link to='#' className='menu-bars'>
                                <AiIcons.AiOutlineClose />
                            </Link>
                        </li>
                       
                        {Sidebar.map((item, index) => {
                            return (
                                <li key={index} className={item.cName}>
                                    <Link to={item.path}>
                                        {item.icon}
                                        <span>{item.title}</span>
                                    </Link>
                                </li>
                            );
                        })}
                    </ul>

                </nav>
            </IconContext.Provider>

        </>
    );
}

export default Nvarbar;