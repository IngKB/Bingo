import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { JugadorBasicComponentComponent } from './pages/Jugador-pages/jugador-basic-component/jugador-basic-component.component';

const routes: Routes = [{
  path: '',
  component: JugadorBasicComponentComponent,
  children: [
    {
      path: 'home',
      component: HomeComponent
    },
    {
      path: '',
      redirectTo: 'home',
      pathMatch: 'full'
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
