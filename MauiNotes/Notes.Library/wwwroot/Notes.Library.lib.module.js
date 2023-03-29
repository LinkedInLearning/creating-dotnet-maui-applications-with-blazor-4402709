export function beforeStart(options, extensions) {
    console.log("beforeStarted");

    var sharedScripts = document.createElement('script');
    sharedScripts.setAttribute('src', '_content/Notes.Library/js/sharedInjectedMethods.js');
    document.body.appendChild(sharedScripts);

}