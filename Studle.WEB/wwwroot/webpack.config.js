const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const BrowserSyncPlugin = require('browser-sync-webpack-plugin');
const path = require('path');
const { lstatSync, readdirSync } = require('fs');

const isDirectory = (source) => lstatSync(source).isDirectory();
const getDirectories = (source) => readdirSync(source).filter((name) => isDirectory(path.join(source, name)));

const basePath = path.resolve(__dirname, 'src');

const getPageEntryPath = (pageName) => {
  const destination = path.relative(basePath, path.join(__dirname, 'src', 'pages', pageName, `${pageName}.js`));
  return `./${destination}`;
};

const pagesDirectories = getDirectories(path.join(__dirname, 'src', 'pages'));

const webpackEntry = pagesDirectories.reduce((acc, name) => {
  acc[name] = getPageEntryPath(name);
  return acc;
}, {});

module.exports = {
  context: basePath,
  entry: webpackEntry,
  output: {
    clean: true,
    path: path.resolve(__dirname, 'dist', 'pages'),
    filename: '[name].js',
  },
  plugins: [
    new MiniCssExtractPlugin({
      filename: '[name].css',
    }),
    new BrowserSyncPlugin({
      host: 'localhost',
      port: 3000,
      open: false,
      files: [
        path.join(__dirname, '*.config.js'),
        path.join(__dirname, 'src', '*'),
        path.join(__dirname, '..', 'Views', '*.cshtml'),
      ],
      proxy: 'localhost:5000',
    }),
  ],
  module: {
    rules: [
      {
        test: /\.scss$/i,
        use: [
          MiniCssExtractPlugin.loader,
          {
            loader: 'css-loader',
            options: {
              // Run `postcss-loader` on each CSS `@import`, do not forget that `sass-loader` compile non CSS `@import`'s into a single file
              // If you need run `sass-loader` and `postcss-loader` on each CSS `@import` please set it to `2`
              importLoaders: 1,
            },
          },
          {
            loader: 'postcss-loader',
          },
          // Can be `less-loader`
          {
            loader: 'sass-loader',
          },
        ],
      },
    ],
  },
};
