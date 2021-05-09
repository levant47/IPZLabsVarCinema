import * as React from "react";
import { Contacts } from "./contacts";
import { Header } from "./header";
import { LogIn } from "./login";
import { MoviesListPage } from "./movie/list-page";
import { MovieDetailsPage } from "./movie/details-page";
import { SessionDetailsPage } from "./session/details-page";
import { User } from "./user/model";

interface State {
    user: User | undefined;
}

const initialState: State = {
    user: undefined,
};

const reducer = (state, action: any) => {
    switch (action.type) {
        case "LOGIN_SUCCESSFUL":
            return {...state, user: action.user};
        default:
            return state;
    }
}

export const StateContext = React.createContext([initialState, undefined as unknown as React.Dispatch<any>] as [State, React.Dispatch<any>]);

export const Main = () => {
    const [state, dispatch] = React.useReducer(reducer, initialState);
    const route = location.pathname;
    return (
        <StateContext.Provider value={[state, dispatch] as any}>
            <Header />
            {(route === "/" || route === "/movies") &&
                <MoviesListPage />}
            {route === "/login" &&
                <LogIn />}
            {route === "/contacts" &&
                <Contacts />}
            {/\/movies\/\d+/.test(route) &&
                <MovieDetailsPage />}
            {/\/sessions\/\d+/.test(route) &&
                <SessionDetailsPage />}
        </StateContext.Provider>
    );
};
