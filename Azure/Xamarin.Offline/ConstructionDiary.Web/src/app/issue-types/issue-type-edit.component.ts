import { Component, OnInit } from "@angular/core";
import { IssueTypeInfo, IssueServiceClient, IssueTypeListItem } from '../../service/service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'country-edit',
    templateUrl: './issue-type-edit.component.html'
})
export class IssueTypeEditComponent implements OnInit {
    public item?: IssueTypeListItem;

    async ngOnInit(): Promise<void> {
        var id = this.route.snapshot.params['id']

        const data = await this.service.getIssueType(id).toPromise();
        if (data) {
            this.item = data;
        }
    }

    constructor(private service: IssueServiceClient, private route: ActivatedRoute, private router: Router) {
    }

    public async save(): Promise<void> {
        if (this.item) {
            await this.service.updateIssueType(this.item).toPromise();
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