import * as React from "react";
import styled from "styled-components";
import { PropsFromStyled } from "./utils/styled-utils";

export const Header = styled((props: PropsFromStyled) => (
    <header className={props.className}>
        <a style={{gridArea: "logo"}} href="/"><img src="/logo.png" width={40} height={40} /></a>
        <a className="title" style={{gridArea: "label"}} href="/">Cinema</a>
        <a style={{gridArea: "movies"}} href="/movies">Movies</a>
        <a style={{gridArea: "contacts"}} href="/contacts">Contacts</a>
        <a className="login" style={{gridArea: "login"}} href="/login">Log in</a>
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

    > .title {
        margin-right: 40px;
        font-size: 2em;
        font-weight: bold;
        color: black;
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
