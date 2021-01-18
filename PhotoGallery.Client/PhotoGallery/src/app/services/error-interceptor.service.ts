import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr'

@Injectable()
export class ErrorInterceptorService implements HttpInterceptor {

constructor(private toastrService: ToastrService) { }

intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
        retry(1),
        catchError(error => {
            let message = "";
            if(error.status === 401){
                message = 'Token has expires or you should be logged in.';
            }else if (error.status === 404){
                message = "Error 404";
            }else if(error.status === 400){
                message = "Error 400";
            }
            else{
                message = "Unexpected error.";
            }
            this.toastrService.error(message)
            return throwError(error);
        })
    );
  }   
}
