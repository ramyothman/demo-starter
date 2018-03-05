import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { OrdersComponent } from './orders/orders.component';
import { throwIfAlreadyLoaded } from './../core/module-import-guard';

@NgModule({
  imports: [
    CommonModule, FormsModule, RouterModule
  ],
  exports: [
    CommonModule, FormsModule, RouterModule, OrdersComponent
    
  ],
  declarations: [OrdersComponent],
  providers: [
    
  ]
})
export class CheckoutModule {
  constructor( @Optional() @SkipSelf() parentModule: CheckoutModule) {
    throwIfAlreadyLoaded(parentModule, 'CheckoutModule');
  }
}
