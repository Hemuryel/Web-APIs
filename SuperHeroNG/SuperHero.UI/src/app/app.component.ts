import { Component } from '@angular/core';
import { SuperHero } from './models/super-hero';
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
  @ViewChild('content', {static: false}) el!: ElementRef;

  constructor(private superHeroService: SuperHeroService) { }

  ngOnInit(): void {
    this.getSuperHeroes();
  }

  getSuperHeroes(){
    this.superHeroService
    .getSuperHeroes()
    .subscribe((result: SuperHero[]) => (this.heroes = result));
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
}
