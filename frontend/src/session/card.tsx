import * as React from "react";
import styled from "styled-components";
import { SessionForMovieVM } from "./for-movie-vm";
import { PropsFromStyled } from "../utils/styled-utils";
import { DateString } from "../utils/types";

const formatSessionTime = (time: DateString): string => {
    const date = new Date(time);
    return `${date.getHours()}:${date.getMinutes().toString().padStart(2, "0")}`;
};

interface Props extends PropsFromStyled {
    session: SessionForMovieVM;
}

export const SessionCard = styled((props: Props) => (
    <a className={props.className} href={localStorage.getItem("user") !== null ? `/sessions/${props.session.id}` : "/login"}>
        {props.session.hallName}, {formatSessionTime(props.session.startTime)}, Seats: {props.session.seatsOccupied}/{props.session.seatsTotal}
    </a>
))`
    text-decoration: none;
    background-color: CornflowerBlue;
    color: white;
    padding: 1em;
    border: 1px solid white;
    border-radius: 1em;

    :hover {
        background-color: DeepSkyBlue;
    }
`;
