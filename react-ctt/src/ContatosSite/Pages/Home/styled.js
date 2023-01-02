import styled from 'styled-components';

const Container = styled.div`
    display : flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;

main {
    display : flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    
    width: 100vw;
    height: 100vh;
}
.TabelaContato {
    display:flex;
}

 .TabelaContato table{
    border: 1px solid;
 }

 .nome {
    width: 20em;
 }
 .email {
    width: 20em;
 }

 .telefone {
    width:  8em;
 }

 .nascimento {
    width: 10em;
 }

 .Zebra {
    background-color: #A9A9A9;
 }

  tr {
    align-self: center;
    height: 2em;
  }

  .iconsTB {
    width: 1.3em;
    margin: 0.3em;
  }
`


const MainDadosContatos = styled.div `
display: flex;
flex-direction:  column;

justify-content:  center;
align-items: center;

border: 1px solid;
margin-bottom: 1em;
padding: 0.5em;

.Main-inputs {
   display: flex;

   width: 100%;
}

.Inputs {
   display:flex;
   flex-direction: column;

   align-items:center;
   justify-content: space-around;
   align-self:center;

   margin: 1em;
   height: 7em;

}
.input-label {
   display: flex;
   flex-direction: row;
}

.label {
   align-self: center;
   margin: 1em;

   text-align: right;
   width: 5em;
}

.Button-adc {
   display: flex;
   align-self: flex-end;
}
`

export { Container, MainDadosContatos };