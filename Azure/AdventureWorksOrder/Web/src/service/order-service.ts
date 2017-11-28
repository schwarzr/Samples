import { EntityInfo } from '../model/entity-info';
import { Injectable } from '@angular/core';
import { SalesOrderListItem } from '../model/sales-order-list-item';
import { SalesOrderItem } from "../model/sales-order-item";
import { SalesOrderDetailItem } from "../model/sales-order-detail-item";

@Injectable()
export abstract class OrderService {

    public abstract getSalesOrderItem(orderId: number): Promise<SalesOrderItem>;

    public abstract getSalesOrderDetailItems(orderId: number): Promise<SalesOrderDetailItem[]>;

    public abstract getSalesTerritories(): Promise<EntityInfo[]>;

    public abstract getShippingMethods(): Promise<EntityInfo[]>;

    public abstract getCustomers(): Promise<EntityInfo[]>;
    public abstract getSalesPeople(): Promise<EntityInfo[]>;
    public abstract getCreditCards(customerId: number): Promise<EntityInfo[]>;

    public abstract getCurrencyRates(): Promise<EntityInfo[]>;

    public abstract getShippingAddresses(customerId: number): Promise<EntityInfo[]>;


    public abstract getSalesOrderListItems(salesTerritoryId: number): Promise<SalesOrderListItem[]>;
}

