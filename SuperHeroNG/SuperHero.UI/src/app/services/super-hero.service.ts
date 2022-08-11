import { Injectable } from '@angular/core';
import { SuperHero } from '../models/super-hero';
import { SuperHeroResponse } from '../models/super-hero-response';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class SuperHeroService {
  private url = "SuperHero";
  constructor(private http: HttpClient) { }

  public getSuperHeroes(page: number) : Observable<SuperHeroResponse> {
    return this.http.get<SuperHeroResponse>(
      `${environment.apiUrl}/${this.url}/${page}`
    );
  }

  public updateHero(hero: SuperHero) : Observable<SuperHero[]> {
    return this.http.put<SuperHero[]>(
      `${environment.apiUrl}/${this.url}`,
      hero
    );
  }

  public createHero(hero: SuperHero) : Observable<SuperHero[]> {
    return this.http.post<SuperHero[]>(
      `${environment.apiUrl}/${this.url}`,
      hero
    );
  }

  public deleteHero(hero: SuperHero) : Observable<SuperHero[]> {
    return this.http.delete<SuperHero[]>(
      `${environment.apiUrl}/${this.url}/${hero.id}`
    );
  }
}
