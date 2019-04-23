"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Observable_1 = require("../../Observable");
function fromFetch(input, init) {
    return new Observable_1.Observable(function (subscriber) {
        var controller = new AbortController();
        var signal = controller.signal;
        var outerSignalHandler;
        var unsubscribed = false;
        if (init) {
            if (init.signal) {
                outerSignalHandler = function () {
                    if (!signal.aborted) {
                        controller.abort();
                    }
                };
                init.signal.addEventListener('abort', outerSignalHandler);
            }
            init.signal = signal;
        }
        else {
            init = { signal: signal };
        }
        fetch(input, init).then(function (response) {
            subscriber.next(response);
            subscriber.complete();
        }).catch(function (err) {
            if (!unsubscribed) {
                subscriber.error(err);
            }
        });
        return function () {
            unsubscribed = true;
            controller.abort();
        };
    });
}
exports.fromFetch = fromFetch;
//# sourceMappingURL=fetch.js.map