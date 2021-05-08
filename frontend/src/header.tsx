import * as React from "react";
import styled from "styled-components";
import { PropsFromStyled } from "./utils/styled-utils";

export const Header = styled((props: PropsFromStyled) => (
    <header className={props.className}>
        <img style={{gridArea: "logo"}} src="/logo.png" width={40} height={40} />
        <h1 style={{gridArea: "label"}}>Cinema</h1>
        <a style={{gridArea: "movies"}} href="movies">Movies</a>
        <a style={{gridArea: "contacts"}} href="contacts">Contacts</a>
        <a className="login" style={{gridArea: "login"}} href="login">Log in</a>
    </header>
))`
    margin: 0 20vw 5vh;

    display: grid;
    align-items: baseline;
    grid-template:
        "logo label movies contacts .   login"
        /auto auto  auto   auto     1fr auto
    ;

    > * {
        margin: 5px;
    }

    > h1 {
        margin-right: 40px;
    }

    > a {
        text-decoration: none;
        color: gray;
        padding: 5px;
        font-size: 1.5em;
    }

    > .login {
        color: white;
        background-color: red;
        border-radius: 30px;
        padding: 15px;
        font-size: unset;
        align-self: center;
    }
`;
