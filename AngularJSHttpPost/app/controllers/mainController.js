(function () {
    angular.module('app')
        .controller('mainCtrl', mainController);

    function mainController($scope, $http) {
        $scope.user = { };
        $scope.submit = submit;

        function submit(){

            $http.post("api/Users/User",$scope.user);
        }
    }
}());