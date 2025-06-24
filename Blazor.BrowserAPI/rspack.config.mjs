import path from "path";

export default {
    mode: "production",
    devtool: false,
    entry: "./Main.ts",
    output: {
        path: path.resolve(import.meta.dirname, "wwwroot"),
        filename: "BrowserAPI.js",
        module: true,
        library: { type: "module" }
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                exclude: [/node_modules/],
                loader: "builtin:swc-loader",
                options: {
                    jsc: {
                        parser: {
                            syntax: "typescript"
                        }
                    }
                },
                type: "javascript/auto"
            }
        ]
    },
    resolve: {
        extensions: [".js", ".ts"]
    },
    watch: true
};

// npx rspack build
