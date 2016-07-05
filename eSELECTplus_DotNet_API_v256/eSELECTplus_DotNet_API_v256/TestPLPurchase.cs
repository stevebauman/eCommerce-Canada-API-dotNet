namespace Moneris
{
    using System;
	public class TestPLPurchase
	{
	  public static void Main(string[] args)
	  {
	        string host = "esqa.moneris.com";
	        string store_id = "store2";
	        string api_token = "yesguy";
	        //Generate Random OrderId
            System.Random RandNum = new System.Random();
            int randNum = RandNum.Next();
            string order_id = "order_" + randNum;
	        string amount = "5.00";
	        string card = "4242424242424242";
	        string exp = "0911";
	        string crypt = "7";
	
            PLPurchase plp = new Moneris.PLPurchase(order_id, amount, card, exp, crypt);

            plp.SetPromoCode("12345");

	        Moneris.HttpsPostRequest mpgReq = new Moneris.HttpsPostRequest(host, store_id, api_token, plp);
	
	        try
	        {
	            Moneris.Receipt receipt = mpgReq.GetReceipt();
	
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
				
	} // end TestPLPurchase
}
