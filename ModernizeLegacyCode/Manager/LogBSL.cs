using System;
using System.Diagnostics;
using System.Security.Principal;
using ModernizeLegacyCode.Models;


namespace ModernizeLegacyCode.Manager
{
    public static class LogBsl
    {
        /// <summary>
        /// Insert the DTO representing the Communication record
        /// </summary>
        /// <param name="logDto">CommunicationLogDTO</param>
        public static void InsertLog(LogDTO logDto)
        {
            using (LogRepository repLog = new LogRepository())
                repLog.Insert(logDto);
        }

        /// <summary>
        /// Insert the DTO representing the Communication record in a specific Environment
        /// </summary>
        /// <param name="logDto">CommunicationLogDTO</param>
        /// <param name="environmentId"></param>
        public static void InsertLog(LogDTO logDto, int environmentId)
        {
            using (LogRepository repLog = new LogRepository())
                repLog.InsertForSpecificEnvironmentId(logDto, environmentId);
        }

        /// <summary>
        /// Creates a CommunicationLogDTO object with common parameters set
        /// </summary>
        /// <param name="methodCalled">Configuration name of the RESTlet or description of REST API function</param>        
        /// <returns>CommunicationLogDTO</returns>
        public static LogDTO CreateOutboundLogDto(string methodCalled)
        {
            return CreateOutboundLogDTO(methodCalled, null, false);
        }

        /// <summary>
        /// Creates a CommunicationLogDTO object with common parameters set
        /// </summary>
        /// <param name="methodCalled">Configuration name of the RESTlet or description of REST API function</param>
        /// <param name="json">The JSON object string</param>
        /// <returns>CommunicationLogDTO</returns>
        public static LogDTO CreateOutboundLogDTO(string methodCalled, string json)
        {
            return CreateOutboundLogDTO(methodCalled, json, false);
        }

        /// <summary>
        /// Creates a CommunicationLogDTO object with common parameters set
        /// </summary>
        /// <param name="methodCalled">Configuration name of the RESTlet or description of REST API function</param>
        /// <param name="json">The JSON object string</param>
        /// <param name="is_xCPFileDrop">Identifies if the outbound call is to create an xCP file drop</param>
        /// <returns>CommunicationLogDTO</returns>
        public static LogDTO CreateOutboundLogDTO(string methodCalled, string json, bool is_xCPFileDrop)
        {
            LogDTO logDTO = new LogDTO
            {
                AppName = Process.GetCurrentProcess().ProcessName,
                CreatedByUserID = WindowsIdentity.GetCurrent().Name,
                IsOutbound = true,
                OutboundMethodCalled = methodCalled,
                RequestBody = json,
                RequestType = (is_xCPFileDrop == true ? 2 : 1),
                ServerName = Environment.MachineName
            };

            return logDTO;
        }

        /// <summary>
        /// Creates a CommunicationLogDTO object with common parameters set
        /// </summary>
        /// <param name="methodCalled">Resource requested from outside source</param>
        /// <param name="requestHeaders">Request headers if available</param>
        /// <param name="json">The JSON object string</param>
        /// <returns>CommunicationLogDTO</returns>
        public static LogDTO CreateInboundLogDTO(string requestedResource, string requestHeaders, string json)
        {
            return CreateInboundLogDTO(requestedResource, requestHeaders, json, false);
        }

        /// <summary>
        /// Creates a CommunicationLogDTO object with common parameters set
        /// </summary>
        /// <param name="methodCalled">Resource requested from outside source</param>
        /// <param name="requestHeaders">Request headers if available</param>
        /// <param name="json">The JSON object string</param>
        /// <param name="is_xCPFileDrop">Identifies if the inbound call was from picking up an xCP file drop</param>
        /// <returns>CommunicationLogDTO</returns>
        public static LogDTO CreateInboundLogDTO(string requestedResource, string requestHeaders, string json, bool is_xCPFileDrop)
        {
            LogDTO logDTO = new LogDTO
            {
                AppName = Process.GetCurrentProcess().ProcessName,
                CreatedByUserID = WindowsIdentity.GetCurrent().Name,
                IsOutbound = false,
                RequestedResource = requestedResource,
                RequestBody = json,
                RequestHeaders = (requestHeaders.Length == 0 ? null : requestHeaders),
                RequestType = (is_xCPFileDrop == true ? 2 : 1),
                ServerName = Environment.MachineName
            };

            return logDTO;
        }
    }
}
