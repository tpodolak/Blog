///<reference path="../../typings/tsd.d.ts" />

module app {
    interface IDownloadScope extends ng.IScope {
        title: string
    }

    class DownloadController {
        static $inject = ['$scope'];

        constructor( $scope: IDownloadScope ) {
            $scope.title = 'New title';
        }
    }
    angular.module('app').controller('downloadCtrl', DownloadController);
}
