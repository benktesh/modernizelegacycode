﻿using System;
using System.Collections.Generic;
using System.Globalization;
using ModernizeLegacyCode.Models;
using Newtonsoft.Json;

namespace ModernizeLegacyCode.Manager
{
    internal class Manager
    {
        public string GetResultList(RequestData request, DateTime requestDateTime)
        {
            string jsonData = string.Empty;
            string jsonRequestData = string.Empty;
            DateTime requestStart = DateTime.Now;

            try
            {
                jsonRequestData = JsonConvert.SerializeObject(request);

                List<ResultDto> resultsDto;
                using (ResultsRepository resultRepository = new ResultsRepository()) //dependency in repositiry
                {
                    resultsDto = resultRepository
                        .GetResults(request.AccountNumber, request.BaseName, request.IsCard);
                }

                List<Result> resultList = new List<Result>();
                foreach (ResultDto resultDto in resultsDto)
                {
                    Result result = new Result();
                    result.Id = resultDto.Id;
                    result.Description = resultDto.Description;
                    result.UpdatedDate = resultDto.UpdatedDate.ToString(CultureInfo.InvariantCulture);
                    result.UpdatedBy = resultDto.UpdatedBy;
                    result.BaseName = resultDto.BaseName;
                    result.Cards = null;  
                    result.Groups = null;  
                    if (request.IsCard)
                    {
                        result.Cards = resultDto.Cards; 
                        result.Groups = resultDto.Groups; 
                        result.Passed = resultDto.Passed;
                        result.ValidationError = resultDto.ValidationError;
                    }

                    resultList.Add(result);
                }
                jsonData = JsonConvert.SerializeObject(resultList);

            }
            catch (Exception ex)
            {
                Logger.LogCustomError(ex.ToString(), LogInformation.LogFilePath);
                jsonData = "Exception occured. Kindly contact our support.";

            }
            finally
            {
                LogCommunication(jsonRequestData, requestStart, jsonData); 
            }
            return jsonData;
        }

        public void LogCommunication(string jsonRequestData, DateTime requestStart, string jsonData)
        {

            LogDTO logDto = new LogDTO();
            logDto.AppName = "AppName";
            logDto.CreatedByUserID = Environment.UserName;
            logDto.HTTPStatusCode = null;
            logDto.IsOutbound = false;
            logDto.OutboundEndpointURL = null;
            logDto.OutboundMethodCalled = null;
            logDto.RequestBody = jsonRequestData;
            logDto.RequestedResource = "GetResultList";
            logDto.RequestEndTime = DateTime.Now;
            logDto.RequestHeaders = null;
            logDto.RequestStartTime = requestStart;
            logDto.DurationOfCall = logDto.RequestEndTime.Subtract(logDto.RequestStartTime).Milliseconds;
            logDto.RequestType = 1;
            logDto.Response = jsonData;
            logDto.ServerName = Environment.MachineName;
            LogBsl.InsertLog(logDto); //dependency on LogBSL
        }
    }
}