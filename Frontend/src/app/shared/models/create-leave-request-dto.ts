export interface CreateLeaveRequestDTO {
  leaveTypeId: number;
  durationInDays: number;
  startDate: string;
  endDate: string;
  reason: string;
}
