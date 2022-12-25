namespace RealmRPG.Data;

class RegisterData : ILuaValue
{
    public string Login { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string RememberPassword { get; set; } = default!;
    public void Parse(LuaValue luaValue)
    {
        Login = luaValue.TableValue!["login"].StringValue!;
        Password = luaValue.TableValue!["password"].StringValue!;
        RememberPassword = luaValue.TableValue!["rememberPassword"].StringValue!;
    }
}