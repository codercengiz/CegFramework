/**
 * @license Angular v7.2.13
 * (c) 2010-2019 Google LLC. https://angular.io/
 * License: MIT
 */

(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/core'), require('@angular/platform-browser-dynamic/testing'), require('@angular/platform-browser/animations'), require('@angular/platform-server')) :
    typeof define === 'function' && define.amd ? define('@angular/platform-server/testing', ['exports', '@angular/core', '@angular/platform-browser-dynamic/testing', '@angular/platform-browser/animations', '@angular/platform-server'], factory) :
    (global = global || self, factory((global.ng = global.ng || {}, global.ng.platformServer = global.ng.platformServer || {}, global.ng.platformServer.testing = {}), global.ng.core, global.ng.platformBrowserDynamic.testing, global.ng.platformBrowser.animations, global.ng.platformServer));
}(this, function (exports, core, testing, animations, platformServer) { 'use strict';

    /*! *****************************************************************************
    Copyright (c) Microsoft Corporation. All rights reserved.
    Licensed under the Apache License, Version 2.0 (the "License"); you may not use
    this file except in compliance with the License. You may obtain a copy of the
    License at http://www.apache.org/licenses/LICENSE-2.0

    THIS CODE IS PROVIDED ON AN *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
    KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
    WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
    MERCHANTABLITY OR NON-INFRINGEMENT.

    See the Apache Version 2.0 License for specific language governing permissions
    and limitations under the License.
    ***************************************************************************** */

    function __decorate(decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    }

    /**
     * @license
     * Copyright Google Inc. All Rights Reserved.
     *
     * Use of this source code is governed by an MIT-style license that can be
     * found in the LICENSE file at https://angular.io/license
     */
    /**
     * Platform for testing
     *
     * @publicApi
     */
    var platformServerTesting = core.createPlatformFactory(testing.ɵplatformCoreDynamicTesting, 'serverTesting', platformServer.ɵINTERNAL_SERVER_PLATFORM_PROVIDERS);
    /**
     * NgModule for testing.
     *
     * @publicApi
     */
    var ServerTestingModule = /** @class */ (function () {
        function ServerTestingModule() {
        }
        ServerTestingModule = __decorate([
            core.NgModule({
                exports: [testing.BrowserDynamicTestingModule],
                imports: [animations.NoopAnimationsModule],
                providers: platformServer.ɵSERVER_RENDER_PROVIDERS
            })
        ], ServerTestingModule);
        return ServerTestingModule;
    }());

    /**
     * @license
     * Copyright Google Inc. All Rights Reserved.
     *
     * Use of this source code is governed by an MIT-style license that can be
     * found in the LICENSE file at https://angular.io/license
     */

    /**
     * @license
     * Copyright Google Inc. All Rights Reserved.
     *
     * Use of this source code is governed by an MIT-style license that can be
     * found in the LICENSE file at https://angular.io/license
     */
    // This file only reexports content of the `src` folder. Keep it that way.

    /**
     * @license
     * Copyright Google Inc. All Rights Reserved.
     *
     * Use of this source code is governed by an MIT-style license that can be
     * found in the LICENSE file at https://angular.io/license
     */

    /**
     * Generated bundle index. Do not edit.
     */

    exports.platformServerTesting = platformServerTesting;
    exports.ServerTestingModule = ServerTestingModule;

    Object.defineProperty(exports, '__esModule', { value: true });

}));
//# sourceMappingURL=platform-server-testing.umd.js.map
