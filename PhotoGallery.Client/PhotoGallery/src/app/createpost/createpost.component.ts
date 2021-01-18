import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PhotoService } from '../services/photo.service';
import { ToastrService } from 'ngx-toastr'

@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['./createpost.component.css']
})
export class CreatepostComponent{
  createPhotoForm: FormGroup;

  constructor(private fb: FormBuilder, private photoService: PhotoService, private toastrService: ToastrService) { 
    this.createPhotoForm = fb.group({
      'ImageUrl': ['', Validators.required],
      'Description': ['']
    })
  }

  create(){
    this.photoService.create(this.createPhotoForm.value).subscribe(res=>{
      this.toastrService.success("Success");
    })
  }

  get imageUrl(){
    return this.createPhotoForm.get('ImageUrl');
  }

}
