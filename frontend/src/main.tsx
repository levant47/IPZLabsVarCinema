import * as React from "react";
import { Contacts } from "./contacts";
import { Header } from "./header";
import { LogIn } from "./login";
import { MoviesListPage } from "./movie/list-page";

export const Main = () => {
    const route = location.pathname;
    return (
        <>
            <Header />
            {(route === "/" || route === "/movies") &&
                <MoviesListPage />}
            {route === "/login" &&
                <LogIn />}
            {route === "/contacts" &&
                <Contacts />}
        </>
    );
};
