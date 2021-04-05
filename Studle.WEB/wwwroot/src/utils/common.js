export const $ = document.querySelector.bind(document);

export const $$ = document.querySelectorAll.bind(document);

export const resetAuthFormError = (inputs, formErrorElement) => {
  inputs.forEach((elem) =>
    elem.addEventListener('change', () => {
      formErrorElement.classList.add('hidden');
    }),
  );
};
