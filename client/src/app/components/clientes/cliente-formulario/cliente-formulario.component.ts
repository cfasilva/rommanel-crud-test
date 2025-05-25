import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { CommonModule } from '@angular/common';
import { Cliente, NovoCliente } from '../shared/cliente.model';

@Component({
  selector: 'app-cliente-formulario',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatSelectModule, MatOptionModule],
  templateUrl: './cliente-formulario.component.html',
  styleUrl: './cliente-formulario.component.scss'
})
export class ClienteFormularioComponent {
  @Input() cliente: Cliente | null = null;
  @Output() salvar = new EventEmitter<NovoCliente | Cliente>();
  @Output() cancelar = new EventEmitter<void>();

  form: FormGroup;

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      nomeRazaoSocial: ['', Validators.required],
      tipoPessoa: ['', [Validators.required, Validators.pattern('^[FJ]$')]],
      documento: ['', Validators.required],
      dataNascimento: [''],
      inscricaoEstadual: [''],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      endereco: this.fb.group({
        cep: ['', Validators.required],
        logradouro: ['', Validators.required],
        numero: ['', Validators.required],
        bairro: ['', Validators.required],
        cidade: ['', Validators.required],
        estado: ['', Validators.required],
      })
    });

    this.form.get('tipoPessoa')?.valueChanges.subscribe(tipo => {
      const dataNascCtrl = this.form.get('dataNascimento');
      const inscricaoEstadualCtrl = this.form.get('inscricaoEstadual');

      if (tipo === 'F') {
        dataNascCtrl?.setValidators([Validators.required]);
      } else {
        dataNascCtrl?.clearValidators();
      }

      if (tipo === 'J') {
        inscricaoEstadualCtrl?.setValidators([Validators.required]);
      } else {
        inscricaoEstadualCtrl?.clearValidators();
      }

      dataNascCtrl?.updateValueAndValidity();
    });
  }

  ngOnChanges() {
    if (this.cliente) {
      this.form.patchValue({
        ...this.cliente,
      });
    } else {
      this.form.reset();
    }
  }

  onSubmit() {
    if (this.form.valid) {
      const value = this.form.value;
      const { ...rest } = value;
      const payload = { ...rest };

      if (this.cliente && this.cliente.id) {
        this.salvar.emit({ ...payload, id: this.cliente.id });
      } else {
        this.salvar.emit(payload);
      }
    }
  }
}
