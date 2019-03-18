import { Component, OnInit } from '@angular/core';
import { BabyEventService } from 'src/app/data/baby-event.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { SleepEvent, BabyEvent, FeedEvent, ChangeEvent } from 'src/app/data/baby-events';

@Component({
  selector: 'Baby-add-baby-event',
  templateUrl: './add-baby-event.component.html',
  styleUrls: ['./add-baby-event.component.scss']
})
export class AddBabyEventComponent implements OnInit {
  addEventGroup: FormGroup;
  addEvent: BabyEvent = new SleepEvent(new Date(), '', '');

  private _sub: Subscription = new Subscription();

  constructor(
    public baby: BabyEventService,
    fb: FormBuilder,
  ) { 
    this.addEventGroup = fb.group({
      typeControl: 'sleep',
      noteControl: '',
      durationControl: '',
    });
  }

  ngOnInit() {
    this._sub.add(
      this.addEventGroup.valueChanges.subscribe((value) => {
        const date = new Date();
        let event: BabyEvent = null;
        switch(value.typeControl) {
          case 'sleep':
            event = new SleepEvent(date, value.noteControl, value.durationControl);
            break;
          case 'feed':
            event = new FeedEvent(date, value.noteControl, value.durationControl);
            break;
          case 'change':
          default:
            event = new ChangeEvent(date, value.noteControl);
            break;
        }

        this.addEvent = event;
      })
    );
  }

  hasDuration(): boolean {
    const type = this.addEventGroup.get('typeControl').value;
    console.log(type);
    return type === 'sleep' || type === 'feed';
  }

  submitEvent() {
    
  }
}
