if (moduleExists("WebPanel")) {
    Logger.information("loading panel.js")

    addEventHandler("onPlayerJoin", ({ player }) => {
        webPanelAddSnackbar(`${player.name} wszedł na serwer`);
    })
}