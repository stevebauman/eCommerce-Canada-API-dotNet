using System;

namespace Moneris
{
	/// <summary>
	/// 
	/// </summary>
	public class TestVSIndependentRefund
	{
		public static void Main(string[] args)
		{
			string host = "esqa.moneris.com";
			string store_id = "moneris";
			string api_token = "hurgle";			
			string amount = "10.00";
			string pan= "4242424254545454";
			string expDate= "1111";
			string crypt = "7";

			string order_id;

			Console.Write ("Please enter an order ID: ");
			order_id = Console.ReadLine();	

			string orderLevelGst = "0.00";	
			string merchantGstNo = "234543345959";
			string orderLevelPst = "0.00";
			string merchantPstNo = "99884300000399";			
			string cri = "CUST_CBENSON";

			try
			{
				L23HttpsPostRequest request=new L23HttpsPostRequest(host, store_id, api_token, 
					new VSIndependentRefund(order_id, amount, pan,expDate, crypt, orderLevelGst, merchantGstNo, 
					                        cri, orderLevelPst, merchantPstNo));
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
