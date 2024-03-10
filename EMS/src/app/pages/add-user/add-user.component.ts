import { Component } from '@angular/core';
import { Usermaster } from 'src/app/models/usermaster';
import { UserMasterService } from 'src/app/services/user-master.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent {
  userData:Usermaster ={
    userID:'',
    userName:'',
    userPassword:'',
    userType:'' 
  }
 
  constructor(private service:UserMasterService){
  }
 
  addUser(): void{
    var data={
      userID:this.userData.userID,
      userName:this.userData.userName,       //making json data
      userPassword:this.userData.userPassword,
      userType:this.userData.userType   
    }
    this.service.addUser(data).subscribe({
      next: (msg) => {
        alert(msg.status); // Display success message
      },
      error: (err) => {
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

  reset(){
    this.userData.userID = '';
    this.userData.userName = '';
    this.userData.userPassword='';
    this.userData.userType=''
  }
}
