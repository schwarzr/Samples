import { Component, OnInit } from "@angular/core";
import { IssueTypeInfo, IssueServiceClient, IssueTypeListItem, EmployeeListItem, EmployeeServiceClient, ProjectInfo } from '../../service/service';
import { ProjectService } from '../project.service';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { ProjectIdResolver } from '../project-id.resolver';

@Component({
    selector: 'employees-list',
    templateUrl: './employees-list.component.html'
})
export class EmployeesListComponent {
    public items: EmployeeListItem[] = [];
    private project?: ProjectInfo;

    public selectedItem?: EmployeeListItem;

    async loadData(): Promise<void> {
        if (this.project?.id) {
            const data = await this.service.getEmployeeListItems(this.project.id).toPromise();
            if (data) {
                this.items = data;
            }
        }
    }

    constructor(private service: EmployeeServiceClient, currentRoute: ActivatedRoute) {
        currentRoute.data.pipe(map(p => <ProjectInfo>p['project']))
            .subscribe(p => { this.project = p; this.loadData(); });
    }

    public select(item: EmployeeListItem) {
        this.selectedItem = item;
    }

    public async delete(item: IssueTypeListItem): Promise<void> {
        if(item.id){
            await this.service.delete(item.id).toPromise();
            await this.loadData();
        }
    }
}