import { Component, OnInit } from '@angular/core';
import { PhotoService } from '../services/photo.service';
import { Photo } from '../models/Photo';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-photos-list',
  templateUrl: './photos-list.component.html',
  styleUrls: ['./photos-list.component.css']
})
export class PhotosListComponent implements OnInit {
  photos: Array<Photo>

  constructor(private photoService: PhotoService, 
    private router: Router, 
    private toastrService: ToastrService) {
    this.photos = [];
   }

  ngOnInit() {
    this.fetchPhotos();
  }

  fetchPhotos(){
    this.photoService.getPhotos().subscribe(photos => {
      this.photos = photos;
    })
  }

  editPhoto(id: number){
    this.router.navigate(["photos/" + id + "/edit"]);
  }

  deletePhoto(id: number){
    this.photoService.deletePhoto(id).subscribe(res => {
      this.fetchPhotos();
      this.toastrService.info("The photo " + id + " has been deleted.");
    })
  }
}
