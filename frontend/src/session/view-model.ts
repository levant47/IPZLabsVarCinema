import { DateString, ℕ } from "../utils/types";

export interface SessionVM {
    id: ℕ;
    hallName: string;
    startTime: DateString;
    seatsOccupied: ℕ;
    seatsTotal: ℕ;
}
