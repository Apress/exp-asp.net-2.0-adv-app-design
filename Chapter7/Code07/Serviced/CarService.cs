#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

using System.EnterpriseServices;
using System.Data;


namespace ESDemo
{
    // Set the transaction mode to "supported"
    [Transaction(TransactionOption.Supported)]
    public class CarService : ServicedComponent
    {
        public CarService() { }

        // If method raises exception, tx is automatically aborted.
        [AutoComplete(true)]
        public void InsertCar(DataSet carData)
        {
            // Insert the car data into the database
        }
    }

}
