import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

<<<<<<< HEAD:CardFile.Web/ClientApp/src/app/spa/footer/footer.component.ts
    title = ' All rights reserved';
    year = new Date().getFullYear();

=======

    title = ' All rights reserved';
    year = new Date().getFullYear();
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f:CardFile.Web/ClientApp/src/app/components/public/footer/footer.component.ts
  constructor() { }

  ngOnInit() {
  }

}
