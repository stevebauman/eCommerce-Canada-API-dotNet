using System;

namespace Moneris
{

	public class TestMCCompletion
	{
		public static void Main(string[] args)
		{
			string host = "esqa.moneris.com";
			string store_id = "moneris";
			string api_token = "hurgle";
			string order_id = "PPOPOOLO";
			string amount = "100.00";
			string txn_number = "25972-283-0";
			string crypt = "7";
			try
			{
				L23HttpsPostRequest request=new L23HttpsPostRequest(host, store_id, api_token, 
					new MCCompletion(order_id, amount, txn_number, crypt));
					
				Receipt myReceipt=request.GetReceipt();
				Console.WriteLine("CardType = " + myReceipt.GetCardType());
				Console.WriteLine("TransAmount = " + myReceipt.GetTransAmount());
				Console.WriteLine("TxnNumber = " + myReceipt.GetTxnNumber());
				Console.WriteLine("ReceiptId = " + myReceipt.GetReceiptId());
				Console.WriteLine("TransType = " + myReceipt.GetTransType());
				Console.WriteLine("ReferenceNum = " + myReceipt.GetReferenceNum());
				Console.WriteLine("ResponseCode = " + myReceipt.GetResponseCode());
				Console.WriteLine("ISO = " + myReceipt.GetISO());
				Console.WriteLine("BankTotals = " + myReceipt.GetBankTotals());
				Console.WriteLine("Message = " + myReceipt.GetMessage());
				Console.WriteLine("AuthCode = " + myReceipt.GetAuthCode());
				Console.WriteLine("Complete = " + myReceipt.GetComplete());
				Console.WriteLine("TransDate = " + myReceipt.GetTransDate());
				Console.WriteLine("TransTime = " + myReceipt.GetTransTime());
				Console.WriteLine("Ticket = " + myReceipt.GetTicket());
				Console.WriteLine("TimedOut = " + myReceipt.GetTimedOut());
				Console.WriteLine("CorporateCard = " + myReceipt.GetCorporateCard());
				Console.WriteLine("MessageId = " + myReceipt.GetMessageId());
			}
			catch ( Exception e )
			{
				Console.WriteLine(e);
			}
		}
	}
}
