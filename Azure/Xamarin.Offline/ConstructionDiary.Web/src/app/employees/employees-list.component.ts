import { Component, OnInit } from "@angular/core";
import { IssueTypeInfo, IssueClient, IssueTypeListItem, EmployeeListItem, EmployeeClient, ProjectInfo } from '../../service/service';
import { ProjectService } from '../project.service';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { ProjectIdResolver } from '../project-id.resolver';

@Component({
    selector: 'employees-list',
    templateUrl: './employees-list.component.html'
})
export class EmployeesListComponent {
    public items: EmployeeListItem[];
    private project: ProjectInfo;

    public selectedItem: EmployeeListItem;

    async loadData(): Promise<void> {
        const data = await this.service.getEmployeeListItems(this.project.id).toPromise();
        this.items = data;
    }

    constructor(private service: EmployeeClient, currentRoute: ActivatedRoute) {
        currentRoute.data.pipe(map(p => <ProjectInfo>p.project))
            .subscribe(p => { this.project = p; this.loadData(); });
    }

    public select(item: EmployeeListItem) {
        this.selectedItem = item;
    }

    public async delete(item: IssueTypeListItem): Promise<void> {
        await this.service.delete(item.id).toPromise();
        await this.loadData();
    }

}