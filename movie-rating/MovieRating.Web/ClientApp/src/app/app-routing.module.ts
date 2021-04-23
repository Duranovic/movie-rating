import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
		path: 'home',
		data: { title: 'home' },
		loadChildren: () => import('./home/home-routing.module').then((mod) => mod.HomeRoutingModule)
	},
  { path: '', redirectTo: 'home', pathMatch: 'full' },
	{ path: '**', redirectTo: '/errors/404', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
