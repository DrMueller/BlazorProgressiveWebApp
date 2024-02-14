export function listenOnline(instance) {
    window.addEventListener("online", updateOnlineStatus(instance));
    window.addEventListener("offline", updateOnlineStatus(instance));
}

async function updateOnlineStatus(instance) {
    await instance.invokeMethodAsync("UpdateOnlineStatus",
        navigator.onLine);
}