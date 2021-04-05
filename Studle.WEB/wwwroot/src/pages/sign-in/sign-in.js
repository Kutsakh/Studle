import * as yup from 'yup';

import { $, $$, resetAuthFormError } from '../../utils/common';
import '../../sections/header/hader';

import './sign-in.scss';

const emailInput = $('[name="email"]');
const passwordInput = $('[name="password"]');
const formElement = $('form');
const formErrorElement = $('#form-error');
const submitButton = $('button[type="submit"]');
const formInputs = $$('form input');

const schema = yup.object().shape({
  email: yup.string().email('Email is invalid').required('Email is required'),
  password: yup.string().required('Password is required'),
});

resetAuthFormError(formInputs, formErrorElement);

submitButton.addEventListener('click', (e) => {
  e.preventDefault();

  const data = {
    email: emailInput.value,
    password: passwordInput.value,
  };

  schema
    .validate(data)
    .then(() => {
      formErrorElement.classList.add('hidden');
      formElement.submit();
    })
    .catch((err) => {
      formErrorElement.innerText = err.message;
      formErrorElement.classList.remove('hidden');
    });
});
