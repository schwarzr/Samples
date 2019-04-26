import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: []
})
export class AppComponent {
  
  public isCollapsed: boolean = true;

  public selectedProject : any;

  constructor(){
    this.selectedProject = {
      name: 'Project 1'
    };
  }
}
