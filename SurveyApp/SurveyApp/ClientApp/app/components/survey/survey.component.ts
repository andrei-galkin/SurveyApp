import { Component, Inject } from '@angular/core';
import { Http, Response } from '@angular/http'; 

@Component({
    selector: 'survey',
    templateUrl: './survey.component.html'
})
export class SurveyComponent {
    public questions: Question[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/SurveyData/GetQuestions').subscribe(result => {
            this.questions = result.json() as Question[];
        }, error => console.error(error));
    }

    onSubmit(form: any): void {
        console.log('you submitted value:', form);
    }
}

interface Question {
    id: number;
    type: number;
    text: string;
    options: string[]
}
