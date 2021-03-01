import { createStore } from 'redux';

import reducer from './reducer';

export default createStore(
  reducer,
  /* eslint-disable no-underscore-dangle */
  window.__redux_state__ || {},
  window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__(),
  /* eslint-enable no-underscore-dangle */
);
