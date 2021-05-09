import * as React from "react";
import styled from "styled-components";
import { PropsFromStyled } from "./utils/styled-utils";

export const LogIn = styled((props: PropsFromStyled) => {
    const [error, setError] = React.useState<string>();
    const emailRef = React.useRef<HTMLInputElement>(null);
    const passwordRef = React.useRef<HTMLInputElement>(null);

    const handleLogInClick = () => {
        fetch(`/api/login`, {
            method: "POST",
            body: JSON.stringify({email: emailRef.current?.value, password: passwordRef.current?.value}),
            headers: {"Content-Type": "application/json"},
        })
            .then(response => {
                if (!response.ok) {
                    response.text().then(setError);
                    return;
                }
                response.json().then(user => {
                    localStorage.setItem("user", user);
                    location.pathname = "/";
                    return;
                });
            });
    };

    return (
        <main className={props.className}>
            <div>
                <h2 style={{gridArea: "header"}}>Account</h2>

                <label style={{gridArea: "email-label"}}>Email:</label>
                <input ref={emailRef} style={{gridArea: "email-input"}} type="text" placeholder="email" />

                <label style={{gridArea: "password-label"}}>Password:</label>
                <input ref={passwordRef} style={{gridArea: "password-input"}} type="password" />

                <span style={{gridArea: "error"}}>{error}</span>

                <button style={{gridArea: "button"}} onClick={handleLogInClick}>Log In</button>
            </div>
        </main>
    );
})`
    margin: 0 20vw;
    display: flex;
    justify-content: space-around;

    > div {
        padding: 40px;
        border 3px solid BurlyWood;
        border-radius: 15px;
        background-color: AntiqueWhite;

        display: grid;
        row-gap: 20px;
        grid-template:
            "header header"
            "email-label email-input"
            "password-label password-input"
            "error error"
            ". button"
        ;

        > span {
            justify-self: center;
            color: red;
        }

        > label {
            justify-self: end;
            font-size: 1.25em;
        }

        > h2 {
            margin: 0;
            justify-self: center;
        }

        > button {
            justify-self: end;
        }
    }
`;
