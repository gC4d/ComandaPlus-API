import { Component, Input } from '@angular/core';


@Component({
  selector: 'app-default-main-form-layout',
  standalone: true,
  imports: [
  ],
  templateUrl: './default-main-form-layout.component.html',
  styleUrl: './default-main-form-layout.component.scss'
})
export class DefaultMainFormLayoutComponent {
  @Input() title: string = "";
  @Input() primaryBtnText: string = ""; 
  @Input() secondaryBtnText: string = ""; 
}
