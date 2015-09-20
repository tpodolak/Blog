( function( ) {

    angular.module('app').controller('mainCtrl', mainController);

    mainController.$inject = ['$scope'];

    function mainController( $scope ) {
        $scope.content = "Main controller content";
    };

}() );