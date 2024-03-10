import { Component } from '@angular/core';
import { Department } from 'src/app/models/department';
import { DepartmentService } from 'src/app/services/department.service';
 
@Component({
  selector: 'app-add-department',
  templateUrl: './add-department.component.html',
  styleUrls: ['./add-department.component.css']
})
export class AddDepartmentComponent {
  deptData:Department ={
    deptID:0,
    deptName:'',
   
  }
 
  constructor(private service:DepartmentService){
  }
 
  addDepartments(): void{
    var data={
      deptName:this.deptData.deptName,
      deptID: this.deptData.deptID,       //making json data
     
    }
    this.service.addDepartments(data).subscribe({
      next:(msg) =>{
        alert(msg.status)
      },
      error:(err) => {
        let errorMessage: string;
        if (err.status === 400) {
          errorMessage = "Invalid data. Please check your input.";
        } else if (err.status === 404) {
          errorMessage = "Resource not found.";
        } else if (err.status === 500) {
          errorMessage = "ID exists";
        } else {
          errorMessage = "An unexpected error occurred.";
        }
        alert(errorMessage); // Display user-friendly error message
      }
    });
  }
  
  reset(){
    this.deptData.deptID = 0;
    this.deptData.deptName = '';
  }
 
}