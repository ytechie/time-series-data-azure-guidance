using System;
using System.Linq;

namespace sql_database_sample
{
    //copied from https://github.com/ytechie/Manufacturing.Framework

    public class DatasourceRecord
    {
        public int DatasourceId { get; set; }
        public DateTime Timestamp { get; set; }
        public int IntervalSeconds { get; set; } //TODO: make more granular/generic?
        public byte[] Value { get; set; }

        public int EncodedDataType
        {
            get
            {
                return (int)DataType;
            }
            set
            {
                DataType = (DataTypeEnum)value;
            }
        }

        public DataTypeEnum DataType { get; set; }

        public enum DataTypeEnum
        {
            Undefined = 0,
            Integer = 1,
            UnsignedFloat = 2,
            Double = 3,
            DateTime = 4,
            String = 5,
            Boolean = 6,
            Decimal = 7
        }

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
            if (Value == null ^ compare.Value == null || (Value != null && !Value.SequenceEqual(compare.Value)))
                return false;
            if (EncodedDataType != compare.EncodedDataType)
                return false;

            return true;
        }

    }
}
