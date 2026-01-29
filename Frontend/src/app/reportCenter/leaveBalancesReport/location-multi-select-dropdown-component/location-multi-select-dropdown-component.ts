import { Component } from '@angular/core';

@Component({
  selector: 'app-location-multi-select-dropdown-component',
  imports: [],
  templateUrl: './location-multi-select-dropdown-component.html',
  styleUrl: './location-multi-select-dropdown-component.scss',
})
export class LocationMultiSelectDropdownComponent {
  isOpen = false;

  locations: string[] = ['Egypt', 'USA'];
  locationFilter: string[] = [];

  toggleLocation(location: string) {
    this.locationFilter = this.locationFilter.includes(location)
      ? this.locationFilter.filter((l) => l !== location)
      : [...this.locationFilter, location];
  }

  toggleSelectAll(checked: boolean) {
    this.locationFilter = checked ? [...this.locations] : [];
  }

  isAllSelected(): boolean {
    return this.locationFilter.length === this.locations.length;
  }

  displayValue(): string {
    return this.locationFilter.length
      ? this.locationFilter.join(', ')
      : 'Location';
  }
}
