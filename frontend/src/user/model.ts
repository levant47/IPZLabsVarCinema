import { ℕ, DateString } from "../utils/types";

export interface User {
    id: ℕ;
    firstName: string;
    lastName: string;
    email: string;
    registrationTime: DateString;
}
