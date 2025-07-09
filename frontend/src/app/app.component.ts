import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModuleModule } from './shared/material-module/material-module.module';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
 // standalone: true,
  //imports: [CommonModule, MaterialModuleModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
   standalone: false
})
export class AppComponent {

}
