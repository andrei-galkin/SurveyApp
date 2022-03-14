import { Component, Input } from '@angular/core';
import { ChartData, ChartOptions, ChartType } from 'chart.js'

@Component({
    selector: 'statchart',
    templateUrl: './statchart.component.html'
})

export class StatchartComponent {

    constructor() {
    }

    @Input()
    chartLabels: string[] = [];

    @Input()
    chartData: number[] = [];

    public chartType: ChartType = 'doughnut';

    public data: ChartData = {
        labels: [],
        datasets: [{
            label: '',
            data: [],
            hoverOffset: 2
        }]
    };


    private getColors(n: number, s: number): any[] {
        var pool = [];
        for (let i = 0; i < n; i++) {
            var r = 8;
            var g = 65 + i * 15;
            var b = 60 + i * 1.5 + 2.5 * s;
            var a = 5 + 7.5 * i + 2.5 * s;
            pool.push("rgba(" + r + "," + g + "," + b + ", " + a + ")");
        }
        return pool;
    }

    ngOnInit() {
        this.data.labels = this.chartLabels;
        this.data.datasets[0].data = this.chartData;
        this.data.datasets[0].backgroundColor = this.getColors(this.chartData.length, 0);
        this.data.datasets[0].hoverBackgroundColor = this.getColors(this.chartData.length, 5);
        this.data.datasets[0].hoverBorderColor = "rgb(8, 65, 60)";
    }
}
