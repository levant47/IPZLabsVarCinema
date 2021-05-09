import * as React from "react";
import styled from "styled-components";
import { User } from "./user/model";
import { PropsFromStyled } from "./utils/styled-utils";
import { DateString } from "./utils/types";

const formatSessionTime = (time: DateString): string => {
    const date = new Date(time);
    return `${date.toDateString()}, ${date.getHours()}:${date.getMinutes().toString().padEnd(2, "0")}`;
}

const TicketContainer = styled.div`
    background-color: white;
    border: 1px solid black;
    border-radius: 10px;
    padding: 5px;
`;

export const AccountPage = styled((props: PropsFromStyled) => {
    const [tickets, setTickets] = React.useState<any[]>();
    const user = JSON.parse(localStorage.getItem("user")!) as User;

    React.useEffect(() => {
        fetch(`/api/tickets?userId=${JSON.parse(localStorage.getItem("user")!).id}`)
            .then(response => response.json())
            .then(setTickets);
    }, []);

    return (
        <main className={props.className}>
            <h2>{user.firstName} {user.lastName} ({user.email})</h2>
            <h2>My Tickets</h2>
            {tickets === undefined &&
                "Loading..."}
            {tickets?.map(ticket =>
                <TicketContainer>"{ticket.movieName}", {ticket.hallName}, {formatSessionTime(ticket.sessionStartTime)}, Row {ticket.row}, Seat {ticket.seat}</TicketContainer>)}
        </main>
    );
})`
    margin: 0 20vw;
    display: flex;
    flex-direction: column;
    row-gap: 10px;
    > * {
        align-self: start;
    }
`;
