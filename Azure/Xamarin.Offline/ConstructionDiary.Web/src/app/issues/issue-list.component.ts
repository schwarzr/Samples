import { Component, OnInit, Provider } from "@angular/core";
import { PageChangedEvent } from "ngx-bootstrap/pagination";
import { IssueServiceClient, ProjectInfo, IssueListItem } from '../../../src/service/service';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';

@Component({
    selector: 'issue-list',
    templateUrl: './issue-list.component.html'
})
export class IssueListComponent {
    public items: IssueListItem[] = [];

    public totalCount: number = 0;

    public currentPage : number = 0;

    public selectedItem?: IssueListItem;
    
    private project?: ProjectInfo;

    constructor(private service: IssueServiceClient, private currentRoute: ActivatedRoute) {
        currentRoute.data.pipe(map(p => <ProjectInfo>p['project']))
            .subscribe(async p => {
                this.project = p; 
                this.totalCount = 0; 
                await this.loadData();
            });
    }

    public select(item: ProjectInfo) : void{
        this.selectedItem = item;
    }

    public pageChanged(event: PageChangedEvent) : void{
        this.currentPage = event.page;
        this.loadData()
    }

    private async loadData(): Promise<void> {
        if(this.project?.id){
            let data = await this.service.getIssues(this.project.id,this.currentPage * 10, 10, this.totalCount == 0 ? undefined: this.totalCount).toPromise();

            if (data.items) {
                this.items = data.items;
            } else {
                this.items = [];
            }
            if(data.totalCount){
                this.totalCount = data.totalCount;
            }
        }
    }
}