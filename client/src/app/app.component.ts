import { Component } from '@angular/core';
import { ClienteListaComponent } from './components/clientes/cliente-lista/cliente-lista.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ClienteListaComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
}
