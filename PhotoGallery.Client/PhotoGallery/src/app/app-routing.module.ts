import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreatepostComponent } from './createpost/createpost.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './services/auth-guard.service';
import { PhotosListComponent } from './photos-list/photos-list.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'create', component: CreatepostComponent, canActivate: [AuthGuardService]},
  {path: 'photos', component: PhotosListComponent, canActivate: [AuthGuardService]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
