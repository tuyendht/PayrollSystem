import React, { Component } from 'react';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import Login from "./components/login.component";


export default class App extends Component {
  static displayName = App.name;

  render () {
      return (<Router>
          <div className="App">
              <div className="outer">
                  <div className="inner">
                      <Switch>
                          <Route exact path='/' component={Login} />
                          <Route path="/sign-in" component={Login} />

                      </Switch>
                  </div>
              </div>
          </div></Router>
      );
  }
}
