import * as React from "react";
import styled from "styled-components";
import * as _ from "lodash/fp";
import { PropsFromStyled } from "../utils/styled-utils";
import { SessionFullVM } from "./full-vm";
import { DateString, ℕ } from "../utils/types";

const Seat = styled.div<{selected: boolean, occupied: boolean}>`
    width: 30px;
    height: 40px;
    background-color: ${props => props.selected ? "DeepSkyBlue" : "lightblue"};
    border: 1px solid white;
    border-radius: 15px;
    text-align: center;
    vertical-align: center;
    display: flex;
    flex-direction: column;
    justify-content: center;
    opacity: ${props => props.occupied ? "0.25" : "1"};

    ${props => !props.occupied && `:hover {
        background-color: DeepSkyBlue;
        cursor: pointer;
    }`}
`;

const SelectedSeatContainer = styled.span`
    background-color: white;
    border: 1px solid black;
    border-radius: 5px;
    padding: 5px;
    margin-right: 10px;
`;

interface SelectedSeat {
    seatRow: ℕ;
    seatIndex: ℕ;
}

const formatSessionTime = (time: DateString): string => {
    const date = new Date(time);
    return `${date.toDateString()}, ${date.getHours()}:${date.getMinutes().toString().padEnd(2, "0")}`;
}

export const SessionDetailsPage = styled((props: PropsFromStyled) => {
    const sessionIdFromRoute = _.parseInt(10, location.pathname.split("/")[2]);
    const [session, setSession] = React.useState<SessionFullVM>();
    const [selectedSeats, setSelectedSeats] = React.useState<SelectedSeat[]>([]);

    const handleCheckout = () => {
        fetch(`/api/tickets/buy`, {
            method: "POST",
            body: JSON.stringify({
                userId: JSON.parse(localStorage.getItem("user")!).id,
                sessionId: session!.id,
                seats: selectedSeats,
            }),
            headers: {"Content-Type": "application/json"},
        })
            .then(() => {
                location.href = "/account";
            });
    };

    React.useEffect(() => {
        fetch(`/api/sessions/${sessionIdFromRoute}/view`)
            .then(response => response.json())
            .then(setSession);
    }, [sessionIdFromRoute]);

    return (
        <main className={props.className}>
            {session === undefined &&
                "Loading..."}
            {session !== undefined && <>
                <h2 style={{gridArea: "session-title"}}>Session of "{session.movieName}" on {formatSessionTime(session.startTime)}</h2>
                <hr style={{gridArea: "hr"}} />
                <h3 style={{gridArea: "hall-name"}}>{session.hallName}</h3>
                <table style={{gridArea: "seat-table"}}>
                    <tbody>
                        {_.range(0, session.hallSeatRowCount).map(row =>
                            <tr>
                                <td>Row {row + 1}</td>
                                {_.range(0, session.hallSeatRowSize).map(column =>
                                    <td><Seat
                                        occupied={session.occupiedSeats.includes(row*session.hallSeatRowSize + column+1)}
                                        selected={selectedSeats.some(selectedSeat => selectedSeat.seatRow == row && selectedSeat.seatIndex === column)}
                                        onClick={() => {
                                            if (session.occupiedSeats.includes(row*session.hallSeatRowSize + column+1)) {
                                                return;
                                            }
                                            if (selectedSeats.some(selectedSeat => selectedSeat.seatRow == row && selectedSeat.seatIndex === column)) {
                                                setSelectedSeats(prevSelectedSeats => prevSelectedSeats
                                                    .filter(selectedSeat => selectedSeat.seatRow != row || selectedSeat.seatIndex !== column));
                                            } else {
                                                setSelectedSeats(prevSelectedSeats => [...prevSelectedSeats, {seatRow: row, seatIndex: column}]);
                                            }
                                        }}
                                    >{column+1}</Seat></td>)}
                            </tr>)}
                    </tbody>
                </table>
                <h3 style={{gridArea: "seats-title"}}>Selected seats</h3>
                <div style={{gridArea: "seats"}}>
                    {selectedSeats.length === 0 &&
                        "None"}
                    {selectedSeats.map(seat =>
                        <SelectedSeatContainer>Row {seat.seatRow + 1}, Seat {seat.seatIndex + 1}</SelectedSeatContainer>)}
                </div>
                <button className="checkout-button" style={{gridArea: "checkout"}} disabled={selectedSeats.length === 0} onClick={handleCheckout}>Checkout</button>
            </>}
        </main>
    );
})`
    margin: 0 20vw;

    display: grid;
    column-gap: 50px;
    grid-template:
        "session-title ."
        "hr hr"
        "hall-name seats-title"
        "seat-table seats" 1fr
        "seat-table checkout"
        /auto 1fr
    ;

    > hr {
        width: 100%;
    }

    > .checkout-button {
        border: none;
        border-radius: 1.5em;
        background-color: red;
        color: white;
        padding: 0.5em;
        font-size: 1.25em;
        justify-self: end;
    }

    > .checkout-button[disabled] {
        opacity: 0.25;
    }
`;
