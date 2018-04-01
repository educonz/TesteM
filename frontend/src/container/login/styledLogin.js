import styled from 'styled-components'

const StyledLogin = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  height: -webkit-fill-available;
  flex-direction: column;

  .ajustar-botoes {
    display: flex;
    justify-content: space-around;
  }

  .container-login{
    padding: 22px;
    background-color: #e7f0f7;
    border: 1px solid rgba(175,206,243,1);
  }

  .btn {
    width: 100px;
    display: flex;
    justify-content: center;
  }
`

export default StyledLogin