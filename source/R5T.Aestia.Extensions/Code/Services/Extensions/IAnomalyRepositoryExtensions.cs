﻿using System;
using System.Threading.Tasks;

using R5T.Sindia;
using R5T.Votadinia;


namespace R5T.Aestia.Extensions
{
    public static class IAnomalyRepositoryExtensions
    {
        /// <summary>
        /// Create a new anomaly (identity) and set the reported UTC time to the current UTC time.
        /// </summary>
        public static async Task<AnomalyIdentity> NewSetReportedUTC(this IAnomalyRepository repository, ICurrentUtcDateTimeProvider currentUtcDateTimeProvider)
        {
            var nowUTC = currentUtcDateTimeProvider.GetCurrentUtcDateTime();

            var anomalyIdentity = await repository.New(nowUTC);

            await repository.SetReportedUTC(anomalyIdentity, nowUTC);

            return anomalyIdentity;
        }
    }
}
