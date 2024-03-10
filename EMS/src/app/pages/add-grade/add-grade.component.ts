import { Component } from '@angular/core';
import { GradeMaster } from 'src/app/models/grademaster';
import { GradeMasterService } from 'src/app/services/grade-master.service';

@Component({
  selector: 'app-add-grade',
  templateUrl: './add-grade.component.html',
  styleUrls: ['./add-grade.component.css']
})
export class AddGradeComponent {
  gradeData:GradeMaster ={
    gradeCode:'',
    description:'',
    minSalary:0,
    maxSalary:0
   
  }
  constructor(private service:GradeMasterService){}
 
  addGrade(): void{
    var data={
      gradeCode:this.gradeData.gradeCode,
      description: this.gradeData.description,       //making json data
      minSalary:this.gradeData.minSalary,
      maxSalary:this.gradeData.maxSalary,
       
    }
    this.service.addGradeMaster(data).subscribe({
      next:(msg) =>{
        alert(msg.status)
      },
      error:(err) => {
        alert(err)
      }
    });
  }

}
