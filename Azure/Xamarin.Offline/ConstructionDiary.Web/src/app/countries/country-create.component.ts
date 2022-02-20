import { Component, OnInit } from "@angular/core";
import { CountryServiceClient, CountryListItem } from '../../service/service';
import { ActivatedRouteSnapshot, ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'country-create',
    templateUrl: './country-edit.component.html'
})
export class CountryCreateComponent {
    public item: CountryListItem;

    constructor(private service: CountryServiceClient, private route: ActivatedRoute, private router: Router) {
        this.item = new CountryListItem();
    }

    public async save(): Promise<void> {
        await this.service.insertCountry(this.item).toPromise();
        const url = this.getNavUrl(this.route);
        await this.router.navigateByUrl(url);
        
    }

    public getNavUrl(route: ActivatedRoute): string {
        if (route.parent) {
            var items = route.parent.snapshot.pathFromRoot;
            return items.map(p => p.url.join('/')).join('/');
        }

        return "";
    }
}