import { EntityInfo } from "./entity-info";

export interface SalesOrderItem {
    accountNumber: string;
    billingAddress: EntityInfo;
    creditCard?: EntityInfo;
    currencyRate?: EntityInfo;
    customer: EntityInfo;
    salesOrderDate: string;
    salesOrderId: number;
    salesOrderNumber: string;
    salesPerson?: EntityInfo;
    salesTerritory?: EntityInfo;
    shipMethod: EntityInfo;
    shippingAddress: EntityInfo;
}