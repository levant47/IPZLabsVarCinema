import * as React from "react";
import styled from "styled-components";
import { PropsFromStyled } from "./utils/styled-utils";

export const Header = styled((props: PropsFromStyled) => (
    <header className={props.className}>
        <a href="movies">Movies</a>
        <a href="login">Log in</a>
        <a href="contacts">Contacts</a>
    </header>
))`
    > a {
        margin: 5px;
    }
`;
