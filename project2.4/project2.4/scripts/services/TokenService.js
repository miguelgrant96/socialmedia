angular
    .module('Token')
    .factory('TokenService', TokenService)

function TokenService()
{
    var AccessToken = "";

    function SetAccessToken(Token)
    {
        this.AccessToken = Token;
    }

    function GetAccessToken()
    {
        return this.AccessToken;
    }

    return {
        SetAccessToken,
        GetAccessToken,
    };
}

