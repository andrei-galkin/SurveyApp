import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'statistic',
    templateUrl: './statistic.component.html'
})
export class StatisticComponent {
    public stats: Stats[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/StatisticData/GetData').subscribe(result => {
            this.stats = result.json() as Stats[];
        }, error => console.error(error));
    }
}

interface Stats {
    text: string;
    id: number;
    type: number;
}
