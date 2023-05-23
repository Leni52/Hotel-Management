import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';



@Injectable({
  providedIn: 'root'
})
export class BackendService {

    constructor(private http: HttpClient) { }

    GETRequest(requestTarget: string, responseType: any = 'json'): Observable<any> {
        return this.http.get(
            requestTarget, {
                observe: 'body',
                responseType: responseType
            }        
        );
    }

    POSTRequest(requestTarget: string, requestData: any, responseType: any = 'json'): Observable<any> {
        return this.http.post(
            requestTarget, {
                observe: 'body',
                responseType: responseType,
                requestData:requestData
            }  
        );
    }

    PUTRequest(requestTarget: string, requestData: any, responseType: any = 'json'): Observable<any> {
          return this.http.put(
            requestTarget, {
                observe: 'body',
                responseType: responseType,
                requestData:requestData
            }  
        );
    }

    DELETERequest(requestTarget: string, responseType: any = 'json'): Observable<any> {
        return this.http.delete(
            requestTarget, {
                observe: 'body',
                responseType: responseType
            }  
        );

  }
}
