import { Component, Input } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

type InputTypes = "text" | "email" | "password"

@Component({
  selector: 'app-primary-input-component',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './primary-input-component.component.html',
  styleUrl: './primary-input-component.component.scss'
})
export class PrimaryInputComponentComponent {

  @Input() type: InputTypes = "text";
  @Input() placeholder: string = "";
  @Input() label: string = "";
  @Input() inputName: string = "";


}
