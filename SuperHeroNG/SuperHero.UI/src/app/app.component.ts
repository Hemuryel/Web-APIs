import { Component } from '@angular/core';
import { SuperHero } from './models/super-hero';
import { SuperHeroResponse } from './models/super-hero-response';
import { SuperHeroService } from './services/super-hero.service';
import { ngxCsv } from 'ngx-csv/ngx-csv';
import { jsPDF } from 'jspdf';
import { ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SuperHero.UI';
  heroes: SuperHero[] = [];
  heroToEdit?: SuperHero;
  page: number = 1;
  lastPage: number = 1;
  @ViewChild('content', {static: false}) el!: ElementRef;

  constructor(private superHeroService: SuperHeroService) { }

  ngOnInit(): void {
    this.getSuperHeroes(1);
  }

  getSuperHeroes(page: number){
    this.superHeroService
    .getSuperHeroes(page)
    .subscribe((result: SuperHeroResponse): void => {
      console.log(result);
      
      this.heroes = result?.superHeroes;
      this.page = result?.currentPage;
      this.lastPage = result?.pages;
    });
  }

  updateHeroList(heroes: SuperHero[]) {
    this.heroes = heroes;
  }

  initNewHero() {
    this.heroToEdit = new SuperHero();
  }

  editHero(hero: SuperHero) {
    this.heroToEdit = hero;
  }

  downloadCsv(){
    var options = { 
      fieldSeparator: ',',
      quoteStrings: '"',
      decimalseparator: '.',
      //showLabels: true, 
      //showTitle: true,
      //title: 'SuperHeroNG',
      useBom: true,
      headers: ["Name", "First Name", "Last Name", "Place"]
    };

    new ngxCsv(this.heroes, "relatorio_superheroes", options);
  }

  downloadPdf(){
    let pdf = new jsPDF('portrait', 'pt', 'A4');

    pdf.html(this.el.nativeElement, {
      callback: (pdf) => {
        pdf.save("modelo.pdf");
      }
    })
  }

  changePage(page: number){
    this.getSuperHeroes(page);
  }
}
