import { Component, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http'; 
import { NgForm } from '@angular/forms';

@Component({
    selector: 'survey',
    templateUrl: './survey.component.html'
})
export class SurveyComponent {
    public questions: Question[];

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/SurveyData/GetQuestions').subscribe(result => {
            this.questions = result.json() as Question[];
        }, error => console.error(error));
    }

    submit(value: any, @Inject('BASE_URL') baseUrl: string) {
        console.log(value);

        //let headers = { headers: new Headers({ 'Content-Type': 'application/json' }) };

        //this.http.post(baseUrl + 'api/SurveyData/SaveQuestions', JSON.stringify(value));

        var headers = new Headers({ 'Content-Type': 'application/json' });
        var options = new RequestOptions({ headers: headers, });
        
        this.http.post(baseUrl + 'api/SurveyData/SaveQuestions', JSON.stringify(value), options)
            .subscribe(
            (err) => {
                if (err) console.log(err);
                console.log("Success");
            });

        this.http.post(baseUrl + 'api/SurveyData/SaveContact', JSON.stringify(value), options)
            .subscribe(
            (err) => {
                if (err) console.log(err);
                console.log("Success");
            });

        

        //const req = this.http.post(baseUrl + 'api/SurveyData/SaveQuestions', {
        //    body: value
        //})
        //    .subscribe(
        //    res => {
        //        console.log(res);
        //    },
        //    err => {
        //        console.log("Error occured");
        //    }
        //);
    }
}

interface Question {
    id: number;
    type: number;
    text: string;
    options: string[]
}
