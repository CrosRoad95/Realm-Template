if (moduleExists("Discord")) {
    Logger.information("loading discord.js")

addEventHandler("onDiscordStatusChannelUpdate", context => {
    context.addLine(`======================================`);
    context.addLine(`Ostatnia aktualizacja statusu serwera: <t:${Math.floor(Date.now() / 1000)}:R>`);
})

addEventHandler("onDiscordStatusChannelUpdate", context => {
    const plrs = countElementsByType("player")
    context.addLine(`Ilość graczy: ${plrs}`);
})
}