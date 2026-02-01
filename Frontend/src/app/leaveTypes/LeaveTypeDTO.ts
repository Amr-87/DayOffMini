export interface LeaveTypeDTO {
  id: number;
  name: string;
  isDefault?: boolean;
  daysOffBalance?: number;

  color?: string;
  reportCirclePercentage?: number;
}
