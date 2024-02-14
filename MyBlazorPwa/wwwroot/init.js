function initialize() {
    debugger;
    window.addEventListener('offline', function (event) {
        console.log('The network connection has been lost.');
    });
    window.addEventListener('online', function (event) {
        console.log('The network connection has been restored.');
    });
}