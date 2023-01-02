import axios from "axios";

const api = axios.create({
    baseURL: "http://localhost:5024"
})

export default class Api {
    async listarTodos(){
        let r = await api.get('/contato');
        return r.data;
    }

    async inserirContato(dsNome,dsEmail,nrTelefone,dtNascimento){
        let contato = {
            dsNome: dsNome,
            dsEmail: dsEmail,
            nrTelefone: nrTelefone,
            dtNascimento: dtNascimento
        }

        let resp = await api.post('/contato',contato);
        return resp.data;
    }

    async alterarContato(pkId,dsNome,dsEmail,nrTelefone,dtNascimento){
        let contato = {
            pkId: pkId,
            dsNome: dsNome,
            dsEmail: dsEmail,
            nrTelefone: nrTelefone,
            dtNascimento: dtNascimento
        }

        await api.put('/contato',contato);
    }


    async deletarContato(contato){
         api.delete(`/contato/${contato}`);
    }
}
