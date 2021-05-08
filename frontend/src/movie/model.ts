import { Base64Image, ℕ } from "../utils/types";

export interface Movie {
    id: ℕ;
    year: ℕ;
    rating: number;
    description: string;
    name: string;
    poster: Base64Image;
}
