import { Component, OnInit } from "@angular/core";
import { IssueTypeInfo, IssueServiceClient, IssueTypeListItem } from '../../service/service';

@Component({
    selector: 'issue-types-list',
    templateUrl: './issue-types-list.component.html'
})
export class IssueTypesListComponent implements OnInit {
    public items: IssueTypeListItem[] = [];

    public selectedItem?: IssueTypeListItem;

    async ngOnInit(): Promise<void> {
        const data = await this.service.getIssueTypeListItems().toPromise();
        if (data) {
            this.items = data;
        }
    }

    constructor(private service: IssueServiceClient) {
    }

    public select(item: IssueTypeListItem) {
        this.selectedItem = item;
    }

    public async delete(item: IssueTypeListItem): Promise<void> {
        if(item.id){
        await this.service.deleteIssueType(item.id).toPromise();
        await this.ngOnInit();
    }
    }
}