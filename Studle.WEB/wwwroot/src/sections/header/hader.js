import { enter, leave, toggle } from 'el-transition';

import { $, $$ } from '../../utils/common';

import './haeder.scss';

$$('.header__nav-btn').forEach((elem) =>
  elem.addEventListener('click', (e) => {
    e.preventDefault();
    e.stopPropagation();
    $$('.header__nav-dropdown:not(.hidden)').forEach((dropdown) =>
      leave(dropdown, 'header__nav-dropdown'),
    );
    toggle(e.currentTarget.nextElementSibling, 'header__nav-dropdown');
  }),
);

$('#open-mobile-menu-btn').addEventListener('click', (e) => {
  e.preventDefault();
  enter($('.header__mobile-menu'), 'header__mobile-menu');
});

$('#close-mobile-menu-btn').addEventListener('click', (e) => {
  e.preventDefault();
  leave($('.header__mobile-menu'), 'header__mobile-menu');
});

window.addEventListener('click', (e) => {
  e.stopPropagation();
  $$('.header__nav-dropdown').forEach((elem) =>
    leave(elem, 'header__nav-dropdown'),
  );
});

$$('.header__nav-dropdown').forEach((elem) =>
  elem.addEventListener('click', (e) => {
    e.stopPropagation();
  }),
);
