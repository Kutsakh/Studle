import * as yup from 'yup';

import { $, $$, resetAuthFormError } from '../../utils/common';
import '../../sections/header/hader';

import './sign-up.scss';

const emailInput = $('[name="email"]');
const nameInput = $('[name="name"]');
const passwordInput = $('[name="password"]');
const confirmPasswordInput = $('[name="confirm-password"]');
const formElement = $('form');
const formErrorElement = $('#form-error');
const submitButton = $('button[type="submit"]');
const formInputs = $$('form input');

const schema = yup.object().shape({
  name: yup.string().required('Name is required'),
  email: yup.string().email('Email is invalid').required('Email is required'),
  password: yup
    .string()
    .min(8, 'Password must be at least 8 characters')
    .required('Password is required'),
  'confirm-password': yup
    .string()
    .oneOf([yup.ref('password'), null], "Passwords didn't match"),
});

resetAuthFormError(formInputs, formErrorElement);

submitButton.addEventListener('click', (e) => {
  e.preventDefault();

  const data = {
    name: nameInput.value,
    email: emailInput.value,
    password: passwordInput.value,
    'confirm-password': confirmPasswordInput.value,
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
