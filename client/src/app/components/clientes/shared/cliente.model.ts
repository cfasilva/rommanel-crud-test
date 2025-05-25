export interface Cliente {
  id: number;
  nomeRazaoSocial: string;
  tipoPessoa: 'F' | 'J';
  documento: string;
  dataNascimento: string;
  inscricaoEstadual?: string;
  telefone: string;
  email: string;
  endereco: {
    cep: string;
    logradouro: string;
    numero: string;
    bairro: string;
    cidade: string;
    estado: string;
  };
}

export interface NovoCliente extends Omit<Cliente, 'id'> {}
