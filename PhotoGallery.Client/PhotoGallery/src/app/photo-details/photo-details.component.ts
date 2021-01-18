import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map, mergeMap } from 'rxjs/operators';
import { Photo } from '../models/Photo';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-photo-details',
  templateUrl: './photo-details.component.html',
  styleUrls: ['./photo-details.component.css']
})
export class PhotoDetailsComponent implements OnInit {
  photo: Photo;

  constructor(private route: ActivatedRoute, private photoService: PhotoService) {
    this.fetchData();
  }

  fetchData(){
    this.route.params.pipe(map(params => {
      const id = params['id'];
      return id;
    }), mergeMap(id => this.photoService.getPhoto(id))).subscribe(res => {
      this.photo = res;
    });
  }

  ngOnInit() {
  }
}