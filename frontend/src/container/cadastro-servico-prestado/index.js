import React, {Component} from 'react'
import {FormGroup, ControlLabel, FormControl, Button} from 'react-bootstrap'

import Fetch from './../../utils/fetch'
import { currencyMask, formatNumberFromCommaToDot } from './../../utils/form-validation'
import StyledCadastroServicoPrestado from './styledCadastroServicoPrestado'

import alertify from 'alertify.js'

const alert = alertify.logPosition('top right')

class CadastroServicoPrestado extends Component {

  constructor(props) {
    super(props)

    this.state = {
      clientes: [],
      tiposServico: [],
      descricao: '',
      cliente: '',
      dataAtendimento: '',
      valor: '',
      tipoServico: '',
    }
  }

  componentDidMount() {
    this.encontrarClientes()
    this.encontrarTiposServico()
  }

  encontrarClientes = () => {
    Fetch
      .get('cliente')
      .then((response) => {
        this.setState({
          clientes: response.data,
          cliente: response.data[0].value,
        })
      })
      .catch((erro) => alert.error('Erro ao carregar clientes, verificar conexão com o servidor.'))
  }

  encontrarTiposServico = () => {
    Fetch
      .get('ServicoPrestado/tiposServicos')
      .then((response) => {
        this.setState({
          tiposServico: response.data,
          tipoServico: response.data[0].value,
        })
      })
      .catch((erro) => alert.error('Erro ao carregar tipos de serviço, verificar conexão com o servidor.'))
  }

  cadastrarServico = (e) => {
    e.preventDefault()

    const dadosServico = {
      Descricao: this.state.descricao,
      DataAtendimento: this.state.dataAtendimento,
      ValorServico: formatNumberFromCommaToDot(this.state.valor),
      TipoServico: this.state.tipoServico,
      Cliente: this.state.cliente,
    }

    Fetch.post('servicoprestado', dadosServico)
      .then((response) => {
        alert.success('Salvo com sucesso!')
        this.setState({
          descricao: '',
          valor: '',
        })
      })
      .catch((erro) => {
        if (erro && erro.response.status === 400) {
          erro.response.data.map(e => alert.error(e.Mensagem))
        }
        else {
          alert.error('Erro ao salvar.')
        }
      })
  }

  handleChange = (e, propName) => {
    if (propName === 'valor'){
      e.target.value = currencyMask(e.target.value)
    }

    this.setState({ [propName]: e.target.value })
  }

  render() {
    const {
      clientes,
      tiposServico,
      descricao,
      cliente,
      dataAtendimento,
      valor,
      tipoServico,
    } = this.state

    return (
      <StyledCadastroServicoPrestado>
        <form onSubmit={this.cadastrarServico}>

          <FormGroup>
            <ControlLabel>Cliente</ControlLabel>
            <FormControl
              id="cliente"
              componentClass="select" 
              placeholder="Cliente"
              value={cliente}
              onChange={e => this.handleChange(e, 'cliente')}>
              {clientes.length && 
                clientes
                .map((cliente, index) => <option key={index} value={cliente.value}>{cliente.label}</option>)}
            </FormControl>
          </FormGroup>

          <FormGroup>
            <ControlLabel>Descrição</ControlLabel>
            <FormControl
              id="descricao"
              type="text"
              placeholder="Descrição"
              value={descricao}
              onChange={e => this.handleChange(e, 'descricao')} />
          </FormGroup>

          <FormGroup>
            <ControlLabel>Data de atendimento</ControlLabel>
            <FormControl 
              id="dataAtendimento"
              type="date"
              value={dataAtendimento}
              onChange={e => this.handleChange(e, 'dataAtendimento')} />
          </FormGroup>

          <FormGroup>
            <ControlLabel>Valor</ControlLabel>
            <FormControl
              id="valor"
              type="text"
              placeholder="Valor"
              value={valor}
              onChange={e => this.handleChange(e, 'valor')} />
          </FormGroup>

          <FormGroup>
            <ControlLabel>Tipo de serviço realizado</ControlLabel>
            <FormControl
              id="tipoServico"
              componentClass="select" 
              placeholder="Tipo de serviço realizado"
              value={tipoServico}
              onChange={e => this.handleChange(e, 'tipoServico')}>
              {tiposServico.length && 
                tiposServico
                .map((servico, index) => <option key={index} value={servico.value}>{servico.label}</option>)}
            </FormControl>
          </FormGroup>

          <Button bsStyle="primary" type="submit">Salvar</Button>
        </form>
      </StyledCadastroServicoPrestado>
    )
  }
}

export default CadastroServicoPrestado