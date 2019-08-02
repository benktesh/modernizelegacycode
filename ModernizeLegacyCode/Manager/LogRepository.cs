using System;
using ModernizeLegacyCode.Models;


namespace ModernizeLegacyCode.Manager
{
    public class LogRepository : IDisposable
    {
        public void Insert(LogDTO logDto)
        {
            //insert into db
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            //insert into db
            //throw new NotImplementedException();
        }

        public void InsertForSpecificEnvironmentId(LogDTO logDto, int specificNetSuiteEnvironmentId)
        {
            //insert for specific environment
            //throw new NotImplementedException();
        }
    }
}