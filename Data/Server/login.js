const handleLogin = async context => {
    const { player } = context;
    const { login, password } = context.form;
    const account = await findAccountByUserName(login);
    if (account !== null) {
        if (await player.logIn(account, password)) {
            Logger.information("found account by username {login}: {account} password={password}", login, account, password);
            context.success();
            player.closeCurrentGui()
        }
        else {
            context.error("Wrong password.");
        }
    }
    else {
        context.error("Account doesnt't exists.");
    }
}

addEventHandler("onFormSubmit", async context => {
    const { name, player } = context;
    switch (context.name) {
        case "login":
            await handleLogin(context);
            break;
        default:
            Logger.information("event name={name} playerName={player} form={form}", name, player.name, JSON.stringify(context.form));
            throw `not implemented form ${name}`;
    }
});
