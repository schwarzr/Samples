import { EntityInfo } from '../model/entity-info';
import { SalesOrderItem } from '../model/sales-order-item';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, InjectionToken } from '@angular/core';
import { OrderService } from './order-service';
import { SalesOrderListItem } from "../model/sales-order-list-item";
import { API_URI } from "./api-uri";
import { SalesOrderDetailItem } from "../model/sales-order-detail-item";

@Injectable()
export class RestOrderService extends OrderService {
    constructor( @Inject(API_URI) private uri: string, private client: HttpClient) {
        super();

    }

    public async getSalesTerritories(): Promise<EntityInfo[]> {
        var data = await this.client.get<EntityInfo[]>(this.uri + "territories").toPromise();

        return data
    }

    public async getSalesOrderListItems(salesTerritoryId: number): Promise<SalesOrderListItem[]> {
        var data = await this.client.get<SalesOrderListItem[]>(this.uri + '?salesTerritoryId=' + salesTerritoryId).toPromise();

        return data
    }

    public async getSalesOrderItem(orderId: number): Promise<SalesOrderItem> {
        var data = await this.client.get<SalesOrderItem>(this.uri + orderId).toPromise();

        return data
    }

    public async getSalesOrderDetailItems(orderId: number): Promise<SalesOrderDetailItem[]> {
        var data = await this.client.get<SalesOrderDetailItem[]>(this.uri + orderId + "/items").toPromise();

        return data
    }

    public async getShippingMethods(): Promise<EntityInfo[]> {
        var data = await this.client.get<EntityInfo[]>(this.uri + "shipmethods").toPromise();
        return data;
    }

    public async getShippingAddresses(customerId: number): Promise<EntityInfo[]> {
        var data = await this.client.get<EntityInfo[]>(this.uri + "addresses/shipping?customerId=" + customerId).toPromise();
        return data;
    }

    public async getSalesPeople(): Promise<EntityInfo[]> {
        var data = await this.client.get<EntityInfo[]>(this.uri + "salespeople").toPromise();
        return data;
    }

    public async  getCreditCards(customerId: number): Promise<EntityInfo[]> {
        var data = await this.client.get<EntityInfo[]>(this.uri + "creditcards?customerId=" + customerId).toPromise();
        return data;
    }

    public async getCurrencyRates(): Promise<EntityInfo[]> {
        var data = await this.client.get<EntityInfo[]>(this.uri + "currency").toPromise();
        return data;
    }

    public async getCustomers(): Promise<EntityInfo[]> {
        var data = await this.client.get<EntityInfo[]>(this.uri + "customers").toPromise();
        return data;
    }
}