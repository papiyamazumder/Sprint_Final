import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';// to perform HTTP Requests & handles Reponse
import { Observable } from 'rxjs';
import { Department } from '../models/department';

 
const baseUrl = 'https://localhost:7227/api/Department'; //controller name will be after api
 
@Injectable({
  providedIn: 'root'
})
 
export class DepartmentService {
 
  constructor(private http:HttpClient) { } //http - object (Injecting the httpclient service)
 
  GetAllDepartments():Observable<Department[]>{   //while fetching we pass the original data of a specific type; i.e here Event
    return this.http.get<Department[]>(baseUrl+'/GetAllDepartments');
  }
  searchdepartments(f:any,v:any):Observable<Department[]>{   //while fetching we pass the original data of a specific type; i.e here Event
    return this.http.get<Department[]>(baseUrl+'/Search?field='+f+'&value='+v);
  }
  addDepartments(data:any):Observable<any>{    //returns an observable of type any. observable gives the subscribe method
    return this.http.post(baseUrl,data);  // return obj-> json
  }
  getDepartment(deptID:any):Observable<Department>{     //while fetching we pass the original data of a specific type; i.e here Event 
    return this.http.get<Department>(baseUrl+"/GetDepartmentById?id=" +deptID);
  }
  updateDepartment(data:any):Observable<any>{
    return this.http.put(baseUrl,data);
  }
  deleteDepartment(id:any):Observable<any>{
    return this.http.delete(baseUrl+'?id='+id);
  }
}
