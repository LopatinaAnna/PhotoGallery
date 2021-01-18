import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Photo } from '../models/Photo';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-photo-edit',
  templateUrl: './photo-edit.component.html',
  styleUrls: ['./photo-edit.component.css']
})
export class PhotoEditComponent implements OnInit {
  editPhotoForm: FormGroup;
  photoId: number;
  photo: Photo;

  constructor(private fb: FormBuilder, 
    private route: ActivatedRoute, 
    private photoService: PhotoService,
    private router: Router) { 
      this.editPhotoForm = this.fb.group({
        'id': [''],
        'description': ['']
      });
    }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.photoId = params['id'];
      this.photoService.getPhoto(this.photoId).subscribe(res => {
        this.photo = res;
        this.editPhotoForm = this.fb.group({
          'id': [this.photo.id],
          'description': [this.photo.description]
        })
      })
    })
  }

  editPhoto(){
    this.photoService.editPhoto(this.editPhotoForm.value).subscribe(res => {
      this.router.navigate(["photos"]);
    });
  }
}
