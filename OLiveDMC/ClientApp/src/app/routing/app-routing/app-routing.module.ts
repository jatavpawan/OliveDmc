import { PrivateLayoutComponent } from './../../private/layout/private-layout/private-layout.component';
import { PrivateModule } from './../../private/module/private/private.module';
import { PublicModule } from './../../public/module/public/public.module';
import { PublicLayoutComponent } from './../../public/layout/public-layout/public-layout.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  //  {
  //    path: '',
  //    redirectTo: 'public',
  //    pathMatch: 'full'
  //  },
   {
    path: '',
    component: PublicLayoutComponent,
    // pathMatch: 'full',
    children: [{
      path: '',
      loadChildren: ()=> PublicModule
    }] 
  },
  //  {
  //    path: 'public',
  //    component: PublicLayoutComponent,
  //    children: [ {
  //      path: '',
  //      loadChildren: ()=> PublicModule
  //    }] 
  //  },
   {
     path: 'private',
     component: PrivateLayoutComponent,
     children: [ {
       path: '',
       loadChildren: ()=> PrivateModule
     }] 
   },

]


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled'})
  ],
  exports: [RouterModule]

})
export class AppRoutingModule { }
