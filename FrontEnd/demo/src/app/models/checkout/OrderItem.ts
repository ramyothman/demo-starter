export class OrderItem {
  ID: string;
  ItemID: string;
  OrderID: string;
  Description: string;
  Quantity: number;
  UnitPrice: number;
  Price: number;
  _Price: number;
  PriceCalculated(): number {
    return this.Quantity * this.UnitPrice;
  }

  static clone(item: OrderItem) : OrderItem{
    var result = new OrderItem();
    result.ID = item.ID;
    result.Description = item.Description;
    result.ItemID = item.ItemID;
    result.OrderID = item.OrderID;
    result.Price = item.Price;
    result.Quantity = item.Quantity;
    result.UnitPrice = item.UnitPrice;
    return result;
  }
}
