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

        function getBoardItems(userId) {
            return $http.get('api/task/' + userId);
        }

        return service;
    }

})(window.angular);