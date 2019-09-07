import { Component, OnInit } from '@angular/core';
import { Request } from '../request';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {

  plans = ['Basic Plan', 'Family Plan', 'International Plan'];
  /*
    public id: number,
    public firstName: string,
    public lastName: string,
    public address: string,
    public city: string,
    public state: string,
    public zip: number,
    public email: string,
    public phone: number,
    public plan: string,
    public ssn: number
  */
  model = new Request(
    18, 'Jon', 'Doe', '4200 Angular Way', 'Seattle', 'WA', 98104, 'jondoe@gmail.com', 2065551234, this.plans[0], 123456789
  );
  submitted = false;

  constructor() { }

  ngOnInit() {
  }

  onSubmit() { this.submitted = true; }

  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }


}
