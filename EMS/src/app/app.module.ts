import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { DatePipe } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './layouts/Admin-navbar/navbar.component';
import { HomeComponent } from './pages/home/home.component';
import { ContactUsComponent } from './pages/contact-us/contact-us.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { DepartmentComponent } from './pages/department/department.component';
import { EmployeeComponent } from './pages/employee/employee.component';
import { GradeMasterComponent } from './pages/grade-master/grade-master.component';
import { UserMasterComponent } from './pages/user-master/user-master.component';
import { AddEmployeeComponent } from './pages/add-employee/add-employee.component';
import { EditEmployeeComponent } from './pages/edit-employee/edit-employee.component';
import { AddDepartmentComponent } from './pages/add-department/add-department.component';
import { EditDepartmentComponent } from './pages/edit-department/edit-department.component';
import { AddGradeComponent } from './pages/add-grade/add-grade.component';
import { EditGradeComponent } from './pages/edit-grade/edit-grade.component';
import { AddUserComponent } from './pages/add-user/add-user.component';
import { EditUserComponent } from './pages/edit-user/edit-user.component';
import { LoginComponent } from './pages/login/login.component';
import { BaseComponent } from './pages/base/base.component';
import { UserComponent } from './pages/user/user.component';
import { UserNavbarComponent } from './layouts/user-navbar/user-navbar.component';
import { UserHomeComponent } from './pages/user-home/user-home.component';
import { UserEmployeeComponent } from './pages/user-employee/user-employee.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    ContactUsComponent,
    DepartmentComponent,
    EmployeeComponent,
    GradeMasterComponent,
    UserMasterComponent,
    AddEmployeeComponent,
    EditEmployeeComponent,
    AddDepartmentComponent,
    EditDepartmentComponent,
    AddGradeComponent,
    EditGradeComponent,
    AddUserComponent,
    EditUserComponent,
    LoginComponent,
    BaseComponent,
    UserComponent,
    UserNavbarComponent,
    UserHomeComponent,
    UserEmployeeComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FontAwesomeModule,
    HttpClientModule,
    FormsModule,
    NgxPaginationModule
  ],
  providers: [
    DatePipe 
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
