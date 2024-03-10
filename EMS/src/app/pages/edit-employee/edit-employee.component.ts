import { Component } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';
import {Router, ActivatedRoute} from '@angular/router';
import { Department } from 'src/app/models/department';
import { GradeMaster } from 'src/app/models/grademaster';
import { GradeMasterService } from 'src/app/services/grade-master.service';
import { DepartmentService } from 'src/app/services/department.service';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent {
 
  updated?:boolean;
  
  depts?:Department[];
  grades?:GradeMaster[];


  constructor(private service:EmployeeService, private deptservice:DepartmentService, private gradeservice:GradeMasterService, private route:Router, private router:ActivatedRoute){}
  empData:any = {
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
  };
ngOnInit(){
  this.updated=false;
  //read id from URL
  //call getevent req pass id
  //assign eventmodel response to local event model
  const id = this.router.snapshot.paramMap.get('id');
  this.getEmployee(id);
  this.loadDepartments();
  this.loadGrades();
}
goToList(){
  this.route.navigate(['/emp']);
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

getEmployee(id:any){
  //call api pass id 
  //assign response to eventData
  this.service.getEmployee(id).subscribe(
    {
    next:(data) => {
      this.empData = data           
    },

    error:(error) => {
      alert(error.message)
    }
  }
  );
}

  update(){
    var data={
      empFirstName:this.empData?.empFirstName,
      empID: this.empData?.empID,       //making json data 
      empLastName:this.empData?.empLastName,
      empDateOfBirth:this.empData?.empDateOfBirth,
      dateOfJoining: this.empData?.dateOfJoining, 
      empDeptID:this.empData?.empDeptID,
      empGrade: this.empData?.empGrade, 
      empDesignation:this.empData?.empDesignation,
      empBasic: this.empData?.empBasic, 
      empGender:this.empData?.empGender,
      empMaritalStatus: this.empData?.empMaritalStatus,
      empHomeAddress: this.empData?.empHomeAddress, 
      empContactNum:this.empData?.empContactNum 
    }
    this.service.updateEmployee(data).subscribe(
      {
        next:(data) => {
          alert("Updated!!");
          this.goToList();
        },
    
        error:(err) => {
          let errorMessage: string;
          if (err.status === 400) {
            errorMessage = "Invalid data. Please check your input.";
          } else if (err.status === 404) {
            errorMessage = "Resource not found.";
          } else if (err.status === 500) {
            errorMessage = "Internal server error. Please try again later.";
          } else {
            errorMessage = "An unexpected error occurred.";
          }
          alert(errorMessage); // Display user-friendly error message
        }
      });
    }
}
