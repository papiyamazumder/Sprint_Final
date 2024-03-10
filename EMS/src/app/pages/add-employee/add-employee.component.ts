import { Component } from '@angular/core';
import { Department } from 'src/app/models/department';
import { Employee } from 'src/app/models/employee';
import { GradeMaster } from 'src/app/models/grademaster';
import { DepartmentService } from 'src/app/services/department.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { GradeMasterService } from 'src/app/services/grade-master.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {
  empData:Employee ={
    empID:'',
    empFirstName:'',
    empLastName:'',
    empDateOfBirth: new Date(),     
    dateOfJoining:new Date(),
    empDeptID: 0,
    empGrade:'',
    empDesignation:'',
    empBasic: 0,
    empGender:'',
    empMaritalStatus:'',
    empHomeAddress:'',
    empContactNum:''
  }
  
  depts?:Department[];
  grades?:GradeMaster[];


  constructor(private empservice:EmployeeService, private deptservice:DepartmentService, private gradeservice:GradeMasterService, private router:Router){}

  ngOnInit(): void {
    this.loadDepartments();
    this.loadGrades();
  }

  loadDepartments():void{   //function body
    this.deptservice.GetAllDepartments().subscribe({
      next:(data) => {
        this.depts = data
      },
      error:(error) => {
        alert(error.message)
      }
    });
  }  

  loadGrades():void{
    this.gradeservice.GetAllGradeMaster().subscribe({
      next:(data) => {
        this.grades = data
      },
      error:(error)=>{
        alert(error.message)
      }
    });
  }

  goToList(){
    this.router.navigate(['/emp']);
  }

  addEmployees(): void{
    var data={ 
      empFirstName:this.empData.empFirstName,
      empID: this.empData.empID,       //making json data 
      empLastName:this.empData.empLastName,
      empDateOfBirth:this.empData.empDateOfBirth,
      dateOfJoining: this.empData.dateOfJoining, 
      empDeptID:this.empData.empDeptID,
      empGrade: this.empData.empGrade, 
      empDesignation:this.empData.empDesignation,
      empBasic: this.empData.empBasic, 
      empGender:this.empData.empGender,
      empMaritalStatus: this.empData.empMaritalStatus,
      empHomeAddress: this.empData.empHomeAddress, 
      empContactNum:this.empData.empContactNum 
    }
    this.empservice.addEmployees(data).subscribe({
      next:(msg) =>{
        alert(msg.status)
        this.goToList();
      },
      error:(err) => {
        let errorMessage: string;
        if (err.status === 400) {
          errorMessage = "Error!! The provided data failed validation checks.";
        } else if (err.status === 404) {
          errorMessage = "Resource not found.";
        } else if (err.status === 500) {
          errorMessage = "Internal Server Error.";
        } else {
          errorMessage = "An unexpected error occurred.";
        }
        alert(errorMessage); // Display user-friendly error message
      }
    });
  }

  reset(){
  this.empData.empFirstName = '';
  this.empData.empID = '';
  this.empData.empLastName = '';
  this.empData.empDateOfBirth = new Date;
  this.empData.dateOfJoining = new Date;
  this.empData.empDeptID = 0;
  this.empData.empGrade = '';
  this.empData.empDesignation = '';
  this.empData.empBasic = 0;
  this.empData.empGender = '';
  this.empData.empMaritalStatus = '';
  this.empData.empHomeAddress = '';
  this.empData.empContactNum = '';
  }
}
