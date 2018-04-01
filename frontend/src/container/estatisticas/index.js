import React, { Component } from 'react'
import { Table } from 'react-bootstrap'
import Fetch from './../../utils/fetch'

import StyledEstatisticas from './styledEstatisticas'

class Estatisticas extends Component {

  constructor(){
    super()

    this.state = {
      clientesMaisGastaram: [],
      mediaValorFornecedor: [],
      fornecedoresSemServico: [],
    }
  }

  componentDidMount(){
    Fetch
      .get(`estatistica/clientesQueMaisGastaram`)
      .then((response) => this.setState({clientesMaisGastaram: response.data}))

    Fetch
      .get(`estatistica/mediaFornecedor`)
      .then((response) => this.setState({mediaValorFornecedor: response.data}))

    Fetch
      .get(`estatistica/fornecedoresSemServico`)
      .then((response) => this.setState({fornecedoresSemServico: response.data}))
  }

  render(){
    const {
      clientesMaisGastaram,
      mediaValorFornecedor,
      fornecedoresSemServico,
    } = this.state

    return(
      <StyledEstatisticas>
        <div>
          <span>Top 3 clientes que mais gastaram</span>
          <Table>
            <thead>
              <tr>
                <th>Mês</th>
                <th>Cliente - Valor total gasto no mês</th>
              </tr>
            </thead>
            <tbody>
            {clientesMaisGastaram.length
              ? clientesMaisGastaram.map((item, index) => (
                <tr key={index}>
                  <td>{item.mes}</td>
                  <td>
                    <div>
                    {item.clientes
                    && item.clientes.map((cliente, indexTwo) => (
                      <div key={indexTwo}>{`${cliente.idCliente} - ${cliente.nomeCliente} - ${cliente.valorTotal} `}</div>
                    ))}
                    </div>
                  </td>
                </tr>
              ))
              : <div>Nenhum registro encontrado.</div>}
          </tbody>
          </Table>
        </div>

        <div>
          <span>Média de serviço por fornecedor</span>
          <Table>
            <thead>
              <tr>
                <th>Fornecedor</th>
                <th>Serviço - Valor médio cobrado</th>
              </tr>
            </thead>
            <tbody>
            {mediaValorFornecedor.length
              ? mediaValorFornecedor.map((fornecedor, index) => (
                <tr key={index}>
                  <td>{`${fornecedor.idFornecedor} - ${fornecedor.fornecedor}`}</td>
                  <td>
                    <div>
                    {fornecedor.mediaServico
                    && fornecedor.mediaServico.map((servico, indexTwo) => (
                      <div key={indexTwo}>{`${servico.servico} - ${servico.media}`}</div>
                    ))}
                    </div>
                  </td>
                </tr>
              ))
              : <div>Nenhum registro encontrado.</div>}
          </tbody>
          </Table>
        </div>

        <div>
          <span>Fornecedores que não prestaram serviço</span>
          <Table>
            <thead>
              <tr>
                <th>Mês</th>
                <th>Fornecedor</th>
              </tr>
            </thead>
            <tbody>
            {fornecedoresSemServico.length
              ? fornecedoresSemServico.map((item, index) => (
                <tr key={index}>
                  <td>{item.mes}</td>
                  <td>
                    <div>
                    {item.fornecedores
                    && item.fornecedores.map((fornecedor, indexTwo) => (
                      <div key={indexTwo}>{`${fornecedor.idFornecedor} - ${fornecedor.nome}`}</div>
                    ))}
                    </div>
                  </td>
                </tr>
              ))
              : <div>Nenhum registro encontrado.</div>}
          </tbody>
          </Table>
        </div>

      </StyledEstatisticas>
    )
  }
}

export default Estatisticas