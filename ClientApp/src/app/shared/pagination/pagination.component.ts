import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';

// tslint:disable:no-inferrable-types
@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {
  @Input()  public   maxPageNumber  : number;
  private   readonly minPageNumber  : number = 1;
  private            selectedPage   : number = 1;
  private   readonly maxPageLinksNumber : number = 5;
  // tslint:disable-next-line:no-output-on-prefix
  @Output()          pageChanged = new EventEmitter<number>();

  public  get hasNextPage    (): boolean { return (this.maxPageNumber > this.selectedPage) ? true : false;        }
  public  get hasPreviousPage(): boolean { return (this.minPageNumber < this.selectedPage) ? true : false;        }
  private get nextPage       (): number  { return this.hasNextPage     ? ++this.selectedPage : this.selectedPage; }
  private get previousPage   (): number  { return this.hasPreviousPage ? --this.selectedPage : this.selectedPage; }

  public  get pageLinksNumber(): number  {
    return (this.maxPageNumber >= this.maxPageLinksNumber) ?
      this.maxPageLinksNumber : this.maxPageNumber;
  }

  public  get startPage(): number {
    if (this.selectedPage - 2 >= this.minPageNumber) {
      if (this.selectedPage + 2 <= this.maxPageNumber) {
        return this.selectedPage - 2;
      } else {
        return (this.maxPageNumber - this.maxPageLinksNumber) > 0 ?
        this.maxPageNumber - this.maxPageLinksNumber : 1;
      }
    } else {
      return this.minPageNumber;
    }

    // if (this.selectedPage - 2 >= this.minPageNumber) {
    //   if (this.selectedPage + 2 <= this.maxPageNumber) {
    //     return this.selectedPage - 2;
    //   } else {
    //     return this.maxPageNumber - this.maxPageLinksNumber;
    //   }
    // } else {
    //   return this.minPageNumber;
    // }
  }

  constructor() { }

  goToPreviousPage(): void {
    if (this.hasPreviousPage) {
      this.selectedPage = this.previousPage;
      this.pageChanged.emit(this.selectedPage);
    }
  }
  goToNextPage(): void {
    if (this.hasNextPage) {
      this.selectedPage = this.nextPage;
      this.pageChanged.emit(this.selectedPage);
    }
  }
  goToPageNumber(value: number) {
    console.log(value);
    if (this.minPageNumber <= value && this.maxPageNumber >= value) {
      this.selectedPage = value;
      this.pageChanged.emit(this.selectedPage);
    }
  }

createFakeArray(): number[] {
  const array = Array(this.pageLinksNumber);

  for (let index = 0; index < this.pageLinksNumber; index++) {
    array[index] = index;
  }

  return array;
}

  ngOnInit() {
  }
}
