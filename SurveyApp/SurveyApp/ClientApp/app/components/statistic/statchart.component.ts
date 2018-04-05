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
    Labels: string[];

    @Input()
    ChartData: number[];

    public ChartType: string = 'doughnut';
}