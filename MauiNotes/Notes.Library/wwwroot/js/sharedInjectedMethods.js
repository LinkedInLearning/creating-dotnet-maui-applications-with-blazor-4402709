window.goBack = () => {
    window.history.back();
};

window.presentConfirm = async (promptTitle, promptText, confirmText, cancelText) => {
    const alert = document.createElement('ion-alert');
    alert.header = promptTitle;
    alert.message = promptText;
    alert.buttons = [
        {
            text: confirmText,
            role: 'confirm',
        },
        {
            text: cancelText,
            role: 'cancel',
        }
    ];

    document.body.appendChild(alert);
    await alert.present();

    const { role } = await alert.onDidDismiss();
    return role;
};

window.getControlValue = (control) => {
    return control.value;
};