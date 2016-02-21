(function (angular) {
    angular.
        module('board').
        service('boardItemService', boardItemService);

    boardItemService.$inject = ['$http'];

    function boardItemService($http) {
        
        var service = {
            getBoardItems: getBoardItems,
            getBoardItemsForUser: getBoardItemsForUser,
            saveBoardItem: saveBoardItem,
            saveBoardItems: saveBoardItems
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
            return $http.put('api/task', boardItem).then(success, error);

            function success(response) {
                return response;
            }

            function error(response) {
                console.log('Unable to save board item.');
            }
        }

        function saveBoardItems(items) {
            return $http.post('api/task', items).then(success, error);

            function success(response) {
                console.log('great success');
            }

            function error(response) {
                
            }
        }

        return service;
    }

})(window.angular);