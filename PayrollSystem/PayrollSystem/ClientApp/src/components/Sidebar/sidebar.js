//import react, { component,usestate } from "react";
//import { navlink } from 'reactstrap';
//import {grcontactinfo, gredit, grusersettings,grcontact} from 'react-icons/gr'
//import { iomdumbrella } from "react-icons/io";
//import { iconcontext } from "react-icons/lib";
//import { link } from 'react-router-dom';
//import { aioutlinebarchart ,aifillcarryout} from "react-icons/ai";
//import { hioutlinereceipttax} from "react-icons/hi";
// function sidebar(props){
//    const [iscollapse,setiscollapse] = usestate(false);
    
//        return (

//        <><nav id="sidebar">
//                <div classname="sidebar-header">
//                    <h3>payroll system</h3>
//                </div>
//                <div classname="user">
//                    <div classname="navbar">
//                        <img classname="avatar" alt="tets" src="https://www.w3schools.com/howto/img_avatar.png"></img>
//                        <a  
//                            classname={iscollapse ? "collapsed" : ""} 
//                            data-toggle="collapse" 
//                            href="#infor"
//                            onclick= {() => setiscollapse(!iscollapse)}
//                        >
//                            <span classname="text-left">{props.datafromparent}</span>
//                            <i classname="arrow down"></i>
//                        </a>
//                        <div classname={iscollapse ? "content-parent show" : "content-parent"}>
//                            <div classname="content">
//                                <iconcontext.provider value={{color : "black", size: "1.2em"}}>
//                                <div classname="list-group list-group-flush">
//                                    <li classname="list-group-item"><strong><grcontactinfo />profile</strong></li>
//                                    <li classname="list-group-item"><gredit />edit profile</li>
//                                    <li classname="list-group-item"><grusersettings />setting</li>
//                                </div>
//                                </iconcontext.provider>
//                            </div>
//                        </div>
//                    </div>
//                </div>
//                <iconcontext.provider value={{color : "black", size: "1.2em"}}>
//                <div classname="list-group">
//                    <li classname="list-group-item">
//                    <navlink tag={link} classname="text-light" to="/home"><aifillcarryout />home</navlink>
//                    </li>
//                    <li classname="list-group-item">
//                    <navlink tag={link} classname="text-light" to="/payruns"><aifillcarryout />pay runs</navlink>
//                    </li>
//                    <li classname="list-group-item">
//                    <navlink tag={link} classname="text-light" to="/taxes"><hioutlinereceipttax />taxes & forms</navlink>
//                    </li>
//                    <li classname="list-group-item">
//                    <navlink tag={link} classname="text-light" to="/benefits"><iomdumbrella />benefits</navlink>
//                    </li>
//                    <li classname="list-group-item">
//                    <navlink tag={link} classname="text-light" to="/reports"><aioutlinebarchart />reports</navlink>
//                    </li>
//                    <li classname="list-group-item">
//                    <navlink tag={link} classname="text-light" to="/contact"><grcontact />contact support</navlink>
//                    </li>
//                </div>
//                </iconcontext.provider>
//            </nav>
//                </>
//        );
    
//};
//export default Sidebar
import React from 'react';
import * as FaIcons from 'react-icons/fa';
import * as AiIcons from 'react-icons/ai';
import * as IoIcons from 'react-icons/io';

export const Sidebar = [
    {
        title: 'Home',
        path: '/home',
        icon: <AiIcons.AiFillHome />,
        cName: 'nav-text'
    },
    {
        title: 'Profile',
        path: '/profile',
        icon: <AiIcons.AiFillProfile />,
        cName: 'nav-text'
    },
    {
        title: 'Run Payroll',
        path: '/pay-payroll',
        icon: <FaIcons.FaMoneyBillWave />,
        cName: 'nav-text'
    },
    {
        title: 'Pay Contractors',
        path: '/pay-contractors',
        icon: <FaIcons.FaMoneyBillWaveAlt />,
        cName: 'nav-text'
    },
    {
        title: 'Time Tracking',
        path: '/time-tracking',
        icon: <IoIcons.IoMdTime />,
        cName: 'nav-text'
    },
    {
        title: 'Time Off',
        path: '/time-off',
        icon: <IoIcons.IoMdTimer />,
        cName: 'nav-text'
    },
    {
        title: 'Benefits',
        path: '/benefits',
        icon: <AiIcons.AiOutlineHeart />,
        cName: 'nav-text'
    },
    {
        title: 'Reports',
        path: '/reports',
        icon: <AiIcons.AiFillBook />,
        cName: 'nav-text'
    }

];