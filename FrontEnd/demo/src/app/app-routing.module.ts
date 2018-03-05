import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IssuesComponent } from './github/issues/issues.component';
import { OrdersComponent } from './checkout/orders/orders.component';
import { AppointmentComponent } from './calendar/appointment/appointment.component';
const routes: Routes = [
  { path: '', component: AppointmentComponent },
  { path: 'issues', component: IssuesComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'appointments', component: AppointmentComponent },
  { path: '**', redirectTo: 'appointments' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {


}
