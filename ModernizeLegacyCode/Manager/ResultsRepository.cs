﻿using System;
using System.Collections.Generic;
using System.Linq;
using ModernizeLegacyCode.Models;

namespace ModernizeLegacyCode.Manager
{
    internal class ResultsRepository : IDisposable
    {
        private readonly List<ResultDto> _results = new List<ResultDto>
        {
            new ResultDto
            {
                AccountNumber = "1",
                BaseName = "X",
                Cards = null,
                Description = "1-X",
                Groups = null
            },
            new ResultDto
            {
                AccountNumber = "1",
                BaseName = "Y",
                Cards = new List<Card>
                {
                    new Card {BalanceTransferRate = new Rate()},
                    new Card {BalanceTransferRate = new Rate()},
                    new Card {BalanceTransferRate = new Rate()},
                },
                Description = "1-X",
                Groups = new List<CardGroup>
                {
                    new CardGroup(),
                    new CardGroup(),
                }
            },

        };
        
        public List<ResultDto> GetResults(string account, string baseName, bool type)
        {
            //returns data accessing the db
            return _results.Where(p =>
                p.AccountNumber.Equals(account, StringComparison.CurrentCultureIgnoreCase) &&
                p.BaseName.Equals(baseName, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}