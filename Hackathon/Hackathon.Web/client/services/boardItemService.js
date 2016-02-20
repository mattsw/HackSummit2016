(function (angular) {
    angular.
        module('board').
        service('boardItemService', boardItemService);

    boardItemService.$inject = ['$http'];

    function boardItemService($http) {
        
        var service = { getBoardItems: getBoardItems };

        function getBoardItems() {
            return  {
                selected: null,
                lists: { 'open': [], 'progress': [], 'blocked': [], 'done': [] }
            };
        }

        return service;
    }

})(window.angular);