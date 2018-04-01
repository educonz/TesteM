import React, { Component } from 'react'
import {FormGroup, ControlLabel, FormControl, Button} from 'react-bootstrap'
import Fetch from './../../utils/fetch'

import StyledLogin from './styledLogin'

import alertify from 'alertify.js'

const alert = alertify.logPosition('top right')

class Login extends Component {

  constructor(props){
    super(props)

    this.state = {
      usuario: '',
      senha: '',
    }
  }

  componentDidMount(){
    localStorage.clear()
  }

  handleChange = (e, propName) => {
    this.setState({ [propName]: e.target.value })
  }

  login = () => {
    const dados = {
      username: this.state.usuario,
      password: this.state.senha
    }

    Fetch.post('login', dados)
    .then((response) => {
      if (response.data.sucesso) {
        localStorage.setItem(Fetch.hashKey, response.data.mensagem)
        this.props.history.push('/')
      }
      else {
        alert.error('Usuário ou senha inválidos. * Utilize admin e senha 12345')
      }
    })
    .catch((erro) => alert.error('Usuário ou senha inválidos.'))
  }

  estatisticas = () =>{
    window.location.href = '/estatisticas'
  }

  render(){
    const {
      usuario,
      senha,
    } = this.state

    return(
      <StyledLogin>
        <div className="container-login">
        <FormGroup>
            <ControlLabel>Usuário</ControlLabel>
            <FormControl
              id="usuario"
              type="text"
              placeholder="Usuário"
              value={usuario}
              onChange={e => this.handleChange(e, 'usuario')} />
          </FormGroup>

          <FormGroup>
            <ControlLabel>Senha</ControlLabel>
            <FormControl
              id="senha"
              type="password"
              placeholder="Senha"
              value={senha}
              onChange={e => this.handleChange(e, 'senha')} />
          </FormGroup>

          <div className="ajustar-botoes">
          <Button bsStyle="primary btn" onClick={this.login}>Login</Button>
          <Button bsStyle="default btn" onClick={this.estatisticas}>Estatísticas</Button>
          </div>
          </div>
      </StyledLogin>
    )
  }
}

export default Login