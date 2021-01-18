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

    constructor(private http: HttpClient) { }

    create(data: Photo): Observable<Photo>{
        return this.http.post<Photo>(this.photoPath, data);
    }

    getPhotos(): Observable<Array<Photo>>{
        return this.http.get<Array<Photo>>(this.photoPath);
    }

    getPhoto(id: number): Observable<Photo>{
        return this.http.get<Photo>(this.photoPath + '/' + id)
    }
}
