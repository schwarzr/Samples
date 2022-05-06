import { ResolveData, Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { ProjectInfo, ProjectServiceClient } from '../../src/service/service';
import { ProjectService } from './project.service';
import { Injectable } from '@angular/core';

@Injectable()
export class ProjectIdResolver implements Resolve<ProjectInfo>{

    constructor(private service: ProjectServiceClient, private projectService: ProjectService) {

    }

    async resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<ProjectInfo> {
        let projectName = route.params['project'];

        var project = await this.service.getProjectByName(projectName).toPromise();

        if (this.projectService.current && this.projectService.current.id != project.id) {
            this.projectService.current = project;
        }

        return project;
    }
}