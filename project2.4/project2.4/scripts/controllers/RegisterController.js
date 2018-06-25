angular.module('Register')
    .controller('RegisterController', function ($scope, $route, $location, UriBuilder, httpRequestService, TokenService, AuthorizationService) {

        

        $scope.registerUser = function () {
            var firstName = $scope.firstName;
            var lastName = $scope.lastName;
            var gender = $scope.gender;
            var email = $scope.email; // Check of email al bestaat?
            var birthdate = $scope.dateOfBirth;
            var password = $scope.password;
            var url = UriBuilder.BuildUrl("Account");
            var data = { 'FirstName': firstName, 'LastName': lastName, 'Password': password, 'Gender': gender, 'Email': email, 'BirthDate': birthdate };
            httpRequestService.PostRequest(url, data, function success(response) { 
                AuthorizationService.Authorize(email, password).then((Response) => {
                    TokenService.SetAccessToken(Response.data.access_token);
                    $location.path("/Feed"); //Redirecten naar Options? om direct instellingen aan te passen?
                    $location.replace();
                }).catch((Response) => {
                    console.log("niet ingelogt");
                });

            }, function fail(response) {
                console.log("registratie niet gelukt: ");
                if (response.data != null)
                    console.log(response.data.ExceptionMessage);
            });
        }

        $scope.redirectLogin = function () {
            $location.path("/");
            $location.replace();
        };
    });

