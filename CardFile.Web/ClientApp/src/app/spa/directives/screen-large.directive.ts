import { Directive, Input, ViewContainerRef, TemplateRef } from "@angular/core";
import { ScreenService } from "../services/screen.service";

@Directive({
  selector: "[appScreenLarge]",
})
export class ScreenLargeDirective {
  private hasView = false;

  constructor(
    private template: TemplateRef<Object>,
    private screenService: ScreenService,
    private viewContainer: ViewContainerRef
  ) {
    screenService.resize$.subscribe(() => {
      this.onResize();
    });
  }

  onResize() {
    this.screenLarge = false;
  }

  ngOnInit() {
    this.onResize();
  }

  @Input()
  set screenLarge(condition) {
    condition =
      this.screenService.screenWidth >= this.screenService.largePixels;
    if (condition && !this.hasView) {
      this.hasView = true;
      this.viewContainer.createEmbeddedView(this.template);
    } else if (!condition && this.hasView) {
      this.hasView = false;
      this.viewContainer.clear();
    }
  }
}
