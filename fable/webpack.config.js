var path = require("path");

module.exports = {
    mode: "development",
    entry: "./src/App.fs.js",
    output: {
        path: path.join(__dirname, "./public"),
        filename: "bundle.js",
    },
    devServer: {
        static: {
            directory: path.join(__dirname, "./public"),
            watch: true,
        },
        port: 8080,
    },
    module: {
    }
}
