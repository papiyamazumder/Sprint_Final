import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';// to perform HTTP Requests & handles Reponse
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';

const baseUrl = 'https://localhost:7227/api/Employee'; //controller name will be after api

@Injectable({
  providedIn: 'root'
})

export class EmployeeService {

  constructor(private http:HttpClient) { } //http - object (Injecting the httpclient service)

  GetAllEmployees():Observable<Employee[]>{   //while fetching we pass the original data of a specific type; i.e here Event 
    return this.http.get<Employee[]>(baseUrl+'/GetAllEmployees');
  }
  searchemployees(f:any,v:any):Observable<Employee[]>{   //while fetching we pass the original data of a specific type; i.e here Event 
    return this.http.get<Employee[]>(baseUrl+'/Search?field='+f+'&value='+v);
  }
  addEmployees(data:any):Observable<any>{    //returns an observable of type any. observable gives the subscribe method
    return this.http.post(baseUrl,data);  // return obj-> json
  }
  getEmployee(empID:any):Observable<Employee>{     //while fetching we pass the original data of a specific type; i.e here Event 
    return this.http.get<Employee>(baseUrl+"/GetEmployeeById?id="+empID);
  }
  updateEmployee(data:any):Observable<any>{
    return this.http.put(baseUrl,data);
  }
  deleteEmployee(id:any):Observable<any>{
    return this.http.delete(baseUrl+'?id='+id);
  }
}