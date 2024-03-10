import { Component } from '@angular/core';
import { GradeMasterService } from 'src/app/services/grade-master.service';
import {Router, ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-edit-grade',
  templateUrl: './edit-grade.component.html',
  styleUrls: ['./edit-grade.component.css']
})
export class EditGradeComponent {

  updated?:boolean;

  constructor(private service:GradeMasterService, private route:ActivatedRoute){}
  gradeData:any = {
    gradeCode:'',
    description:'',
    minSalary:0,
    maxSalary:0
  };
 
 
  ngOnInit(){
    this.updated=false;
    //read id from URL
    //call getevent req pass id
    //assign eventmodel response to local event model
    const gradecode = this.route.snapshot.paramMap.get('gradecode');
    this.getGradeMaster(gradecode);
  }
 
  getGradeMaster(gradecode:any){
    //call api pass id
    //assign response to eventData
    this.service.getGradeMaster(gradecode).subscribe(
      {
      next:(data) => {
        this.gradeData = data          
      },
   
      error:(error) => {
        alert(error.message)
      }
    }
    );
  }
 
  update(){
    var data={
      gradeCode:this.gradeData?.gradeCode,
      description: this.gradeData?.description,       //making json data
      minSalary:this.gradeData?.minSalary,
      maxSalary:this.gradeData?.maxSalary,
     
     
    }
    this.service.updateGradeMaster(data).subscribe(
      {
      next:(data) => {
        alert('Updated');
        //this.gradeData = data          
        // this.updated=true;
        // alert(              "Updated");
      },
 
      error:(error) => {
        alert(error)
        this.updated=false;
      }
    }
    );
  }
}
 
