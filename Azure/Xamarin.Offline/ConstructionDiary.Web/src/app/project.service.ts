import { Injectable } from "@angular/core";
import { ProjectInfo, ProjectClient } from '../../src/service/service';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';

@Injectable()
export class ProjectService {
    private _current: ProjectInfo;

    public get current(): ProjectInfo {
        return this._current;
    }

    public set current(value: ProjectInfo) {
        this._current = value;
        var url = this.getNavUrl(value.displayString);
        this.router.navigateByUrl('/' + url);
    }

    public projects: ProjectInfo[] = [];

    constructor(private service: ProjectClient, private route: ActivatedRoute, private router: Router) {
        router.events
            .pipe(filter(e => e instanceof NavigationEnd))
            .subscribe(p =>
                console.log('title', (<NavigationEnd>p).url)
            );
    }

    async initialize(): Promise<void> {
        this.projects = await this.service.getProjects().toPromise();
        this.current = this.projects[0];
    }


    public getNavUrl(newProject: string): string {
        let root = this.router.routerState.snapshot.root;
        while (root.firstChild) {
            root = root.firstChild;
        }

        let items = root.pathFromRoot;

        return items.map(p => (p.routeConfig && p.routeConfig.path == ':project') ? newProject : p.url.join('/')).filter(p => p).join('/');
    }
}