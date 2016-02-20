(function (angular) {
    angular.
        module('board').
        controller('MainCtrl', mainCtrl);

    mainCtrl.$inject = ['$state', 'boardItemService', 'tasks'];

    function mainCtrl($state, boardItemService, tasks) {
        var vm = this;

        vm.model = tasks.data;
        //vm.model = boardItemService.getBoardItemsForUser(2);

        vm.updateItemStatus = updateItemStatus;

        function updateItemStatus(item, status) {
            item.status = status;
        }
    }

})(window.angular);