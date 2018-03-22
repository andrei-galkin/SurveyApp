import { Component, Inject } from '@angular/core';
import { OnInit, Pipe, ViewChild, ElementRef } from '@angular/core';
import { Http } from '@angular/http';
import { BaseChartDirective } from 'ng2-charts/ng2-charts';

@Component({
    selector: 'statistic',
    templateUrl: './statistic.component.html'
})
export class StatisticComponent {
    public stats: Stats[];
    @ViewChild(BaseChartDirective) chart: BaseChartDirective;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/StatisticData/GetData').subscribe(result => {
            this.stats = result.json() as Stats[];
            this.refresh_chart();
            for (let i = 0; i < this.stats.length; i++) {
                let stat = this.stats[i];
                if (stat.id == 1) {

                    //for (let j = 0; j < stat.results.length; j++) {
                    //    let result = stat.results[j];                        
                    //    this.barChartLabels.push(result.text);
                    //    this.barChartData.push(result.count.toString());
                    //}
                }
            }

        }, error => console.error(error));
    }

    refresh_chart() {
        setTimeout(() => {

            this.barChartLabels = ['new2', 'new2'];

            //if (this.chart && this.chart.chart && this.chart.chart.config) {
            //    //this.chart.chart.config.data.labels = this.barChartLabels;
            //    //this.chart.chart.config.data.datasets = this.datasets_lines;
            //    //this.chart.chart.update();
            //}
        });
    }

    public barChartOptions: any = {
        scaleShowVerticalLines: false,
        responsive: true
    };
  
    public barChartLabels: string[] = ['2006', '2007', '2008', '2009', '2010', '2011', '2012'];
    public barChartType: string = 'bar';
    public barChartLegend: boolean = true;

    public barChartData: any[] = [
        { data: [65, 59, 80, 81, 56, 55, 40], label: 'Series A' },
        { data: [28, 48, 40, 19, 86, 27, 90], label: 'Series B' }
    ];

    // events
    public chartClicked(e: any): void {
        console.log(e);
    }

    public chartHovered(e: any): void {
        console.log(e);
    }
}

interface Stats {
    text: string;
    id: number;
    type: number;
    results: StatResult
}

interface StatResult {
    text: string;
    count: number;
}