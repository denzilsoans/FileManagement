import { Component } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public message: string;
  public FileComp: File;

  constructor(private http: HttpClient) { }

  upload(files,event) {
    if (files.length === 0)
      return;

    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

    const uploadReq = new HttpRequest('POST', "api/home/uploadfile", formData, {
      reportProgress: true,
    });

    this.http.request(uploadReq).subscribe(event => {
      this.FileComp = null;
      this.message = "Uploaded successfully";
    });
  }
}
