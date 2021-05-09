import { DateString, ℕ } from "../utils/types";

export interface SessionForMovieVM {
    id: ℕ;
    hallName: string;
    startTime: DateString;
    seatsOccupied: ℕ;
    seatsTotal: ℕ;
}
