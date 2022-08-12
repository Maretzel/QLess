import { Component, OnInit } from '@angular/core';
import { LoadParameter } from 'src/app/models/api-models/loadparameter.model';
import { TapcardService } from '../tapcard.service';

@Component({
  selector: 'app-tapcard',
  templateUrl: './tapcard.component.html',
  styleUrls: ['./tapcard.component.css']
})
export class TapcardComponent implements OnInit {

  loadParam: LoadParameter = {
    id: 0,
    transactionAmount: 0,
    transactionType: "Tap"
  };

  constructor(private tapService: TapcardService) { }

  ngOnInit(): void {
  }

  onSubmit(cardId: number) {
    this.loadCard(cardId)
  }

  message: string;

  loadCard(carId: number){

    this.loadParam.id = carId;
    this.loadParam.transactionType = "Tap"
    this.tapService.tapCard(this.loadParam).subscribe(
      (SuccessResponse) => {
        this.message = SuccessResponse.message;
      },
      (errorReponse) => {
        this.message = errorReponse.message;
      }
    )
  }
}
