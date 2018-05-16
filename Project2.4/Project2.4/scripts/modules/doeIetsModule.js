var app = angular.module('doeIets', ['ngRoute', 'Login', 'Register', 'Feed', 'Profile', 'Options', 'Privacy']); //Dut niet als ik hier Options en Privacy bij gooi..


app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            //Login
            templateUrl: 'views/Login/Login.html',
            controller: 'LoginController',
        })
        .when('/Register', {
            //Register
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
            templateUrl: 'views/Application/Profile.html',
            controller: 'ProfileController',
        })
        .when('/Options', {
            //Options
            templateUrl: 'views/Application/Options.html',
            controller: 'OptionsController',
        })
        .when('/Privacy', {
            //Privacy
            templateUrl: 'views/Application/Privacy.html',
            controller: 'PrivacyController',
        })
        .otherwise({
            //Login
            redirectTo: '/'
        });
}]);