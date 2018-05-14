var app = angular.module('doeIets', ['ngRoute', 'Login']);


app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            //Login
            templateUrl: 'views/Login/Login.html',
            controller: 'LoginController',
        })
        .otherwise({
            //Login
            redirectTo: '/'
        });
}]);