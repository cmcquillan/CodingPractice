import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AddBabyEventComponent } from './components/add-baby-event/add-baby-event.component';
import { ListBabyEventComponent } from './components/list-baby-event/list-baby-event.component';

@NgModule({
  declarations: [
    AppComponent,
    AddBabyEventComponent,
    ListBabyEventComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
