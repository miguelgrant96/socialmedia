angular.module('Register')
    .controller('RegisterController', function ($scope, $route, $location) {

        $scope.redirectLogin = function () {
            $location.path("/");
            $location.replace();
        };
    });