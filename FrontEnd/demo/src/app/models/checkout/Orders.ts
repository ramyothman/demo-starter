import { OrderItem } from './OrderItem';
import { Customer } from './Customer';
export class Orders {
  ID: string;
  CustomerID: number;
  OrderDate: Date;
  TotalPrice: number;
  OrderItem: OrderItem[];
  Customer: Customer;
}
