using System;
using System.Linq;

namespace CsvDataGenerator
{
    //copied from https://github.com/ytechie/Manufacturing.Framework

    public class DatasourceRecord
    {
        public int DatasourceId { get; set; }
        public DateTime Timestamp { get; set; }
        public int IntervalSeconds { get; set; } //TODO: make more granular/generic?
        public double Value { get; set; }
        
        public virtual bool Equivalent(DatasourceRecord compare)
        {
            if (compare == null)
                return false;
            if (this == compare)
                return true;

            if (DatasourceId != compare.DatasourceId)
                return false;
            if (Timestamp != compare.Timestamp)
                return false;
            if (IntervalSeconds != compare.IntervalSeconds)
                return false;
            if (Value == compare.Value)
                return false;

            return true;
        }

    }
}
