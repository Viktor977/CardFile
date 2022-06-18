<<<<<<< HEAD
import { Directive,Input,TemplateRef,ViewContainerRef } from '@angular/core';

import { ScreenService } from '../services/screen.service';
=======
import { Directive,Input, TemplateRef, ViewContainerRef, OnInit } from '@angular/core';
import { ScreenService } from '../services/screen.service';

>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
@Directive({
  selector: '[appScreenSmall]'
})
export class ScreenSmallDirective {

    private hasView = false;
    constructor(private template: TemplateRef<Object>,
        private screenService: ScreenService,
        private viewContainer: ViewContainerRef) {
        screenService.resize$.subscribe(() => {
            this.onResize();
        });
    }

    ngOnInit() {
        this.onResize();
    }

    onResize() {
        this.screenLarge = false;
    }

    @Input()
    set screenLarge(condition) {
        condition = this.screenService.screenWidth < this.screenService.largePixels;
        if (condition && !this.hasView) {
            this.hasView = true;
            this.viewContainer.createEmbeddedView(this.template);
        } else if (!condition && this.hasView) {
            this.hasView = false;
            this.viewContainer.clear();
        }
    }

<<<<<<< HEAD
=======
   
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
}
