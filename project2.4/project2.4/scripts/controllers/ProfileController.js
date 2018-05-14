angular.module('Profile')
    .controller('ProfileController', function ($scope, $route, $location) {

        $scope.redirectFeed = function () {
            $location.path("/Feed");
            $location.replace();
        };

    });