(function (angular) {
    angular.
        module('board').
        controller('MainCtrl', mainCtrl);

    mainCtrl.$inject = ['$state', 'boardItemService'];

    function mainCtrl($state, boardItemService) {
        var vm = this;

        vm.model = boardItemService.getBoardItems();
    }

})(window.angular);