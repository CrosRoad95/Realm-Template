local function createLoginWindow(guiProvider)
	local window = guiProvider.window(__("LoginWindow", "Login"), 0, 0, 300, 185);
	guiProvider.centerWindow(window)
	local information = guiProvider.label("", 10, 20, 280, 25, window);
	guiProvider.label("Login:", 10, 45, 90, 25, window);
	local loginInput = guiProvider.input(100, 45, 190, 25, window);
	guiProvider.label("Hasło:", 10, 80, 90, 25, window);
	local passwordInput = guiProvider.input(100, 80, 190, 25, window);
	local rememberPassword = guiProvider.checkbox("Zapamiętaj", 10, 120, 100, 20, false, window);
	local navigateToRegister = guiProvider.button("Nie mam konta", 10, 150, 100, 20, window);
	local loginButton = guiProvider.button("Zaloguj", 130, 150, 160, 20, window);

	guiProvider.setMasked(passwordInput, true)
	local form = createForm("login", {
		["login"] = loginInput,
		["password"] = passwordInput
	});

	if(guiProvider.tryLoadRememberedForm(form))then
		guiProvider.setSelected(rememberPassword, true)
	end

	guiProvider.onClick(navigateToRegister, function()
		guiProvider.invokeAction("navigateToRegister")
	end)

	guiProvider.onClick(loginButton, function()
		local success, data = form.submit()
		if(success)then
			if(guiProvider.getSelected(rememberPassword))then
				guiProvider.rememberForm(form)
			else
				guiProvider.forgetForm(form)
			end
		else
			guiProvider.setValue(information, data)
		end
	end)

	function stateChanged(key, value)
		iprint("payload", key, value)
	end
	return window, stateChanged
end

addEventHandler("onClientResourceStart", resourceRoot, function()
	registerGui(createLoginWindow, "login")
end)
