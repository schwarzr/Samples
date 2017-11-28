import { EntityInfo } from '../../model/entity-info';
import { SalesOrderDetailItem } from '../../model/sales-order-detail-item';
import { SalesOrderItem } from '../../model/sales-order-item';
import { OrderService } from '../../service/order-service';
import { ActivatedRoute } from '@angular/router';
import { Component } from '@angular/core';

@Component({
    selector: "order-detail",
    templateUrl: "./order-detail.component.html"
})
export class OrderDetailComponent {
    public item: SalesOrderItem;
    public details: SalesOrderDetailItem[] = [];
    public territories: EntityInfo[] = [];
    public shippingmethods: EntityInfo[] = [];
    public shippingaddresses: EntityInfo[] = [];
    public creditcards: EntityInfo[] = [];
    public customers: EntityInfo[] = [];
    public salespeople: EntityInfo[] = [];




    constructor(private route: ActivatedRoute, private service: OrderService) {
        route.params.subscribe(p => this.loadData(<number>p['id']));
    }

    private async loadData(id: number): Promise<void> {
        let data = await this.service.getSalesOrderItem(id);
        let detailData = await this.service.getSalesOrderDetailItems(id);
        this.territories = await this.service.getSalesTerritories();
        this.shippingmethods = await this.service.getShippingMethods();
        this.shippingaddresses = await this.service.getShippingAddresses(data.customer.id);
        this.customers = await this.service.getCustomers();
        this.salespeople = await this.service.getSalesPeople();
        this.creditcards = await this.service.getCreditCards(data.customer.id);

        this.item = data;
        this.details = detailData;
    }
}