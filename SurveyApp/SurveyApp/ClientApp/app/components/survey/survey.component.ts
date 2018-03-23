import { Component, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http'; 
import { NgForm } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { query } from '@angular/animations/src/animation_metadata';

@Component({
    selector: 'survey',
    templateUrl: './survey.component.html'
})
export class SurveyComponent {
    public questions: Question[];
    public saved: boolean;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/SurveyData/GetQuestions').subscribe(result => {
            this.questions = result.json() as Question[];
        }, error => console.error(error));
    }

    submit(value: any) {        
        var headers = new Headers(
            { 'Accept': 'application/json;', 'Content-Type': 'application/json; charset = utf-8' }
        );
        var options = new RequestOptions({ headers: headers, });
        var json = JSON.stringify(value).replace('"', '\"');
        console.log(json);

        this.http.post('api/SurveyData/SaveAnswer', json, options)
            .subscribe(
            (err) => {
                if (err) console.log(err);
                console.log("Success");
                this.questions = [];
                this.saved = true;
            });        
    }
}

interface Question {
    index: number;
    id: string;
    type: number;
    text: string;
    options: string[]
}
