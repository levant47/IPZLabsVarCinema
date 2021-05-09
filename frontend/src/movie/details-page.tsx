import * as React from "react";
import { useEffect, useState } from "react";
import styled from "styled-components";
import * as _ from "lodash/fp";
import { PropsFromStyled } from "../utils/styled-utils";
import { Movie } from "./model";
import { MovieRating } from "./rating";
import { SessionVM } from "../session/view-model";
import { SessionCard } from "../session/card";

export const MovieDetailsPage = styled((props: PropsFromStyled) => {
    const movieIdFromRoute = _.parseInt(10, location.pathname.split("/")[2]);
    const [movie, setMovie] = useState<Movie>();
    const [sessions, setSessions] = useState<SessionVM[]>([]);

    useEffect(() => {
        fetch(`/api/movies/${movieIdFromRoute}`)
            .then(response => response.json())
            .then(setMovie);

        fetch(`/api/sessions/currentForMovie?movieId=${movieIdFromRoute}`)
            .then(response => response.json())
            .then(setSessions);
    }, [movieIdFromRoute]);

    return (
        <main className={props.className}>
            {movie === undefined &&
                "Loading..."}
            {movie !== undefined && <>
                <div className="details-container">
                    <img style={{gridArea: "poster"}} src={movie.poster} height={500} />
                    <h1 style={{gridArea: "name"}}>{movie.name}</h1>
                    <h3 style={{gridArea: "year"}}>Year: {movie.year}</h3>
                    <p style={{gridArea: "description"}}>{movie.description}</p>
                    <MovieRating style={{gridArea: "rating"}} rating={movie.rating} />
                </div>

                <h2>Sessions for tomorrow</h2>
                <hr />
                <div className="sessions-container">
                    {sessions.map(session =>
                        <SessionCard session={session} />)}
                </div>
            </>}
        </main>
    );
})`
    margin: 0 20vw;

    > .details-container {
        margin-bottom: 40px;
        display: grid;
        column-gap: 5vw;
        grid-template:
            "poster name"
            "poster year"
            "poster rating"
            "poster description" 1fr
        ;
    }

    > .sessions-container {
        display: flex;
        column-gap: 10px;
    }
`;
