(function (angular) {
    angular.
        module('board').
        service('boardItemService', boardItemService);

    boardItemService.$inject = ['$http'];

    function boardItemService($http) {
        
        var service = {
            getBoardItems: getBoardItems,
            getBoardItemsForUser: getBoardItemsForUser
        };

        function getBoardItems() {
            return  {
                selected: null,
                lists: { 'open': [], 'progress': [], 'blocked': [], 'done': [] }
            };
        }

        function getBoardItemsForUser(userId) {
            return $http.get('api/task/' + userId);
        }

        return service;
    }

})(window.angular);