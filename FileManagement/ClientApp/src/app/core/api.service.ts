import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs/index';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})

export class ApiService {
  private BaseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.BaseUrl = baseUrl;
  }

  private token: string = "";
  private tokenExpiration: Date = new Date();

  handleError(error: HttpErrorResponse) {
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      // Client-side errors
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side errors
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }

  public get loginRequired(): boolean {
    return this.token.length == 0 || this.tokenExpiration > new Date();
  }

  public login(creds) {
    return this.http.post("/account/createtoken", creds)
      .pipe(
        map((response: any) => {
          let tokenInfo = response;
          this.token = tokenInfo.token;
          this.tokenExpiration = tokenInfo.expiration;

          localStorage.setItem('token', tokenInfo.token);
          localStorage.setItem("expires_at", JSON.stringify(tokenInfo.valueOf()));
          return true;
        }), catchError(this.handleError));
  }

  public logout() {
    return this.http.get("/account/Logout").pipe(
      map(() => {
        this.token = "";
        this.tokenExpiration = new Date();

        localStorage.removeItem("token");
        localStorage.removeItem("expires_at");
        return true;
      }), catchError(this.handleError));;
  }
}
