using System;

namespace ModernizeLegacyCode.Models
{
    public class LogDTO
    {
        public string OutboundMethodCalled { get; set; }
        public string OutboundEndpointURL { get; set; }
        public string Response { get; set; }
        public string RequestedResource { get; set; }
        public string RequestHeaders { get; set; }
        public string RequestBody { get; set; }
        public int? RequestType { get; set; }
        public bool IsOutbound { get; set; }
        public int? HTTPStatusCode { get; set; }
        public double DurationOfCall { get; set; }
        public DateTime RequestEndTime { get; set; }
        public DateTime RequestStartTime { get; set; }
        public string CreatedByUserID { get; set; }
        public string AppName { get; set; }
        public Guid CommunicationID { get; set; }
        public string ServerName { get; set; }
        public int NetSuiteEnvironmentID { get; set; }
    }
}