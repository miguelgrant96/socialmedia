angular.module('Login')
    .controller('LoginController', function ($scope, $route, $location, UriBuilder, AuthorizationService) {
       

        $scope.loginUser = function (e) {
            var username = $scope.username;
            var password = $scope.password;

            $location.path("/Feed");
            $location.replace();

            //TODO server bende.
            AuthorizationService.Authorize(username, password).then((Response) => {
                $location.path("/Feed");
                $location.replace();
            }).catch((Response) => {
                console.log("niet ingelogt");
            });
           
            
        };

        $scope.redirectRegister = function (e) {
            $location.path("/Register");
            $location.replace();
        };
    });