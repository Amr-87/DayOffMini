import { Component, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { ReportFiltersModel } from '../ReportFiltersModel';

@Component({
  selector: 'app-filters-bar',
  standalone: true,
  imports: [NgSelectModule, FormsModule],
  templateUrl: './filters-bar.html',
})
export class FiltersBar {
  filterChange = output<ReportFiltersModel>();

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

  filters: ReportFiltersModel = {
    teams: [],
    locations: [],
    policies: [],
  };

  applyFilters() {
    this.filterChange.emit(this.filters);
  }

  clearFilters() {
    this.filters = { teams: [], locations: [], policies: [] };
    this.applyFilters();
  }
}
