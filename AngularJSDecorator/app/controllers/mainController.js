(function () {
    angular.module('myApp')
        .controller('mainCtrl', mainCtrl);

    mainCtrl.$inject = ['$scope']
    function mainCtrl($scope) {
        $scope.greeting = "Hello from main controller";
    }
})();