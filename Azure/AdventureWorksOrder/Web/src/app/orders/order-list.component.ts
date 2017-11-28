import { EntityInfo } from '../../model/entity-info';
import { SalesOrderListItem } from '../../model/sales-order-list-item';
import { Component, Input, OnInit } from '@angular/core';
import { OrderService } from "../../service/order-service";
import 'devextreme/data/odata/store';

@Component({
    selector: 'order-list',
    templateUrl: './order-list.component.html'
})
export class OrderListComponent implements OnInit {

    public orders: any;
    public territories: EntityInfo[];

    private _selectedTerritory: EntityInfo;

    public get selectedTerritory(): EntityInfo {
        return this._selectedTerritory;
    }

    @Input()
    public set selectedTerritory(v: EntityInfo) {
        this._selectedTerritory = v;
        this.loadData(this._selectedTerritory.id);
    }

    private async loadData(salesTerritoryId: number): Promise<void> {
        // this.orders = {
        //     store: {
        //         type: 'odata',
        //         version: 4,
        //         url: 'http://localhost:56187/Orders'
        //     },
        //     select: [
        //         'salesOrderId',
        //         'customer',
        //         'orderDate',
        //         'orderNumber'
        //     ],
        //     filter: ['salesTerritoryId', '=', salesTerritoryId]
        // }

        var data = await this.service.getSalesOrderListItems(salesTerritoryId);
        this.orders = data;
    }

    constructor(private service: OrderService) {

    }

    public async ngOnInit(): Promise<void> {
        var data = await this.service.getSalesTerritories();
        this.territories = data;
        this._selectedTerritory = data[0];
        await this.loadData(this._selectedTerritory.id);
    }
}