import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
 
import { GradeMaster } from '../models/grademaster'; 
 
const baseUrl ='https://localhost:7227/api/GradeMaster';
 
@Injectable({
  providedIn: 'root'
})
export class GradeMasterService {
 
  constructor(private http:HttpClient ) { }
  GetAllGradeMaster():Observable<GradeMaster[]>{
    return this.http.get<GradeMaster[]>(baseUrl+'/GetAllGrades');
  }
 
   deleteGrade(gradecode:any):Observable<any>{
    return this.http.delete(baseUrl+'?gradecode='+gradecode);
  }
 
 
 
  addGradeMaster(data:any):Observable<any>{    //returns an observable of type any. observable gives the subscribe method
    return this.http.post(baseUrl,data);
 
}
 
 
updateGradeMaster(data:any):Observable<any>{
  return this.http.put(baseUrl,data);
}
 
getGradeMaster(gradeCode:any):Observable<GradeMaster>{     //while fetching we pass the original data of a specific type; i.e here Event
  return this.http.get<GradeMaster>(baseUrl+"/GetGradesById?gradecode="+gradeCode);
}
 
}