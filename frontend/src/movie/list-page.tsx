import * as React from "react";
import { useEffect, useState } from "react";
import { Movie } from "./model";
import styled from "styled-components";
import { PropsFromStyled } from "../utils/styled-utils";
import { MovieList } from "./list";
import { Filters, MovieListFilter } from "./list-filter";

export const MoviesListPage = styled((props: PropsFromStyled) => {
    const [filters, setFilters] = useState<Filters>({});

    const [isLoading, setIsLoading] = useState(true);
    const [movies, setMovies] = useState<Movie[]>([]);

    const filteredMovies = movies.filter(movie => {
        if (filters.year !== undefined && movie.year !== filters.year) {
            return false;
        }
        if (filters.name !== undefined && !movie.name.toLowerCase().includes(filters.name.toLowerCase())) {
            return false;
        }
        return true;
    });

    useEffect(() => {
        fetch("/api/movies")
            .then(response => response.ok ? response.json() : Promise.reject())
            .then(setMovies)
            .finally(() => {
                setIsLoading(false)
            });
    }, []);

    return (
        <main className={props.className}>
            {isLoading &&
                <p>Loading...</p>}
            {!isLoading &&
                <MovieList movies={filteredMovies} />}

            <MovieListFilter filters={filters} setFilters={setFilters} />
        </main>
    );
})`
    margin: 0 20vw;
    display: grid;
    grid-template-columns: 3fr 1fr;
`;
