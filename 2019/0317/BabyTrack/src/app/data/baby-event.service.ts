import { Injectable } from "@angular/core";
import { BabyEvent } from './baby-events';
import { BehaviorSubject } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class BabyEventService {
    events$ = new BehaviorSubject<BabyEvent[]>([]);

    constructor() {}

    addEvent(event: BabyEvent) {
        const events = this.events$.value;
        events.push(event);
        this.events$.next(events);
    }

    removeEvent(event: BabyEvent) {
        const events = this.events$.value;
        let i = events.indexOf(event);
        if (i > -1) {
            events.slice(i, 1);
            this.events$.next(events);
        }
    }
}