import { $ } from '../../utils/common';
import initPage from '../../utils/initPage';

import store from './store';
import { decrement, increment } from './actions';

import './home.scss';

const render = (prevState, state) => {
  const { counter } = state;
  const { prevCounter = {} } = prevState || {};

  if (prevCounter.value !== counter.value) {
    $('#counter').innerText = counter.value.toString();
  }

  if (!prevState) {
    $('#increment').addEventListener('click', () =>
      store.dispatch(increment()),
    );

    $('#decrement').addEventListener('click', () =>
      store.dispatch(decrement()),
    );
  }
};

initPage(store, render);
