import * as React from "react";
import styled from "styled-components";
import { PropsFromStyled } from "./utils/styled-utils";

export const AccountPage = styled((props: PropsFromStyled) => {
    return (
        <main className={props.className}>
            My Tickets
        </main>
    );
})`
    margin: 0 20vw;
`;
