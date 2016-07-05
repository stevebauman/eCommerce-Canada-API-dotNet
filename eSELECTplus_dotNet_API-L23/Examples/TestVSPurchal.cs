using System;

namespace Moneris
{

   public class TestVSPurchal
   {
	public static void Main(string[] args)
	{
	   string host = "esqa.moneris.com";
	   string store_id = "moneris";
	   string api_token = "hurgle";
	   string order_id;
	   string txn_number;

	   Console.Write ("Please enter an order ID: ");
	   order_id = Console.ReadLine();		

	   Console.Write ("Please enter a txn number: ");
	   txn_number = Console.ReadLine();	
	   
	   try
	   {
	   
	   	/************************** Level 2 Addendum ********************************/
	   	
	   	String dutyAmount = "1.00";
	   	String shipToPosCode = "M8X 2W8";
	   	String shipFromPosCode = "M1K 2Y7";
	   	String desCouCode = "Canada";
	   	String vatRefNum = "VAT12345";
	   	String vatTaxAmtFreShip = "0.21";
	   	String vatTaxRateFreShip = "7.00";   	
	   
        	VSPurcha data2 = 
        		new VSPurcha(dutyAmount, shipToPosCode, shipFromPosCode, desCouCode, vatRefNum, vatTaxAmtFreShip, vatTaxRateFreShip);

		/************************** Level 3 Addendum ********************************/

		string[] itemComCode = new string[3]{"CC01", null, null};
		string[] productCode = new string[3]{null, "VP02", "HHGGR"};
		string[] itemDescription = new string[3]{"CC01 descr", "VP02 descr", "Freight/Shipping"};
		string[] itemQuantity = new string[3]{"1", "2", "1"};
		string[] itemUom = new string[3]{"EA", "EA", "EA"};
		string[] unitCost = new string[3]{"0.00.", "0.00", "0.00"};
		string[] vatTaxAmt = new string[3]{"0", "0", "0.21"};
		string[] vatTaxRate = new string[3]{"0", "0", "7.00"};
		string[] discountAmt = new string[3]{"0", "0", "0"};
		
		// Every order has one or more VSPurchl, which can be also called Line Item
		// If the order has a Freight/Shipping line item, the productCode value has to be Freight/Shipping
		// If the order has a Discount line item, the productCode value has to be Discount. 
		// And discountAmt has to be a great than 0 value
		
		VSPurchl[] data3 = new VSPurchl[3];

		data3[0] = new VSPurchl(itemComCode[0], productCode[0], itemDescription[0], itemQuantity[0], 
				      itemUom[0], unitCost[0], vatTaxAmt[0], vatTaxRate[0], discountAmt[0]);

		data3[1] = new VSPurchl(itemComCode[1], productCode[1], itemDescription[1], itemQuantity[1], 
				      itemUom[1], unitCost[1], vatTaxAmt[1], vatTaxRate[1], discountAmt[1]);

		data3[2] = new VSPurchl(itemComCode[2], productCode[2], itemDescription[2], itemQuantity[2], 
				      itemUom[2], unitCost[2], vatTaxAmt[2], vatTaxRate[2], discountAmt[2]);
		
		/****************************** Request ***************************************/
		
		VSPurchal data = new VSPurchal(order_id,txn_number,data2,data3);
		
		L23HttpsPostRequest request=new L23HttpsPostRequest(host, store_id, api_token, data);
				
		/****************************** Response *************************************/
		
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
		Console.WriteLine("e.StackTrace:"+e.StackTrace+",e.Message:"+e.Message);
	   }
		
	}
   }
}
