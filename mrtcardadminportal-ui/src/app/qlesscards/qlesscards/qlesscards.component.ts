import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Qlesscardtype } from 'src/app/models/ui-models/qlesscardtype.mode';
import { QlesscardService } from '../qlesscard.service';

@Component({
  selector: 'app-qlesscards',
  templateUrl: './qlesscards.component.html',
  styleUrls: ['./qlesscards.component.css']
})
export class QlesscardsComponent implements OnInit {
  qlesscard : Qlesscardtype[] = [];
  displayedColumns: string[] = ['name', 'description', 'initialLoad'];
  dataSource: MatTableDataSource<Qlesscardtype> = new MatTableDataSource<Qlesscardtype>();

  constructor(private qlessService: QlesscardService) { }

  ngOnInit(): void {
    this.qlessService.getQlessCardType()
    .subscribe(
      (successResponse) => {
        this.qlesscard = successResponse;
        this.dataSource = new MatTableDataSource<Qlesscardtype>(this.qlesscard);
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
    )
  }

}
