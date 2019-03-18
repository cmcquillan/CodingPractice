/**
 * The base for a baby event.
 */
export interface BabyEvent {
  type: 'feed' | 'change' | 'sleep';
  date: Date;
  duration?: string;
  note: string;
  noteLabel: string;
}

export class ChangeEvent implements BabyEvent {
    type: 'change';
    noteLabel = 'Description';

    constructor(
        public date: Date,
        public note: string
    ) {}
}

export class FeedEvent implements BabyEvent {
    type: 'feed';
    noteLabel = 'Feeding Notes';

    constructor(
        public date: Date,
        public note: string,
        public duration: string,
    ) {}
}

export class SleepEvent implements BabyEvent {
    type: 'sleep';
    noteLabel = 'Naptime Notes';

    constructor(
        public date: Date,
        public note: string,
        public duration: string,
    ) {}
}
