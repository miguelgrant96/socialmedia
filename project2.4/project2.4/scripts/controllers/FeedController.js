angular.module('Feed')
    .controller('FeedController', function ($scope, $route, $location, $timeout, UriBuilder, httpRequestService) {
        
        $timeout(function () {
            var url = UriBuilder.BuildUrl("Feed");
            httpRequestService.getRequest(url,function success (response) {
                $scope.Feed = response.data;
            }, function fail (response) {
                console.log("Ging iets fout bij het ophalen van de Feed");
            });
        }, 1000);

        $scope.PostFeed = function ()
        {
            var feedtext = $scope.NewPostText;
            var url = UriBuilder.BuildUrl("Feed");
            httpRequestService.PostRequest(url, null, function success(response) {
                console.log("gelukt");
            }, function fail(response)
            {
                console.log("niet helemaal");
            });
        }

        $scope.redirectFeed = function (e) {
            $location.path("/Feed");
            $location.replace();
        };

        $scope.redirectProfile = function (e) {
            $location.path("/Profile");
            $location.replace();
        };

        $scope.redirectOptions = function (e) {
            $location.path("/Options");
            $location.replace();
        };

        $scope.redirectPrivacy = function (e) {
            $location.path("/Privacy");
            $location.replace();
        };

        $scope.redirectFriends = function (e) {
            $location.path("/Friends");
            $location.replace();
        };

        $scope.redirectLogin = function () {
            $location.path("/");
            $location.replace();
        };
    });
