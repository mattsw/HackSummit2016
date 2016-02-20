(function (angular) {
    angular.
        module('board').
        controller('MainCtrl', mainCtrl);

    mainCtrl.$inject = ['$state'];

    function mainCtrl($state) {
        var vm = this;
    }

})(window.angular);