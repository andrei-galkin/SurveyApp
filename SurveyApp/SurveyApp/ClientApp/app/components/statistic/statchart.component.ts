import { Component, Input, Inject, Directive, ElementRef, Renderer2 } from '@angular/core';

@Component({
    selector: 'statchart',
    templateUrl: './statchart.component.html'
})

    @Directive({ selector: '[statchart]' })
export class StatchartComponent {

    constructor() {        
    }

    @Input()
    Labels: string[] = ['T', 'T1'];

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
        this.Labels = ['Test 1', 'Test 2', 'Test 3'];
    }
}