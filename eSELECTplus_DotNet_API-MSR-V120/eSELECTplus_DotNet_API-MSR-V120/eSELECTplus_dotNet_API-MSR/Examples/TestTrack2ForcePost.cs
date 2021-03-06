using System;

namespace MSRMoneris
{
	/// <summary>
	/// 
	/// </summary>
	public class TestForcePost
	{
		public static void Main(string[] args)
		{
			//Request Variables
			string host = "esqa.moneris.com";
			string store_id = "store2";
			string api_token = "yesguy";

			//Transaction Variables
			string order_id;
			string amount = "10.00";
			string track1;
			string track2;
			string pan = null;
			string expiry_date= null;
			string auth_code = "AU4R6";
			string pos_code = "00";
			
			Console.Write ("Please enter an order ID: ");   
			order_id = Console.ReadLine();  

			Console.Write ("Please swipe card\n");   
			track1 = Console.ReadLine();  
			track2 = Console.ReadLine();  
	
			HttpsPostRequest mpgReq =
				new HttpsPostRequest(host, store_id, api_token,
					new Track2ForcePost(order_id, amount, track2, pan, expiry_date, auth_code, pos_code));
	
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
	}
}
