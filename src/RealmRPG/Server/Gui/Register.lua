local function createLoginWindow(guiProvider)
	local window = guiProvider.window(__("LoginWindow", "Login / Register"), 0, 0, 300, 220);
	guiProvider.centerWindow(window)
	local information = guiProvider.label("", 10, 20, 280, 25, window);
	guiProvider.label("Login:", 10, 45, 90, 25, window);
	local loginInput = guiProvider.input(100, 45, 190, 25, window);
	guiProvider.label("Hasło:", 10, 80, 90, 25, window);
	local passwordInput = guiProvider.input(100, 80, 190, 25, window);
	guiProvider.label("Powtórz hasło:", 10, 115, 90, 25, window);
	local repeatPasswordInput = guiProvider.input(100, 115, 190, 25, window);
	local acceptRules = guiProvider.checkbox("Akceptuje regulamin", 10, 155, 100, 20, false, window);
	local navigateToRegister = guiProvider.button("Mam już konto", 10, 185, 100, 20, window);
	local registerButton = guiProvider.button("Zarejestruj", 120, 185, 170, 20, window);

	guiProvider.setMasked(passwordInput, true)
	local form = createForm("register", {
		["login"] = loginInput,
		["password"] = passwordInput,
		["repeatPassword"] = repeatPasswordInput
	});

	guiProvider.onClick(navigateToRegister, function()
		guiProvider.invokeAction("navigateToLogin")
	end)

	guiProvider.onClick(registerButton, function()
		if(guiProvider.getSelected(acceptRules))then
			local success, data = form.submit()			
			if(success)then
				guiProvider.invokeAction("navigateToLogin")
			else
				guiProvider.setValue(information, data)
			end
		else
		end
	end)

	function stateChanged(key, value)
		iprint("payload", key, value)
	end
	return window, stateChanged
end

addEventHandler("onClientResourceStart", resourceRoot, function()
	registerGui(createLoginWindow, "register")
end)