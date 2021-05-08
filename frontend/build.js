const esbuild = require('esbuild');
const http = require('http');
const fs = require('fs');

esbuild.serve({
    servedir: 'static',
}, {
    entryPoints: ['src/index.tsx'],
    bundle: true,
    minify: true,
    outfile: 'static/bundle.js',
}).then(result => {
    const {host, port} = result

    // Then start a proxy server on port 3000
    http.createServer((req, res) => {
        const options = {
            hostname: host,
            port: port,
            path: req.url,
            method: req.method,
            headers: req.headers,
        };

        // Forward each incoming request to esbuild
        const proxyReq = http.request(options, proxyRes => {
          // If esbuild returns "not found", send a custom 404 page
          if (proxyRes.statusCode === 404) {
            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.end(fs.readFileSync('static/index.html'));
            return;
          }

          // Otherwise, forward the response from esbuild to the client
          res.writeHead(proxyRes.statusCode, proxyRes.headers);
          proxyRes.pipe(res, { end: true });
        });

        // Forward the body of the request to esbuild
        req.pipe(proxyReq, { end: true });
    }).listen(8000);
});
