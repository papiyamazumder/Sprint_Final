import { Component } from '@angular/core';
import { UserMasterComponent } from '../user-master/user-master.component';
import { UserMasterService } from 'src/app/services/user-master.service';
import {Router, ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent {

  updated?:boolean;

  constructor(private service:UserMasterService, private route:ActivatedRoute){}

    userData:any ={
        userID:'',
        userName:'',
        userPassword:'',
        userType:'' 
    };

ngOnInit(){
  this.updated=false;
  //read id from URL
  //call getevent req pass id
  //assign eventmodel response to local event model
  const id = this.route.snapshot.paramMap.get('id');
  this.getUser(id);
}
getUser(id:any){
  //call api pass id 
  //assign response to eventData
  this.service.getById(id).subscribe(
    {
    next:(data) => {
      this.userData = data           
    },

    error:(error) => {
      alert(error.message)
    }
  }
  );
}

  update(){
    var data={
      userID:this.userData?.userID,
      userName:this.userData?.userName,
      userPassword:this.userData?.userPassword,
      userType:this.userData?.userType,
    }

    this.service.updateUser(data).subscribe(
      {
      next:(data) => {
        alert("Updated!!")
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
