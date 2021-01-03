import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['./createpost.component.css']
})
export class CreatepostComponent{
  createPhotoForm: FormGroup;

  constructor(private fb: FormBuilder, private photoService: PhotoService) { 
    this.createPhotoForm = fb.group({
      'ImageUrl': ['', Validators.required],
      'Description': ['']
    })
  }

  create(){
    this.photoService.create(this.createPhotoForm.value).subscribe(res=>{
      console.log(res);
    })
  }

  get imageUrl(){
    return this.createPhotoForm.get('ImageUrl');
  }

}
