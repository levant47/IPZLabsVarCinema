import * as React from "react";
import styled from "styled-components";
import { PropsFromStyled } from "../utils/styled-utils";
import { Movie } from "./model";
import { MovieCard } from "./card";

interface Props extends PropsFromStyled {
    movies: Movie[];
}

export const MovieList = styled((props: Props) => (
    <div className={props.className}>
        {props.movies.map(movie =>
            <MovieCard key={movie.id} className="movie-card" movie={movie} />)}
        {props.movies.length === 0 &&
            "No movies found"}
    </div>
))`
    display: flex;
    flex-wrap: wrap;
    row-gap: 40px;

    > * {
        margin: 5px 10px;
    }
`;
