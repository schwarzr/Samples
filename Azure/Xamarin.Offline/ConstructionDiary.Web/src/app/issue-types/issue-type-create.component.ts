import { Component, OnInit } from "@angular/core";
import { IssueTypeInfo, IssueServiceClient, IssueTypeListItem } from '../../service/service';
import { ActivatedRouteSnapshot, ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'issue-type-create',
    templateUrl: './issue-type-edit.component.html'
})
export class IssueTypeCreateComponent {
    public item: IssueTypeListItem;

    constructor(private service: IssueServiceClient, private route: ActivatedRoute, private router: Router) {
        this.item = new IssueTypeListItem();
    }

    public async save(): Promise<void> {
        await this.service.insertIssueType(this.item).toPromise();
        const url = this.getNavUrl(this.route);
        await this.router.navigateByUrl(url);
    }

    public getNavUrl(route: ActivatedRoute): string {
        if (route.parent) {
            var items = route.parent.snapshot.pathFromRoot;

            return items.map(p => p.url.join('/')).join('/');
        }
        return "";
    }
}