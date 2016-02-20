(function (angular) {
    angular.
        module('board').
        controller('MainCtrl', mainCtrl);

    mainCtrl.$inject = ['$state', 'boardItemService'];

    function mainCtrl($state, boardItemService) {
        var vm = this;

        vm.model = boardItemService.getBoardItems();
        //vm.model = boardItemService.getBoardItemsForUser(2);


        vm.updateItemStatus = updateItemStatus;

        function updateItemStatus(item, status) {
            item.status = status;
        }
    }

})(window.angular);