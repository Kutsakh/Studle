import { DECREMENT, INCREMENT } from '../actionTypes';

export const counterInitialState = {
  value: 0,
};

const counterReducer = (state = counterInitialState, { type }) => {
  const actionReducers = {
    [INCREMENT]: () => ({ ...state, value: state.value + 1 }),
    [DECREMENT]: () => ({ ...state, value: state.value - 1 }),
  };
  return actionReducers[type] ? actionReducers[type]() : { ...state };
};

export default counterReducer;
