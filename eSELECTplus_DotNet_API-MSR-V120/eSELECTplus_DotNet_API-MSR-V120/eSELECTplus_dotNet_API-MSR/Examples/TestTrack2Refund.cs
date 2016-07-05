namespace MSRMoneris
{
    using System;
	public class TestTrack2Refund
	{
	  public static void Main(string[] args)
	  {
		//Request Variables
		string host = "esqa.moneris.com";
		string store_id = "store2";
		string api_token = "yesguy";

		//Transaction Variables
            	string order_id;            
            	string txn_number;
		string amount = "5.00";

		Console.Write ("Please input the order ID: ");
		order_id = Console.ReadLine();

	        Console.Write ("Please input the txn number: ");
		txn_number = Console.ReadLine();
          
		//Request Object
	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token,
	                       new Track2Refund(order_id, amount, txn_number));
	
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
				
	} // end TestTrack2Refund
}
