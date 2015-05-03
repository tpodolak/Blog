(function () {
    angular.module('app.download', ['app.common'])
        .controller('downloadCtrl', downloadController);

    function downloadController($rootScope, $scope) {
        var me = this;
        me.counter = 0;
        $scope.$on('afterRender', onAfterRender);
        $scope.messages = [];
        $scope.handleRenderButtonClick = handleRenderButtonClick;
        $scope.greeting = "Greetings from download controller";
        function onAfterRender() {
            var message = 'Calling afterRender handler and unsubscribing, this handler will not be called again';
            console.log(message);
            $scope.messages.push(message);
            $scope.$un('afterRender', onAfterRender);
        }

        function handleRenderButtonClick() {
            me.counter += 1;
            var message = 'Broadcasting afterRender event - broadcast count ' + '(' + me.counter + ')';
            console.log(message);
            $scope.messages.push(message);
            $rootScope.$broadcast('afterRender');
        }
    }
}());