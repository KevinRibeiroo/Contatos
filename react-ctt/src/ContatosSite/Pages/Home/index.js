import { useEffect, useState } from "react";
import { Container, MainDadosContatos } from "./styled";
import Api from "../../service/api";
import { InputMaxStr, InputData } from "../../components/common/inputs";
import { AdcAltContato } from "../../components/common/button";

const api = new Api();

export default function Home(){
    const [contatos,setContatos] = useState([]);
    const [idContato, setIdContato] = useState('');
    const [nome,setNome] = useState('')
    const [telefone, setTelefone] = useState('')
    const [email,setEmail] = useState('')
    const [nascimento, setNascimento] = useState('')

    function resetDados() {
        setIdContato('');
        setEmail('');
        setNome('');
        setTelefone('');
        setNascimento('');
    }

    function alterarDados(item) {
        setIdContato(item.pkId);
        setEmail(item.dsEmail);
        setNome(item.dsNome);
        setTelefone(item.nrTelefone);
        setNascimento(item.dtNascimento);
    }

    async function atualizar(){
        const r = await api.listarTodos();
        setContatos(r);
    }

    async function inserir(){
        if (idContato == 0) {
            const resp = await api.inserirContato(nome,email,telefone,nascimento);
            return resp;
        }
        else {
            await api.alterarContato(idContato,nome,email,telefone,nascimento)
        }
        resetDados();
        atualizar();
    }

    async function deletar(contato){
        api.deletarContato(contato);
        atualizar();
    }

    useEffect(() =>{
        atualizar();
    },[])

    return (
    <Container>
        <main> 
         <div className="Container">
           <MainDadosContatos>
            <div className="Main-inputs">
                <div className="Inputs">
                <div className="input-label">
                        <div className="label">Nome</div>
                        <InputMaxStr type="text" value={nome} onChange={e => setNome(e.target.value)}/>
                </div>
                <div className="input-label">
                    <div className="label">Email</div>
                        <InputMaxStr type="email" value={email} onChange={e => setEmail(e.target.value)} />
                </div>
                </div>
                <div className="Inputs">
                <div className="input-label">
                    <div className="label">Telefone</div>
                        <InputData  value={telefone} onChange={e => setTelefone(e.target.value)} />
                </div>
                <div className="input-label">
                    <div className="label">Nascimento</div>
                        <InputData type="date" value={nascimento} onChange={e => setNascimento(e.target.value)} />
                </div>
                </div>
            </div>
            <div className="Button-adc">
                <AdcAltContato onClick={() => inserir()}>Adicionar</AdcAltContato>
            </div>
            </MainDadosContatos> 
            <div className="TabelaContato"> 
                <table>
                    <thead className="cabecalhoGrid">
                        <th className="nome">Nome</th>
                        <th className="email">Email</th>
                        <th className="telefone">Telefone</th>
                        <th className="nascimento">Data de nascimento</th>
                    </thead>
                    <tbody>
                        {
                            contatos.map((x,i) => 
                                <tr className={i % 2 === 0 ?"Zebra" :""}>
                                    <td >{x.dsNome}</td>
                                    <td>{x.dsEmail}</td>
                                    <td>{x.nrTelefone}</td>
                                    <td>{x.dtNascimento}</td>
                                    <td onClick={() => alterarDados(x)}><img src="/assets/images/alterar.png" alt="" className="iconsTB"/></td>
                                    <td onClick={() => deletar(x.pkId)}><img src="/assets/images/lixo.png" alt="" className="iconsTB"/></td>
                                </tr>
                            )
                        }
                    </tbody>
                </table>
            </div>
          </div>
        </main> 
    </Container> 
    )
}