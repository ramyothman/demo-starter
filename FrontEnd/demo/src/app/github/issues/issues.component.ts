import { Component, OnDestroy, OnInit, Input, Output, ChangeDetectorRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { IssuesService } from './../../services/github/issues.service';
import { Issue } from './../../models/github/issue';
import { OrdersService } from './../../services/checkout/orders.service';
import { Orders } from './../../models/checkout/Orders';
import { OrderItem } from './../../models/checkout/OrderItem';
declare var $: any;

@Component({
  selector: 'app-issues',
  templateUrl: './issues.component.html',
  styleUrls: ['./issues.component.scss']
})
export class IssuesComponent implements OnInit {
  issues: Issue[] = [];
  orderItem: OrderItem;
  currentOrderId = 'c0d3436c-e316-4fcb-93b3-5387593cbb04';
  constructor(private issuesService: IssuesService, private ordersService: OrdersService) {

  }

  AddItem(item: Issue) {
    var orderItem: OrderItem = new OrderItem();
    orderItem.Description = item.title;
    orderItem.ItemID = item.id.toString();
    orderItem.OrderID = this.currentOrderId;
    
    orderItem.Quantity = 1;
    orderItem.UnitPrice = item.number - 16000;
    orderItem.Price = orderItem.Quantity * orderItem.UnitPrice;
    
    this.ordersService.AddItem(orderItem).subscribe(result => {
      this.orderItem = result;
    });
  }

  

  ngOnInit(): void {
    var that = this;
    this.issuesService.getIssues().subscribe(result => {
      that.issues = result;
      console.log(result);
    });
  }
}
