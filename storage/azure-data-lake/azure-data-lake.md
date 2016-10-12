# Azure Data Lake for Time Series Data Storage

The Azure Data Lake service consists of 2 parts:

* Azure Data Lake *Store*
* Azure Data Lake *Analytics*

**Important Note:** Performance numbers are only to give a general idea about what performance is possible. They should not be considered official or unofficial benchmarks.

## Storage Efficiency

10,000 records in CSV is 535,430 bytes

Applying Gzip compression results in a file that is 143,427 bytes. This is 26% compression ratio.

A single record, after compression, is 14.3 bytes.

## Cost

Note: Always check the [current Data Lake Pricing](https://azure.microsoft.com/en-us/pricing/details/data-lake-store/).

The cost at the time of this writing is $.08/GB.

Within 1GB, we can store ~75 million records. In other words, we can store around 75 million time series records for about 8 cents per month.