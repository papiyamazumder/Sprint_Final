import { Component, ViewChild } from '@angular/core';
import { Usermaster } from 'src/app/models/usermaster';
import { UserMasterService } from 'src/app/services/user-master.service';
import { Router } from '@angular/router';
 
@Component({
  selector: 'app-user-master',
  templateUrl: './user-master.component.html',
  styleUrls: ['./user-master.component.css']
})
export class UserMasterComponent {
  userlist?:Usermaster[];  //defining a property emplist of the class Employee
 
  constructor(private service:UserMasterService, private router:Router){}
  ngOnInit(){
    this.getAll();  //calling the get all function on initialization
  }
  goToAddUser(){
    this.router.navigate(['/add-user']);
  }
  goToEditUser(id:any){
    this.router.navigate(['/edit-user',id])
  }
  delete(id:any):void{
    this.service.deleteUser(id).subscribe({
      next:(id)=>{
        alert(id.status);
        this.getAll();
      },
      error:(err)=>{
      alert(err.message);}
    });
    }
    
  getAll():void{   //function body
    this.service.getallUser().subscribe({
      next:(data) => {
        this.userlist = data
      },
      error:(error) => {
        alert(error.message)
      }
      });
}
}