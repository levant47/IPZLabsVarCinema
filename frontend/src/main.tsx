import * as React from "react";
import { Contacts } from "./contacts";
import { Header } from "./header";
import { LogIn } from "./login";
import { Movies } from "./movies";

export const Main = () => {
    const route = location.pathname;
    return (
        <>
            <Header />
            {(route === "/" || route === "/movies") &&
                <Movies />}
            {route === "/login" &&
                <LogIn />}
            {route === "/contacts" &&
                <Contacts />}
        </>
    );
};
