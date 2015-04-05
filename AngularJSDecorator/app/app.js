(function () {
    angular.module('myApp', [
        'ngRoute'
    ]).config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            url: "/mainView",
            controller: 'mainCtrl',
            templateUrl: "views/mainView.html"
        }).when('mainView', {
            url: "/mainView",
            controller: 'mainCtrl',
            templateUrl: "views/mainView.html"
        }).otherwise({
            redirectTo: '/mainView'
        });
    }]);
})();



