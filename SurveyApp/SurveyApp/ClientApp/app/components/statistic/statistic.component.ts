import { Component, Inject, OnChanges, SimpleChanges } from '@angular/core';
import { OnInit, Pipe, ViewChild, ElementRef } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'statistic',
    templateUrl: './statistic.component.html'
})
export class StatisticComponent {
    public questions: IQuestion[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/StatisticData/GetData').subscribe(result => {
            this.questions = result.json() as IQuestion[];
            console.log(this.questions);

        }, error => console.error(error));
    }
}

interface IQuestion {
    text: string;
    id: number;
    index: number;
    type: number;
    response: IResponse[];
}

interface IResponse {
    data: number;
    label: string;
}