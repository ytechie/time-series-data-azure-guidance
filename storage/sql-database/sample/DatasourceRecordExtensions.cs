using System;
using System.IO;
using System.Text;

namespace sql_database_sample
{
    public static class DatasourceRecordExtensions
    {
        public static decimal GetDecimalValue(this DatasourceRecord record)
        {
            ThrowExceptionOnInvalidConversion(record.DataType, DatasourceRecord.DataTypeEnum.Decimal);

            using (var memoryStream = new MemoryStream(record.Value))
            {
                using (var binaryReader = new BinaryReader(memoryStream))
                {
                    return binaryReader.ReadDecimal();
                }
            }
        }

        public static void SetDecimalValue(this DatasourceRecord record, decimal value)
        {
            ThrowExceptionOnInvalidConversion(record.DataType, DatasourceRecord.DataTypeEnum.Decimal);

            using (var memoryStream = new MemoryStream())
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write(value);
                    record.Value = memoryStream.ToArray();
                }
            }
            record.DataType = DatasourceRecord.DataTypeEnum.Decimal;
        }

        public static int GetIntValue(this DatasourceRecord record)
        {
            ThrowExceptionOnInvalidConversion(record.DataType, DatasourceRecord.DataTypeEnum.Integer);

            return BitConverter.ToInt32(record.Value, 0);
        }

        public static void SetIntValue(this DatasourceRecord record, int value)
        {
            ThrowExceptionOnInvalidConversion(record.DataType, DatasourceRecord.DataTypeEnum.Integer);

            record.Value = BitConverter.GetBytes(value);
            record.DataType = DatasourceRecord.DataTypeEnum.Integer;
        }

        public static double GetDoubleValue(this DatasourceRecord record)
        {
            ThrowExceptionOnInvalidConversion(record.DataType, DatasourceRecord.DataTypeEnum.Double);

            return BitConverter.ToDouble(record.Value, 0);
        }

        public static void SetDoubleValue(this DatasourceRecord record, double value)
        {
            ThrowExceptionOnInvalidConversion(record.DataType, DatasourceRecord.DataTypeEnum.Double);

            record.Value = BitConverter.GetBytes(value);
            record.DataType = DatasourceRecord.DataTypeEnum.Double;
        }

        public static string GetStringValue(this DatasourceRecord record)
        {
            ThrowExceptionOnInvalidConversion(record.DataType, DatasourceRecord.DataTypeEnum.String);

            return Encoding.UTF8.GetString(record.Value);
        }

        public static void SetStringValue(this DatasourceRecord record, string value)
        {
            ThrowExceptionOnInvalidConversion(record.DataType, DatasourceRecord.DataTypeEnum.String);

            record.Value = Encoding.UTF8.GetBytes(value);
            record.DataType = DatasourceRecord.DataTypeEnum.String;
        }

        private static void ThrowExceptionOnInvalidConversion(DatasourceRecord.DataTypeEnum from,
    DatasourceRecord.DataTypeEnum to)
        {
            if (!(from == DatasourceRecord.DataTypeEnum.Undefined || from == to))
                throw new NotSupportedException();
        }
    }
}