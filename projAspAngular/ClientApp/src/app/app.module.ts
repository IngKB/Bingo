import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './shared/components/nav-menu/nav-menu.component';
import { HomeComponent } from './pages/home/home.component';
import { FetchDataComponent } from './pages/fetch-data/fetch-data.component';
import { JugadorBasicComponentComponent } from './pages/Jugador-pages/jugador-basic-component/jugador-basic-component.component';
import { AppRoutingModule } from './app-routing.module';
import { ToolbarComponent } from './shared/components/toolbar/toolbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { RegisterDialogComponent } from './pages/register-dialog/register-dialog.component';
import { HomeJugadorComponent } from './pages/Jugador-pages/home-jugador/home-jugador.component';
import { LoginDialogComponent } from './pages/login-dialog/login-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    JugadorBasicComponentComponent,
    ToolbarComponent,
    RegisterDialogComponent,
    HomeJugadorComponent,
    LoginDialogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MaterialModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule
  ],
  providers: [],
  entryComponents: [RegisterDialogComponent, LoginDialogComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
