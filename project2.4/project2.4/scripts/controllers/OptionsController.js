
angular.module('Options')
    .controller('OptionsController', function ($scope, $route, $location, UriBuilder, httpRequestService) {

        var url = UriBuilder.BuildUrl("ProfileInfo", { 'id': null });
        httpRequestService.getRequest(url, function success(response) {
            $scope.ProfileInfo = response.data;
        }, function fail(response) {
            console.log("Ging iets fout bij het ophalen van het profiel account");
        });

        $scope.UpdateProfile = function () {
            var id = $scope.ProfileInfo.Id;
            var firstName = $scope.firstName;
            var lastName = $scope.lastName;
            var gender = $scope.gender;
            var birthdate = $scope.dateOfBirth;
            var Work = $scope.Work;
            var School = $scope.School;
            var Hometown = $scope.Hometown;
            var Relation = $scope.Relation;
            var Hobby = $scope.Hobby;
            var ProfilePicUrl = $scope.ProfileInfo.ProfilePictureUrl;
            var url = UriBuilder.BuildUrl("ProfileInfo");
            var data = { 'Id': id, 'FirstName': firstName, 'LastName': lastName, 'Gender': gender, 'Email': null, 'BirthDate': birthdate, 'Work': Work, 'School': School, 'Hometown': Hometown, 'Relation': Relation, 'Hobby': Hobby, 'ProfilePictureUrl': ProfilePicUrl };
            httpRequestService.PostRequest(url, data, function success(response) {
                
            }, function fail(response) {
                    console.log("niet helemaal");
            });

        };


        // Redirects
        $scope.Persoonlijk = true;
        $scope.Beveiliging = false;
        $scope.Privacy = false;
        $scope.Meldingen = false;
        $scope.About = false;

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
            $scope.About = false;
        }

        $scope.showBeveiliging = function () {
            $scope.Persoonlijk = false;
            $scope.Beveiliging = true;
            $scope.Privacy = false;
            $scope.Meldingen = false;
            $scope.About = false;
        }

        $scope.showPrivacy = function () {
            $scope.Persoonlijk = false;
            $scope.Beveiliging = false;
            $scope.Privacy = true;
            angular.element(document.querySelector(".menuItem")).css("height", "100px");
            $scope.Meldingen = false;
            $scope.About = false;
        }

        $scope.showMeldingen = function () {
            $scope.Persoonlijk = false;
            $scope.Beveiliging = false;
            $scope.Privacy = false;
            $scope.Meldingen = true;
            $scope.About = false;
        }


        $scope.showAbout = function () {
            $scope.Persoonlijk = false;
            $scope.Beveiliging = false;
            $scope.Privacy = false;
            $scope.Meldingen = false;
            $scope.About = true;
        }
    });