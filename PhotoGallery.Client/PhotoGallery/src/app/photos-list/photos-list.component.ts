import { Component, OnInit } from '@angular/core';
import { PhotoService } from '../services/photo.service';
import { Photo } from '../models/Photo';
import { Router } from '@angular/router';

@Component({
  selector: 'app-photos-list',
  templateUrl: './photos-list.component.html',
  styleUrls: ['./photos-list.component.css']
})
export class PhotosListComponent implements OnInit {
  photos: Array<Photo>

  constructor(private photoService: PhotoService, private router: Router) {
    this.photos = [];
   }

  ngOnInit() {
    this.photoService.getPhotos().subscribe(photos => {
      this.photos = photos;
    })
  }
}
