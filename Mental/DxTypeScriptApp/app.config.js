// NOTE object below must be a valid JSON
window.DxTypeScriptApp = $.extend(true, window.DxTypeScriptApp, {
    "config": {
        "layoutSet": "navbar",
        "navigation": [
            {
                title: "Home",
                onExecute: "#home",
                icon: "home"
            },
            {
                title: "About",
                onExecute: "#about",
                icon: "info"
            }
        ]
    }
});