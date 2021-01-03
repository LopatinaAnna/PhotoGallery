import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from'@angular/common/http';
import { environment } from '../../environments/environment'
import { Observable } from 'rxjs';
import { Photo } from '../models/Photo';
import { AuthService } from './auth.service';

@Injectable({
    providedIn: 'root'
  })
export class PhotoService {
    private  photoPath = environment.apiUrl + '/photos'

    constructor(private http: HttpClient, private authService: AuthService) { }

    create(data: Photo): Observable<Photo>{
        let headers = new HttpHeaders();
        headers = headers.set('Authorization', `Bearer ${this.authService.getToken()}`);

        return this.http.post<Photo>(this.photoPath, data, {headers});
    }
}
