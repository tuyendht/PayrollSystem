import React, { Component } from 'react';
import { Button } from 'reactstrap';
import { Link } from 'react-router-dom';
function Home(){
return (
    <>
        <div className ="">
           <Button tag={Link} to="/register"className="btn btn-primary">Let's Start</Button>
        </div>
        
    </>
)
};
export  default Home