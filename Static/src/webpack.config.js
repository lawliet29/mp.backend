var OpenBrowserPlugin = require('open-browser-webpack-plugin');
var ExtractTextPlugin = require('extract-text-webpack-plugin');

module.exports = {
    resolve: {
        extensions: [ '', '.ts', '.tsx', '.js' ]
    },
    entry: {
        main: './src/main.tsx',
        tests: './test/main.ts'
    },
    output: {
        filename: './dist/[name].js',
        sourceMapFilename: './dist/[name].map',
        publicPath: './dist'
    },
    module: {
        loaders: [
            { test: /\.tsx?$/, loader: 'react-hot!ts-loader?jsx=true', exclude: /(\.test.ts$|node_modules)/},
            { test: /\.sass$/, loaders: ['style-loader', 'css-loader?modules&sourceMap', 'sass-loader?sourceMap'] },
            { test: /\.html/, loader: 'html' }
        ]
    },
    devServer: {
        contentBase: './dist',
        port: 8081
    },
    devtool: 'inline-source-map',
    plugins: [
        new ExtractTextPlugin('style.css', { allChunks: true }),
        new OpenBrowserPlugin({ url: 'http://localhost:8081' })
    ],
    debug: true,
    process: true,
    colors: true
};