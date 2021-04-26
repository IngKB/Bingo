import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SignalRService, WeatherForecast } from '../../services/signal-r.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit{
  public url:string;
  constructor(public signalRService: SignalRService, private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) { this.url = baseUrl}

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addTransferChartDataListener();

    this.startHttpRequest();
  }

  private startHttpRequest = () => {
    this.http.get(this.url + 'api/chat')
      .subscribe(res => {
        console.log(res);
      })
  }
}
