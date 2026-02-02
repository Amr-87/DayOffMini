import { Component, inject } from '@angular/core';
import { ErrorService } from '../../services/error-service';

@Component({
  selector: 'app-error-modal',
  standalone: true,
  templateUrl: './error-modal-component.html',
})
export class ErrorModalComponent {
  private errorService = inject(ErrorService);

  error = this.errorService.error;

  close() {
    this.errorService.clear();
  }
}
