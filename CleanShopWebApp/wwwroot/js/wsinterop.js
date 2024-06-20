window.connect = function (url) {
    var socket = new WebSocket(url);

    socket.onopen = function (event) {
        console.log('WebSocket connected!');
    };

    socket.onmessage = function (event) {
        console.log('Received message:', event.data);
    };

    socket.onclose = function (event) {
        console.log('WebSocket closed.');
    };

    socket.onerror = function (error) {
        console.error('WebSocket error:', error);
    };

    window.sendMessage = function (message) {
        socket.send(message);
    };
};