angular.module('Feed')
    .controller('FeedController', function ($scope, $route, $location) {

        $scope.redirectFeed = function () {
            $location.path("Feed");
            $location.replace();
        };

    });