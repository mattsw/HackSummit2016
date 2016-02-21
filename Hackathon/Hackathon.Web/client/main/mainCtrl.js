﻿(function (angular) {
    angular.
        module('board').
        controller('MainCtrl', mainCtrl);

    mainCtrl.$inject = ['$state', 'boardItemService', 'tasks'];

    function mainCtrl($state, boardItemService, tasks) {
        var vm = this;

        vm.model = tasks.data;
        vm.model.selected = null;
        //vm.model = boardItemService.getBoardItemsForUser(2);

        vm.updateItemStatus = updateItemStatus;
        vm.addItem = addItem;

        function updateItemStatus(item, status) {
            item.status = status;
        }

        function addItem(item) {
            boardItemService.saveBoardItem(item).then(success, error);

            function success(response) {
                vm.model.open(item);
            }

            function error(response) {


            }
        }
    }

})(window.angular);