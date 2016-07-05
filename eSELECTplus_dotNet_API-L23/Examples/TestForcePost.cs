using System;

namespace Moneris
{
	/// <summary>
	/// 
	/// </summary>
	public class TestForcePost
	{
		public static void Main(string[] args)
		{
			string host = "esqa.moneris.com";
			string cust_id= "Chris_Higgins_21";
			string store_id = "moneris";
			string api_token = "hurgle";
			string order_id = "ZZZ_003";
			string amount = "59.00";
			string pan = "4242424242424242";
			string expdate = "0910";
			string auth_code = "88864";
			string crypt = "7";
	
			HttpsPostRequest mpgReq =
				new HttpsPostRequest(host, store_id, api_token,
				new ForcePost(order_id, cust_id, amount, pan, expdate, auth_code, crypt));
	
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
	}
}
