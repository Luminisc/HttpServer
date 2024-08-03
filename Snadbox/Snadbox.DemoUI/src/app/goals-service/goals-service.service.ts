import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class GoalsServiceService {
  constructor(private http: HttpClient) { }
  getList = () => this.http.get<Goal[]>('/goal');
  get = (id: string) => this.http.get<Goal>(`/goal/${id}`);
  create = (goal: Goal) => this.http.put<Goal>(`/goal`, goal);
  update = (goal: Goal) => this.http.post<void>(`/goal/${goal.id}`, goal);
  delete = (id: string) => this.http.delete<void>(`/goal/${id}`);
}

export class Goal {
  id: string = '';
  title?: string;
  description?: string;
}
