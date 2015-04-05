(function () {
    angular.module('app.common', [])
        .config(extendServices);

    /*ngInject*/
    function extendServices($provide)
    {
        $provide.decorator('$rootScope', extendRootScope);
    }

    /*ngInject*/
    function extendRootScope($delegate)
    {
        $delegate.$un = function (name, listener) {
            var namedListeners = this.$$listeners[name],
                idx;
            if (namedListeners && (idx = namedListeners.indexOf(listener)) > -1) {
                namedListeners.splice(idx, 1);
            }
        };
        return $delegate;
    }
}());