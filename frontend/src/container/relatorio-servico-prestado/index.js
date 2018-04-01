import React, {Component} from 'react'
import {
  Table,
  Form,
  FormGroup,
  ControlLabel,
  FormControl,
  Button
} from 'react-bootstrap'
import Fetch from './../../utils/fetch'
import {currencyMask, formatNumberFromCommaToDot} from './../../utils/form-validation'

import StyledRelatorioServicoPrestado from './styledRelatorioServicoPrestado'

export default class RelatorioServicoPrestado extends Component {

  constructor() {
    super()

    this.state = {
      servicosPrestados: [],
      dataDe: '',
      dataAte: '',
      estado: '',
      cliente: '',
      cidade: '',
      bairro: '',
      valorMinimo: '',
      valorMaximo: ''
    }
  }

  componentDidMount() {
    Fetch
      .get(`servicoprestado/relatorio`)
      .then((response) => this.setState({servicosPrestados: response.data}))
  }

  handleChange = (e, propName) => {
    this.setState({[propName]: e.target.value})
  }

  handleChangeValue = (e, propName) => {
    e.target.value = currencyMask(e.target.value)
    this.setState({[propName]: e.target.value})
  }

  filtrar = () => {
    const queryParameter = {
      DataDe: this.state.dataDe,
      DataAte: this.state.dataAte,
      Cidade: this.state.cidade,
      Cliente: this.state.cliente,
      Bairro: this.state.bairro,
      Estado: this.state.estado,
      ValorMaximo: formatNumberFromCommaToDot(this.state.valorMaximo),
      ValorMinimo: formatNumberFromCommaToDot(this.state.valorMinimo),
    }

    Fetch
      .get(`servicoprestado/relatorio?${this.queryParams(queryParameter)}`)
      .then((response) => this.setState({servicosPrestados: response.data}))
  }

  queryParams = (obj) => {
    let str = [];
    for (let p in obj)
      if (obj.hasOwnProperty(p)) {
        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
      }
    return str.join("&");
  }

  render() {
    const {
      servicosPrestados,
      dataDe,
      dataAte,
      estado,
      cliente,
      cidade,
      bairro,
      valorMinimo,
      valorMaximo
    } = this.state

    return (
      <StyledRelatorioServicoPrestado>
        <Form inline>
          <FormGroup>
            <ControlLabel className="espaco-label">Período de:</ControlLabel>
            <FormControl
              className="espaco-label"
              id="dataDe"
              type="date"
              value={dataDe}
              onChange={e => this.handleChange(e, 'dataDe')}/>
          </FormGroup>

          <FormGroup>
            <ControlLabel className="espaco-label">Período até:</ControlLabel>
            <FormControl
              className="espaco-label"
              id="dataAte"
              type="date"
              value={dataAte}
              onChange={e => this.handleChange(e, 'dataAte')}/>
          </FormGroup>
        </Form>
        <Form inline>
          <FormGroup>
            <ControlLabel className="espaco-label">Cliente:</ControlLabel>
            <FormControl
              className="espaco-label"
              id="cliente"
              type="text"
              placeholder="Cliente"
              value={cliente}
              onChange={e => this.handleChange(e, 'cliente')}/>
          </FormGroup>

          <FormGroup>
            <ControlLabel className="espaco-label">Estado:</ControlLabel>
            <FormControl
              className="espaco-label"
              id="estado"
              type="text"
              placeholder="Estado"
              value={estado}
              onChange={e => this.handleChange(e, 'estado')}/>
          </FormGroup>
        </Form>
        <Form inline>
          <FormGroup>
            <ControlLabel className="espaco-label">Cidade:</ControlLabel>
            <FormControl
              className="espaco-label"
              id="cidade"
              type="text"
              placeholder="Cidade"
              value={cidade}
              onChange={e => this.handleChange(e, 'cidade')}/>
          </FormGroup>

          <FormGroup>
            <ControlLabel className="espaco-label">Bairro:</ControlLabel>
            <FormControl
              className="espaco-label"
              id="bairro"
              type="text"
              placeholder="Bairro"
              value={bairro}
              onChange={e => this.handleChange(e, 'bairro')}/>
          </FormGroup>
        </Form>

        <Form inline>
          <FormGroup>
            <ControlLabel className="espaco-label">Valor mínimo</ControlLabel>
            <FormControl
              className="espaco-label"
              id="valorMinimo"
              type="text"
              placeholder="Valor mínimo"
              value={valorMinimo}
              onChange={e => this.handleChangeValue(e, 'valorMinimo')}/>
          </FormGroup>
          <FormGroup>
            <ControlLabel className="espaco-label">Valor máximo</ControlLabel>
            <FormControl
              className="espaco-label"
              id="valorMaximo"
              type="text"
              placeholder="Valor máximo"
              value={valorMaximo}
              onChange={e => this.handleChangeValue(e, 'valorMaximo')}/>
          </FormGroup>
        </Form>

        <Button bsStyle="default" onClick={this.filtrar}>Filtrar</Button>

        <Table responsive>
          <thead>
            <tr>
              <th>Cliente</th>
              <th>Bairro</th>
              <th>Cidade</th>
              <th>Estado</th>
              <th>Tipo serviço</th>
              <th>Valor</th>
              <th>Data atendimento</th>
            </tr>
          </thead>
          <tbody>
            {servicosPrestados.length
              ? servicosPrestados.map((servico, index) => (
                <tr key={index}>
                  <td>{servico.cliente}</td>
                  <td>{servico.bairro}</td>
                  <td>{servico.cidade}</td>
                  <td>{servico.estado}</td>
                  <td>{servico.tipoServico}</td>
                  <td>{servico.valor}</td>
                  <td>{servico.dataAtendimento}</td>
                </tr>
              ))
              : <div>Nenhum registro encontrado.</div>}
          </tbody>
        </Table>
      </StyledRelatorioServicoPrestado>
    )
  }
}