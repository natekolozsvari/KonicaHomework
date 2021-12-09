import React, { Component } from 'react';
import { Route, Redirect } from 'react-router';
import { Layout } from './components/Layout';
import  DocumentList  from './components/DocumentList';
import Document from './components/Document';
import Registration from './components/Registration';
import Login from './components/Login';
import { Counter } from './components/Counter';
import { ReactSession } from 'react-client-session';
import axios from "axios";
import './custom.css'

ReactSession.setStoreType("localStorage");


export default class App extends Component {
  static displayName = App.name;

  render () {

    return (
      <Layout>
        <Route exact path='/documents' component={DocumentList} />
        <Route exact path="/">
            <Redirect to="/documents" />
        </Route>
        <Route exact path='/documents/:id' component={Document} />
        <Route exact path='/registration' component={Registration} />
        <Route exact path='/login' component={Login} />

      </Layout>
    );
  }
}
