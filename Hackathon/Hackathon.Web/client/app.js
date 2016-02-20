(function (angular) {
    'use strict';

    angular
        .module('board', ['ui.router', 'dndLists'])
        .config(config)
        .run(run);

    config.$inject = ['$stateProvider', '$locationProvider', '$urlRouterProvider'];

    function config($stateProvider, $locationProvider, $urlRouterProvider) {
        $stateProvider
            .state('main', {
                templateUrl: 'client/main/main.html',
                controller: 'MainCtrl as vm',
                resolve: {
                    tasks: ['boardItemService', function(boardItemService) {
                        return boardItemService.getBoardItemsForUser(1);
                    }]
                }
            });
    }

    run.$inject = ['$state', '$rootScope'];

    function run($state, $rootScope) {
        $rootScope.$on('stateChangeStart',
            function (event, toState, toParams, fromState, fromParams, options) {
                console.log(toState.name);
            });

        $rootScope.$on('stateChangeError',
            function (event, toState, toParams, fromState, fromParams, error) {
                console.log(toState.name);
            });

        $state.go('main');
    }

})(window.angular);