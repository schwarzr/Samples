import { Component, OnInit } from "@angular/core";
import { IssueTypeInfo, IssueServiceClient, IssueTypeListItem, EmployeeServiceClient, EmployeeListItem, ProjectInfo } from '../../service/service';
import { ActivatedRouteSnapshot, ActivatedRoute, Router } from '@angular/router';
import { ProjectService } from '../project.service';
import { map } from 'rxjs/operators';

@Component({
    selector: 'employee-create',
    templateUrl: './employee-edit.component.html'
})
export class EmployeeCreateComponent {
    public item: EmployeeListItem;
    private project?: ProjectInfo;

    constructor(private service: EmployeeServiceClient, private route: ActivatedRoute, private router: Router) {
        this.item = new EmployeeListItem();

        route.data.pipe(map(p => <ProjectInfo>p['project'] ?? null))
            .subscribe(p => { this.project = p; });
    }

    public async save(): Promise<void> {
        if (this.project?.id) {
            await this.service.insert(this.project.id, this.item).toPromise();
            const url = this.getNavUrl(this.route);
            await this.router.navigateByUrl(url);
        }
    }

    public getNavUrl(route: ActivatedRoute): string {
        if (route.parent) {
            var items = route.parent.snapshot.pathFromRoot;

            return items.map(p => p.url.join('/')).join('/');
        }
        return "";
    }
}