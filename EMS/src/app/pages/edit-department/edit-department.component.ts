import { Component } from '@angular/core';
import { Department } from 'src/app/models/department';
import { DepartmentService } from 'src/app/services/department.service';
import {Router, ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-edit-department',
  templateUrl: './edit-department.component.html',
  styleUrls: ['./edit-department.component.css']
})
export class EditDepartmentComponent {

  updated?:boolean;

  constructor(private service:DepartmentService,  private route:Router,  private router:ActivatedRoute){}

    deptData:any ={
      deptID:0,
      deptName:'',
    };

ngOnInit(){
  this.updated=false;
  //read id from URL
  //call getevent req pass id
  //assign eventmodel response to local event model
  const id = this.router.snapshot.paramMap.get('id');
  this.getDepartment(id);
}
getDepartment(id:any){
  //call api pass id 
  //assign response to eventData
  this.service.getDepartment(id).subscribe(
    {
    next:(data) => {
      this.deptData = data           
    },

    error:(error) => {
      alert(error.message)
    }
  }
  );
}
goToList(){
  this.route.navigate(['/dept']);
}

  update(){
    var data={
      deptID:this.deptData?.deptID,
      deptName:this.deptData?.deptName
    }

    this.service.updateDepartment(data).subscribe(
      {
      next:(data) => {
        alert("Department table is Updated!!")
        this.goToList();
        //this.deptData = data         
        // this.updated=true;
        // alert("Updated");
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

