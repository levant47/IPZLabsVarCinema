import { ℕ } from "./types";

// [from; to)
export const randomReal = (from = 0, to: number): number => Math.random() * (to - from) + from;

// [from; to)
export const randomInt = (from = 0, to: ℕ): ℕ => Math.floor(randomReal(from, to));
