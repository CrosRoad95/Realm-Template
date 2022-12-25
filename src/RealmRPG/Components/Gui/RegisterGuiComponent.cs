namespace RealmRPG.Components.Gui;

public sealed class RegisterGuiComponent : GuiComponent
{
    public RegisterGuiComponent() : base("register")
    {

    }

    protected override async Task HandleForm(IFormContext formContext)
    {
        switch (formContext.FormName)
        {
            case "register":
                var registerData = formContext.GetData<RegisterData>();
                break;
            default:
                throw new NotImplementedException();
        }
    }

    protected override async Task HandleAction(IActionContext actionContext)
    {
        switch (actionContext.ActionName)
        {
            case "navigateToLogin":
                Entity.AddComponent(new LoginGuiComponent());
                Entity.DestroyComponent(this);
                break;
            default:
                throw new NotImplementedException();
        }
    }
}
