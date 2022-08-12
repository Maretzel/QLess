import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { LoadParameter } from '../models/api-models/loadparameter.model';
import { LoadCardService } from './loadcard.service';


@Component({
  selector: 'app-cardtype',
  templateUrl: './loadcards.component.html',
  styleUrls: ['./loadcards.component.css']
})
export class LoadCardsComponent implements OnInit {

  loadParam: LoadParameter = {
    id: 0,
    transactionAmount: 0,
    transactionType: "Load"
  };
  message: string;

  constructor(private loadService: LoadCardService) {

  }

  ngOnInit(): void {
  }

  onSubmit(cardId: number, cashInserted: number, amountToLoad: number) {
    this.loadCard(cardId, cashInserted - amountToLoad)
  }

  loadCard(carId: number, amountToLoad: number){
    this.loadParam.id = carId;
    this.loadParam.transactionAmount = amountToLoad;
    this.loadParam.transactionType = "Load"
    this.loadService.loadCard(this.loadParam).subscribe(
      (SuccessResponse) => {
        this.setMessage(SuccessResponse.message)
        this.message = SuccessResponse.message;
      },
      (errorReponse) => {
        this.message = errorReponse.message;
      }
    )
  }

  setMessage(message: string) {
    this.message = message;
  }


}
