import styled from "styled-components";

const TOTAL_NUMBER_OF_STARS = 5;

interface Props {
    rating: number;
}

export const MovieRating = styled.span<Props>`
    --star-color: gray; /* unfilled color */
    --star-background: gold; /* filled color */
    --percent: calc(${props => props.rating} / ${TOTAL_NUMBER_OF_STARS} * 100%);

    font-size: 1.5em;
    display: inline-block;
    font-family: Times;
    line-height: 1;
    
    &::before {
        content: '★★★★★';
        letter-spacing: 3px;
        background: linear-gradient(90deg, var(--star-background) var(--percent), var(--star-color) var(--percent));
        -webkit-background-clip: text;
        -webkit-text-fill-color: transparent;
    }
`;
