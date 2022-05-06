import { Component } from "@angular/core";

@Component({
    selector: 'dashboard',
    templateUrl: './dashboard.component.html',
})
export class DashboardComponent
{
    public company: string;

    constructor() {
        this.company = AppSettings.configuration.company;
    }
}