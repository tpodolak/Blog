var express = require('express'),
    path = require('path'),
    app = express();

app.use(express.static(path.join(__dirname, '/app')));

app.get('/', function (req, res) {
    res.sendFile(path.join(__dirname, '/app/index.html'));
});

app.listen(3000,'127.0.0.1', function () {
    var host = server.address().address;
    var port = server.address().port;
    console.log( path.join(__dirname,'server.js') + ' listening at http://%s:%s', host, port);
});