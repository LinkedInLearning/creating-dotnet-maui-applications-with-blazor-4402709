window.goBack = () => {
    window.history.back();
};

window.readText = (textToRead) => {
    const utterance = new SpeechSynthesisUtterance(textToRead);
    window.speechSynthesis.speak(utterance);
};