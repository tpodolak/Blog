(function () {
    angular.module('app', [
        'ngRoute',
        'app.common',
        'app.download'
    ]).config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/downloading', {
            url: "/downloading",
            controller: 'downloadCtrl',
            templateUrl: "views/downloadView.html"
        }).otherwise({
            redirectTo: '/downloading'
        });
    }]);
})();


