angular.module('Profile')
    .controller('ProfileController', function ($scope, $route, $location, $timeout, UriBuilder, httpRequestService) {
        
        
        //Getting ProfileInfo and Feed 
        var url = UriBuilder.BuildUrl("ProfileInfo", { 'id': null });
        httpRequestService.getRequest(url, function success(response) {
            $scope.ProfileInfo = response.data;
            var url = UriBuilder.BuildUrl("Feed", { 'id': $scope.ProfileInfo.Id });
            httpRequestService.getRequest(url, function success(response) {
                $scope.Feed = response.data;
            }, function fail(response) {
                console.log("Ging iets fout bij het ophalen van de Feed");
            });
        }, function fail(response) {
            console.log("Ging iets fout bij het ophalen van het Profile");
        });
        

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

        $scope.changeView = function (val) {
            if (val == 'posts') {
                $scope.content = "Show all the posts";

                $scope.showPosts = true;
                $scope.showMedia = false;
                $scope.showNotities = false;
                $scope.showOverMij = false;
            } else if (val == 'media') {
                $scope.content = "Show all the media";

                $scope.showPosts = false;
                $scope.showMedia = true;
                $scope.showNotities = false;
                $scope.showOverMij = false;
            } else if (val == 'notities') {
                $scope.content = "Show all the notes";

                $scope.showPosts = false;
                $scope.showMedia = false;
                $scope.showNotities = true;
                $scope.showOverMij = false;
            } else if (val == 'over mij') {
                $scope.content = "Show the over mij page";

                $scope.showPosts = false;
                $scope.showMedia = false;
                $scope.showNotities = false;
                $scope.showOverMij = true;
            }

        }
    });
