angular.module('Login')
    .controller('LoginController', function ($scope, $route, $location) {
       

        $scope.loginUser = function (e) {
            var username = $scope.username;
            var password = $scope.password;

            //TODO server bende.

            $location.path("/Feed");
            $location.replace();
        };

        $scope.redirectRegister = function (e) {
            $location.path("/Register");
            $location.replace();
        };
    });
