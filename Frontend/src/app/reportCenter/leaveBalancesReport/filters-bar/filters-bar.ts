import { Component, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { ReportFiltersModel } from '../ReportFiltersModel';

@Component({
  selector: 'app-filters-bar',
  standalone: true,
  imports: [FormsModule, NgSelectModule],
  templateUrl: './filters-bar.html',
})
export class FiltersBar {
  filterChange = output<ReportFiltersModel>();

  // Options
  allTeams = [
    'Marketing',
    'Engineering',
    'HR',
    'Design',
    'Sales',
    'Support',
    'Finance',
  ];
  allLocations = ['Egypt', 'USA'];
  allPolicies = ['Default Policy'];

  // Filters model
  filters: ReportFiltersModel = {
    teams: [],
    locations: [],
    policies: [],
  };

  // Team search handled by ng-select filter
  teamSearch = '';

  // --- Methods ---
  applyFilters() {
    console.log('Applied filters:', this.filters);
    this.filterChange.emit(this.filters);
  }

  clearFilters() {
    this.filters = { teams: [], locations: [], policies: [] };
    this.teamSearch = '';
    console.log('Cleared filters');
  }
}
