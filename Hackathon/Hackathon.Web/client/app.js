(function (angular) {
    angular
        .module('board', ['ui.router'])
        .config(config)
        .run(run);

    config.$inject = ['$stateProvider', '$locationProvider', '$urlRouterProvider'];

    function config($stateProvider, $locationProvider, $urlRouterProvider) {
        $stateProvider
            .state('main', {
                templateUrl: 'client/main/main.html',
                controller: 'MainCtrl as vm'
            });
    }

    run.$inject = ['$state', '$rootScope'];

    function run($state, $rootScope) {
        $state.go('main');

        $rootScope.$on('stateChangeStart',
            function (event, toState, toParams, fromState, fromParams, options) {
            });

        $rootScope.$on('stateChangeError',
            function (event, toState, toParams, fromState, fromParams, error) {

        });
    }

})(window.angular);