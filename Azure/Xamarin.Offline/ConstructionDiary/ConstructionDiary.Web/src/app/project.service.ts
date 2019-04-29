import { Injectable } from "@angular/core";
import { ProjectInfo, ProjectClient } from '../../src/service/service';

@Injectable()
export class ProjectService {
    public current: ProjectInfo;

    public projects: ProjectInfo[] = [];

    constructor(private service: ProjectClient) {

    }

    async initialize(): Promise<void> {
        this.projects = await this.service.getProjects().toPromise();
        this.current = this.projects[0];
    }
}