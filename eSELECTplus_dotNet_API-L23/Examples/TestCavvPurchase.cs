namespace Moneris
{
    using System;
	using System.Collections;

	public class TestCavvPurchase
	{
	  public static void Main(string[] args)
	  {
	        string host = "esqa.moneris.com";
	        string store_id = "moneris";
	        string api_token = "hurgle";
	        string order_id;      //will prompt for user input;
			string cust_id = "Ladainian_Tomlinson";
	        string amount = "199.00";
	        string card_num = "4242424242424242";
	        string expiry_date = "0911";
	        string cavv = args[0];

		  Console.Write ("Please enter an order ID: ");
		  order_id = Console.ReadLine();

			Hashtable cavvParams = new Hashtable();
			cavvParams.Add("order_id",order_id);
			cavvParams.Add("cust_id",cust_id);
			cavvParams.Add("amount",amount);
			cavvParams.Add("pan",card_num);
			cavvParams.Add("expdate",expiry_date);
			cavvParams.Add("cavv",cavv);

	        CavvPurchase cavvPurchase = new CavvPurchase(cavvParams);
	
	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token,
	                       		  cavvPurchase);
	
	        try
	        {
	            Receipt receipt = mpgReq.GetReceipt();
	
	    		Console.WriteLine("CardType = " + receipt.GetCardType());
	    		Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
	    		Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
	    		Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
	    		Console.WriteLine("TransType = " + receipt.GetTransType());
	    		Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
	    		Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
	    		Console.WriteLine("ISO = " + receipt.GetISO());
	    		Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
	    		Console.WriteLine("Message = " + receipt.GetMessage());
	    		Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
	    		Console.WriteLine("Complete = " + receipt.GetComplete());
	    		Console.WriteLine("TransDate = " + receipt.GetTransDate());
	    		Console.WriteLine("TransTime = " + receipt.GetTransTime());
	    		Console.WriteLine("Ticket = " + receipt.GetTicket());
	    		Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} // end TestDrive Item
}
