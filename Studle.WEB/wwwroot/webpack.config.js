const path = require('path');

module.exports = {
    context: path.resolve(__dirname, 'src'),
    entry: {
        home: './pages/home/home.js',
    },
    output: {
        path: path.resolve(__dirname, 'dist/pages'),
        filename: '[name].js',
    },
};