import * as React from "react";
import { useEffect, useState } from "react";
import styled from "styled-components";
import * as _ from "lodash/fp";
import { PropsFromStyled } from "../utils/styled-utils";
import { Movie } from "./model";
import { MovieRating } from "./rating";

export const MovieDetailsPage = styled((props: PropsFromStyled) => {
    const movieIdFromRoute = _.parseInt(10, location.pathname.split("/")[2]);
    const [movie, setMovie] = useState<Movie>();

    useEffect(() => {
        fetch(`/api/movies/${movieIdFromRoute}`)
            .then(response => response.json())
            .then(setMovie);
    }, [movieIdFromRoute]);

    return (
        <main className={props.className}>
            {movie === undefined &&
                "Loading..."}
            {movie !== undefined && <>
                <img style={{gridArea: "poster"}} src={movie.poster} height={500} />
                <h1 style={{gridArea: "name"}}>{movie.name}</h1>
                <h3 style={{gridArea: "year"}}>Year: {movie.year}</h3>
                <p style={{gridArea: "description"}}>{movie.description}</p>
                <MovieRating style={{gridArea: "rating"}} rating={movie.rating} />
            </>}
        </main>
    );
})`
    margin: 0 20vw;

    display: grid;
    column-gap: 5vw;
    grid-template:
        "poster name"
        "poster year"
        "poster rating"
        "poster description" 1fr
    ;
`;
