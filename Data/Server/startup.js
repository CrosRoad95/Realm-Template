import * as TestModule from "Test/test.js"
import "panel.js"
import "discord.js"
import "login.js"

Logger.information("startup.js, TestModule: {TestModule}", TestModule);
Logger.information("loaded modules: {modules}", JSON.stringify(getModules()));

const spawn = createSpawn("dynamicSpawn", "test", new Vector3(0, 20, 3));
//spawn.addRequiredPolicy("Admin");

Logger.information("createSpawn is persistant?: {persistant}", spawn.isPersistant());
addEventHandler("onPlayerJoin", async ({ player }) => {
    Logger.information("player joined: {player} isLoggedIn={isLoggedIn}", player.name, player.isLoggedIn);
    let account = await findAccountByUserName("test")
    Logger.information("account = {account}", account);
    //const loggedIn = await player.logIn(account, "asdASD123!@#");
    //if (!loggedIn)
    //    Logger.warning("Fail to log in");
    //Logger.information("is logged in?: {player} isLoggedIn={isLoggedIn}", player.name, player.isLoggedIn);
    //let account2 = await player.getAccount();
    //Logger.information("accounts ids: {a} = {b}", account.id, account2.id);
    //Logger.information("role: {a}", player.isInRole("admin"));
    //Logger.information("claims: {claims}", JSON.stringify(player.claims));
    //Logger.information("roles: {roles}", JSON.stringify(player.roles));

    player.openGui("login")
})

const spawns = getElementsByType("spawn");
Logger.information("spawns: {spawnsA} {spawnsB}", spawns.length, countElementsByType("spawn"));

for (var key in spawns) {
    Logger.information("Spawn: {spawnName}, is persistant: {isPersistant}", spawns[key].name, spawns[key].isPersistant());
}

const func = () => Logger.information("you should not see this");
addEventHandler("onPlayerJoin", func);
removeEventHandler("onPlayerJoin", func);

addEventHandler("onPlayerLogin", async ({player, account}) => {
    Logger.information("player logged in: {player}, {account}", player, account)
    await player.spawn(spawn);
    Logger.information("is player authorized to admin? {isAuythorized}", await player.authorize("Admin"))
})

addEventHandler("onPlayerLogout", ({ player }) => {
    Logger.information("logout {player}", player)
});

addEventHandler("onPlayerSpawn", ({ player, spawn }) => {
    Logger.information("player spawned: {player}", player)
});

(async () => {
    let account = await findAccountByUserName("test")
    if (account === null) {
        Logger.information("creating account...");
        account = await createAccount("test", "asdASD123!@#")
    }
    Logger.information("account: {account} {username}", account, account.userName);
})()