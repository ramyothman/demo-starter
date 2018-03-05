import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AppointmentComponent } from './appointment/appointment.component';
import { throwIfAlreadyLoaded } from './../core/module-import-guard';

@NgModule({
  imports: [
    CommonModule, FormsModule, RouterModule
  ],
  exports: [
    CommonModule, FormsModule, RouterModule, AppointmentComponent
    
  ],
  declarations: [AppointmentComponent],
  providers: [
    
  ]
})
export class CalendarModule {
  constructor( @Optional() @SkipSelf() parentModule: CalendarModule) {
    throwIfAlreadyLoaded(parentModule, 'CalendarModule');
  }
}
