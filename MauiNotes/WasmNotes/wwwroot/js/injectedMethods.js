
window.readText = (textToRead) => {
    const utterance = new SpeechSynthesisUtterance(textToRead);
    window.speechSynthesis.speak(utterance);
};

window.isOnline = () => {
    return window.navigator.onLine;
};