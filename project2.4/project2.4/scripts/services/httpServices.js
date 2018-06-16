angular
    .module('httpRequests')
    .factory('AuthorizationService', AuthorizationService)
    .factory('httpRequestService', httpRequestService)
    .factory('UriBuilder', UriBuilder)
    .factory('AuthenticationService', AuthenticationService);

function UriBuilder(SettingService) {

    function BuildUrl(Controller, DataObj = {}) {
        var Url = SettingService.getConStr() + "/api/" + Controller;

        if (Object.keys(DataObj).length > 0) {
            Url += "?";

            for (var i in DataObj) {
                Url += i + "=" + DataObj[i] + "&";

            }
        }
        return Url;
    }

    return {
        BuildUrl,
    };
}

function httpRequestService($http, TokenService, AuthenticationService, SettingService) {

    function getRequest2(url) {
        return new Promise((resolve, reject) => {

            var config = {
                method: 'GET',
                url: url,
                timeout: 15000,
                async: false,
            };

            doRequest(config, resolve, reject, 1);

        });
    };

    function getRequest(url, SuccessCallback, errorCallback) {
        var config = {
            method: 'GET',
            url: url,
            timeout: 15000,
            async: false,
        };

        doRequest(config, SuccessCallback, errorCallback, 1);
    }

    function PostRequest(url, data, SuccessCallback, errorCallback) {
        var config = {
            method: 'POST',
            url: url,
            data: data,
            timeout: 15000,
            async: false,
        };

        doRequest(config, SuccessCallback, errorCallback, 1);
    }

    function PostRequest2(url, data) {
        return new Promise((resolve, reject) => {
            var config = {
                method: 'POST',
                url: url,
                data: data,
                timeout: 15000,
                async: false,
            };

            doRequest(config, resolve, reject, 1);
        });
    }

    function PutRequest(url, data, SuccessCallback, errorCallback) {
        var config = {
            method: 'PUT',
            url: url,
            data: data,
            timeout: 15000,
            async: false,
        };

        doRequest(config, SuccessCallback, errorCallback, 1);
    }

    function PutRequest2(url, data) {
        return new Promise((resolve, reject) => {

            var config = {
                method: 'PUT',
                url: url,
                data: data,
                timeout: 15000,
                async: false,
            };

            doRequest(config, resolve, reject, 1);
        });
    }

    function doRefresh(error) {
        AuthenticationService.Refresh(SettingService.getConStr() + "/token",
            function success(response) {
                TokenService.setToken(response.data);
            }, function failure(response) {
                error();
            });
    }

    function doRequest(request, resolve, reject, attempt) {
        $http(request)
            .then((response) => {
                resolve(response);
            })
            .catch((response) => {
                if (response.status == 401) {
                    doRefresh(reject)
                }

                if (attempt < 3) {
                    console.log(attempt);
                    setTimeout(function () {
                        doRequest(request, resolve, reject, attempt + 1);
                    }, 2000);
                } else {
                    reject(response);
                }

            });
    }


    return {
        getRequest,
        getRequest2,
        PostRequest,
        PostRequest2,
        PutRequest,
        PutRequest2,
    };
};

function AuthorizationService($http) {

    function Authorize(url, username, password) {
        var data = "username=" + username + "&password=" + password + "&client_id=ECApp&grant_type=password&client_secret=";
        var req = {
            method: 'POST',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            url: url,
            data: data,
            timeout: 15000,
        };

        return $http(req);
    }
    return {
        Authorize,
    };
};

function AuthenticationService($http, TokenService) {

    function Authenticate(url, username, password, callback) {

        var data = { "User": username, "Pwd": password };
        var req = {
            method: 'POST',
            headers: { 'Authorization': 'Bearer ' + TokenService.Token.getAccessToken() },
            url: url,
            data: data,
            timeout: 6000,
        };

        $http(req)
            .then(function (response) {
                callback(response);

            })
            .catch(function (response) {
                callback(response);
            })
    };

    function Refresh(url, success, failure) {

        var data = "client_id=ECApp&grant_type=refresh_token&client_secret=&refresh_token=" + TokenService.Token.getRefreshToken();
        var req = {
            method: 'POST',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            url: url,
            data: data,
            async: false,
        };

        $http(req)
            .then(function (response) {
                success(response);

            })
            .catch(function (response) {
                failure(response);
            })
    }

    return {
        Refresh,
        Authenticate,
    };
};