using System;

namespace DbEngine.query
{
    /*
	 This class should contain a member variable which is a String array, to hold the headers.
	*/
    public class Header
    {
        public string[] Headers { get; set; }

        //implement constructor and override tostring method


// *****************************************
// THIS IS ADDED CODE

public Header(){

	}

	//Setter method for header
	public void setHeader(string[] header ){
		this.Headers = header;
	}

	//Getter method for header
	public String[] getHeaders()
	{
		return Headers;
	}

// *****************************************
    }
}