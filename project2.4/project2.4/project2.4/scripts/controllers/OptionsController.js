
angular.module('Options')
    .controller('OptionsController', function ($scope, $route, $location) {
        $scope.Persoonlijk = true;
        $scope.Beveiliging = false;
        $scope.Privacy = false;
        $scope.Meldingen = false;


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


        $scope.showPersoonlijk = function ()
        {
            $scope.Persoonlijk = true;
            $scope.Beveiliging = false;
            $scope.Privacy = false;
            $scope.Meldingen = false;
        }

        $scope.showBeveiliging = function () {
            $scope.Persoonlijk = false;
            $scope.Beveiliging = true;
            $scope.Privacy = false;
            $scope.Meldingen = false;
        }

        $scope.showPrivacy = function () {
            $scope.Persoonlijk = false;
            $scope.Beveiliging = false;
            $scope.Privacy = true;
            $scope.Meldingen = false;
        }

        $scope.showMeldingen = function () {
            $scope.Persoonlijk = false;
            $scope.Beveiliging = false;
            $scope.Privacy = false;
            $scope.Meldingen = true;
        }

    });