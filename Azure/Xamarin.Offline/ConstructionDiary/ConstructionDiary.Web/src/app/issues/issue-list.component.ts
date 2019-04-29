import { Component, OnInit } from "@angular/core";
import { IssueClient, ProjectInfo, IssueListItem } from '../../../src/service/service';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';

@Component({
    selector: 'issue-list',
    templateUrl: './issue-list.component.html'
})
export class IssueListComponent {

    public items: IssueListItem[];

    constructor(private service: IssueClient, private currentRoute: ActivatedRoute) {
        currentRoute.data.pipe(map(p => <ProjectInfo>p.project))
            .subscribe(p => this.loadData(p));
    }

    private async loadData(project: ProjectInfo): Promise<void> {
        let data = await this.service.getIssues(project.id).toPromise();

        this.items = data;
    }
}