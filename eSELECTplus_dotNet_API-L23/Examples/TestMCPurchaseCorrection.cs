using System;

namespace Moneris
{
	/// <summary>
	/// 
	/// </summary>
	public class TestMCPurchaseCorrection
	{
		public static void Main(string[] args)
		{
			string host = args[0];
			string store_id = args[1];
			string api_token = args[2];
			string order_id = args[3];
			string txn_number = args[4];
			string crypt = args[5];
			try
			{
				L23HttpsPostRequest request=new L23HttpsPostRequest(host, store_id, api_token, 
					new MCPurchaseCorrection(order_id, txn_number, crypt));
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
