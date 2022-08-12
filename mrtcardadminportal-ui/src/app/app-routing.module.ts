import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoadCardsComponent } from './cards/loadcards.component';
import { TapcardComponent } from './cards/tapcard/tapcard.component';
import { QlesscardsComponent } from './qlesscards/qlesscards/qlesscards.component';


const routes: Routes = [
{
  path:'',
  component: LoadCardsComponent
},
{
  path: 'loadcard',
  component: LoadCardsComponent
},
{
  path: 'qlesscards',
  component: QlesscardsComponent
},
{
  path: 'tapcard',
  component: TapcardComponent
}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
