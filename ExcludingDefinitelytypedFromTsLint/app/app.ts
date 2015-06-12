///<reference path="../typings/tsd.d.ts" />

module app {

    angular.module('app', ['ngRoute'])
        .config(configureRoutes);

    configureRoutes.$inject = ['$routeProvider'];
    function configureRoutes( $routeProvider: ng.route.IRouteProvider ): void {
        $routeProvider.when('/downloading', {
            url: '/downloading',
            controller: 'downloadCtrl',
            templateUrl: 'views/downloadView.html'
        }).otherwise({
            redirectTo: '/downloading'
        });
    }
}
