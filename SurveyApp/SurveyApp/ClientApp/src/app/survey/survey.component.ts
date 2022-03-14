import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent {
  public questions: IQuestion[] = [];
  public saved: boolean = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IQuestion[]>(baseUrl + 'survey').subscribe(result => {
      this.questions = result;
    }, error => console.error(error));
  }

  cookJson(json: string) {
    return JSON.stringify(json).replace(new RegExp(":true", 'g'), ":\"true\"");
  }

  submit(value: any) {
    const headers = { 'content-type': 'application/json' }
    const body = this.cookJson(value);

    this.http.post('survey', body, { 'headers': headers })
      .subscribe(
        (err) => {
          if (err) {
            console.log(err);
          }
          console.log("Success");
          this.questions = [];
          this.saved = true;
        });
  }
}

interface IQuestion {
  index: number;
  id: string;
  type: number;
  text: string;
  options: string[];
}
