import React, { Component,useState } from "react";
import { NavLink } from 'reactstrap';
import {GrContactInfo, GrEdit, GrUserSettings,GrContact} from 'react-icons/gr'
import { IoMdUmbrella } from "react-icons/io";
import { IconContext } from "react-icons/lib";
import { Link } from 'react-router-dom';
import { AiOutlineBarChart ,AiFillCarryOut} from "react-icons/ai";
import { HiOutlineReceiptTax} from "react-icons/hi";
 function Sidebar(){
    const [isCollapse,setIsCollapse] = useState(false);
    
        return (

        <><nav id="sidebar">
                <div className="sidebar-header">
                    <h3>Payroll System</h3>
                </div>
                <div className="user">
                    <div className="navbar">
                        <img className="avatar" alt="tets" src="https://www.w3schools.com/howto/img_avatar.png"></img>
                        <a 
                            className={isCollapse ? "collapsed" : ""} 
                            data-toggle="collapse" 
                            href="#infor"
                            onClick= {() => setIsCollapse(!isCollapse)}
                        >
                            <span>Tran cong minh hieu</span>
                            <i class="arrow down"></i>
                        </a>
                        <div className={isCollapse ? "content-parent show" : "content-parent"}>
                            <div className="content">
                                <IconContext.Provider value={{color : "black", size: "1.2em"}}>
                                <div className="list-group list-group-flush">
                                    <li class="list-group-item"><strong><GrContactInfo />Profile</strong></li>
                                    <li class="list-group-item"><GrEdit />Edit Profile</li>
                                    <li class="list-group-item"><GrUserSettings />Setting</li>
                                </div>
                                </IconContext.Provider>
                            </div>
                        </div>
                    </div>
                </div>
                <IconContext.Provider value={{color : "black", size: "1.2em"}}>
                <div className="list-group">
                    <li class="list-group-item">
                    <NavLink tag={Link} className="text-light" to="/"><AiFillCarryOut />Pay Runs</NavLink>
                    </li>
                    <li class="list-group-item">
                    <NavLink tag={Link} className="text-light" to="/taxes"><HiOutlineReceiptTax />Taxes & Forms</NavLink>
                    </li>
                    <li class="list-group-item">
                    <NavLink tag={Link} className="text-light" to="/benefits"><IoMdUmbrella />Benefits</NavLink>
                    </li>
                    <li class="list-group-item">
                    <NavLink tag={Link} className="text-light" to="/reports"><AiOutlineBarChart />Reports</NavLink>
                    </li>
                    <li class="list-group-item">
                    <NavLink tag={Link} className="text-light" to="/contact"><GrContact />Contact Support</NavLink>
                    </li>
                </div>
                </IconContext.Provider>
            </nav>
                </>
        );
    
};
export default Sidebar