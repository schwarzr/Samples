import { Component, OnInit } from "@angular/core";
import { CountryClient, CountryListItem } from '../../service/service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'country-edit',
    templateUrl: './country-edit.component.html'
})
export class CountryEditComponent implements OnInit {
    public item: CountryListItem;

    async ngOnInit(): Promise<void> {
        var id = this.route.snapshot.params['id']

        const data = await this.service.getCountry(id).toPromise();
        this.item = data;
    }

    constructor(private service: CountryClient, private route: ActivatedRoute, private router: Router) {
    }

    public async save(): Promise<void> {
        await this.service.updateCountry(this.item).toPromise();
        const url = this.getNavUrl(this.route);
        await this.router.navigateByUrl(url);
    }

    public getNavUrl(route: ActivatedRoute): string {
        var items = route.parent.snapshot.pathFromRoot;

        return items.map(p => p.url.join('/')).join('/');
    }
}