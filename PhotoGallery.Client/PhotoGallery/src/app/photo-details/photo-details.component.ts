import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Photo } from '../models/Photo';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-photo-details',
  templateUrl: './photo-details.component.html',
  styleUrls: ['./photo-details.component.css']
})
export class PhotoDetailsComponent implements OnInit {
  id: number = 0;
  photo: Photo;

  constructor(private route: ActivatedRoute, private photoService: PhotoService) {
    this.route.params.subscribe(res => {
      this.id = res['id'];
      this.photoService.getPhoto(this.id).subscribe(res => {
        this.photo = res;
      })
    })
  }

  ngOnInit() {
  }
}