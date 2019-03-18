import { Component, OnInit } from '@angular/core';
import { BabyEventService } from 'src/app/data/baby-event.service';

@Component({
  selector: 'Baby-list-baby-event',
  templateUrl: './list-baby-event.component.html',
  styleUrls: ['./list-baby-event.component.scss']
})
export class ListBabyEventComponent implements OnInit {

  constructor(
    public baby: BabyEventService
  ) { }

  ngOnInit() {
  }

}
