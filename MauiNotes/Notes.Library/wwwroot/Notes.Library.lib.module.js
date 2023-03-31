export function beforeStart(options, extensions) {
    console.log("beforeStarted");

    var sharedScripts = document.createElement('script');
    sharedScripts.setAttribute('src', '_content/Notes.Library/js/sharedInjectedMethods.js');
    document.body.appendChild(sharedScripts);

    var sharedCss = document.createElement('link');
    sharedCss.setAttribute('rel', 'stylesheet');
    sharedCss.setAttribute('href', '_content/Notes.Library/css/library.css');
    document.head.appendChild(sharedCss);
}