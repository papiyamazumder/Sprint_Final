import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './pages/home/home.component';
import { DepartmentComponent } from './pages/department/department.component';
import { EmployeeComponent } from './pages/employee/employee.component';
import { GradeMasterComponent } from './pages/grade-master/grade-master.component';
import { UserMasterComponent } from './pages/user-master/user-master.component';
import { ContactUsComponent } from './pages/contact-us/contact-us.component';
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
import { UserHomeComponent } from './pages/user-home/user-home.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'admin',
    component: BaseComponent,
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'emp', component: EmployeeComponent },
      { path: 'add-emp', component: AddEmployeeComponent },
      { path: 'edit/:id', component: EditEmployeeComponent },
      { path: 'dept', component: DepartmentComponent },
      { path: 'add-dept', component: AddDepartmentComponent },
      { path: 'edit-dept/:id', component: EditDepartmentComponent },
      { path: 'grade', component: GradeMasterComponent },
      { path: 'add-grade', component: AddGradeComponent },
      { path: 'edit-grade/:gradecode', component: EditGradeComponent },
      { path: 'user', component: UserMasterComponent },
      { path: 'add-user', component: AddUserComponent },
      { path: 'edit-user/:id', component: EditUserComponent },
      { path: 'contact', component: ContactUsComponent },
      { path: '', redirectTo: 'home', pathMatch: 'full' },
    ],
  },
  {
    path: 'user',
    component: UserComponent,
    children: [
      { path: 'user-home', component: UserHomeComponent },
      { path: 'emp', component: EmployeeComponent },
      { path: 'edit/:id', component: EditEmployeeComponent },
      { path: 'contact', component: ContactUsComponent },
      { path: '', redirectTo: 'user-home', pathMatch: 'full' },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
