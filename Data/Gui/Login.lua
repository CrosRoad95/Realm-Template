local function createLoginWindow(guiProvider)
	local window = guiProvider.window("Logowanie", 0, 0, 400, 400);
	guiProvider.centerWindow(window)
	local information = guiProvider.label("", 10, 20, 380, 25, window);
	local loginInput = guiProvider.input(100, 45, 200, 25, window);
	local passwordInput = guiProvider.input(100, 120, 200, 25, window);
	local loginButton = guiProvider.button("Zaloguj", 100, 300, 200, 20, window);

	guiProvider.setMasked(passwordInput, true)
	local form = createForm("login", {
		["login"] = loginInput,
		["password"] = passwordInput
	});

	guiProvider.onClick(loginButton, function()
		local success, data = form.submit()
		iprint("response", success, data)
		if(success)then
			guiProvider.setValue(information, "")
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
setDebugViewActive(true)
