import { Component, OnDestroy, OnInit, Input, Output, ChangeDetectorRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { OrdersService } from './../../services/checkout/orders.service';
import { Orders } from './../../models/checkout/Orders';
import { OrderItem } from './../../models/checkout/OrderItem';
declare var $: any;

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  currentOrder: Orders;
  currentOrderId = 'c0d3436c-e316-4fcb-93b3-5387593cbb04';
  test: number = 0;
  constructor(private ordersService: OrdersService) {

  }
  ngOnInit(): void {
    var that = this;
    
    //This should be the current new order in place - for simplicity I am fixing it here
    this.ordersService.getById(this.currentOrderId).subscribe(result => {
      that.currentOrder = result;
      console.log(result);
    });
  }
}
