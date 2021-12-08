import React, { Component } from 'react';
import { Route, Redirect } from 'react-router';
import { Layout } from './components/Layout';
import  DocumentList  from './components/DocumentList';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { ReactSession } from 'react-client-session';
import axios from "axios";
import './custom.css'


ReactSession.setStoreType("sessionStorage");
ReactSession.set("username", "a");
ReactSession.set("id", 1);
console.log(ReactSession.get("username"))


export default class App extends Component {
  static displayName = App.name;

  render () {

    return (
      <Layout>
        <Route exact path='/documents' component={DocumentList} />
        <Route exact path="/">
            <Redirect to="/documents" />
        </Route>
        {/*<Route exact path='/counter' component={Counter} />*/}
        <Route exact path='/fetch-data' component={FetchData} />
      </Layout>
    );
  }
}
