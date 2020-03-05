/// <reference path="ts/jquery.d.ts" />
/// <reference path="ts/knockout.d.ts" />
/// <reference path="ts/globalize.d.ts" />
/// <reference path="ts/cldr.js.d.ts" />
/// <reference path="ts/cldr.js-event.d.ts" />
/// <reference path="ts/cldr.js-supplemental.d.ts" />
/// <reference path="ts/dx.all.d.ts" />

declare module DxTypeScriptApp {
    export interface Config {
        layoutSet?: string;
        navigation: Array<DevExpress.framework.dxCommandOptions>;
        commandMapping: {
            [containderId: string]: {
                defaults?: DevExpress.framework.dxCommandOptions;
                commands?: DevExpress.framework.dxCommandOptions;
            }
        };
    }

    export var app: DevExpress.framework.html.HtmlApplication;
    export var config: Config;
}