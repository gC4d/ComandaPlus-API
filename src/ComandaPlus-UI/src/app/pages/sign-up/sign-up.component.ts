import { Component } from '@angular/core';
import { DefaultLoginLayoutComponent } from '../../components/default-login-layout/default-login-layout.component';
import { PrimaryInputComponentComponent } from '../../components/primary-input-component/primary-input-component.component';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { DefaultMainFormLayoutComponent } from '../../components/default-main-form-layout/default-main-form-layout.component';


interface SignUpForm {
  firstName: FormControl
  lastName: FormControl
  birthDate: FormControl
  email: FormControl,
  password: FormControl
}

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [
    DefaultMainFormLayoutComponent,
    PrimaryInputComponentComponent,
  DefaultLoginLayoutComponent,

    ReactiveFormsModule
  ],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss'
})
export class SignUpComponent {
  signUpForm!: FormGroup<SignUpForm>;

  constructor(){
    this.signUpForm = new FormGroup({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      birthDate: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)])
    })
  }
}
