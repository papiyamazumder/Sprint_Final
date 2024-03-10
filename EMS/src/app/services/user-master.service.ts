import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Usermaster } from 'src/app/models/usermaster';
import { Observable } from 'rxjs';
const baseUrl = 'https://localhost:7227/api/UserMaster'; //controller name will be after api
 
@Injectable({
  providedIn: 'root'
})
export class UserMasterService {
 
  constructor(private http:HttpClient) {}
  addUser(data:any):Observable<any>{    //returns an observable of type any. observable gives the subscribe method
    return this.http.post(baseUrl+'/create-user',data);
  }
  getallUser():Observable<Usermaster[]>{
    return this.http.get<Usermaster[]>(baseUrl+'/GetAllUserCredentials');
  }
  getById(id:any):Observable<Usermaster[]>{
    return this.http.get<Usermaster[]>(baseUrl+"/GetUserCredentialsById?id="+id);
  }
  updateUser(data:any):Observable<any>{   //while fetching we pass the original data of a specific type; i.e here Event
    return this.http.put(baseUrl,data);
  }
  deleteUser(id:any):Observable<any>{
    return this.http.delete(baseUrl+'?id='+id);
  }
}