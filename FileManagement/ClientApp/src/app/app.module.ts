import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, CanActivate } from '@angular/router';
import { AuthInterceptor } from './core/auth-Interceptor';
import { AuthGuard } from './core/auth-guard';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './areas/home/home.component';
import { LoginComponent } from "./areas/login/login.component";
import { LogoutComponent } from "./areas/logout/logout.component";

let ROUTES = [
  { path: '', component: LoginComponent  },
  { path: "home", component: HomeComponent, canActivate: [AuthGuard] },
  { path: "logout", component: LogoutComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    LogoutComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(ROUTES)
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
