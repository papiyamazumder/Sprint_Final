import { Component } from '@angular/core';
import { GradeMaster } from 'src/app/models/grademaster'; 
 
import { GradeMasterService } from 'src/app/services/grade-master.service';
import { Router } from '@angular/router';
 
@Component({
  selector: 'app-grade-master',
  templateUrl: './grade-master.component.html',
  styleUrls: ['./grade-master.component.css']
})
export class GradeMasterComponent  {
 gradelist ?:GradeMaster[];
 //grademaster : any[] =[];
 gradedata:GradeMaster={
  gradeCode:'',
  description:'',
  minSalary: 0,
  maxSalary:0
};
 
 
 constructor(private service:GradeMasterService, private router:Router){}
 
ngOnInit(){
  this.getAll();
//  this.delete();
//  this.updategrade();
//   this.();
}
 
goToEditGrade(gradecode:any){
  this.router.navigate(['/edit-grade',gradecode]);
}

goToAddGrade(){
  this.router.navigate(['/add-grade']);
}
 
getAll():void{   //function body
 
  this.service.GetAllGradeMaster().subscribe(
   
    {
    next:(data) => {
      this.gradelist  = data
    },
    error:(error) => {
      alert(error.message)
    }
    }
   
    );
  }
 

  delete(gradecode:any):void{
    this.service.deleteGrade(gradecode).subscribe({
      next:(id)=>{
        alert(id.status);
        this.getAll();
      }, 
      error:(err)=>{
      alert(err.message);}
    });
    }
 

 
 
 
 
 
// updategrade(): void {
 
//   this.service.updateGradeMaster( ).subscribe(
//     {
//      next:(data) => {
//       this.gradelist  = data
//     },
//     error: (error) => {
//       alert(error.message)
//     }
//   }
//   );
// }
 
 
addGrade():void{
  var data1={
    userID:this.gradedata.gradeCode,
    userName:this.gradedata.description,
    userPassword:this.gradedata.minSalary,
    userType:this.gradedata.maxSalary
  }
  this.service.addGradeMaster(data1).subscribe({
    next:(msg) =>{
      alert(msg.status)
  },
  error:(err) => {
    alert(err)
  }
})
 
 
}
}