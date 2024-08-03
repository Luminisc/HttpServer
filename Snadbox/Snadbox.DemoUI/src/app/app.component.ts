import { Component, OnInit } from '@angular/core';
import { Goal, GoalsServiceService } from './goals-service/goals-service.service';
import { map, Observable, tap } from 'rxjs';
import { Guid } from 'typescript-guid';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
  goals: Observable<GridItem[]> | null = null;
  selectedItem: GridItem | null = null;

  constructor (private goalsServiceService: GoalsServiceService) {}

  ngOnInit(): void {
    this.loadGoals();
  }

  loadGoals() {
    this.goals = this.goalsServiceService.getList()
      .pipe(map(response => response.map(y => y as GridItem)))
      .pipe(tap(_ => this.selectedItem = null));
  }

  create() {
    const gridItem: GridItem = {
      id: Guid.EMPTY.toString()
    }
    this.selectedItem = gridItem;
  }

  edit(gridItem: GridItem) {
    let upsert: Observable<any> =
      gridItem.id != Guid.EMPTY.toString()
        ? this.goalsServiceService.update(gridItem)
        : this.goalsServiceService.create(gridItem);

    upsert
      .pipe(tap(x => this.loadGoals()))
      .subscribe();
  }

  delete(gridItem: GridItem) {
    this.goalsServiceService.delete(gridItem.id)
      .pipe(tap(x => this.loadGoals()))
      .subscribe();
  }
}

class GridItem extends Goal {

}
