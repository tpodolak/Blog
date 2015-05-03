(function () {
    angular.module('app', [
        'ngRoute'
    ]).config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/main', {
            url: "/main",
            controller: 'mainCtrl',
            templateUrl: "app/views/mainView.html"
        }).otherwise({
            redirectTo: '/main'
        });
    }]);
})();


