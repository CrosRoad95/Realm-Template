namespace RealmRPG.Components.Gui;

public sealed class LoginGuiComponent : GuiComponent
{
    public LoginGuiComponent() : base("login")
    {

    }

    protected override async Task HandleForm(IFormContext formContext)
    {
        switch (formContext.FormName)
        {
            case "login":
                var loginData = formContext.GetData<LoginData>();
                var userManager = Entity.GetRequiredService<UserManager<User>>();
                var user = await userManager.FindByNameAsync(loginData.Login);
                if (user == null)
                {
                    formContext.ErrorResponse("Login lub hasło jest niepoprawne.");
                    return;
                }

                if (!await userManager.CheckPasswordAsync(user, loginData.Password))
                {
                    formContext.ErrorResponse("Login lub hasło jest niepoprawne.");
                    return;
                }

                await Entity.AddComponentAsync(new AccountComponent(user));
                Entity.DestroyComponent(this);
                formContext.SuccessResponse();
                break;
            default:
                throw new NotImplementedException();
        }
    }

    protected override async Task HandleAction(IActionContext actionContext)
    {
        switch (actionContext.ActionName)
        {
            case "navigateToRegister":
                Entity.AddComponent(new RegisterGuiComponent());
                Entity.DestroyComponent(this);
                break;
            default:
                throw new NotImplementedException();
        }
    }
}
