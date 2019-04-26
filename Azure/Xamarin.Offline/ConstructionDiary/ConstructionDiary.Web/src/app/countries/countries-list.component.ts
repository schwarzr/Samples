import { Component, OnInit } from "@angular/core";
import { CountryClient, CountryListItem } from '../../service/service';

@Component({
    selector: 'countries-list',
    templateUrl: './countries-list.component.html'
})
export class CountriesListComponent implements OnInit {
    public items: CountryListItem[];

    public selectedItem: CountryListItem;

    async ngOnInit(): Promise<void> {
        const data = await this.service.getCountryListItems().toPromise();
        this.items = data;
    }

    constructor(private service: CountryClient) {

    }

    public select(item: CountryListItem) {
        this.selectedItem = item;
    }

    public async delete(item: CountryListItem): Promise<void> {
        await this.service.deleteCountry(item.id).toPromise();
        await this.ngOnInit();
    }

}