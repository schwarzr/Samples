import { Component, OnInit } from "@angular/core";
import { IssueTypeInfo, IssueServiceClient, IssueTypeListItem, EmployeeServiceClient, EmployeeListItem, ProjectInfo } from '../../service/service';
import { ActivatedRoute, Router } from '@angular/router';
import { map } from 'rxjs/operators';

@Component({
    selector: 'employee-edit',
    templateUrl: './employee-edit.component.html'
})
export class EmployeeEditComponent {
    public item?: EmployeeListItem;
    private project?: ProjectInfo;

    async loadData(): Promise<void> {
        var id = this.route.snapshot.params['id']

        const data = await this.service.getEmployeeListItem(id).toPromise();
        if (data) {
            this.item = data;
        }
    }

    constructor(private service: EmployeeServiceClient, private route: ActivatedRoute, private router: Router) {
        route.data.pipe(map(p => <ProjectInfo>p['project']))
            .subscribe(p => { this.project = p; this.loadData(); });
    }

    public async save(): Promise<void> {
        if (this.item) {
            await this.service.update(this.item).toPromise();
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