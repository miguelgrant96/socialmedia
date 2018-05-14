var app = angular.module('doeIets', ['ngRoute', 'Login', 'Register', 'Feed', 'Profile']);


app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            //Login
            templateUrl: 'views/Login/Login.html',
            controller: 'LoginController',
        })
        .when('/Register', {
            //'Register
            templateUrl: 'views/Login/Register.html',
            controller: 'RegisterController',
        })
        .when('/Feed', {
            //Feed
            templateUrl: 'views/Application/Feed.html',
            controller: 'FeedController',
        })
        .when('/Profile', {
            //Profile
            templateUrl: 'views/Profile/Profile.html',
            controller: 'ProfileController',
        })
        .otherwise({
            //Login
            redirectTo: '/'
        });
}]);