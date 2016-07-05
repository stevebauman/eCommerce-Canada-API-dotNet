namespace Moneris
{
    using System;
	public class TestIndependentRefund
	{
	  public static void Main(string[] args)
	  {
	        string host = "esqa.moneris.com";
	        string store_id = "moneris";
	        string api_token = "hurgle";
	        string order_id = "ZZZ_004";
		    string cust_id = "Prime_Time_Deion_Sanders_21";
	        string amount = "98.00";
	        string card = "373599005095005";
	        string exp = "1211";
	        string crypt = "7";
	
	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token,
	                       new IndependentRefund(order_id, cust_id, amount, card, exp, crypt));
	
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
