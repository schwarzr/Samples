import { Component, OnInit } from "@angular/core";
import { IssueTypeInfo, IssueClient, IssueTypeListItem } from '../../service/service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'country-edit',
    templateUrl: './issue-type-edit.component.html'
})
export class IssueTypeEditComponent implements OnInit {
    public item: IssueTypeListItem;

    async ngOnInit(): Promise<void> {
        var id = this.route.snapshot.params['id']

        const data = await this.service.getIssueType(id).toPromise();
        this.item = data;
    }

    constructor(private service: IssueClient, private route: ActivatedRoute, private router: Router) {
    }

    public async save(): Promise<void> {
        await this.service.updateIssueType(this.item).toPromise();
        const url = this.getNavUrl(this.route);
        await this.router.navigateByUrl(url);
    }

    public getNavUrl(route: ActivatedRoute): string {
        var items = route.parent.snapshot.pathFromRoot;

        return items.map(p => p.url.join('/')).join('/');
    }
}