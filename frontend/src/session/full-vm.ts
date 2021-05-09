import { ℕ, DateString } from "../utils/types";

export interface SessionFullVM {
    id: ℕ;
    startTime: DateString;
    movieName: string;
    hallName: string;
    hallSeatRowCount: ℕ;
    hallSeatRowSize: ℕ;
    occupiedSeats: ℕ[];
}
