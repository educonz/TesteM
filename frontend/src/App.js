import React, { Component } from 'react'
import Container from './container'
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom'

class App extends Component {
  render() {
    return (
      <Router basename="/">
        <Switch>
          <Route component={Container} />
        </Switch>
      </Router>
    )
  }
}

export default App