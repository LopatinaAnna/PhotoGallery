import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptorService implements HttpInterceptor {

constructor() { }

intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
        retry(1),
        catchError(error => {
            if(error.status === 401){
                alert("401")
            }else if (error.status === 404){
                alert("404")
            }else if(error.status === 400){
                alert("400")
            }
            else{
                alert("000")
            }
            return throwError(error);
        })
    );
  }   
}
