import { Component } from '@angular/core';

@Component({
  selector: 'app-leave-policy-multi-select-dropdown-component',
  imports: [],
  templateUrl: './leave-policy-multi-select-dropdown-component.html',
  styleUrl: './leave-policy-multi-select-dropdown-component.scss',
})
export class LeavePolicyMultiSelectDropdownComponent {
  isOpen = false;

  policies: string[] = ['Default Policy'];
  leavePolicyFilter: string[] = [];

  togglePolicy(policy: string) {
    this.leavePolicyFilter = this.leavePolicyFilter.includes(policy)
      ? this.leavePolicyFilter.filter((p) => p !== policy)
      : [...this.leavePolicyFilter, policy];
  }

  toggleSelectAll(checked: boolean) {
    this.leavePolicyFilter = checked ? [...this.policies] : [];
  }

  isAllSelected(): boolean {
    return this.leavePolicyFilter.length === this.policies.length;
  }

  displayValue(): string {
    return this.leavePolicyFilter.length
      ? this.leavePolicyFilter.join(', ')
      : 'Leave Policy';
  }
}
