import { createStore } from "redux";

const initialState = {
    counter: 0,
};

const INCREMENT = 'INCREMENT';
const DECREMENT = 'DECREMENT';

const increment = () => ({ type: INCREMENT });
const decrement = () => ({ type: DECREMENT });

const reducer = (state = initialState, { type, payload }) => {
    switch (type) {
       case INCREMENT:
           return { ...state, counter: state.counter + 1 };
       case DECREMENT:
           return { ...state, counter: state.counter - 1 };
       default:
           return { ...state };
   }
};

const store = createStore(reducer, initialState, undefined);

const render = () => {
    const { counter } = store.getState();
    console.log(store.getState());
    document.getElementById('counter').innerText = counter;
};

store.subscribe(render);

document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('increment').addEventListener('click', () => {
        store.dispatch(increment());
    });
    document.getElementById('decrement').addEventListener('click', () => {
        store.dispatch(decrement());
    });
});