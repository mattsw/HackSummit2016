(function (angular) {
    angular.
        module('board').
        service('boardItemService', boardItemService);

    boardItemService.$inject = ['$http'];

    function boardItemService($http) {
        
        var service = {
            getBoardItems: getBoardItems,
            getBoardItemsForUser: getBoardItemsForUser,
            saveBoardItem: saveBoardItem
        };

        function getBoardItems() {
            return  {
                selected: null,
                lists: { 'open': [], 'progress': [], 'blocked': [], 'done': [] }
            };
        }

        function getBoardItemsForUser(userId) {
            return $http.get('api/task/' + userId).then(success, error);

            function success(response) {
                return response;
            }

            function error(response) {
                console.log('Didnt work from server');
            }
        }

        function saveBoardItem(boardItem) {
            $http.put('api/task', boardItem).then(success, error);

            function success(response) {
                return response;
            }

            function error(response) {
                console.log('Unable to save board item.');
            }
        }

        return service;
    }

})(window.angular);