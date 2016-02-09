using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_database_sample
{
    class DbDataReaderSimulator : DbDataReader
    {
        private DatasourceRecord _currentRecord;
        private int _datasourceId;
        private DatasourceRecord.DataTypeEnum _dataType;
        private Random _random;

        private List<string> _fields = new List<string> { "Timestamp", "DatasourceId", "Value" };
        

        public DbDataReaderSimulator(int datasourceId, DatasourceRecord.DataTypeEnum dataType)
        {
            _datasourceId = datasourceId;
            _dataType = dataType;

            _random = new Random();
        }

        public override object this[string name]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override object this[int ordinal]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int Depth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int FieldCount
        {
            get
            {
                return _fields.Count;
            }
        }

        public override bool HasRows
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsClosed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int RecordsAffected
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool GetBoolean(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override byte GetByte(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            throw new NotImplementedException();
        }

        public override char GetChar(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            throw new NotImplementedException();
        }

        public override string GetDataTypeName(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetDateTime(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override decimal GetDecimal(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override double GetDouble(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override Type GetFieldType(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override float GetFloat(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override Guid GetGuid(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override short GetInt16(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override int GetInt32(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetInt64(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override string GetName(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        public override string GetString(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override object GetValue(int ordinal)
        {
            if(ordinal == 0)
            {
                return _currentRecord.Timestamp;
            }
            if(ordinal == 1)
            {
                return _currentRecord.DatasourceId;
            }
            if(ordinal == 2)
            {
                return _currentRecord.Value;
            }

            throw new NotSupportedException("Don't support column " + ordinal);
        }

        public override int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public override bool IsDBNull(int ordinal)
        {
            return false;
        }

        public override bool NextResult()
        {
            //noop
            return false;
        }

        public override bool Read()
        {
            _currentRecord = new DatasourceRecord();
            _currentRecord.Timestamp = DateTime.UtcNow;
            _currentRecord.DatasourceId = _datasourceId;
            _currentRecord.DataType = _dataType;

            if(_dataType == DatasourceRecord.DataTypeEnum.Double)
            {
                _currentRecord.SetDoubleValue(_random.NextDouble());
            }
            else
            {
                throw new NotSupportedException("Simulator doesn't support " + _dataType.ToString());
            }

            return true;
        }
    }
}
