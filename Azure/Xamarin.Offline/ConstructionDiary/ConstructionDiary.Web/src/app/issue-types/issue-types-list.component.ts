import { Component, OnInit } from "@angular/core";
import { IssueTypeInfo, IssueClient, IssueTypeListItem } from '../../service/service';

@Component({
    selector: 'issue-types-list',
    templateUrl: './issue-types-list.component.html'
})
export class IssueTypesListComponent implements OnInit {
    public items: IssueTypeListItem[];

    public selectedItem: IssueTypeListItem;

    async ngOnInit(): Promise<void> {
        const data = await this.service.getIssueTypeListItems().toPromise();
        this.items = data;
    }

    constructor(private service: IssueClient) {

    }

    public select(item: IssueTypeListItem) {
        this.selectedItem = item;
    }

    public async delete(item: IssueTypeListItem): Promise<void> {
        await this.service.deleteIssueType(item.id).toPromise();
        await this.ngOnInit();
    }

}