using System;
namespace DMedics.Services.Constants
{
    public class StatusCodes
    {
        public const string Successful = "SA00";
        public const string GeneralError = "S06";
        public const string ModelValidationError = "S09";
        public const string EndpointTimeoutException = "S19";
        public const string CacheDataRetrievalError = "S29";
        public const string SQLException = "SA39";
        public const string SQLTimeoutException = "S38";
        public const string NoRecordFound = "S37";
        public const string RecordExist = "S31";
        public const string FatalError = "S99";
    }
}
