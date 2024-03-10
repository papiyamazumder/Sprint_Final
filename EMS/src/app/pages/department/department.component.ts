import { Component, ViewChild, ElementRef} from '@angular/core';
import { Department } from 'src/app/models/department';
import { DepartmentService } from 'src/app/services/department.service';
import { Router } from '@angular/router';
import * as XLSX from "xlsx";
 
@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent {
  deptlist?:Department[];  //defining a property deptlist of the class Department
  
  constructor(private service:DepartmentService, private router:Router){}
   //creating a constructor and passing the service class in it
 
  ngOnInit(){
    this.getAll();  //calling the get all function on initialization
  }
 
  goToAddDepartment(){
    this.router.navigate(['/add-dept']);
  }

  goToEditDepartment(id:any){
    alert(id);
    this.router.navigate(['/edit-dept',id]);
  }
 
  getAll():void{   //function body
    this.service.GetAllDepartments().subscribe({
      next:(data) => {
        this.deptlist = data
      },
      error:(error) => {
        alert(error.message)
      }
      });
  } 
  delete(id:any):void{
    this.service.deleteDepartment(id).subscribe({
      next:(id)=>{
        alert(id.status);
        this.getAll();
      }, 
      error:(err)=>{
      alert(err.message);}
    });
    } 
 
}