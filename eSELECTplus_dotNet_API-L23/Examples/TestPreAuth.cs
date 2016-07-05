namespace Moneris
{
    using System;
    
	public class TestPreAuth
	{
	  public static void Main(string[] args)
	  {

		string host = "esqa.moneris.com";
		string order_id;		//will prompt user for input
	        string cust_id = "Champ_Bailey_24";
		string store_id = "moneris";
		string api_token = "hurgle";
		string amount = "100.00";
		//string card = "5454545442424242";
        string card = "373269005095005";
		string exp_date = "0812";
		string crypt = "7";
		
		Console.Write ("Please enter an order ID: ");
		order_id = Console.ReadLine();		

	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token,
	                       new PreAuth(order_id, cust_id, amount, card, exp_date, crypt));
	                     
		/**********************   REQUEST  ************************/	                     
	      
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
			Console.WriteLine("CorporateCard = " + receipt.GetCorporateCard());
			Console.WriteLine("MessageId = " + receipt.GetMessageId());
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} // end TestDrive Item
}
