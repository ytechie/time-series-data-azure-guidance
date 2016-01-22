# Guidance for storing time series data in Azure

The goal of this project is to assess basic ways of storing time series data in Azure.

## Should I be using an existing solution?

There are a number of companies that specialize in cloud-based time series data historians. For projects with extremely large storage requirements, high-performance needs, or advanced features such as model-based compression or interpolation, it's advisable to look at the existing products on the market.

These third-party solutions may be much easier to implement versus creating an in-house solution.

## High-Level Comparison of Popular Storage Approaches

These are currently untested.

Click on a storage solution header for details.

<table>
    <tr>
        <th></th>
        <th><a href="storage/sql-database/sql-database.md">SQL Database</a></th>
        <th>Blob Storage</th>
        <th>HBase</th>
        <th>Azure Data Lake</th>
        <th>OpenTSDB</th>
    </tr>
    <tr>
        <td>Writes</td>
        <td>Excellent</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>Random Access Reads</td>
        <td>Excellent</td>
        <td>Poor</td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>Batch Reads</td>
        <td>Excellent</td>
        <td>Good</td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>Aggregation</td>
        <td>Good (TSQL)</td>
        <td>Poor</td>
        <td></td>
        <td>Good</td>
        <td></td>
    </tr>
    <tr>
        <td>Storage Efficiency</td>
        <td>Excellent</td>
        <td>Excellent</td>
        <td></td>
        <td>Poor</td>
        <td></td>
    </tr>
    <tr>
        <td>Cost</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>Interpolation</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>Interoperability</td>
        <td>Excellent</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
</table>

## Storage Solutions Not Tested

* DocumentDB
