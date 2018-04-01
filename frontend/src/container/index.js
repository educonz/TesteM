import React, { Component } from 'react'
import { Route } from 'react-router-dom'
import Menu from './menu'
import CadastroServicoPrestado from './cadastro-servico-prestado'
import RelatorioServicoPrestado from './relatorio-servico-prestado'
import Estatisticas from './estatisticas'
import Login from './login'

class Container extends Component {

  render(){
    
    return(
      <div>
        {!this.props.location.pathname.includes('login') && <Menu />}
        <Route path="/servicosprestados/cadastrar" component={CadastroServicoPrestado} />
        <Route path="/servicosprestados/relatorio" component={RelatorioServicoPrestado} />
        <Route path="/estatisticas" component={Estatisticas} />
        <Route path="/login" component={Login} /> 
      </div>
    )
  }
}

export default Container