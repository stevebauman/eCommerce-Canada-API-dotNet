namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;
    
	public class TestResTempAdd
	{
	  public static void Main(string[] args)
	  {

		string host = "esqa.moneris.com";
        string store_id = "store5";
        string api_token = "yesguy";
        string pan = "5454545454545454";
        string expdate = "0909";
        string crypt_type = "7";
        string duration = "60";

        ResTempAdd resTempAdd = new ResTempAdd(pan, expdate, crypt_type, duration);

        //resTempAdd.SetDataKeyFormat("1"); //1=F6L4 w/ Length preserve, 2=F6L4 w/o Length preserve

        HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, resTempAdd);
	                     
		/**********************   REQUEST  ************************/	                     
	      
	        try
	        {
	            Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("DataKey = " + receipt.GetDataKey());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
                Console.WriteLine("PaymentType = " + receipt.GetPaymentType());

                //ResolveData
                
                Console.WriteLine("MaskedPan = " + receipt.GetResDataMaskedPan());
                Console.WriteLine("Exp Date = " + receipt.GetResDataExpdate());
               
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} // end TestTempResAdd
}
