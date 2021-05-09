import * as React from "react";
import { Movie } from "./model";
import { PropsFromStyled } from "../utils/styled-utils";
import styled from "styled-components";
import { MovieRating } from "./rating";

interface Props extends PropsFromStyled {
    movie: Movie;
}

export const MovieCard = styled((props: Props) => (
    <a className={props.className} href={`/movies/${props.movie.id}`}>
        <img className="poster" style={{gridArea: "poster"}} src={props.movie.poster} height={300} width={200} />
        <span className="name" style={{gridArea: "name"}}>{props.movie.name}</span>
        <span className="year" style={{gridArea: "year"}}>({props.movie.year})</span>
        <MovieRating className="rating" style={{gridArea: "rating"}} rating={props.movie.rating} />
    </a>
))`
    text-decoration: none;
    color: inherit;
    display: grid;
    grid-template:
        "poster" 300px
        "name" auto
        "year" auto
        "." 1fr
        "rating" auto
        /200px
    ;

    width: 200px;
    background-color: white;
    padding-bottom: 1em;
    border-radius: 0.5em;

    > .name {
        text-align: center;
        font-size: 1.5em;
        font-weight: bold;
        margin: 10px 0 0;
    }

    > .year {
        text-align: center;
        font-size: 1em;
        color: grey;
    }

    > .rating {
        text-align: center;
    }
`;
