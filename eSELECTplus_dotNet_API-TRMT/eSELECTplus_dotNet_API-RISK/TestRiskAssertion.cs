namespace MonerisRisk
{
    using System;
    using System.Collections;

	public class TestRiskAssertion
	{
	  public static void Main(string[] args)
	  {
		  /******************* REQUEST VARIABLES*******************************/

		  string host = "esqa.moneris.com";
		  string store_id = "moneris";
		  string api_token = "hurgle";

		  /****************** TRANSACTION VARIABLES *****************************/

		  string orig_order_id; 		//will prompt user for input
		  string assert_activities_desc = "charge_back";
		  string assert_impact_desc = "medium";
		  string assert_confidence_desc = "suspicious";

		  Console.Write ("Please enter an order ID: ");
		  orig_order_id = Console.ReadLine(); 

			HttpsPostRequest mpgReq =
	               new HttpsPostRequest(host, store_id, api_token,
	                       new Assert(orig_order_id, assert_activities_desc, assert_impact_desc, assert_confidence_desc));	
	        try
	        {
	            Receipt receipt = mpgReq.GetReceipt();

                Hashtable results = new Hashtable();
	
	    		Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
	    		Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());

                results = receipt.GetResult();

                //Iterate through the response
                IDictionaryEnumerator r = results.GetEnumerator();
                while (r.MoveNext())
                {
                    Console.WriteLine(r.Key.ToString() + " = " + r.Value.ToString());
                }
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} // end TestRiskAssertion
}
