import React, { Component } from 'react';
import { Route } from 'react-router';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { BrowserRouter as Router, Switch, Link } from "react-router-dom";
import Login from "./components/Loginform/login.component";
import Layout from "./components/Layout/layout.js";
import Home from "./views/home.js"
import Taxes from "./views/taxes.js"

export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
        <Router>
            {
                <Layout >
                    <Route exact path='/' component={Home} />
                    <Route path='/taxes' component={Taxes} />
                </Layout>
            /* <div className="App">
                <div className="outer">
                    <div className="inner">
                        <Switch>
                            <Route exact path='/' component={Login} />
                            <Route path="/sign-in" component={Login} />
                        </Switch>
                    </div>
                </div>
            </div> */}
        </Router>
      );
  }
}
