import React, {Component} from 'react'
import {Navbar, Nav, MenuItem, NavItem} from 'react-bootstrap'
import Fetch from './../../utils/fetch'
import StyledMenu from './styledMenu'

class Menu extends Component {

  constructor(){
    super()
    this.state = {
      showServicoPrestado: false,
    }
  }

  componentDidMount(){
    const hash = localStorage.getItem('AUTH-TOKEN-HASH')
    this.setState({
      showServicoPrestado: !!hash
    })
  }

  sair = () => {
    localStorage.clear()
    window.location.href = '/login'
  }

  estatisticas = () =>{
    window.location.href = '/estatisticas'
  }

  cadastrar = () =>{
    window.location.href = '/servicosprestados/cadastrar'
  }

  relatorio = () =>{
    window.location.href = '/servicosprestados/relatorio'
  }

  render() {
    const {showServicoPrestado} = this.state
    return (
      <StyledMenu>
      <Navbar inverse collapseOnSelect style={{backgroundColor: '#2f4296'}}>
        <Navbar.Header>
          <Navbar.Brand>
            <a href="/">Teste Meta</a>
          </Navbar.Brand>
        </Navbar.Header>

        <Nav>
          {showServicoPrestado && <NavItem eventKey={1} href="#" onClick={this.cadastrar}>Cadastrar serviço</NavItem>}
          {showServicoPrestado && <NavItem eventKey={2} href="#" onClick={this.relatorio}>Relatório serviço</NavItem>}
          <NavItem eventKey={3} href="#" onClick={this.estatisticas}>Estatísticas</NavItem>
          <NavItem eventKey={4} href="#" onClick={this.sair}>Sair</NavItem>
        </Nav>
      </Navbar>
      </StyledMenu>
    )
  }
}

export default Menu