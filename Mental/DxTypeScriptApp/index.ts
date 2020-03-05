/// <reference path="ts/jquery.d.ts" />
/// <reference path="ts/knockout.d.ts" />
/// <reference path="ts/globalize.d.ts" />
/// <reference path="ts/cldr.js.d.ts" />
/// <reference path="ts/cldr.js-event.d.ts" />
/// <reference path="ts/cldr.js-supplemental.d.ts" />
/// <reference path="ts/dx.all.d.ts" />
/// <reference path="index.d.ts" />

interface External { Notify(arg: string): any; }

module DxTypeScriptApp {
    $(function() {
        // Uncomment the line below to disable platform-specific look and feel and to use the Generic theme for all devices
        // DevExpress.devices.current({ platform: "generic" });

        var isDeviceReady: boolean = false,
            isViewShown: boolean = false;

        function hideSplashScreen() {
            if (isDeviceReady && isViewShown) {
                navigator["splashscreen"].hide();
            }
        }

		if (document.addEventListener) {
			document.addEventListener("deviceready", function () {
				isDeviceReady = true;
				hideSplashScreen();
				document.addEventListener("backbutton", function () {
					DevExpress.processHardwareBackButton();
				}, false);
			}, false);
		}

        function onViewShown() {
            isViewShown = true;
            hideSplashScreen();
            app.off("viewShown", onViewShown);
        }

        function onNavigatingBack(e) {
            if (e.isHardwareButton && !app.canBack()) {
                e.cancel = true;
                exitApp();
            }
        }

        function exitApp() {
            switch (DevExpress.devices.real().platform) {
                case "android":
                    navigator["app"].exitApp();
                    break;
                case "win":
                    window["MSApp"].terminateApp('');
                    break;
            }
        }

        app = new DevExpress.framework.html.HtmlApplication({
            namespace: DxTypeScriptApp,
            navigation: config.navigation,
            layoutSet: DevExpress.framework.html.layoutSets[config.layoutSet],
            commandMapping: config.commandMapping
        });
        app.router.register(":view/:id", { view: "home", id: undefined });
        app.on("viewShown", onViewShown);
        app.on("navigatingBack", onNavigatingBack);
        app.navigate();
    });
}