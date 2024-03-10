import { Component, ViewChild, ElementRef} from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';
import { Router } from '@angular/router';
import * as XLSX from "xlsx";


@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent {

  searchValue?:string;
  searchKeyword?:string;
  emplist?:Employee[];  //defining a property emplist of the class Employee

  
  @ViewChild("excelTable") table: any;
  constructor(private service:EmployeeService, private router:Router){}
   //creating a constructor and passing the service class in it

  ngOnInit(){
    this.getAll();  //calling the get all function on initialization
  }

  goToAddEmployee(){
    this.router.navigate(['/add-emp']);
  }

  goToEditEmployee(id:any){
    this.router.navigate(['/edit',id]);
  }

  getAll():void{   //function body
    this.service.GetAllEmployees().subscribe({
      next:(data) => {
        this.emplist = data
      },
      error:(error) => {
        alert(error.message)
      }
      });
  }  

  delete(id:any):void{
    this.service.deleteEmployee(id).subscribe({
      next:(id)=>{
        alert(id.status);
        this.getAll();
      }, 
      error:(err)=>{
      alert(err.message);}
    });
    }

  searchemployees(){
    var filter={
      field:this.searchKeyword,
      value:this.searchValue
    }
    alert(filter.field);
    this.service.searchemployees(this.searchKeyword,this.searchValue).subscribe({
      next:(data) => {
        this.emplist = data
        
      },
      error:(error) => {
        alert(error.message);
      }
      });
  }


  exportemployees() {
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(
      this.table.nativeElement
    );

    /* new format */
    var fmt = "0.00";
    /* change cell format of range B2:D4 */
    var range = { s: { r: 1, c: 1 }, e: { r: 2, c: 100000 } };
    for (var R = range.s.r; R <= range.e.r; ++R) {
      for (var C = range.s.c; C <= range.e.c; ++C) {
        var cell = ws[XLSX.utils.encode_cell({ r: R, c: C })];
        if (!cell || cell.t != "n") continue; // only format numeric cells
        console.log(cell);
        cell.z = fmt;
        console.log(cell.z);
      }
    }
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, "Sheet1");
    var fmt = "@";
    wb.Sheets["Sheet1"]["F"] = fmt;

    /* save to file */
    XLSX.writeFile(wb, "EmployeeData.xlsx");
  }
}

  

