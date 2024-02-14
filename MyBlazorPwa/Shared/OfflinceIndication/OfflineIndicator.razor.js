export function listenOnline(instance) {
    window.addEventListener("online", function (event) {
        updateOnlineStatus(instance);
    });

    window.addEventListener("offline", function (event) {
        updateOnlineStatus(instance);
    });
}

async function updateOnlineStatus(instance) {
    await instance.invokeMethodAsync("UpdateOnlineStatus",
        navigator.onLine);
}