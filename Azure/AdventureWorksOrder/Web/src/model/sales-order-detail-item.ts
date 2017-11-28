import { EntityInfo } from "./entity-info";

export interface SalesOrderDetailItem {
  carrierTrackingNumber?: any;
  lineTotal: number;
  modifiedDate: string;
  orderQty: number;
  product: EntityInfo;
  salesOrderDetailId: number;
  salesOrderId: number;
  unitPrice: number;
  unitPriceDiscount: number;
}
