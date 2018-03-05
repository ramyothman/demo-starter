import { Component, OnDestroy, OnInit, Input, Output, ChangeDetectorRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AppointmentService } from './../../services/appointment/appointment.service';
import { Appointment } from './../../models/appointment/Appointment';
declare var $: any;

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.scss']
})
export class AppointmentComponent implements OnInit {
  currentAppointment: Appointment;
  appointments: Appointment[];
  currentMonth = 0;
  months: string[] = [];
  constructor(private appointmentService: AppointmentService) {
    
  }

  ngOnInit(): void {
    var that = this;
    this.currentMonth = 0;
    this.months = this.appointmentService.getMonths();
    this.setCurrentMonth(this.currentMonth);
  }

  setCurrentMonth(month: number) {
    this.currentMonth = month;
    this.getAppointments();
  }

  getAppointments() {
    this.appointmentService.getByMonth(this.currentMonth + 1).subscribe(result => {
      this.appointments = result;
    });
  }
  getAppointment(appointment) {
    this.currentAppointment = appointment;
  }
}
