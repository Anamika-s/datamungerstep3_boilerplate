using System;

namespace DbEngine.query
{
    /*
	 This class should contain a member variable which is a String array, to hold
	 the data type for all columns for all data types
	*/
    public class DataTypeDefinitions
    {
        public string[] DataTypes { get; set; }

        //implement constructor and override tostring method


// *****************************************
// THIS IS ADDED CODE


	 

	public DataTypeDefinitions(){

	}

	//Setter method for Columns
	public void setColumns(String[] columns){
		this.DataTypes = columns;
	}

	//Getter method for DataTypes
	public String[] getDataTypes() {
		return DataTypes;
	}
// *****************************************

    }
}