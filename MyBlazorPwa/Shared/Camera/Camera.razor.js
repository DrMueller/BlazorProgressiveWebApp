export async function startCamera(videoElementId) {
    try {
        const videoElement = document.getElementById(videoElementId);
        if (!videoElement) {
            throw new Error("Video element not found");
        }
        const stream = await navigator.mediaDevices.getUserMedia({ video: true });
        videoElement.srcObject = stream;
    } catch (error) {
        console.error("Error accessing the camera:", error);
    }
}