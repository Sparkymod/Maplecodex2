namespace Maplecodex2.Components.Notification
{
    public static class NotificationCodex
    {
        /// <summary>
        /// Login Messages Repository
        /// </summary>
        public enum LoginCode
        {
            UnknownError = 000,
            Success = 001,
            BadUser = 003,
            BadPass = 004,
            BadUserOrBadPass = 005,
            NotFound = 006,
            SignOut = 007,
            SignOutError = 008,
            NoName = 009,
        }

        /// <summary>
        /// Blazor Page Messages Repository
        /// </summary>
        public enum BlazorCode
        {
            UnknownError = 0000,
        }

        /// <summary>
        /// Web Response Messages Repository
        /// </summary>
        public enum WebErrorCode
        {
            NotModified = 304,
            BadRequest = 400,
            Unauthorized = 401,
            Forbidden = 403,
            NotFound = 404,
            NotAcceptable = 406,
            NotContent = 204,
            PartialContent = 206,
            Timeout = 408,
            Conflict = 409,
            InternalServerError = 500,
            Unknown = 900,
            SoapError = 901
        }
    }
}
