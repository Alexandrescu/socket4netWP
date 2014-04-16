var http = require('http'),
	fs = require('fs');

function theServer(request, response) {

	fs.readFile("client.html", 'utf-8', function (error, data) {
        response.writeHead(200, {'Content-Type': 'text/html'});
        response.write(data);
        response.end();
    });

}

var app = http.createServer(theServer).listen(1337);

var io = require('socket.io').listen(app);

io.sockets.on('connection', function(socket) {
    socket.on('message_to_server', function(data) {
        io.sockets.emit("message_to_client",{ message: data["message"] });
    });
});