import * as React from "react";
import styled from "styled-components";
import { PropsFromStyled } from "../utils/styled-utils";
import { ℕ } from "../utils/types";
import * as _ from "lodash/fp";
import { useState } from "react";

export interface Filters {
    name?: string | undefined;
    year?: ℕ | undefined;
}

interface Props extends PropsFromStyled {
    filters: Filters;
    setFilters: React.Dispatch<React.SetStateAction<Filters>>;
}

export const MovieListFilter = styled((props: Props) => {
    const [isYearValid, setIsYearValid] = useState(true);
    const [isNameValid, setIsNameValid] = useState(true);

    return (
        <aside className={props.className}>
            <h3>Filters</h3>
            <div className="filter-group">
                <label>Year:</label>
                <input
                    type="text"
                    onChange={event => {
                        const newYearString = event.target.value.trim();
                        const newYear = newYearString !== "" ? _.parseInt(10, newYearString) : undefined;
                        if (newYear !== undefined && (Number.isNaN(newYear) || newYear <= 1900 || newYear >= 2100)) {
                            setIsYearValid(false);
                            return;
                        }
                        props.setFilters(prevFilters => ({...prevFilters, year: newYear}));
                        setIsYearValid(true);
                    }}
                />
                {!isYearValid && <small>Year must be between 1900 and 2100</small>}
            </div>
            <div className="filter-group">
                <label>Name:</label>
                <input
                    type="text"
                    onChange={event => {
                        const newName = event.target.value.trim() || undefined;
                        if (newName !== undefined && newName.length < 3) {
                            setIsNameValid(false);
                            return;
                        }
                        props.setFilters(prevFilters => ({...prevFilters, name: newName}));
                        setIsNameValid(true);
                    }}
                />
                {!isNameValid && <small>Name must be at least 3 characters long</small>}
            </div>
        </aside>
    );
})`
    border: 1px solid orange;
    border-radius: 2em;
    padding: 2em;
    align-self: flex-start;

    > h3 {
        margin-top: 0;
        text-align: center;
    }

    > .filter-group {
        margin: 10px 0;
        display: grid;

        > label {
            grid-area: label;
            font-weight: bold;
        }

        > input {
            grid-area: input;
            border: 0;
            border-radius: 5px;
        }

        > small {
            grid-area: small;
            font-size: 0.75em;
            color: gray;
        }

        grid-template:
            "label input"
            ".     small"
            /auto  1fr
        ;
    }
`;
