const initPage = (store, render) => {
  document.addEventListener('DOMContentLoaded', () => {
    let prevState;
    const update = () => {
      const state = store.getState();
      render(prevState, state);
      prevState = state;
    };
    store.subscribe(update);
    update();
  });
};

export default initPage;
