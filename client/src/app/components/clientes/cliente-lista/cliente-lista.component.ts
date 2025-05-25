import { Component, OnInit } from '@angular/core';
import { Cliente, NovoCliente } from '../shared/cliente.model';
import { ClienteService } from '../shared/cliente.service';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ClienteFormularioComponent } from '../cliente-formulario/cliente-formulario.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cliente-lista',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatButtonModule, MatIconModule, ClienteFormularioComponent],
  templateUrl: './cliente-lista.component.html',
  styleUrl: './cliente-lista.component.scss'
})
export class ClienteListaComponent implements OnInit {
  clientes: Cliente[] = [];
  colunas = ['nomeRazaoSocial', 'documento', 'telefone', 'email', 'acoes'];
  formularioAberto = false;
  clienteSelecionado: Cliente | null = null;

  constructor(private clienteService: ClienteService) {}

  ngOnInit() {
    this.carregarClientes();
  }

  carregarClientes() {
    this.clienteService.getClientes().subscribe(clientes => this.clientes = clientes);
  }

  abrirFormulario() {
    this.formularioAberto = true;
    this.clienteSelecionado = null;
  }

  editarCliente(cliente: Cliente) {
    this.formularioAberto = true;
    this.clienteSelecionado = cliente;
  }

  deletarCliente(cliente: Cliente) {
    if (confirm(`Deseja excluir o cliente "${cliente.nomeRazaoSocial}"?`)) {
      this.clienteService.deletarCliente(cliente.id).subscribe(() => this.carregarClientes());
    }
  }

  salvarCliente(cliente: NovoCliente | Cliente) {
    if ('id' in cliente) {
      this.clienteService.atualizarCliente(cliente.id, cliente).subscribe(() => {
        this.carregarClientes();
        this.fecharFormulario();
      });
    } else {
      this.clienteService.criarCliente(cliente).subscribe(() => {
        this.carregarClientes();
        this.fecharFormulario();
      });
    }
  }

  fecharFormulario() {
    this.formularioAberto = false;
    this.clienteSelecionado = null;
  }
}
