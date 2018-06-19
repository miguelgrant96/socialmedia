angular
    .module('httpRequests')
    .factory('AuthorizationService', AuthorizationService)
    .factory('httpRequestService', httpRequestService)
    .factory('UriBuilder', UriBuilder)

function UriBuilder() {

    function BuildUrl(Controller, DataObj = {}) {
        var Url = "http://localhost:50263/" + "/api/" + Controller;

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

function httpRequestService($http, TokenService) {


    function getRequest(url, SuccessCallback, errorCallback) {
        var config = {
            method: 'GET',
            url: url,
            headers: { 'Authorization': 'Bearer ' + TokenService.GetAccessToken() },
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
            headers: { 'Authorization': 'Bearer ' + TokenService.GetAccessToken()},
            timeout: 15000,
            async: false,
        };

        doRequest(config, SuccessCallback, errorCallback, 1);
    }

    function PutRequest(url, data, SuccessCallback, errorCallback) {
        var config = {
            method: 'PUT',
            url: url,
            data: data,
            headers: { 'Authorization': 'Bearer ' + TokenService.GetAccessToken() },
            timeout: 15000,
            async: false,
        };

        doRequest(config, SuccessCallback, errorCallback, 1);
    }

    function doRequest(request, resolve, reject, attempt) {
        $http(request)
            .then((response) => {
                resolve(response);
            })
            .catch((response) => {
                reject(response);
            });
    }


    return {
        getRequest,
        PostRequest,
        PutRequest,
    };
};

function AuthorizationService($http) {

    function Authorize(username, password) {
        var url = "http://localhost:50263/" + "/token";
        var data = "username=" + username + "&password=" + password + "&client_id=WebSite&grant_type=password&client_secret=4E939AE2-A552-4FD3-84B4-B54ECB7A02AB";
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

