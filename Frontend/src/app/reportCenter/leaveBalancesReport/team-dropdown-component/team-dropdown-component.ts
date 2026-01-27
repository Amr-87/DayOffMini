import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-team-dropdown-component',
  imports: [FormsModule],
  templateUrl: './team-dropdown-component.html',
  styleUrl: './team-dropdown-component.scss',
})
export class TeamDropdownComponent {
  isOpen = false;
  teamFilter: string = ''; // selected value
  teamSearch: string = ''; // search input
  teams: string[] = ['Alpha', 'Beta', 'Gamma', 'Delta']; // example teams

  // Filter teams by search input
  filteredTeams(): string[] {
    if (!this.teamSearch) return this.teams;
    return this.teams.filter((team) =>
      team.toLowerCase().includes(this.teamSearch.toLowerCase()),
    );
  }

  selectTeam(team: string) {
    this.teamFilter = team;
    this.isOpen = false;
    this.teamSearch = '';
  }

  selectAll() {
    this.teamFilter = 'All Teams';
    this.isOpen = false;
    this.teamSearch = '';
  }
}
