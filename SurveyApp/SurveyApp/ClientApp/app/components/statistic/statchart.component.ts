import { Component, Inject } from '@angular/core';

@Component({
    selector: 'statchart',
    templateUrl: './statchart.component.html'
})
export class StatchartComponent {

    constructor() {        
    }

    public doughnutChartLabels: string[] = ['Download Sales', 'In-Store Sales', 'Mail-Order Sales'];
    public doughnutChartData: number[] = [350, 450, 100];
    public doughnutChartType: string = 'doughnut';

    // events
    public chartClicked(e: any): void {
        console.log(e);
    }

    public chartHovered(e: any): void {
        console.log(e);
    }

    setData() {
        this.doughnutChartLabels = ['Test 1', 'Test 2', 'Test 3'];
    }
}