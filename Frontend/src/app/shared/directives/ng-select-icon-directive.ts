import {
  AfterViewInit,
  Directive,
  ElementRef,
  Input,
  Renderer2,
} from '@angular/core';

@Directive({
  selector: '[ngSelectIcon]',
  standalone: true,
})
export class NgSelectIconDirective implements AfterViewInit {
  @Input('ngSelectIcon') icon = 'calendar_today';

  constructor(
    private el: ElementRef<HTMLElement>,
    private renderer: Renderer2,
  ) {}

  ngAfterViewInit() {
    const ngSelect = this.el.nativeElement;
    const container = ngSelect.querySelector('.ng-select-container');

    if (!container) return;

    // Ensure positioning
    this.renderer.addClass(container, 'relative');

    // Create icon
    const iconEl = this.renderer.createElement('span');
    iconEl.textContent = this.icon;

    this.renderer.addClass(iconEl, 'material-icons');
    this.renderer.addClass(iconEl, 'ng-select-right-icon');

    this.renderer.appendChild(container, iconEl);
  }
}

/*
examples of usage:
<ng-select ngSelectIcon="event"></ng-select>
<ng-select ngSelectIcon="schedule"></ng-select>
<ng-select ngSelectIcon="date_range"></ng-select>
*/
