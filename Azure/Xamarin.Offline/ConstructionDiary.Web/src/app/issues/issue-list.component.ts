import { Component, OnInit, Provider } from "@angular/core";
import { IssueServiceClient, ProjectInfo, IssueListItem } from '../../../src/service/service';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';

@Component({
    selector: 'issue-list',
    templateUrl: './issue-list.component.html'
})
export class IssueListComponent {
    public items: IssueListItem[] = [];

    public selectedItem?: IssueListItem;

    constructor(private service: IssueServiceClient, private currentRoute: ActivatedRoute) {
        currentRoute.data.pipe(map(p => <ProjectInfo>p['project']))
            .subscribe(p => this.loadData(p));
    }

    public select(item: ProjectInfo) : void{
        this.selectedItem = item;
    }

    private async loadData(project: ProjectInfo): Promise<void> {
        if(project.id){
            let data = await this.service.getIssues(project.id).toPromise();

            if (data) {
                this.items = data;
            }
        }
    }
}