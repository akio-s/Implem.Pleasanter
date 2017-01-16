﻿using Implem.Pleasanter.Libraries.Settings;
namespace Implem.Pleasanter.Libraries.Migrators
{
    public static class Version1_007
    {
        public static void Migrate1_007(this Settings.SiteSettings ss)
        {
            ss.Columns = ss.ColumnCollection;
            ss.ColumnCollection = null;
            ss.Aggregations = ss.AggregationCollection;
            ss.AggregationCollection = null;
            ss.Links = ss.LinkCollection;
            ss.LinkCollection = null;
            ss.Summaries = (SettingList<Summary>)ss.SummaryCollection;
            ss.SummaryCollection = null;
            ss.Migrated = true;
        }
    }
}