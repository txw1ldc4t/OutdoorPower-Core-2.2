using OutdoorPower.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutdoorPower.Models
{
    public class DealerInventory : Inventory
    {
        public DealerInventory()
        {
            Images = new List<DealerInventoryImage>();
        }

        [StringLength(300, ErrorMessage = "A maximum of 300 characters is allowed for title.")]
        public string Title { get; set; }

        public IList<DealerInventoryImage> Images { get; set; }

        [StringLength(1000, ErrorMessage = "A maximum of 1000 characters is allowed for the description.")]
        public string Description { get; set; }

        public Boolean OPTPublic { get; set; }

        public Dealer DealerInfo { get; set; }

        [StringLength(300, ErrorMessage = "A maximum of 300 characters is allowed for warranty.")]
        public string Warranty { get; set; }

        // This field is set via the trigger: TRG_Inventories_Sold 
        // on the OutdoorPowerMetrics..Inventories Table
        public bool? IsSold { get; set; }

        public string ConditionString
        {
            get
            {
                switch (Condition)
                {
                    case 1:
                        return "Excellent";
                    case 2:
                        return "Very Good";
                    case 3:
                        return "Average";
                    case 4:
                        return "Couple of Dents";
                    case 5:
                        return "Needs Repairs";
                }

                return "Not Avaliable";
            }
        }

        public string FuelString
        {
            get
            {
                switch (Fuel)
                {
                    case 1:
                        return "Gas";
                    case 2:
                        return "Diesel";
                    case 3:
                        return "Propane";
                    case 4:
                        return "Gas/Propane";
                    case 5:
                        return "Electric";
                }

                return "Not Avaliable";
            }
        }

        public string YMMString
        {
            get
            {
                string returnString = "Not Available";
                string makeString = "";
                string modelString = "";

                if (Year > 0)
                    returnString = Year.ToString();

                if (!String.IsNullOrEmpty(QInventoryMakeOther))
                {
                    makeString = QInventoryMakeOther;
                }
                else if(Make != null)
                {
                    makeString = Make.Name;
                }

                if (!String.IsNullOrEmpty(makeString)){
                    if (returnString == "Not Available")
                    {
                        returnString = makeString;
                    }
                    else
                    {
                        returnString += " " + makeString;
                    }

                    if (!String.IsNullOrEmpty(QInventoryModelOther))
                    {
                        modelString = QInventoryModelOther;
                    }
                    else if (Model != null)
                    {
                        modelString = Model.Name;
                    }

                    if (!String.IsNullOrEmpty(modelString))
                    {
                        returnString += " " + modelString;

                        if (!String.IsNullOrEmpty(QInventoryModelOptionOther))
                        {
                            returnString += " " + QInventoryModelOptionOther;
                        }
                        else if (ModelOption != null)
                        {
                            returnString += " " + ModelOption.Name;
                        }
                    }
                }

                return returnString;
            }
        }

        public IList<Metrics.Customer> Customers { get; set; }

        public IList<SalesInfoModalViewModel> SalesInfo { get; set; }
    }
}
