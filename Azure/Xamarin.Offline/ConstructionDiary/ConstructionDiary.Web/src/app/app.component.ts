import { Component, OnInit } from '@angular/core';
import { ProjectService } from './project.service';
import { ProjectInfo } from 'src/service/service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: []
})
export class AppComponent implements OnInit {
  async ngOnInit(): Promise<void> {
    await this.projectService.initialize();
  }

  public isCollapsed: boolean = true;

  public selectProject(projectid: string) {
    this.projectService.current = this.projectService.projects.filter(p => p.id == projectid)[0];
  }

  constructor(public projectService: ProjectService) {
  }
}
