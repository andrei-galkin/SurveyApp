import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { StatchartComponent } from './statchart.component';

@Component({
  selector: 'statistic',
  templateUrl: './statistic.component.html'
})
export class StatisticComponent {
  public questions: IQuestion[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IQuestion[]>(baseUrl + 'statistic').subscribe(result => {
      this.questions = result;
    }, error => console.error(error));
  }
}

interface IQuestion {
  text: string;
  id: number;
  index: number;
  type: number;
  labels: string[];
  data: number[];
  result: IResult[];
}

interface IResult {
  count: number;
  text: string;
}
